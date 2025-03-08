// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using SimPe.Data;
using SimPe.Interfaces.Files;
using SimPe.Interfaces.Plugin;
using SimPe.Interfaces.Scenegraph;
using SimPe.PackedFiles.Cpf;

namespace SimPe.Plugin
{
	/// <summary>
	/// ZOffers some Recolor Methods for Packages
	/// </summary>
	public class ObjectRecolor
	{
		/// <summary>
		/// The Base Package
		/// </summary>
		public IPackageFile Package
		{
			get;
		}

		Packages.GeneratableFile dn_pkg;
		public IPackageFile GMNDPackage => dn_pkg;

		Packages.GeneratableFile gm_pkg;
		public IPackageFile MMATPackage => gm_pkg;

		/// <summary>
		/// Creates a new Isntance
		/// </summary>
		/// <param name="package">The Object you want to Recolor</param>
		public ObjectRecolor(IPackageFile package)
		{
			Package = package;

			if (System.IO.File.Exists(ScenegraphHelper.GMND_PACKAGE))
			{
				dn_pkg = Packages.File.LoadFromFile(
					ScenegraphHelper.GMND_PACKAGE
				);
			}
			else
			{
				dn_pkg = Packages.File.LoadFromStream(
					null
				);
				dn_pkg.FileName = ScenegraphHelper.GMND_PACKAGE;
			}

			if (System.IO.File.Exists(ScenegraphHelper.MMAT_PACKAGE))
			{
				gm_pkg = Packages.File.LoadFromFile(
					ScenegraphHelper.MMAT_PACKAGE
				);
			}
			else
			{
				gm_pkg = Packages.File.LoadFromStream(
					null
				);
				gm_pkg.FileName = ScenegraphHelper.MMAT_PACKAGE;
			}
		}

		/// <summary>
		/// Chnages materialStateFlags and objectStateIndex according to the MaTD Reference Name
		/// </summary>
		/// <param name="mmat">The MMAT File to change the values in</param>
		public static void FixMMAT(Cpf mmat)
		{
			string name = mmat.GetSaveItem("name").StringValue;
			if (name.EndsWith("_clean"))
			{
				mmat.GetSaveItem("materialStateFlags").UIntegerValue = 0;
				mmat.GetSaveItem("objectStateIndex").IntegerValue = 0;
			}
			else if (name.EndsWith("_dirty"))
			{
				mmat.GetSaveItem("materialStateFlags").UIntegerValue = 2;
				mmat.GetSaveItem("objectStateIndex").IntegerValue = 1;
			}
			else if (name.EndsWith("_lit"))
			{
				mmat.GetSaveItem("materialStateFlags").UIntegerValue = 1;
				mmat.GetSaveItem("objectStateIndex").IntegerValue = 3;
			}
			else if (name.EndsWith("_unlit"))
			{
				mmat.GetSaveItem("materialStateFlags").UIntegerValue = 0;
				mmat.GetSaveItem("objectStateIndex").IntegerValue = 4;
			}
			else if (name.EndsWith("_on"))
			{
				mmat.GetSaveItem("materialStateFlags").UIntegerValue = 2;
				mmat.GetSaveItem("objectStateIndex").IntegerValue = 6;
			}
			else if (name.EndsWith("_off"))
			{
				mmat.GetSaveItem("materialStateFlags").UIntegerValue = 0;
				mmat.GetSaveItem("objectStateIndex").IntegerValue = 5;
			}
		}

		/// <summary>
		/// Returns a list of all GMNDs that need a tsDesignMode Block
		/// </summary>
		/// <returns>List of GMNDs</returns>
		/// <remarks>Will return an empty List if the Block is found in at least one of the GMNDs</remarks>
		protected Rcol[] GetGeometryNodes()
		{
			ArrayList list = new ArrayList();
			IPackedFileDescriptor[] pfds = Package.FindFiles(
				FileTypes.GMND
			);

			foreach (IPackedFileDescriptor pfd in pfds)
			{
				Rcol gmnd = new GenericRcol(null, false).ProcessFile(pfd, Package);
				foreach (IRcolBlock rb in gmnd.Blocks)
				{
					if (rb.BlockName == "cDataListExtension")
					{
						DataListExtension dle = (DataListExtension)rb;
						//if (dle.Extension.VarName.Trim().ToLower()=="tsnoshadow") list.Add(gmnd);
						if (
							dle.Extension.VarName.Trim().ToLower()
							== "tsdesignmodeenabled"
						)
						{
							return new Rcol[0];
						}
					}
				}
				list.Add(gmnd);
			}

			Rcol[] rcols = new Rcol[list.Count];
			list.CopyTo(rcols);
			return rcols;
		}

