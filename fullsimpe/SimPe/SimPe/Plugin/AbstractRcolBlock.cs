using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using SimPe.Interfaces.Scenegraph;

namespace SimPe.Plugin
{
	/// <summary>
	/// You need to implement is to provide a new RCOL Block
	/// </summary>
	public abstract class AbstractRcolBlock : IRcolBlock
	{
		protected SGResource sgres;

		/// <summary>
		/// Returns / Sets the cSGResource of this Block, or null if none is avilable
		/// </summary>
		[Browsable(false)]
		public SGResource NameResource
		{
			get => sgres;
			set => sgres = value;
		}

		protected uint version;

		[ReadOnly(true)]
		public uint Version
		{
			get => version;
			set => version = value;
		}

		protected Rcol parent;

		[Browsable(false)]
		public Rcol Parent
		{
			get => parent;
			set => parent = value;
		}

		public AbstractRcolBlock()
		{
			sgres = null;
			BlockID = 0;
			version = 0;
		}

		public AbstractRcolBlock(Rcol parent)
		{
			this.parent = parent;
			if (parent != null)
			{
				Register(Rcol.Tokens);
			}

			sgres = null;
			BlockID = 0;
			version = 0;
		}

		/// <summary>
		/// Data was changed
		/// </summary>
		[Browsable(false)]
		public bool Changed
		{
			get => parent.Changed;
			set
			{
				if (parent != null)
				{
					parent.Changed = value;
				}
			}
		}

		/// <summary>
		/// Refresh the Display
		/// </summary>
		public void Refresh()
		{
			//parent.CallWhenTabPageChanged = null;
			InitTabPage();
			InitResourceTabPage();
		}

		/// <summary>
		/// You can use this to setop the Controls on a TabPage before it is displayed
		/// </summary>
		protected virtual void InitTabPage()
		{
		}

		/// <summary>
		/// You can use this to setop the Controls on a ResourceTabPage before it is displayed
		/// </summary>
		protected virtual void InitResourceTabPage()
		{
		}

		/// <summary>
		/// Adds the Ressource TabPage to the Form
		/// </summary>
		/// <param name="tc">The TabControl you want to add the resourceTabPage to</param>
		/// <param name="cb">The ComboBox that selects the SubBlocks</param>
		/// <returns></returns>
		internal virtual void AddToResourceTabControl(TabControl tc, ComboBox cb)
		{
			tc.Tag = cb;

			//remove all additional Pages
			for (int i = tc.TabPages.Count - 1; i >= 0; i--)
			{
				if (tc.TabPages[i].Tag != null)
				{
					tc.TabPages.RemoveAt(i);
				}
			}

			if (ResourceTabPage != null)
			{
				ResourceTabPage.Tag = null;
				InitResourceTabPage();
				ResourceTabPage.Tag = this;
				tc.TabPages.Add(ResourceTabPage);
			}
		}

		/// <summary>
		/// Add this Class to the tabControl
		/// </summary>
		/// <param name="tc">The tabControl the Page will be added to</param>
		public void AddToTabControl(TabControl tc)
		{
			if (parent != null)
			{
				parent.ClearTabPageChanged();
			}

			if (TabPage != null)
			{
				TabPage.Tag = null;
				InitTabPage();
			}
			AddToTabControl(tc, this);
			ExtendTabControl(tc);
		}

		/// <summary>
		/// Add the TabPage (assigned to a RcolBlock) to the tabControl
		/// </summary>
		/// <param name="tc">The tabControl the Page will be added to</param>
		/// <param name="rb">The RcolBlock</param>
		public static void AddToTabControl(TabControl tc, IRcolBlock rb)
		{
			if (rb.TabPage != null)
			{
				rb.TabPage.Tag = rb;
				rb.TabPage.Text = rb.BlockName;
				tc.TabPages.Add(rb.TabPage);
			}
		}

		#region IRcolBlock Members
		/// <summary>
		/// Unserializes a BinaryStream into the Attributes of this Instance
		/// </summary>
		/// <param name="reader">The Stream that contains the FileData</param>
		public abstract void Unserialize(System.IO.BinaryReader reader);

		/// <summary>
		/// Serializes a the Attributes stored in this Instance to the BinaryStream
		/// </summary>
		/// <param name="writer">The Stream the Data should be stored to</param>
		/// <remarks>
		/// Be sure that the Position of the stream is Proper on
		/// return (i.e. must point to the first Byte after your actual File)
		/// </remarks>
		public abstract void Serialize(System.IO.BinaryWriter writer);

		/// <summary>
		/// Creates a new Instance
		/// </summary>
		public IRcolBlock Create()
		{
			return Create(GetType(), parent);
		}

		/// <summary>
		/// Creates a new Instance
		/// </summary>
		public static IRcolBlock Create(Type type, Rcol parent)
		{
			object[] args = new object[1];
			args[0] = parent;
			IRcolBlock irb = (IRcolBlock)Activator.CreateInstance(type, args);
			return irb;
		}

		/// <summary>
		/// Creates a new Instance
		/// </summary>
		public static IRcolBlock Create(Type type, Rcol parent, uint id)
		{
			IRcolBlock irb = Create(type, parent);
			irb.BlockID = id;
			return irb;
		}

