// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
namespace SimPe.Actions.Default
{
	/// <summary>
	/// Summary description for CreateAction.
	/// </summary>
	public class CreateAction : AbstractActionDefault
	{
		public CreateAction()
		{
		}

		#region IToolAction Member

		public override bool ChangeEnabledStateEventHandler(
			object sender,
			Events.ResourceEventArgs es
		)
		{
			return es.LoadedPackage != null && es.LoadedPackage.Loaded;
		}

		public override void ExecuteEventHandler(
			object sender,
			Events.ResourceEventArgs e
		)
		{
			if (!ChangeEnabledStateEventHandler(null, e))
			{
				return;
			}

			e.LoadedPackage.Package.Add(
				e.LoadedPackage.Package.NewDescriptor(
					0xffffffff,
					0,
					Data.MetaData.LOCAL_GROUP,
					0
				),
				true
			);
		}

		#endregion

		#region IToolPlugin Member

		public override string ToString()
		{
			return "Create Resource";
		}

		#endregion

		#region IToolExt Member
		public override System.Drawing.Image Icon => GetIcon.actionCreate;
		#endregion
	}
}
