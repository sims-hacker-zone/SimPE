// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;
using System.Linq;

using SimPe.Data;
using SimPe.Interfaces;
using SimPe.Interfaces.Files;
using SimPe.Interfaces.Plugin;
using SimPe.PackedFiles.Picture;

namespace SimPe.Providers
{
	/// <summary>
	/// Provides an Alias Matching a SimID with it's Name
	/// </summary>
	public class Opcodes : SimCommonPackage, Interfaces.Providers.IOpcodeProvider
	{
		/// <summary>
		/// List of known Opcode Names
		/// </summary>
		private ArrayList names;

		/// <summary>
		/// List of known Operands for Expressions
		/// </summary>
		private ArrayList operands;

		/// <summary>
		/// List of known Data Owners
		/// </summary>
		private ArrayList dataowners;

		/// <summary>
		/// List aof all Fields contained in an ObjD File
		/// </summary>
		private ArrayList objddesc;

		/// <summary>
		/// List of all Motives
		/// </summary>
		private ArrayList motives;

		/// <summary>
		/// List of Objf Lines
		/// </summary>
		private ArrayList objf;

		/// <summary>
		/// List of all Available Memories
		/// </summary>
		private Hashtable memories;

		/// <summary>
		/// Creates the List for the specific Folder
		/// </summary>
		public Opcodes()
			: base(null) { }

		/// <summary>
		/// Creates an Alias out of a Memory File
		/// </summary>
		/// <returns>the IAlias Object</returns>
		protected static void ProcessMemoryFile(
			IPackedFileDescriptor pfd,
			PackedFiles.Wrapper.ExtObjd objd,
			PackedFiles.Wrapper.ExtObjd objd_pr,
			PackedFiles.Wrapper.Str str,
			ArrayList list,
			ref Hashtable memories,
			IPackageFile BasePackage
		)
		{
		}

		/// <summary>
		/// Loads Memory Files form the Object Package
		/// </summary>
		public void LoadMemories()
		{
			memories = new Hashtable();
			//if (BasePackage==null) return;

			Registry reg = Helper.WindowsRegistry;
			ArrayList list = new ArrayList();
			IPackedFileDescriptor pfd;

			PackedFiles.Wrapper.ExtObjd objd =
				new PackedFiles.Wrapper.ExtObjd();
			PackedFiles.Wrapper.Str str = new PackedFiles.Wrapper.Str();

			FileTableBase.FileIndex.Load();
			var items =
				FileTableBase.FileIndex.FindFileDiscardingGroup(
					FileTypes.OBJD,
					0x00000000000041A7
				);

			string max = " / " + items.Count().ToString();
			int ct = 0;
			if (items.Any()) //found anything?
			{
				bool wasrunning = WaitingScreen.Running;
				WaitingScreen.Wait();
				try
				{
					foreach (
						Interfaces.Scenegraph.IScenegraphFileIndexItem item in items
					)
					{
						ct++;
						if (ct % 137 == 1)
						{
							WaitingScreen.UpdateMessage(ct.ToString() + max);
						}

						pfd = item.FileDescriptor;

						string name = "";
						objd.ProcessData(item);

						if (memories.Contains(objd.Guid))
						{
							continue;
						}

						try
						{
							var sitem =
								FileTableBase.FileIndex.FindFile(
									FileTypes.CTSS,
									pfd.Group,
									objd.CTSSInstance,
									null
								).FirstOrDefault();
							if (sitem != null)
							{
								str.ProcessData(sitem);
								PackedFiles.Wrapper.StrItemList strs =
									str.LanguageItems(
										Helper.WindowsRegistry.Config.LanguageCode
									);
								if (strs.Length > 0)
								{
									name = strs[0].Title;
								}

								//not found?
								if (name == "")
								{
									strs = str.LanguageItems(1);
									if (strs.Length > 0)
									{
										name = strs[0].Title;
									}
								}
							}
						}
						catch (Exception) { }
						//still no name?
						if (name == "")
						{
							name = objd.FileName;
						}

#if DEBUG
						IAlias a = new Alias(objd.Guid, name, "{1}: {name} (0x{id})");
#else
						IAlias a = new Alias(objd.Guid, name, "{1}: {name}");
#endif

						object[] o = new object[3];

						o[0] = pfd;
						o[1] = objd.Type;
						o[2] = null;
						Picture pic = new Picture();
						var iitem =
							FileTableBase.FileIndex.FindFile(
								FileTypes.IMG,
								pfd.Group,
								1,
								null
							).FirstOrDefault();
						if (iitem != null)
						{
							pic.ProcessData(iitem);
							System.Drawing.Image img = pic.Image;
							o[2] = img;

							WaitingScreen.Update(img, ct.ToString() + max);
						}
						a.Tag = o;
						if (!memories.Contains(objd.Guid))
						{
							memories.Add(objd.Guid, a);
						}
					} //foreach item
				}
				finally
				{
					if (!wasrunning)
					{
						WaitingScreen.Stop();
					}
				}
			} // if items>0
			  //System.Threading.Thread.CurrentThread.Priority = System.Threading.ThreadPriority.Normal;
		}

