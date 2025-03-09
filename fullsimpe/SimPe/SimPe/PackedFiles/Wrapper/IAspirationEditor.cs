// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using SimPe.PackedFiles.Sdsc;

namespace SimPe.PackedFiles.Wrapper
{
	public interface IAspirationEditor
	{
		Data.AspirationTypes[] LoadAspirations(SDesc sim);
		void StoreAspirations(Data.AspirationTypes[] asps, SDesc sim);
	}
}
