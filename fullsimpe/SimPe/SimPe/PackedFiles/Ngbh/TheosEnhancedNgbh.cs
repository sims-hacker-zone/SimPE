// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.Linq;

using SimPe.Forms.MainUI;
using SimPe.Interfaces;
using SimPe.Interfaces.Plugin;
using SimPe.PackedFiles.Sdsc;
using SimPe.Plugin;

namespace SimPe.PackedFiles.Ngbh
{
	/// <summary>
	/// Extends the basic Neighborhood Plugin by some usefull Features
	/// </summary>
	public class EnhancedNgbh : ExtNgbh
	{
		public EnhancedNgbh()
			: base()
		{
			//
			// TODO: F�gen Sie hier die Konstruktorlogik hinzu
			//
		}

		/// <summary>
		/// Returns a Human Readable Description of this Wrapper
		/// </summary>
		/// <returns>Human Readable Description</returns>
		protected override IWrapperInfo CreateWrapperInfo()
		{
			return new AbstractWrapperInfo(
				"Extended Neighbourhood/Memory Wrapper",
				"Quaxi (with extensions developed by Theo)",
				"This File contains the Memories and Inventories of all Sims and Lots that Live in this Neighbourhood.",
				2,
				System.Drawing.Image.FromStream(
					GetType()
						.Assembly.GetManifestResourceStream("SimPe.img.ngbh.png")
				)
			);
		}

		class ExceptionBuilder : ApplicationException
		{
			System.Text.StringBuilder msg = new System.Text.StringBuilder();

			public override string Message => msg.ToString();

			public ExceptionBuilder()
			{
			}

			public void Append(string str)
			{
				msg.Append(str);
			}

			public void AppendFormat(string format, params object[] args)
			{
				msg.AppendFormat(format, args);
			}
		}

		class AliasList : CollectionBase
		{
			public AliasList()
			{
			}

			public int Add(IAlias alias)
			{
				return List.Add(alias);
			}

			public bool Contains(IAlias alias)
			{
				return List.Contains(alias);
			}

			public bool Contains(uint id)
			{
				return FindById(id) != null;
			}

			public IAlias FindById(uint id)
			{
				IAlias ret = null;
				int i = -1;
				while (++i < List.Count)
				{
					IAlias alias = (IAlias)List[i];
					if (alias.Id == id)
					{
						ret = alias;
						break;
					}
				}
				return ret;
			}
		}

		public void FixNeighborhoodMemories()
		{
			int deletedCount = 0;
			int fixedCount = 0;

			ExceptionBuilder trace = new ExceptionBuilder();
			trace.Append("Invalid memories found:" + Helper.lbr);

			NgbhSlots slots = GetSlots(Data.NeighborhoodSlots.Sims);

			foreach (NgbhSlot slot in slots)
			{
				// SDesc always returns null
				NgbhItems simMemories = slot.ItemsB;

				ArrayList memoryToRemove = new ArrayList();
				ArrayList memoryToFix = new ArrayList();

				NgbhItem lastSpamMemory = null;

				for (int j = 0; j < simMemories.Length; j++)
				{
					NgbhItem simMemory = simMemories[j];

					// skip tokens...
					if (simMemory.IsMemory)
					{
						// ...and the lame "Met Unknown" memories
						if (simMemory.SimInstance != 0)
						{
							// fix invalid sim instances, fixes things that aren't broken
							ushort inst =
								FileTableBase.ProviderRegistry.SimDescriptionProvider.GetInstance(
									simMemory.SimID
								);
							if (simMemory.SimInstance != inst)
							{
								simMemory.SimInstance = inst;
								memoryToFix.Add(simMemory);
							}
							/*
							if (simDesc == null) // SDesc always returns null, so this wipes every memery
							{
								memoryToRemove.Add(simMemory);
							}*/
						}

						// it could be spam...
						// collapse duplicate items
						if (simMemory.IsSpam)
						{
							if (
								lastSpamMemory != null
								&& lastSpamMemory.Guid == simMemory.Guid
								&& lastSpamMemory.SimInstance == simMemory.SimInstance
							)
							{
								memoryToRemove.Add(simMemory);
							}

							lastSpamMemory = simMemory;
						}
						else
						{
							lastSpamMemory = null;
						}
					}
				} // for simMemories

				if (memoryToRemove.Count > 0 || memoryToFix.Count > 0)
				{
					deletedCount += memoryToRemove.Count;
					fixedCount += memoryToFix.Count;

					if (FileTableBase.ProviderRegistry.SimDescriptionProvider.SimInstance[(ushort)slot.SlotID].FirstOrDefault() is SDesc simDesc) // SDesc always returns null so this won't be used as it always throwa an ERROR
					{
						trace.AppendFormat(
							"{0} {1}: {2} \r\n",
							simDesc.SimName,
							simDesc.SimFamilyName,
							memoryToRemove.Count + memoryToFix.Count
						);
					}

					foreach (NgbhItem item in memoryToFix)
					{
						trace.AppendFormat("[FIX]- {0}\r\n", item.ToString());
					}

					NgbhItem[] itemsToRemove = (NgbhItem[])
						memoryToRemove.ToArray(typeof(NgbhItem));
					foreach (NgbhItem item in itemsToRemove)
					{
						trace.AppendFormat("[DEL]- {0}\r\n", item.ToString());
					}

					trace.Append("\t\r\n\r\n");
					slot.ItemsB.Remove(itemsToRemove);
				}
			}

			if (deletedCount > 0 || fixedCount > 0)
			{
				Helper.ExceptionMessage(
					string.Format(
						"Fixed/Deleted {0} invalid memories.",
						deletedCount + fixedCount
					),
					trace
				);
			}
		}