		/// <summary>
		/// Loads String Resource from the Package
		/// </summary>
		/// <param name="list">The List where you want to store the Resource</param>
		/// <param name="instance">The Instance of the TextFile</param>
		/// <param name="lang">The Language Number</param>
		public void LoadData(ref ArrayList list, ushort instance, ushort lang)
		{
			list = new ArrayList();
			if (BasePackage == null)
			{
				return;
			}

			IPackedFileDescriptor pfd = BasePackage.FindFile(
				FileTypes.STR,
				0x00000000,
				0x7FE59FD0,
				instance
			);
			PackedFiles.Wrapper.StrItemList sis = new PackedFiles.Wrapper.Str().ProcessFile(pfd, BasePackage).FallbackedLanguageItems(
				(Languages)lang
			);
			for (ushort i = 0; i < sis.Length; i++)
			{
				list.Add(sis[i].Title);
			} //for
		}

		/// <summary>
		/// Loads the name of all Fields stored in Objd Files
		/// </summary>
		/// <param name="type">The Type of the Object = Language Code</param>
		public void LoadObjdDescription(ushort type)
		{
			LoadData(ref objddesc, 0xCC, type);
		}

		/// <summary>
		/// Loads all package Files in the directory and scans them for Name Informations
		/// </summary>
		public void LoadDataOwners()
		{
			LoadData(ref dataowners, 0x84, 1);
		}

		/// <summary>
		/// Loads all package Files in the directory and scans them for OBJf Informations
		/// </summary>
		public void LoadObjf()
		{
			LoadData(ref objf, 0xF5, 1);
		}

		/// <summary>
		/// Loads all package Files in the directory and scans them for Name Informations
		/// </summary>
		public void LoadOperators()
		{
			LoadData(ref operands, 0x88, 1);
		}

		/// <summary>
		/// Loads the Motive File
		/// </summary>
		public void LoadMotives()
		{
			LoadData(ref motives, 0x86, 1);
		}

		/// <summary>
		/// Loads all package Files in the directory and scans them for Name Informations
		/// </summary>
		public void LoadOpcodes()
		{
			names = new ArrayList();
			if (BasePackage == null)
			{
				return;
			}

			//IPackedFileDescriptor pfd = BasePackage.FindFile(Data.FileTypes.STR, 0x00000000, 0x7FE59FD0, 0x0000008B);
			FileTableBase.FileIndex.Load();
			var items =
				FileTableBase.FileIndex.FindFile(
					FileTypes.STR,
					0x7FE59FD0,
					0x000000000000008B,
					null
				);
			PackedFiles.Wrapper.Str str = new PackedFiles.Wrapper.Str();

			foreach (Interfaces.Scenegraph.IScenegraphFileIndexItem item in items)
			{
				str.ProcessData(item.FileDescriptor, BasePackage);

				for (ushort i = 0; i < str.Items.Length; i++)
				{
					PackedFiles.Wrapper.StrToken si = str.Items[i];

					if (si.Language.Id == 1)
					{
						names.Add(si.Title);
					}
				} //for
			}
		}