		/// <summary>
		/// Creates a new Instance
		/// </summary>
		public IRcolBlock Create(uint id)
		{
			return Create(GetType(), parent, id);
		}

		/// <summary>
		/// Registers the Object in the given Hashtable
		/// </summary>
		/// <param name="listing"></param>
		/// <returns>The Name of the Class Type</returns>
		public string Register(Hashtable listing)
		{
			string name = BlockName;
			if (listing != null)
			{
				if (!listing.ContainsKey(name))
				{
					listing.Add(name, GetType());
				}
			}

			return name;
		}

		/// <summary>
		/// Returns the ID used for this Block
		/// </summary>
		[Browsable(false)]
		public uint BlockID
		{
			get; set;
		}

		protected string blockname;

		/// <summary>
		/// if not null this is the default name for the Block in the Rcol
		/// </summary>
		[Browsable(false)]
		public virtual string BlockName
		{
			get
			{
				if (blockname == null)
				{
					return "c" + GetType().Name;
				}
				else
				{
					return blockname;
				}
			}
			set => blockname = value;
		}

		/// <summary>
		/// Returns a tabPage that contains a GUI for this Element
		/// </summary>
		[Browsable(false)]
		public virtual System.Windows.Forms.TabPage TabPage => null;

		/// <summary>
		/// Returns a tabPage that will be displayed in the top TabControl on the Rcol
		/// Page if the Block is is the first one
		/// </summary>
		[Browsable(false)]
		public virtual System.Windows.Forms.TabPage ResourceTabPage => null;

		/// <summary>
		/// Adds more TabPages (which are needed to process the Class) to the Control
		/// </summary>
		/// <param name="tc">The TabControl the Pages will be added to</param>
		public virtual void ExtendTabControl(TabControl tc)
		{
		}
		#endregion

		public override string ToString()
		{
			if (sgres == null)
			{
				return BlockName;
			}
			else
			{
				return sgres.FileName + " (" + BlockName + ")";
			}
		}

		/// <summary>
		/// Returns the RCOL which lists this Resource in it's ReferencedFiles Attribute
		/// </summary>
		/// <param name="type">the Type of the ressource youar looking for</param>
		/// <returns>null or the RCOl Ressource</returns>
		public Rcol FindReferencingParent(uint type)
		{
			IScenegraphFileIndex nfi =
				FileTableBase.FileIndex.AddNewChild();
			nfi.AddIndexFromPackage(Parent.Package);
			Rcol rcol = FindReferencingParent_NoLoad(type);
			FileTableBase.FileIndex.RemoveChild(nfi);
			nfi.Clear();

			if (rcol == null && !FileTableBase.FileIndex.Loaded)
			{
				FileTableBase.FileIndex.Load();
				rcol = FindReferencingParent_NoLoad(type);
			}

			if (rcol == null)
			{
				throw new Warning(
					"No Parent was found in the Search Path!",
					"Either there is no Scenegraph Resource that is referencing the File, or the package containing that Resource is not in the FileTable (see Extra->Preferences...)"
				);
			}

			return rcol;
		}

		delegate void WaitMessasge(string message);

		/// <summary>
		/// Returns the RCOL which lists this Resource in it's ReferencedFiles Attribute
		/// </summary>
		/// <param name="type">the Type of the ressource youar looking for</param>
		/// <returns>null or the RCOl Ressource</returns>
		/// <remarks>This Version will not load the FileTable</remarks>
		public Rcol FindReferencingParent_NoLoad(uint type)
		{
			WaitMessasge wm;

			IScenegraphFileIndexItem[] items =
				FileTableBase.FileIndex.FindFile(type, true);
			try
			{
				if (Wait.Running)
				{
					wm = delegate (string message)
					{
						Wait.Message = message;
						Wait.Progress++;
					};
					Wait.SubStart(items.Length);
				}
				else
				{
					wm = delegate (string message)
					{
					};
				}

				foreach (IScenegraphFileIndexItem item in items)
				{
					wm("");
					Rcol r = new GenericRcol(null, false);

					//try to open the File in the same package, not in the FileTable Package!
					if (
						item.Package.SaveFileName.Trim().ToLower()
						== parent.Package.SaveFileName.Trim().ToLower()
					)
					{
						r.ProcessData(
							parent.Package.FindFile(item.FileDescriptor),
							parent.Package
						);
					}
					else
					{
						r.ProcessData(item);
					}

					foreach (
						Interfaces.Files.IPackedFileDescriptor pfd in r.ReferencedFiles
					)
					{
						if (
							pfd.Type == Parent.FileDescriptor.Type
							&& (
								pfd.Group == Parent.FileDescriptor.Group
								|| (
									pfd.Group == Data.MetaData.GLOBAL_GROUP
									&& Parent.FileDescriptor.Group
										== Data.MetaData.LOCAL_GROUP
								)
							)
							&& pfd.SubType == Parent.FileDescriptor.SubType
							&& pfd.Instance == Parent.FileDescriptor.Instance
						)
						{
							return r;
						}
					}
				}
			}
			finally
			{
				if (Wait.Running)
				{
					Wait.SubStop();
				}
			}

			return null;
		}

		public abstract void Dispose();
	}
}
