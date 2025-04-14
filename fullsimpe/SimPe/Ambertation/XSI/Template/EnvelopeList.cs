// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections;

namespace Ambertation.XSI.Template
{
	public sealed class EnvelopeList : ExtendedContainer
	{
		public EnvelopeList(Container parent, string args)
			: base(parent, args)
		{
		}

		protected override void CustomClear()
		{
		}

		protected override void FinishDeSerialize()
		{
			base.FinishDeSerialize();
			CustomClear();
		}

		protected override void PrepareSerialize()
		{
			base.PrepareSerialize();
			TemplateCollection templateCollection = new TemplateCollection(this);
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					ITemplate pd = (ITemplate)enumerator.Current;
					templateCollection.Add(pd);
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}

			Clear(rec: false);
			AddLiteral(templateCollection.Count);
			foreach (ITemplate item in templateCollection)
			{
				Add(item);
			}
		}
	}
}
