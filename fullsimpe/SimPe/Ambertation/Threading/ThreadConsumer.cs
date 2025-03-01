// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Threading;

using SimPe;

namespace Ambertation.Threading
{
	internal class OldThreadBuffer
	{
		// Anzahl der Elemente
		internal static bool finished_create;
		internal static bool finished_consume;

		// Thread - Lock - Variablen
		private static object buffer_free = "";
		private static object buffer_not_empty = "";
		private static object consuming = "";

		// Buffer - Variables
		private const int N = 50; // maximum Number of Elements in the Buffer
		private static int counter = 0; // Number of Elements in the Buffer
		internal static object[] buffer = new object[N]; // Buffer

		// Synchronisierte create - Methode
		public static void Produce(object o)
		{
			lock (buffer_not_empty)
			{
				if (counter == N) // Is Buffer full
				{
					// wait until a slot is available
					Monitor.Wait(buffer_free);
				}

				// Add Data to the Buffer
				buffer[counter] = o;
				// -------------
				counter++;

				// Signal that we have added a Element
				Monitor.PulseAll(buffer_not_empty);
			}
		}

		internal static void Init()
		{
			finished_create = false;
			finished_consume = false;
		}

		internal static void Finish()
		{
			lock (buffer_not_empty)
			{
				finished_create = true;
				// Signal that we have added a Element
				Monitor.PulseAll(buffer_not_empty);
			}
		}

		// Synchronisierte consume - Methode
		internal static object Consume()
		{
			object o = new object();

			lock (buffer_free)
			{
				lock (consuming)
				{
					while (counter == 0) // is Buffer Empty
					{
						if (!finished_create)
						{
							// wait until an Element is added
							Monitor.Wait(buffer_not_empty);
						}
						else
						{
							finished_consume = true;
							return null;
						}
					}

					// Hole Daten ab
					o = buffer[counter - 1];
					buffer[counter - 1] = null;

					// -------------
					counter--;

					Monitor.PulseAll(consuming);
				}

				// Signal that we have removed an Element from the Buffer
				Monitor.PulseAll(buffer_free);
			}

			return o;
		}
	}

	public abstract class ProducerThread
	{
		#region ThreadBuffer
		// Anzahl der Elemente
		internal bool finished_create;
		internal bool finished_consume;
		bool canceled;

		// Thread - Lock - Variablen
		private object buffer_free = "";
		private object buffer_not_empty = "";
		private object consuming = "";

		// Buffer - Variables
		private const int N = 50; // maximum Number of Elements in the Buffer
		private int counter = 0; // Number of Elements in the Buffer
		internal object[] buffer = new object[N]; // Buffer

		// Synchronisierte create - Methode
		protected void AddToBuffer(object o)
		{
			lock (buffer_not_empty)
			{
				if (counter == N) // Is Buffer full
				{
					// wait until a slot is available
					Monitor.Wait(buffer_free);
				}

				// Add Data to the Buffer
				buffer[counter] = o;
				// -------------
				counter++;

				// Signal that we have added a Element
				Monitor.PulseAll(buffer_not_empty);
			}
		}

		internal void Init()
		{
			finished_create = false;
			finished_consume = false;
			canceled = false;

			for (int i = 0; i < buffer.Length; i++)
			{
				buffer[i] = null;
			}

			counter = 0;
		}

		internal void Finish()
		{
			lock (buffer_not_empty)
			{
				finished_create = true;
				// Signal that we have added a Element
				Monitor.PulseAll(buffer_not_empty);
			}
		}

		internal bool Canceled
		{
			get => canceled;
			set
			{
				canceled = value;

				if (value)
				{
					if (Canceling != null)
					{
						Canceling(this, new EventArgs());
					}

					// Signal that we have added a Element
					counter = 0;
					Monitor.PulseAll(buffer_not_empty);
					Monitor.PulseAll(buffer_free);
				}
			}
		}

		public void Cancel()
		{
			Canceled = true;
		}

		// Synchronisierte consume - Methode
		internal object Consume()
		{
			object o = new object();

			lock (buffer_free)
			{
				lock (consuming)
				{
					while (counter == 0) // is Buffer Empty
					{
						if (!finished_create)
						{
							// wait until an Element is added
							Monitor.Wait(buffer_not_empty);
						}
						else
						{
							finished_consume = true;
							return null;
						}

						if (Canceled)
						{
							return null;
						}
					}

					// Hole Daten ab
					o = buffer[counter - 1];
					buffer[counter - 1] = null;

					// -------------
					counter--;

					Monitor.PulseAll(consuming);
				}

				// Signal that we have removed an Element from the Buffer
				Monitor.PulseAll(buffer_free);
			}

			return o;
		}

		#endregion
		public event EventHandler Finished;
		public event EventHandler Canceling;

		/// <summary>
		/// Use this Method top Produces objects, add the Objects to the
		/// Buffer, by calling <see cref="AddToBuffer"/>
		/// </summary>
		protected abstract void Produce();

		protected virtual void OnFinish()
		{
		}

		public void start()
		{
			Init();
			Wait.SubStart();
			Produce();

			Finish();
			while (!finished_consume)
			{
				Thread.Sleep(500);
			}

			Wait.SubStop();
			OnFinish();
			if (Finished != null)
			{
				Finished(this, new EventArgs());
			}
		}
	}

	public abstract class ConsumerThread
	{
		ProducerThread pt;

		public ConsumerThread(ProducerThread producer)
		{
			pt = producer;
		}

		/// <summary>
		/// Implements the Consume Action for this Thread
		/// </summary>
		/// <param name="o">The Object that should be consumed (can never be NULL)</param>
		/// <returns>false if all active Consumers should stop Consuming</returns>
		/// <remarks>
		/// you should only return false if you know what you are
		/// doing, as this could block the Producer Thread!
		/// </remarks>
		protected abstract bool Consume(object o);

		public void start()
		{
			while (!pt.finished_consume && !pt.Canceled)
			{
				// consume Data
				object o = pt.Consume();
				if (o == null)
				{
					break;
				}

				pt.finished_consume = !Consume(o);
			}

			pt.finished_consume = true;
		}
	}
}
