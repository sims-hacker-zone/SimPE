// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.ComponentModel;
using System.IO;
using Avalonia.Controls;

namespace SimPe.Common.Models.Interfaces;

public interface IWrapper : INotifyPropertyChanged, INotifyPropertyChanging
{
	public IResource Resource { get; set; }

	public static virtual IWrapper Unserialize(BinaryReader reader, Sims2.Models.Resource.Resource file)
	{
		throw new NotImplementedException();
	}

	public void Serialize(BinaryWriter writer);

	public T As<T>() where T : IWrapper
	{
		return (T)this;
	}

	public UserControl Panel { get; }

	public string FriendlyName { get; }
}