		static bool ArrayEquals(ushort[] a, ushort[] b)
		{
			if (a.Length != b.Length)
			{
				return false;
			}

			for (int i = 0; i < a.Length; i++)
			{
				if (a[i] != b[i])
				{
					return false;
				}
			}

			return true;
		}

		public void DeleteMemoryEchoes(NgbhItems items, uint ownerID)
		{
			int deletedCount = 0;
			ExceptionBuilder trace = new ExceptionBuilder();
			trace.Append("Memories found:" + Helper.lbr);

			NgbhSlots slots = GetSlots(Data.NeighborhoodSlots.Sims);
			foreach (NgbhSlot slot in slots)
			{
				// skip my own memories?
				if (ownerID == slot.SlotID)
				{
					continue;
				}

				SDesc simDesc =
					(SDesc)FileTableBase.ProviderRegistry.SimDescriptionProvider.SimInstance[(ushort)slot.SlotID].FirstOrDefault();
				NgbhItems simMemories = slot.ItemsB;

				NgbhItems memoryToRemove =
					new NgbhItems(null);
				for (int j = 0; j < simMemories.Length; j++)
				{
					for (int i = 0; i < items.Length; i++)
					{
						NgbhItem item = items[i];
						NgbhItem simMemory = simMemories[j];

						if (
							simMemory.IsMemory
							&& item.IsMemory
							&& simMemory.Guid == item.Guid
							&& ArrayEquals(simMemory.Data, item.Data)
							&& !simMemory.Flags.IsVisible
						)
						{
							memoryToRemove.Add(simMemory); // simMemory.RemoveFromParentB();
						}
					}
				}

				if (memoryToRemove.Count > 0)
				{
					deletedCount += memoryToRemove.Count;
					trace.AppendFormat(
						"{0} {1}: {2} \r\n",
						simDesc.SimName,
						simDesc.SimFamilyName,
						memoryToRemove.Count
					);
					foreach (NgbhItem item in memoryToRemove)
					{
						trace.AppendFormat("\t- {0}\r\n", item.ToString());
					}

					trace.Append("\t\r\n\r\n");
					slot.ItemsB.Remove(memoryToRemove);
				}
			}

			if (deletedCount > 0)
			{
				Message.Show(
					string.Format(
						"Deleted {0} memories from the sim pool",
						deletedCount
					)
						+ Helper.lbr
						+ Helper.lbr
						+ trace.ToString()
				);
			}
		}
	}
}
