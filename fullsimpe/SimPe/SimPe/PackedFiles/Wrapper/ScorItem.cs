// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.Collections.Generic;

using SimPe.PackedFiles.Wrapper.SCOR;

namespace SimPe.PackedFiles.Wrapper
{
	/// <summary>
	/// An Item as stored in a Scor Resource
	/// </summary>
	public class ScorItem
	{
		#region GuiWrappers
		static Dictionary<string, Type> guis;
		static Dictionary<string, IScorItemToken> readers;
		static IScorItemToken deftoken;
		internal static Dictionary<string, Type> GuiElements
		{
			get
			{
				if (guis == null)
				{
					LoadGuielements();
				}

				return guis;
			}
		}

		internal static Dictionary<string, IScorItemToken> Readers
		{
			get
			{
				if (guis == null)
				{
					LoadGuielements();
				}

				return readers;
			}
		}

		internal static IScorItemToken DefaultTokenParser
		{
			get
			{
				if (guis == null)
				{
					LoadGuielements();
				}

				return deftoken;
			}
		}

		static void LoadGuielements()
		{
			guis = new Dictionary<string, Type>();
			readers = new Dictionary<string, IScorItemToken>();

			deftoken = new ScorItemTokenDefault();

			guis.Add("Learned Behaviors", typeof(ScoreItemLearnedBehaviour));
			guis.Add("Business Rewards", typeof(ScoreItemBusinessRewards));

			readers.Add("Business Rewards", new ScorItemTokenBusinessRewards());
		}

		internal void LoadGuiElement(string name)
		{
			gui = GetGuiElement(name, null);
		}

		protected AScorItem GetGuiElement(string name, byte[] data)
		{
			AScorItem ret = null;
			if (GuiElements.ContainsKey(name))
			{
				ret =
					Activator.CreateInstance(
						GuiElements[name],
						new object[] { this }
					) as AScorItem;
			}
			if (ret == null)
			{
				ret = new ScoreItemDefault(this);
			}

			if (data != null)
			{
				System.IO.BinaryReader br = new System.IO.BinaryReader(
					new System.IO.MemoryStream(data)
				);
				ret.SetData(name, br);
				br.Close();
			}

			return ret;
		}

		internal IScorItemToken GetTokenParser(string name)
		{
			return Readers.ContainsKey(name) ? Readers[name] : DefaultTokenParser;
		}
		#endregion

		AScorItem gui;
		public AScorItem Gui
		{
			get
			{
				if (gui == null)
				{
					SetGui("", new byte[0]);
				}

				return gui;
			}
		}

		public Scor Parent
		{
			get;
		}

		/// <summary>
		/// Constructor
		/// </summary>
		public ScorItem(string name, Scor parent)
			: this(parent)
		{
			SetGui(name, new byte[0]);
		}

		internal ScorItem(Scor parent)
		{
			Parent = parent;
			SetGui("", new byte[0]);
		}

		~ScorItem()
		{
			//if (gui != null) gui.Dispose();
		}

		protected void SetGui(string name, byte[] data)
		{
			//if (gui != null) gui.Dispose();
			gui = GetGuiElement(name, data);
		}

		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		internal void Unserialize(System.IO.BinaryReader reader)
		{
			string name = StreamHelper.ReadString(reader);

			IScorItemToken tp = GetTokenParser(name);

			lock (tp)
			{
				byte[] data = tp.UnserializeToken(this, reader);

				if (tp.ActivatedGUI == null)
				{
					SetGui(name, data);
				}
				else
				{
					gui = tp.ActivatedGUI;
					gui.SetData(name, null);
				}
			}
		}

		internal static byte[] UnserializeDefaultToken(System.IO.BinaryReader reader)
		{
			if (reader.BaseStream.Position > reader.BaseStream.Length - 1)
			{
				return new byte[0];
			}

			ArrayList bytes = new ArrayList();

			byte test = reader.ReadByte();
			byte last = test;
			while (last != 0x00 || test != 0x04)
			{
				bytes.Add(test);
				if (reader.BaseStream.Position > reader.BaseStream.Length - 1)
				{
					break;
				}

				last = test;
				test = reader.ReadByte();
			}

			if (reader.BaseStream.Position <= reader.BaseStream.Length - 1)
			{
				if (bytes.Count > 0)
				{
					bytes.RemoveAt(bytes.Count - 1);
				}
			}

			byte[] data = new byte[bytes.Count];
			bytes.CopyTo(data);

			return data;
		}

		/// <summary>
		/// Serializes a the Attributes stored in this Instance to the BinaryStream
		/// </summary>
		/// <param name="writer">The Stream the Data should be stored to</param>
		/// <remarks>
		/// Be sure that the Position of the stream is Proper on
		/// return (i.e. must point to the first Byte after your actual File)
		/// </remarks>
		internal void Serialize(System.IO.BinaryWriter writer, bool last)
		{
			Gui.Serialize(writer, last);
			SerializeDefaultToken(writer, last);
		}

		internal static void SerializeDefaultToken(
			System.IO.BinaryWriter writer,
			bool last
		)
		{
			if (!last)
			{
				writer.Write((ushort)0x0400);
			}
		}

		public override string ToString()
		{
			return Gui.TokenName;
		}
	}

	public class ScorItems
		: IEnumerable<ScorItem>,
			IDisposable
	{
		List<ScorItem> list;

		public ScorItems()
		{
			list = new List<ScorItem>();
		}

		public void Add(ScorItem si)
		{
			list.Add(si);
		}

		public void Remove(ScorItem si)
		{
			list.Remove(si);
		}

		public void Clear()
		{
			list.Clear();
		}

		public int Count => list.Count;

		public bool Contains(ScorItem si)
		{
			return list.Contains(si);
		}

		protected int FindIndex(string name)
		{
			for (int i = 0; i < list.Count; i++)
			{
				if (this[i].Gui.Name == name)
				{
					return i;
				}
			}

			return -1;
		}

		public ScorItem this[string name]
		{
			get => list[FindIndex(name)];
			set => list[FindIndex(name)] = value;
		}

		public ScorItem this[int index]
		{
			get => list[index];
			set => list[index] = value;
		}

		#region IEnumerable Member

		public IEnumerator GetEnumerator()
		{
			return list.GetEnumerator();
		}

		#endregion

		#region IDisposable Member

		public void Dispose()
		{
			list.Clear();
			list = null;
		}

		#endregion

		#region IEnumerable<ScorItem> Members

		IEnumerator<ScorItem> IEnumerable<ScorItem>.GetEnumerator()
		{
			return list.GetEnumerator();
		}

		internal IEnumerator<ScorItem> GetScorItemEnumerator()
		{
			return list.GetEnumerator();
		}

		#endregion
	}
}
