// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;

namespace Ambertation.XSI.Template
{
	public sealed class FileInfo : ExtendedContainer
	{
		private string projectname;

		private string username;

		private string orginator;

		private DateTime saved;

		public string ProjectName
		{
			get
			{
				return projectname;
			}
			set
			{
				projectname = value;
				if (projectname == null)
				{
					projectname = "";
				}
			}
		}

		public string UserName
		{
			get
			{
				return username;
			}
			set
			{
				username = value;
				if (username == null)
				{
					username = "";
				}
			}
		}

		public string Orginator => orginator;

		public DateTime Saved => saved;

		public FileInfo(Container parent, string args)
			: base(parent, args)
		{
			projectname = "";
			username = "";
			orginator = "";
			saved = DateTime.Now;
		}

		protected override void FinishDeSerialize()
		{
			base.FinishDeSerialize();
			projectname = Line(0).StripQuotes();
			username = Line(1).StripQuotes();
			string text = Line(2).StripQuotes();
			saved = Helpers.ToDateTime(text, saved);
			orginator = Line(3).StripQuotes();
			CustomClear();
		}

		protected override void PrepareSerialize()
		{
			base.PrepareSerialize();
			saved = DateTime.Now;
			Clear(rec: false);
			AddLiteral("\"" + projectname.Trim() + "\"");
			AddLiteral("\"" + username.Trim() + "\"");
			AddLiteral("\"" + saved.ToLongDateString() + " " + saved.ToLongTimeString() + "\"");
			AddLiteral("\" Ambertation's .NET XSI Library (" + GetType().Assembly.GetName().Version.ToString() + ")\"");
		}
	}
}
