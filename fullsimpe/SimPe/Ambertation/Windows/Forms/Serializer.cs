// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Ambertation.Windows.Forms
{
	public class Serializer
	{
		protected class Pass2Descriptor
		{
			private object o;

			private object par;

			private Pass2Control ser;

			public object Object => o;

			public Control Parent => par as Control;

			public Pass2Control Pass2 => ser;

			public Pass2Descriptor(object o, Pass2Control pass)
			{
				this.o = o;
				ser = pass;
				if (o is Control)
				{
					par = ((Control)o).Parent;
				}
				else
				{
					par = null;
				}
			}
		}

		protected class Pass2ToolStripDescriptor : Pass2Descriptor, IComparable
		{
			private Point loc;

			private int index;

			public Point Location => loc;

			public int Index => index;

			public Pass2ToolStripDescriptor(object o, Pass2Control pass, int index, Point loc)
				: base(o, pass)
			{
				this.loc = loc;
				this.index = index;
			}

			public int CompareTo(object obj)
			{
				if (obj is Pass2ToolStripDescriptor pass2ToolStripDescriptor)
				{
					if (Location.X > pass2ToolStripDescriptor.Location.X)
					{
						return 1;
					}

					if (Location.X < pass2ToolStripDescriptor.Location.X)
					{
						return -1;
					}
				}

				return 0;
			}
		}

		protected delegate void Pass2Control(Pass2Descriptor o);

		protected class SerilaizeDescriptor
		{
			private int id;

			private SerializeControl ser;

			private DeSerializeControl deser;

			public int Id => id;

			public SerializeControl Serilaizer => ser;

			public DeSerializeControl DeSerializer => deser;

			public SerilaizeDescriptor(int id, SerializeControl ser, DeSerializeControl deser)
			{
				this.id = id;
				this.ser = ser;
				this.deser = deser;
			}
		}

		protected delegate void SerializeControl(BinaryWriter writer, object o);

		protected delegate void DeSerializeControl(BinaryReader reader, object o, uint ver);

		private const uint MAGIC = 4211087879u;

		private const uint VERSION = 6u;

		private static Serializer sz;

		private List<Pass2Descriptor> pass2;

		private Dictionary<Type, SerilaizeDescriptor> map;

		private Dictionary<int, SerilaizeDescriptor> revmap;

		private Dictionary<string, Control> items;

		private Dictionary<string, ToolStripItem> buts;

		private int namect;

		private List<Pass2ToolStripDescriptor> reorderstrips;

		public static Serializer Global
		{
			get
			{
				if (sz == null)
				{
					sz = new Serializer();
				}

				return sz;
			}
		}

		private Serializer()
		{
			namect = 0;
			pass2 = new List<Pass2Descriptor>();
			items = new Dictionary<string, Control>();
			buts = new Dictionary<string, ToolStripItem>();
			map = new Dictionary<Type, SerilaizeDescriptor>();
			map[typeof(object)] = new SerilaizeDescriptor(0, SerializeGeneric, DeserializeGeneric);
			map[typeof(ToolStripItem)] = new SerilaizeDescriptor(1, SerializeToolStripItem, DeserializeToolStripItem);
			map[typeof(ToolStrip)] = new SerilaizeDescriptor(2, SerializeToolStrip, DeserializeToolStrip);
			map[typeof(DockManager)] = new SerilaizeDescriptor(3, SerializeDockManager, DeserializeDockManager);
			reorderstrips = new List<Pass2ToolStripDescriptor>();
			revmap = new Dictionary<int, SerilaizeDescriptor>();
			foreach (SerilaizeDescriptor value in map.Values)
			{
				revmap[value.Id] = value;
			}
		}

		private void RegisterControl(Control obj)
		{
			if (obj != null)
			{
				SetName(obj);
				items[obj.Name] = obj;
			}
		}

		public void Register(DockManager dm)
		{
			RegisterControl(dm);
		}

		public void Register(ToolStripContainer tsc)
		{
			RegisterControl(tsc);
			Register(tsc.LeftToolStripPanel);
			Register(tsc.TopToolStripPanel);
			Register(tsc.RightToolStripPanel);
			Register(tsc.BottomToolStripPanel);
			Register(tsc.ContextMenuStrip);
		}

		public void Register(ToolStripPanel pn)
		{
			if (pn.Name == "")
			{
				pn.Name = "myToolStripPanel_" + items.Count;
			}

			RegisterControl(pn);
			foreach (Control control in pn.Controls)
			{
				if (control is ToolStrip ts)
				{
					Register(ts);
				}
			}
		}

		public void Register(ContextMenuStrip men)
		{
			if (men == null)
			{
				return;
			}

			RegisterControl(men);
			foreach (ToolStripItem item in men.Items)
			{
				Register(item);
			}
		}

		public void Register(ToolStrip ts)
		{
			RegisterControl(ts);
			foreach (ToolStripItem item in ts.Items)
			{
				Register(item);
			}
		}

		public void Register(ToolStripItem item)
		{
			if (item != null)
			{
				SetName(item);
				buts[item.Name] = item;
			}
		}

		private void SetName(Control c)
		{
			if (c.Name == "")
			{
				c.Name = "my" + ((object)c).GetType().Name + "_" + namect;
				namect++;
			}
		}

		private void SetName(ToolStripItem c)
		{
			if (c.Name == "")
			{
				c.Name = "my" + ((object)c).GetType().Name + "_" + namect;
				namect++;
			}
		}

		public void ToFile(string flname)
		{
			BinaryWriter binaryWriter = new BinaryWriter(File.Create(flname));
			Serialize(binaryWriter);
			binaryWriter.Close();
		}

		public Stream ToStream()
		{
			MemoryStream memoryStream = new MemoryStream();
			ToStream(memoryStream);
			return memoryStream;
		}

		public void ToStream(Stream s)
		{
			BinaryWriter writer = new BinaryWriter(s);
			Serialize(writer);
			s.Flush();
		}

		private void Serialize(BinaryWriter writer)
		{
			writer.Write(4211087879u);
			writer.Write(6u);
			SerializeButtons(writer);
			SerializeControls(writer);
		}

		private void SerializeControls(BinaryWriter writer)
		{
			writer.Write(items.Count);
			foreach (Control value in items.Values)
			{
				Type key = ((object)value).GetType();
				if (!map.ContainsKey(key))
				{
					key = typeof(object);
				}

				SerilaizeDescriptor d = map[key];
				Serialize(writer, d, value.Name, value);
			}
		}

		private void SerializeButtons(BinaryWriter writer)
		{
			writer.Write(buts.Values.Count);
			foreach (ToolStripItem value in buts.Values)
			{
				SerilaizeDescriptor d = map[typeof(ToolStripItem)];
				Serialize(writer, d, value.Name, value);
			}
		}

		private void Serialize(BinaryWriter writer, SerilaizeDescriptor d, string name, object o)
		{
			if (o == null)
			{
				o = new object();
			}

			if (d == null)
			{
				d = map[typeof(object)];
			}

			writer.Write(d.Id);
			writer.Write(name);
			d.Serilaizer(writer, o);
		}

		public void FromFile(string flname)
		{
			if (File.Exists(flname))
			{
				Stream stream = File.Open(flname, FileMode.Open);
				try
				{
					FromStream(stream);
				}
				finally
				{
					stream.Close();
				}
			}
		}

		public void FromStream(Stream s)
		{
			FromStream(s, seekbeg: true);
		}

		private void ReadException(BinaryReader reader, string msg)
		{
			throw new FileLoadException(msg);
		}

		public void FromStream(Stream s, bool seekbeg)
		{
			if (seekbeg)
			{
				s.Seek(0L, SeekOrigin.Begin);
			}

			pass2.Clear();
			BinaryReader binaryReader = new BinaryReader(s);
			if (s.Length - s.Position < 8)
			{
				return;
			}

			uint num = binaryReader.ReadUInt32();
			uint num2 = binaryReader.ReadUInt32();
			if (num != 4211087879u)
			{
				ReadException(binaryReader, "Not a Layout Resource (invalid MAGIC Code)");
			}

			if (num2 > 6)
			{
				ReadException(binaryReader, "Not a Layout Resource (unknown Version)");
			}

			DeserializeButtons(binaryReader, num2);
			DeserializeControls(binaryReader, num2);
			foreach (Pass2Descriptor item in pass2)
			{
				item.Pass2(item);
			}

			RorderButtons();
		}

		private void RorderButtons()
		{
			reorderstrips.Sort();
			foreach (Pass2ToolStripDescriptor reorderstrip in reorderstrips)
			{
				ToolStrip toolStrip = reorderstrip.Object as ToolStrip;
				toolStrip.Parent = null;
			}

			foreach (Pass2ToolStripDescriptor reorderstrip2 in reorderstrips)
			{
				ToolStripPanel toolStripPanel = reorderstrip2.Parent as ToolStripPanel;
				ToolStrip toolStrip2 = reorderstrip2.Object as ToolStrip;
				if (toolStripPanel != null)
				{
					toolStrip2.Location = reorderstrip2.Location;
					toolStripPanel.Controls.Add(toolStrip2);
					toolStrip2.Location = reorderstrip2.Location;
				}
			}
		}

		private void DeserializeControls(BinaryReader reader, uint ver)
		{
			reorderstrips.Clear();
			int num = reader.ReadInt32();
			for (int i = 0; i < num; i++)
			{
				int key = reader.ReadInt32();
				string key2 = reader.ReadString();
				if (revmap.ContainsKey(key))
				{
					SerilaizeDescriptor serilaizeDescriptor = revmap[key];
					Control o = ((!items.ContainsKey(key2)) ? new Control() : items[key2]);
					serilaizeDescriptor.DeSerializer(reader, o, ver);
				}
			}
		}

		private void DeserializeButtons(BinaryReader reader, uint ver)
		{
			int num = reader.ReadInt32();
			for (int i = 0; i < num; i++)
			{
				int key = reader.ReadInt32();
				string key2 = reader.ReadString();
				if (revmap.ContainsKey(key))
				{
					SerilaizeDescriptor serilaizeDescriptor = revmap[key];
					ToolStripItem o = ((!buts.ContainsKey(key2)) ? new ToolStripButton() : buts[key2]);
					serilaizeDescriptor.DeSerializer(reader, o, ver);
				}
			}
		}

		private void SerializeGeneric(BinaryWriter writer, object o)
		{
		}

		private void DeserializeGeneric(BinaryReader reader, object o, uint ver)
		{
		}

		private void SerializeToolStripItem(BinaryWriter writer, object o)
		{
			ToolStripItem toolStripItem = o as ToolStripItem;
			writer.Write((int)toolStripItem.Overflow);
			writer.Write(toolStripItem.Visible);
			writer.Write(toolStripItem.Available);
			if (toolStripItem is ToolStripButton)
			{
				writer.Write(((ToolStripButton)toolStripItem).Checked);
			}
			else
			{
				writer.Write(value: false);
			}
		}

		private void DeserializeToolStripItem(BinaryReader reader, object o, uint ver)
		{
			ToolStripItem toolStripItem = o as ToolStripItem;
			toolStripItem.Overflow = (ToolStripItemOverflow)reader.ReadInt32();
			bool visible = reader.ReadBoolean();
			toolStripItem.Visible = visible;
			toolStripItem.Available = reader.ReadBoolean();
			if (toolStripItem is ToolStripButtonExt || toolStripItem is MenuStripButtonExt)
			{
				toolStripItem.Visible = true;
			}

			bool @checked = false;
			if (ver >= 6)
			{
				@checked = reader.ReadBoolean();
			}

			if (toolStripItem is ToolStripButton)
			{
				if (ver <= 5)
				{
					@checked = reader.ReadBoolean();
				}

				((ToolStripButton)toolStripItem).Checked = @checked;
			}
		}

		private void SerializeToolStrip(BinaryWriter writer, object o)
		{
			ToolStrip toolStrip = o as ToolStrip;
			writer.Write(toolStrip.Location.X);
			writer.Write(toolStrip.Location.Y);
			if (toolStrip.Parent != null)
			{
				writer.Write(toolStrip.Parent.Name);
				writer.Write(toolStrip.Parent.Controls.GetChildIndex(toolStrip));
			}
			else
			{
				writer.Write("");
				writer.Write(0);
			}

			writer.Write(toolStrip.Visible);
		}

		private void DeserializeToolStrip(BinaryReader reader, object o, uint ver)
		{
			ToolStrip toolStrip = o as ToolStrip;
			int x = reader.ReadInt32();
			int y = reader.ReadInt32();
			string key = reader.ReadString();
			int num = reader.ReadInt32();
			if (items.ContainsKey(key))
			{
				toolStrip.Parent = items[key];
				toolStrip.Parent.Controls.SetChildIndex(toolStrip, num);
			}

			bool visible = reader.ReadBoolean();
			if (toolStrip != null)
			{
				toolStrip.Visible = visible;
				toolStrip.Location = new Point(x, y);
			}

			pass2.Add(new Pass2ToolStripDescriptor(o, Pass2ToolStrip, num, new Point(x, y)));
		}

		private void Pass2ToolStrip(Pass2Descriptor pass)
		{
			Pass2ToolStripDescriptor pass2ToolStripDescriptor = pass as Pass2ToolStripDescriptor;
			ToolStrip toolStrip = pass2ToolStripDescriptor.Object as ToolStrip;
			if (toolStrip.Parent != null)
			{
				toolStrip.Parent.Controls.SetChildIndex(toolStrip, pass2ToolStripDescriptor.Index);
			}

			toolStrip.Location = pass2ToolStripDescriptor.Location;
			if (toolStrip.Parent is ToolStripPanel)
			{
				reorderstrips.Add(pass2ToolStripDescriptor);
			}
		}

		private void SerializeDockManager(BinaryWriter writer, object o)
		{
			DockManager dockManager = o as DockManager;
			dockManager.Serialize(writer);
		}

		private void DeserializeDockManager(BinaryReader reader, object o, uint ver)
		{
			DockManager dockManager = o as DockManager;
			dockManager.Deserialize(reader);
		}
	}
}
