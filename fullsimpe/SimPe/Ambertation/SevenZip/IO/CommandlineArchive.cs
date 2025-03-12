// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Ambertation.SevenZip.Exceptions;

namespace Ambertation.SevenZip.IO
{
	public class CommandlineArchive : IDisposable
	{
		public delegate void ExtractedFileEventhandler(object sender, int number, string filename);

		private string aname;

		private StreamReader stdout;

		private StreamReader stderr;

		private StreamWriter wstdout;

		private StreamWriter wstderr;

		private string lasterr;

		private string lastout;

		private int exct;

		private static string ExeName => Path.Combine(Application.StartupPath, "7zecmd.dll");

		public string ArchiveName => aname;

		protected string ArchiveNameSave => "\"" + aname + "\"";

		public StreamReader StdOut => stdout;

		public StreamReader StdErr => stderr;

		public string LastError => lasterr;

		public string LastOutput => lastout;

		public string[] SupportedForUnpack => new string[9] { ".7z", ".rar", ".zip", ".bz2", ".gz", ".tar", ".arj", ".lzh", ".z" };

		public string[] SupportedForPack => new string[5] { ".7z", ".zip", ".bz2", ".gz", ".tar" };

		public event EventHandler ProcessUpdate;

		public event ExtractedFileEventhandler ExtractedFile;

		private static void LoadExternData()
		{
			string[] manifestResourceNames = typeof(CommandlineArchive).Assembly.GetManifestResourceNames();
			string[] array = manifestResourceNames;
			foreach (string text in array)
			{
				string text2 = "";
				if (!text.EndsWith(".dll"))
				{
					continue;
				}

				Stream manifestResourceStream = typeof(CommandlineArchive).Assembly.GetManifestResourceStream(text);
				if (manifestResourceStream == null)
				{
					continue;
				}

				BinaryReader binaryReader = new BinaryReader(manifestResourceStream);
				if (text.StartsWith("Ambertation.SevenZip.Formats."))
				{
					text2 = text.Replace("Ambertation.SevenZip.Formats.", "");
					text2 = Path.Combine(Path.Combine(Application.StartupPath, "Formats"), text2);
				}
				else if (text.StartsWith("Ambertation.SevenZip.Codecs."))
				{
					text2 = text.Replace("Ambertation.SevenZip.Codecs.", "");
					text2 = Path.Combine(Path.Combine(Application.StartupPath, "Codecs"), text2);
				}
				else
				{
					text2 = text.Replace("Ambertation.SevenZip.", "");
					text2 = Path.Combine(Application.StartupPath, text2);
				}

				if (File.Exists(text2))
				{
					continue;
				}

				string directoryName = Path.GetDirectoryName(text2);
				if (!Directory.Exists(directoryName))
				{
					Directory.CreateDirectory(directoryName);
				}

				Console.WriteLine(text + " -> " + text2);
				try
				{
					BinaryWriter binaryWriter = new BinaryWriter(File.Create(text2));
					try
					{
						while (binaryReader.BaseStream.Position < binaryReader.BaseStream.Length)
						{
							binaryWriter.Write(binaryReader.ReadByte());
						}
					}
					finally
					{
						binaryWriter.Close();
					}
				}
				finally
				{
					binaryReader.Close();
				}
			}
		}

		public CommandlineArchive(string aname)
		{
			this.aname = aname;
			try
			{
				LoadExternData();
			}
			catch (Exception value)
			{
				Console.WriteLine(value);
			}

			stdout = new StreamReader(new MemoryStream());
			stderr = new StreamReader(new MemoryStream());
			wstdout = new StreamWriter(stdout.BaseStream);
			wstderr = new StreamWriter(stderr.BaseStream);
			lasterr = "";
			lastout = "";
		}

		protected void DoExtractedFile(string name)
		{
			if (this.ExtractedFile != null)
			{
				this.ExtractedFile(this, exct, name);
			}

			exct++;
		}

		protected void DoProcessUpdate(Process process)
		{
			string text = process.StandardOutput.ReadToEnd();
			long position = stdout.BaseStream.Position;
			wstdout.Write(text);
			wstdout.Flush();
			stdout.BaseStream.Seek(position, SeekOrigin.Begin);
			lastout += text;
			string text2 = process.StandardError.ReadToEnd();
			position = stderr.BaseStream.Position;
			wstderr.Write(text2);
			wstderr.Flush();
			stderr.BaseStream.Seek(position, SeekOrigin.Begin);
			lasterr += text2;
			string[] array = text.Split('\r');
			string[] array2 = array;
			foreach (string text3 in array2)
			{
				string text4 = text3.Trim();
				if (text4.StartsWith("Extracting"))
				{
					string name = text4.Substring(10).Trim();
					DoExtractedFile(name);
				}
			}

			if (this.ProcessUpdate != null)
			{
				this.ProcessUpdate(this, new EventArgs());
			}
		}

