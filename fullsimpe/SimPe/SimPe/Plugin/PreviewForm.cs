// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Windows.Forms;

using SimPe.PackedFiles.Cpf;
using SimPe.PackedFiles.Mmat;

namespace SimPe.Plugin
{
	/// <summary>
	/// Summary description for PreviewForm.
	/// </summary>
	public class PreviewForm : Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		Ambertation.Graphics.DirectXPanel dx = null;

		public PreviewForm()
		{
			//
			// Required designer variable.
			//
			InitializeComponent();

			dx.Settings.AddAxis = false;
			dx.LoadSettings(Helper.SimPeViewportFile);
			dx.ResetDevice += new EventHandler(dx_ResetDevice);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				components?.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources =
				new System.Resources.ResourceManager(typeof(PreviewForm));
			dx = new Ambertation.Graphics.DirectXPanel();
			SuspendLayout();
			//
			// dx
			//
			dx.BackColor = System.Drawing.Color.FromArgb(
				128,
				128,
				255
			);
			dx.Dock = DockStyle.Fill;
			dx.Effect = null;
			dx.Location = new System.Drawing.Point(0, 0);
			dx.Name = "dx";
			dx.Size = new System.Drawing.Size(494, 476);
			dx.TabIndex = 0;
			dx.WorldMatrix =
				(Microsoft.DirectX.Matrix)resources.GetObject("dx.WorldMatrix")
			;
			//
			// PreviewForm
			//
			AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			BackColor = System.Drawing.Color.FromArgb(
				128,
				128,
				255
			);
			ClientSize = new System.Drawing.Size(494, 476);
			Controls.Add(dx);
			Font = new System.Drawing.Font("Tahoma", 8.25F);
			FormBorderStyle = FormBorderStyle.FixedToolWindow;
			Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "PreviewForm";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Recolour Preview";
			ResumeLayout(false);
		}
		#endregion

		static void Exception()
		{
			throw new Warning(
				"This Item can't be previewed!",
				"SimPe was unable to build the Scenegraph."
			);
		}

		public static Ambertation.Scenes.Scene BuildScene(
			MmatWrapper mmat,
			Interfaces.Files.IPackageFile package
		)
		{
			Ambertation.Scenes.Scene scn = BuildScene(out Interfaces.Scenegraph.IScenegraphFileIndex fii, mmat, package);
			fii.Clear();
			return scn;
		}

		public static Ambertation.Scenes.Scene BuildScene(
			out Interfaces.Scenegraph.IScenegraphFileIndex fii,
			MmatWrapper mmat,
			Interfaces.Files.IPackageFile package
		)
		{
			Ambertation.Scenes.Scene scn = BuildScene(out fii, mmat, package, out Interfaces.Files.IPackageFile npkg);

			if (npkg != null)
			{
				npkg.Close();
				if (npkg is Packages.GeneratableFile)
				{
					((Packages.GeneratableFile)npkg).Dispose();
				}
			}
			npkg = null;

			return scn;
		}

		public static Ambertation.Scenes.Scene BuildScene(
			Interfaces.Scenegraph.IScenegraphFileIndex fii,
			MmatWrapper mmat,
			Interfaces.Files.IPackageFile package
		)
		{
			Ambertation.Scenes.Scene scn = BuildScene(fii, mmat, package, out Interfaces.Files.IPackageFile npkg);

			if (npkg != null)
			{
				npkg.Close();
				if (npkg is Packages.GeneratableFile)
				{
					((Packages.GeneratableFile)npkg).Dispose();
				}
			}
			npkg = null;

			return scn;
		}

		public static Ambertation.Scenes.Scene BuildScene(
			out Interfaces.Scenegraph.IScenegraphFileIndex fii,
			MmatWrapper mmat,
			Interfaces.Files.IPackageFile package,
			out Interfaces.Files.IPackageFile npkg
		)
		{
			npkg = null;
			Wait.Start();
			fii = FileTableBase.FileIndex.AddNewChild();
			try
			{
				return BuildScene(fii, mmat, package, out npkg);
			}
			catch (System.IO.FileNotFoundException)
			{
				Wait.Stop();
				MessageBox.Show(
					"The Microsoft Managed DirectX Extensions were not found on your System. Without them, the Preview is not available.\n\nYou can install them manually, by extracting the content of the DirectX\\ManagedDX.CAB on your Sims 2 Installation CD #1. If you double click on the extracted msi File, all needed Files will be installed.",
					"Warning",
					MessageBoxButtons.OK
				);
				return null;
			}
			finally
			{
				FileTableBase.FileIndex.RemoveChild(fii);
				Wait.Stop();
			}
		}

