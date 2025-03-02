// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using SimPe.Interfaces;
using SimPe.Interfaces.Plugin;

namespace SimPe.PackedFiles.Wrapper.Factory
{
	/// <summary>
	/// The Wrapper Factory for Default Wrappers that ship with SimPe
	/// </summary>
	public class DefaultWrapperFactory : AbstractWrapperFactory
	{
		#region AbstractWrapperFactory Member
		public override IWrapper[] KnownWrappers
		{
			get
			{
				if (Helper.NoPlugins)
				{
					return new IWrapper[0];
				}
				// if (Helper.StartedGui == Executable.Classic)
				// {
				// 	IWrapper[] wrappers =
				// 	{
				// 		new Picture(),
				// 		new Xml(),
				// 		new Fami(
				// 			LinkedProvider.SimNameProvider
				// 		),
				// 		new SRel(),
				// 		new Cpf(),
				// 		new FamilyTies(
				// 			LinkedProvider.SimNameProvider
				// 		),
				// 		new Nref(),
				// 		new Objd(
				// 			LinkedProvider.OpcodeProvider
				// 		),
				// 		new Plugin.Glob(),
				// 		new ObjLua(),
				// 		new CompressedFileList(),
				// 		new Str(),
				// 	};
				// 	return wrappers;
				// }
				// else
				{
					IWrapper[] wrappers =
					{

					};
					return wrappers;
				}
			}
		}

		#endregion
	}
}