		/// <summary>
		/// Loads the ObjectsPackage if not already loaded
		/// </summary>
		public void LoadPackage()
		{
			if (BasePackage == null)
			{
				Registry reg = Helper.WindowsRegistry;
				string file = System.IO.Path.Combine(

						PathProvider.Global.GetExpansion(Expansions.BaseGame)
						.InstallFolder,
					"TSData\\Res\\Objects\\objects.package"
				);
				BasePackage = System.IO.File.Exists(file) ? Packages.File.LoadFromFile(file) : (IPackageFile)null;
			}
		}

		/// <summary>
		/// Returns the the name of the function with the given Opcode
		/// </summary>
		/// <param name="opcode">The opcode of the Instruction</param>
		/// <returns>The Alias of the Sim</returns>
		public string FindName(ushort opcode)
		{
			if (opcode >= 0x2000)
			{
				return "Unknown Semi Global";
			}

			LoadPackage();

			if (opcode >= 0x0100)
			{
				if (BasePackage == null)
				{
					return "Unknown Global";
				}
				//IPackedFileDescriptor pfd = BasePackage.FindFile(Data.FileTypes.BHAV, 0x0, 0x7FD46CD0, opcode);
				FileTableBase.FileIndex.Load();

				foreach (
					Interfaces.Scenegraph.IScenegraphFileIndexItem item in FileTableBase.FileIndex.FindFile(
						FileTypes.BHAV,
						0x7FD46CD0,
						opcode,
						null
					)
				)
				{
					if (item.FileDescriptor != null)
					{
						byte[] data = new byte[0];
						IPackedFile pf = item.Package.Read(item.FileDescriptor);
						data = pf.IsCompressed ? pf.Decompress(0x40) : pf.Data;

						return Helper.ToString(data);
					}
				}

				return "Unknown Global";
			}

			if (names == null)
			{
				LoadOpcodes();
			}

			object o = null;
			if (opcode < names.Count)
			{
				o = names[opcode];
			}

			return o != null ? (string)o : Localization.Manager.GetString("unknown");
		}

		/// <summary>
		/// Returns the the name of all Fileds in an Objd File
		/// </summary>
		public ArrayList OBJDDescription(ushort type)
		{
			LoadPackage();
			if (BasePackage == null)
			{
				return new ArrayList();
			}

			LoadObjdDescription(type);
			return objddesc ?? new ArrayList();
		}

		/// <summary>
		/// Returns the the a Memory Alias
		/// </summary>
		/// <param name="guid">Guid of the Memory</param>
		/// <returns>An IAlias Object describing the Memory</returns>
		public IAlias FindMemory(uint guid)
		{
			/*LoadPackage();
			if (BasePackage==null) return new Alias(guid, Localization.Manager.GetString("unknown"));	*/


			if (memories == null)
			{
				LoadMemories();
			}

			object o = null;
			o = memories[guid];

			return o != null ? (IAlias)o : new Alias(guid, Localization.Manager.GetString("unknown"));
		}

		/// <summary>
		/// Returns a list of all known memories
		/// </summary>
		public Hashtable StoredMemories
		{
			get
			{
				//LoadPackage();
				if (memories == null)
				{
					LoadMemories();
				}

				return memories;
			}
		}

		/// <summary>
		/// Returns the List of known Primitives
		/// </summary>
		public ArrayList StoredMotives
		{
			get
			{
				LoadPackage();
				if (motives == null)
				{
					LoadMotives();
				}

				return motives;
			}
		}