		protected virtual string BuildBaseArguments()
		{
			return "-y";
		}

		protected void Run(string commandline)
		{
			Run(commandline, "");
		}

		protected void Run(string commandline, string workdir)
		{
			Run(commandline, workdir, nobasearg: false);
		}

		protected void Run(string commandline, string workdir, bool nobasearg)
		{
			stderr.BaseStream.SetLength(0L);
			stdout.BaseStream.SetLength(0L);
			lastout = "";
			lasterr = "";
			Process process = new Process();
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.RedirectStandardError = true;
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.FileName = ExeName;
			if (nobasearg)
			{
				process.StartInfo.Arguments = commandline;
			}
			else
			{
				process.StartInfo.Arguments = BuildBaseArguments() + " " + commandline;
			}

			process.StartInfo.WorkingDirectory = workdir;
			process.StartInfo.EnvironmentVariables["PATH"] = Application.StartupPath;
			Console.WriteLine(process.StartInfo.FileName + " " + process.StartInfo.Arguments);
			process.Start();
			while (!process.HasExited)
			{
				process.WaitForExit(1000);
				DoProcessUpdate(process);
			}

			DoProcessUpdate(process);
		}

		protected string GetErrorMessage()
		{
			if (lasterr.Trim() != "")
			{
				return lasterr.Trim();
			}

			int num = lastout.IndexOf("Error:");
			if (num >= 0)
			{
				return lastout.Substring(num + 6).Trim();
			}

			num = lastout.IndexOf("WARNINGS for files:");
			if (num >= 0)
			{
				return lastout.Substring(num + 19).Trim();
			}

			return "";
		}

		protected void ThrowError()
		{
			string errorMessage = GetErrorMessage();
			if (errorMessage == "")
			{
				return;
			}

			if (errorMessage == "cannot find archive")
			{
				throw new ArchiveNotFound(aname);
			}

			throw new SevenZipException(errorMessage);
		}

		public void Help()
		{
			Run("", "", nobasearg: true);
		}

		public ArchiveFile[] ListContent()
		{
			Run("l " + ArchiveNameSave);
			ThrowError();
			string[] array = lastout.Trim().Split('\r');
			string[] array2 = new string[6];
			ArrayList arrayList = new ArrayList();
			for (int i = 6; i < array.Length - 2; i++)
			{
				string text = array[i];
				array2[0] = text.Substring(0, 11).Trim();
				array2[1] = text.Substring(11, 9).Trim();
				array2[2] = text.Substring(20, 6).Trim();
				array2[3] = text.Substring(26, 13).Trim();
				array2[4] = text.Substring(39, 13).Trim();
				array2[5] = text.Substring(53).Trim();
				ArchiveFile value = new ArchiveFile(array2);
				Console.WriteLine(value);
				arrayList.Add(value);
			}

			ArchiveFile[] array3 = new ArchiveFile[arrayList.Count];
			arrayList.CopyTo(array3);
			return array3;
		}

		public void AddFiles(string[] files)
		{
			AddFiles("", files);
		}

		public void AddFiles(string basedir, string[] files)
		{
			if (files.Length == 0)
			{
				return;
			}

			string text = "";
			foreach (string text2 in files)
			{
				string path = Path.Combine(basedir, text2);
				if (!File.Exists(path))
				{
					throw new FileNotFound(path);
				}

				text = text + "\"" + text2 + "\" ";
			}

			Run("a " + ArchiveNameSave + " " + text, basedir);
			ThrowError();
		}

		public int Extract(string destfolder)
		{
			return Extract(destfolder, flat: false);
		}

		public int Extract(string destfolder, ArchiveFile[] files)
		{
			return Extract(destfolder, files, flat: false);
		}

		public int Extract(string destfolder, bool flat)
		{
			return Extract(destfolder, null, flat);
		}

		public int Extract(string destfolder, ArchiveFile[] files, bool flat)
		{
			string text = "x ";
			if (flat)
			{
				text = "e ";
			}

			text = text + "-o\"" + destfolder + "\" ";
			text = text + ArchiveNameSave + " ";
			if (files != null)
			{
				foreach (ArchiveFile archiveFile in files)
				{
					text = text + "\"" + archiveFile.Name + "\" ";
				}
			}

			exct = 0;
			Run(text);
			ThrowError();
			return exct;
		}

		public void Dispose()
		{
			if (stdout != null)
			{
				stdout.Close();
			}

			stdout = null;
			if (stderr != null)
			{
				stderr.Close();
			}

			stderr = null;
		}
	}
}