		public static Ambertation.Scenes.Scene BuildScene(
			Interfaces.Scenegraph.IScenegraphFileIndex fii,
			MmatWrapper mmat,
			Interfaces.Files.IPackageFile package,
			out Interfaces.Files.IPackageFile npkg
		)
		{
			npkg = null;
			try
			{
				FileTableBase.FileIndex.Load();
				if (System.IO.File.Exists(package.SaveFileName))
				{
					fii.AddIndexFromFolder(
						System.IO.Path.GetDirectoryName(package.SaveFileName)
					);
				}

				npkg = Tool.Dockable.ObjectWorkshopHelper.CreatCloneByCres(
					mmat.ModelName
				);
				try
				{
					foreach (
						Interfaces.Files.IPackedFileDescriptor pfd in package.Index
					)
					{
						Interfaces.Files.IPackedFileDescriptor npfd = pfd.Clone();
						npfd.UserData = package.Read(pfd).UncompressedData;
						if (pfd == mmat.FileDescriptor)
						{
							mmat.ProcessData(npfd, npkg);
						}

						npkg.Add(npfd, true);
					}

					fii.AddIndexFromPackage(npkg, true);
					//fii.WriteContentToConsole();

					return RenderScene(mmat);
				}
				finally { }
			}
			catch (System.IO.FileNotFoundException)
			{
				Wait.Stop();
				MessageBox.Show(
					"The Microsoft Managed DirectX Extensions were not found on your System. Without them, the Preview is not available.\n\nYou can install them manually, by extracting the content of the DirectX\\ManagedDX.CAB on your Sims 2 Installation CD #1. If you double click on the extracted msi File, all needed Files will be installed.",
					"Warning",
					MessageBoxButtons.OK
				);
				return null;
			}
		}

		public static Ambertation.Scenes.Scene RenderScene(MmatWrapper mmat)
		{
			try
			{
				try
				{
					GenericRcol rcol = mmat.GMDC;
					if (rcol != null)
					{
						GeometryDataContainerExt gmdcext = new GeometryDataContainerExt(
							rcol.Blocks[0] as GeometryDataContainer
						);
						gmdcext.UserTxmtMap[mmat.SubsetName] = mmat.TXMT;
						gmdcext.UserTxtrMap[mmat.SubsetName] = mmat.TXTR;
						Ambertation.Scenes.Scene scene = gmdcext.GetScene(
							new Gmdc.ElementOrder(
								Gmdc.ElementSorting.Preview
							)
						);

						return scene;
					}
					else
					{
						Exception();
					}
				}
				finally { }
			}
			catch (System.IO.FileNotFoundException)
			{
				Wait.Stop();
				MessageBox.Show(
					"The Microsoft Managed DirectX Extensions were not found on your System. Without them, the Preview is not available.\n\nYou can install them manually, by extracting the content of the DirectX\\ManagedDX.CAB on your Sims 2 Installation CD #1. If you double click on the extracted msi File, all needed Files will be installed.",
					"Warning",
					MessageBoxButtons.OK
				);
				return null;
			}
			return null;
		}

		Ambertation.Scenes.Scene scene;

		//static Ambertation.Panel3D p3d;
		public static void Execute(
			Cpf cmmat,
			Interfaces.Files.IPackageFile package
		)
		{
			if (!(cmmat is MmatWrapper))
			{
				return;
			}

			MmatWrapper mmat = cmmat as MmatWrapper;

			try
			{
				PreviewForm f = new PreviewForm();
				f.scene = BuildScene(out Interfaces.Scenegraph.IScenegraphFileIndex fii, mmat, package);
				fii.Clear();
				if (f.scene == null)
				{
					return;
				}

				f.dx.Reset();
				f.dx.ResetDefaultViewport();
				f.ShowDialog();
				f.dx.Meshes.Clear(true);
			}
			catch (System.IO.FileNotFoundException)
			{
				Wait.Stop();
				MessageBox.Show(
					"The Microsoft Managed DirectX Extensions were not found on your System. Without them, the Preview is not available.\n\nYou can install them manually, by extracting the content of the DirectX\\ManagedDX.CAB on your Sims 2 Installation CD #1. If you double click on the extracted msi File, all needed Files will be installed.",
					"Warning",
					MessageBoxButtons.OK
				);
				return;
			}
			catch (Exception ex)
			{
				Wait.Stop();
				Helper.ExceptionMessage(ex);
			}
			finally { }
		}

		private void dx_ResetDevice(object sender, EventArgs e)
		{
			dx.Meshes.Clear();
			dx.AddScene(scene);
		}
	}
}