		/// <summary>
		/// Returns the List of known Primitives
		/// </summary>
		public ArrayList StoredPrimitives
		{
			get
			{
				LoadPackage();
				if (names == null)
				{
					LoadOpcodes();
				}

				return names;
			}
		}

		/// <summary>
		/// Returns a list of all known Objf Lines
		/// </summary>
		public ArrayList StoredObjfLines
		{
			get
			{
				LoadPackage();
				if (objf == null)
				{
					LoadObjf();
				}

				return objf;
			}
		}

		/// <summary>
		/// Returns the the name of the Expression Operator
		/// </summary>
		/// <param name="op">Numerical Value of the Operator</param>
		/// <returns>The Name of The Operator</returns>
		public string FindExpressionOperator(byte op)
		{
			LoadPackage();
			if (BasePackage == null)
			{
				return Localization.Manager.GetString("unk");
			}

			if (operands == null)
			{
				LoadOperators();
			}

			object o = null;
			if (op < operands.Count)
			{
				o = operands[op];
			}

			return o != null ? o.ToString() : Localization.Manager.GetString("unk");
		}

		/// <summary>
		/// Returns the names Operatores in Expression Primitives
		/// </summary>
		public ArrayList StoredExpressionOperators => operands;

		/// <summary>
		/// Returns the the name of a Data Owner
		/// </summary>
		/// <param name="owner">Numerical Value of the Owner</param>
		/// <returns>The Name</returns>
		public string FindExpressionDataOwners(byte owner)
		{
			LoadPackage();
			if (BasePackage == null)
			{
				return Localization.Manager.GetString("unk");
			}

			if (dataowners == null)
			{
				LoadDataOwners();
			}

			object o = null;
			if (owner < dataowners.Count)
			{
				o = dataowners[owner];
			}

			return o != null ? o.ToString() : Localization.Manager.GetString("unk");
		}

		/// <summary>
		/// Returns the names of the Data in an Expression Primitive
		/// </summary>
		public ArrayList StoredDataNames => dataowners;

		/// <summary>
		/// Returns the the name of a Motive
		/// </summary>
		/// <param name="owner">Numerical Value</param>
		/// <returns>The Name</returns>
		public string FindMotives(ushort nr)
		{
			LoadPackage();
			if (BasePackage == null)
			{
				return Localization.Manager.GetString("unk");
			}

			if (motives == null)
			{
				LoadMotives();
			}

			object o = null;
			if (nr < motives.Count)
			{
				o = motives[nr];
			}

			return o != null ? o.ToString() : Localization.Manager.GetString("unk");
		}

		/// <summary>
		/// returns null or a Mathcing global BHAV File
		/// </summary>
		/// <param name="opcode">the Opcode of the BHAV</param>
		/// <returns>The Descriptor for the Bhav File in the BasePackage or null</returns>
		public Interfaces.Scenegraph.IScenegraphFileIndexItem LoadGlobalBHAV(
			ushort opcode
		)
		{
			return LoadSemiGlobalBHAV(opcode, 0x7FD46CD0);
		}

		/// <summary>
		/// Returns the Bhav for a Semi Global Opcode
		/// </summary>
		/// <param name="opcode">The Opcode</param>
		/// <param name="group">The group of the SemiGlobal</param>
		/// <returns>The Descriptor of the Bhaf File in the Base Packagee or null</returns>
		public Interfaces.Scenegraph.IScenegraphFileIndexItem LoadSemiGlobalBHAV(
			ushort opcode,
			uint group
		)
		{
			//LoadPackage();
			//if (BasePackage==null) return null;
			FileTableBase.FileIndex.Load();

			return FileTableBase.FileIndex.FindFile(
				FileTypes.BHAV,
				group,
				opcode,
				null
			).FirstOrDefault();
		}

		/// <summary>
		/// Called if the BaseBackae was changed
		/// </summary>
		protected override void OnChangedPackage()
		{
			names = null;
		}
	}
}