		/// <summary>
		/// Returns a List of all objects that Refer to the passed GMND
		/// </summary>
		/// <param name="gmnd">a GMND</param>
		/// <returns>List of SHPEs</returns>
		protected IEnumerable<Rcol> GetReferringShape(Rcol gmnd)
		{
			return from pfd in Package.FindFiles(FileTypes.SHPE)
				   let shpe = new GenericRcol(null, false).ProcessFile(pfd, Package)
				   from item in ((Shape)shpe.Blocks[0]).Items
				   where item.FileName.Trim().ToLower() == gmnd.FileName.Trim().ToLower()
				   select shpe;
		}

		/// <summary>
		/// Adss a DesignMode Block and returns it
		/// </summary>
		/// <param name="gmnd"></param>
		/// <param name="dle"></param>
		protected void AddDesignModeBlock(Rcol gmnd, DataListExtension dle)
		{
			dle.Extension.VarName = "tsDesignModeEnabled";

			((GeometryNode)gmnd.Blocks[0]).ObjectGraphNode.Items.Add(new ObjectGraphNodeItem
			{
				Enabled = 0x01,
				Dependant = 0x00,
				Index = (uint)gmnd.Blocks.Count
			});
			gmnd.Blocks.Add(dle);
		}

		/// <summary>
		/// ind the ResourceNode that is referencing the passed Shape
		/// </summary>
		/// <param name="shpe"></param>
		/// <returns></returns>
		protected Rcol FindResourceNode(Rcol shpe)
		{
			return (from cpfd in Package.FindFiles(FileTypes.CRES)
					let pfd = shpe.FileDescriptor
					let cres = new GenericRcol(null, false).ProcessFile(cpfd, Package)
					from rpfd in cres.ReferencedFiles
					where (rpfd.Group == pfd.Group) && (rpfd.Instance == pfd.Instance)
								&& (rpfd.SubType == pfd.SubType) && (rpfd.Type == pfd.Type)
					select cres).FirstOrDefault() ?? new GenericRcol(null, false);
		}

		/// <summary>
		/// adds the subsets to the tsDesignMode.. Block and returns a List of all added Subsets
		/// </summary>
		/// <param name="shpes"></param>
		/// <param name="gmnd"></param>
		/// <param name="subsets"></param>
		protected void GetSubsets(
			IEnumerable<Rcol> shpes,
			Rcol gmnd,
			ArrayList subsets
		)
		{
			ArrayList list = new ArrayList();
			ArrayList localsubsets = new ArrayList();
			DataListExtension dle = new DataListExtension(gmnd);
			uint index = (uint)(gm_pkg.FindFiles(FileTypes.MMAT).Length + 1);

			foreach (Rcol shpe in shpes)
			{
				Shape sh = (Shape)shpe.Blocks[0];
				Rcol cres = FindResourceNode(shpe);

				foreach (ShapePart part in sh.Parts)
				{
					if (subsets.Contains(part.Subset))
					{
						continue;
					}

					if (localsubsets.Contains(part.Subset))
					{
						continue;
					}

					//Read the MATD
					foreach (IPackedFileDescriptor pfd in Package.FindFile(
						part.FileName + "_txmt",
						FileTypes.TXMT
					))
					{
						Rcol matd = new GenericRcol(null, false).ProcessFile(pfd, Package);
						MaterialDefinition md =
							(MaterialDefinition)matd.Blocks[0];

						//check that the Material is not transparent
						if (md.GetProperty("stdMatAlphaBlendMode").Value == "none")
						{
							//check that the Material references a texture
							if (
								Package
									.FindFile(
										md.GetProperty("stdMatBaseTextureName").Value
											+ "_txtr",
										FileTypes.TXTR
									)
									.Length > 0
							)
							{
								localsubsets.Add(part.Subset);
								list.Add(new WorkshopMMAT(part.Subset)
								{
									Tag = new object[3]
									{
										matd,
										cres.FileName,
										new ExtensionItem
										{
											Name = part.Subset,
											Typecode = ExtensionItem.ItemTypes.Array
										}
									}
								});
							}
						}
					}
				}
			}

			WorkshopMMAT[] mmats = new WorkshopMMAT[list.Count];
			list.CopyTo(mmats);

			Listing li = new Listing();
			if (mmats.Length > 0)
			{
				mmats = li.Execute(mmats);
			}

			foreach (WorkshopMMAT mmat in mmats)
			{
				subsets.Add(mmat.Subset);
				dle.Extension.Items.Add((ExtensionItem)mmat.Tag[2]);
				AddMMAT(
					(Rcol)mmat.Tag[0],
					mmat.Subset,
					(string)mmat.Tag[1],
					index++,
					false
				);
			}

			if (dle.Extension.Items.Count > 0)
			{
				AddDesignModeBlock(gmnd, dle);
				gmnd.SynchronizeUserData();
				dn_pkg.Add(gmnd.FileDescriptor);
			}
		}

		/// <summary>
		/// Add a MMAT to the package
		/// </summary>
		protected Cpf AddMMAT(
			Rcol matd,
			string subset,
			string cresname,
			uint instance,
			bool substate
		)
		{
			//now add the default MMAT
			System.IO.BinaryReader br = new System.IO.BinaryReader(
				GetType()
					.Assembly.GetManifestResourceStream("SimPe.files.mmat.simpe")
			);
			Packages.PackedFileDescriptor pfd1 =
				new Packages.PackedFileDescriptor
				{
					Group = 0xffffffff,
					SubType = 0x00000000,
					Instance = instance,
					Type = FileTypes.MMAT, //MMAT
					UserData = br.ReadBytes((int)br.BaseStream.Length)
				};

			Package.Add(pfd1);
			Cpf mmat = new Cpf().ProcessFile(pfd1, Package);

			if (!substate)
			{
				mmat.GetSaveItem("family").StringValue = System
					.Guid.NewGuid()
					.ToString();
			}

			mmat.GetSaveItem("name").StringValue = matd.FileName.Substring(
				0,
				matd.FileName.Length - 5
			);
			mmat.GetSaveItem("subsetName").StringValue = subset;
			mmat.GetSaveItem("modelName").StringValue = cresname;

			//Get the GUID
			IPackedFileDescriptor[] pfds = Package.FindFiles(
				FileTypes.OBJD
			);
			mmat.GetSaveItem("objectGUID").UIntegerValue = 0x00000000;
			foreach (IPackedFileDescriptor pfd in pfds)
			{
				mmat.GetSaveItem("objectGUID").UIntegerValue = new PackedFiles.Wrapper.Objd(null).ProcessFile(pfds[0], Package).SimId;

				if (pfd.Instance == 0x000041A7)
				{
					break;
				}
			}

			FixMMAT(mmat);
			mmat.SynchronizeUserData();

			gm_pkg.Add(mmat.FileDescriptor);

			//alternate states
			if (!substate)
			{
				string name = mmat.GetSaveItem("name").StringValue;
				pfds = ObjectCloner.FindStateMatchingMatd(name, Package);

				if (pfds != null)
				{
					if (pfds.Length > 0)
					{
						Cpf mmat2 = AddMMAT(
							new GenericRcol(null, false).ProcessFile(pfds[0], Package),
							subset,
							cresname,
							instance,
							true
						);
						mmat2.GetSaveItem("family").StringValue = mmat.GetSaveItem(
							"family"
						).StringValue;
					}
				}
			}

			return mmat;
		}

		/// <summary>
		/// Enables the Color Options for this Object
		/// </summary>
		public void EnableColorOptions()
		{
			foreach (Rcol gmnd in GetGeometryNodes())
			{
				GetSubsets(GetReferringShape(gmnd), gmnd, new ArrayList());
			}

			dn_pkg.Save();
			gm_pkg.Save();
		}

		/// <summary>
		/// Add the MATD referenced by the passed MMAT
		/// </summary>
		/// <param name="mmat">A valid MMAT file</param>
		protected void AddMATD(Cpf mmat)
		{
			Packages.File pkg = Packages.File.LoadFromFile(
				System.IO.Path.Combine(
					PathProvider.Global.GetExpansion(Expansions.BaseGame).InstallFolder,
					"TSData\\Res\\Sims3D\\Objects02.package"
				)
			);
			string flname =
				Hashes.StripHashFromName(mmat.GetSaveItem("name").StringValue)
				+ "_txmt";

			foreach (IPackedFileDescriptor pfd in pkg.FindFile(
				flname,
				FileTypes.TXMT
			))
			{
				Rcol matd = new GenericRcol(null, false).ProcessFile(pfd, pkg);

				if (matd.FileName.Trim().ToLower() == flname.Trim().ToLower())
				{
					matd.SynchronizeUserData();
					if (Package.FindFile(matd.FileDescriptor) == null)
					{
						Package.Add(matd.FileDescriptor);
					}
				}
			}

			//pkg.Reader.Close();
		}

		/// <summary>
		/// Load all MATDs referenced by the passed MMATs
		/// </summary>
		/// <param name="pfds">List of MMAT Descriptors from the current Package</param>
		protected void LoadReferencedMATDs(
			IPackedFileDescriptor[] pfds
		)
		{
			//WaitingScreen.Wait();
			if (WaitingScreen.Running)
			{
				WaitingScreen.UpdateMessage("Loading Material Overrides");
			}

			foreach (IPackedFileDescriptor pfd in pfds)
			{
				AddMATD(new Cpf().ProcessFile(pfd, Package));
			}
			//WaitingScreen.Stop();
		}

		/// <summary>
		/// Load all MATDs referenced by the MMATs in the package
		/// </summary>
		public void LoadReferencedMATDs()
		{
			LoadReferencedMATDs(Package.FindFiles(FileTypes.MMAT));
		}
	}
}
