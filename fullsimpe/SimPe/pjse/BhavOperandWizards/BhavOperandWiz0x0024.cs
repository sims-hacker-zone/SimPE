/***************************************************************************
 *   Copyright (C) 2005 by Peter L Jones                                   *
 *   pljones@users.sf.net                                                  *
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 2 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 *   This program is distributed in the hope that it will be useful,       *
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of        *
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the         *
 *   GNU General Public License for more details.                          *
 *                                                                         *
 *   You should have received a copy of the GNU General Public License     *
 *   along with this program; if not, write to the                         *
 *   Free Software Foundation, Inc.,                                       *
 *   59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.             *
 ***************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using SimPe.PackedFiles.Wrapper;

namespace pjse.BhavOperandWizards.Wiz0x0024
{
	/// <summary>
	/// Zusammenfassung f�r BhavInstruction.
	/// </summary>
	internal class UI : System.Windows.Forms.Form, iBhavOperandWizForm
	{
		#region Form variables

		internal System.Windows.Forms.Panel pnWiz0x0024;
		private System.Windows.Forms.ComboBox cbType;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lbType;
		private System.Windows.Forms.Label lbMessage;
		private System.Windows.Forms.Label lbTitle;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cbScope;
		private System.Windows.Forms.Label lbIconType;
		private System.Windows.Forms.CheckBox cbBlockBHAV;
		private System.Windows.Forms.CheckBox cbBlockSim;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.CheckBox cbUTMessage;
		private System.Windows.Forms.CheckBox cbUTButton1;
		private System.Windows.Forms.CheckBox cbUTButton2;
		private System.Windows.Forms.CheckBox cbUTButton3;
		private System.Windows.Forms.CheckBox cbUTTitle;
		private System.Windows.Forms.ComboBox cbIconType;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox tbIconID;
		private System.Windows.Forms.Button btnStrIcon;
		private System.Windows.Forms.Panel pnTNS;
		private System.Windows.Forms.TextBox tbPriority;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox tbTimeout;
		private System.Windows.Forms.Label lbTnsStyle;
		private System.Windows.Forms.ComboBox cbTnsStyle;
		private System.Windows.Forms.Panel pnTempVar;
		private System.Windows.Forms.Label lbTempVar;
		private System.Windows.Forms.Panel pnLocalVar;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ComboBox cbTempVar;
		private System.Windows.Forms.ComboBox cbTVMessage;
		private System.Windows.Forms.ComboBox cbTVButton1;
		private System.Windows.Forms.ComboBox cbTVButton2;
		private System.Windows.Forms.ComboBox cbTVButton3;
		private System.Windows.Forms.ComboBox cbTVTitle;
		private System.Windows.Forms.TextBox tbLocalVar;
		private System.Windows.Forms.TextBox tbMessage;
		private System.Windows.Forms.TextBox tbButton1;
		private System.Windows.Forms.TextBox tbButton2;
		private System.Windows.Forms.TextBox tbButton3;
		private System.Windows.Forms.TextBox tbTitle;
		private System.Windows.Forms.TextBox tbStrMessage;
		private System.Windows.Forms.TextBox tbStrButton1;
		private System.Windows.Forms.TextBox tbStrButton2;
		private System.Windows.Forms.TextBox tbStrButton3;
		private System.Windows.Forms.TextBox tbStrTitle;
		private System.Windows.Forms.Label lbButton3;
		private System.Windows.Forms.Label lbButton2;
		private System.Windows.Forms.Label lbButton1;
		private Button btnDefTitle;
		private Button btnDefButton3;
		private Button btnDefButton2;
		private Button btnDefButton1;
		private Button btnDefMessage;
		private Button btnStrTitle;
		private Button btnStrButton3;
		private Button btnStrButton2;
		private Button btnStrButton1;
		private Button btnStrMessage;

		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		public UI()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//

			cbType.Items.Clear();
			cbType.Items.AddRange(BhavWiz.readStr(GS.BhavStr.Dialog).ToArray());

			if (typeDescriptions == null)
				typeDescriptions = BhavWiz.readStr(GS.BhavStr.DialogDesc);

			cbTnsStyle.Items.Clear();
			cbTnsStyle.Items.AddRange(BhavWiz.readStr(GS.BhavStr.TnsStyle).ToArray());

			cbIconType.Items.Clear();
			cbIconType.Items.AddRange(BhavWiz.readStr(GS.BhavStr.DialogIcon).ToArray());

			Button[] b =
			{
				btnStrMessage,
				btnStrButton1,
				btnStrButton2,
				btnStrButton3,
				btnStrTitle,
				btnStrIcon,
			};
			alStrBtn = new ArrayList(b);

			Button[] bd =
			{
				btnDefMessage,
				btnDefButton1,
				btnDefButton2,
				btnDefButton3,
				btnDefTitle,
			};
			alDefBtn = new ArrayList(bd);

			TextBox[] t =
			{
				tbStrMessage,
				tbStrButton1,
				tbStrButton2,
				tbStrButton3,
				tbStrTitle,
			};
			alTextBox = new ArrayList(t);

			CheckBox[] c =
			{
				cbUTMessage,
				cbUTButton1,
				cbUTButton2,
				cbUTButton3,
				cbUTTitle,
			};
			alCBUseTemp = new ArrayList(c);

			ComboBox[] ct =
			{
				cbTVMessage,
				cbTVButton1,
				cbTVButton2,
				cbTVButton3,
				cbTVTitle,
			};
			alCBTempVar = new ArrayList(ct);

			TextBox[] tb8 = { tbPriority, tbTimeout, tbLocalVar, tbIconID };
			alHex8 = new ArrayList(tb8);

			TextBox[] tb16 = { tbMessage, tbButton1, tbButton2, tbButton3, tbTitle };
			alHex16 = new ArrayList(tb16);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);

			inst = null;
		}

		private static List<String> typeDescriptions = null;

		private Instruction inst = null;
		private ArrayList alStrBtn = null;
		private ArrayList alDefBtn = null;
		private ArrayList alTextBox = null;
		private ArrayList alCBUseTemp = null;
		private ArrayList alCBTempVar = null;
		private ArrayList alHex8 = null;
		private ArrayList alHex16 = null;

		byte dialog = 0;
		bool nowait = false;
		byte iconType = 0;
		byte iconID = 0;
		byte tempVar = 0;
		bool noblock = false;
		byte tnsStyle = 0;
		byte priority = 0;
		byte timeout = 0;
		byte localVar = 0;
		Scope scope = Scope.Private;
		ushort[] messages = { 0, 0, 0, 0, 0 }; // Message, Yes, No, Cancel, Title
		bool[] useTemp = { false, false, false, false, false }; // Message, Yes, No, Cancel, Title
		bool[] states = { false, false, false, false, false }; // message, yes, no, cancel, title

		bool internalchg = false;

		private bool hex8_IsValid(object sender)
		{
			if (alHex8.IndexOf(sender) < 0)
				throw new Exception(
					"hex8_IsValid not applicable to control " + sender.ToString()
				);
			try
			{
				Convert.ToByte(((TextBox)sender).Text, 16);
			}
			catch (Exception)
			{
				return false;
			}
			return true;
		}

		private bool hex16_IsValid(object sender)
		{
			if (alHex16.IndexOf(sender) < 0)
				throw new Exception(
					"hex16_IsValid not applicable to control " + sender.ToString()
				);
			try
			{
				Convert.ToUInt16(((TextBox)sender).Text, 16);
			}
			catch (Exception)
			{
				return false;
			}
			return true;
		}

		private void setType(int newType)
		{
			internalchg = true;

			dialog = (byte)newType;

			if (dialog != cbType.SelectedIndex)
				cbType.SelectedIndex = (cbType.Items.Count > dialog) ? dialog : -1;

			this.lbType.Text =
				typeDescriptions.Count > dialog ? typeDescriptions[dialog] : "";

			bool tvState = false;
			bool tnsState = false;
			bool lvState = false;

			states[0] = states[1] = states[2] = states[3] = states[4] = false; // forget everything...
			switch (dialog)
			{
				case 0x00:
				case 0x03:
				case 0x04:
					states[0] = states[1] = states[4] = true; // message, button 1, title
					break;
				case 0x02:
					states[0] = states[1] = states[2] = states[4] = true; // message, button 1, button 2, title
					tvState = states[3] = true; // button 3
					break;
				case 0x08:
				case 0x0a: // TNS, TNS modify
					tnsState = tvState = states[0] = true; // message
					break;
				case 0x09: // TNS stop
					tvState = true;
					break;
				case 0x0e:
					states[0] = states[1] = states[2] = states[4] = true; // message, button 1, button 2, title
					lvState = true;
					break;
				case 0x0f:
					states[1] = states[2] = true; // button 1, button 2
					states[0] = states[3] = states[4] = false; // msg, btn3, title
					break;
				case 0x13:
					states[1] = states[2] = states[4] = true; // button 1, button 2, title
					break;
				case 0x0b:
				case 0x0c:
				case 0x0d:
				case 0x10:
				case 0x11:
				case 0x12:
				case 0x14:
				case 0x15:
					break;
				case 0x16:
				case 0x19:
					states[0] = states[4] = true; // message, title
					break;
				case 0x1c: // TNS Append
					tvState = states[0] = true; // message
					break;
				default:
					states[0] = states[1] = states[2] = states[4] = true; // message, button 1, button 2, title
					break;
			}

			this.pnTempVar.Visible = tvState;
			this.pnTNS.Visible = tnsState;
			this.pnLocalVar.Visible = lvState;

			internalchg = false;

			// Make the display match the help text
			for (int i = 0; i < states.Length; i++)
				setString(i, messages[i]);
		}

		private void setTnsStyle(int newStyle)
		{
			internalchg = true;

			tnsStyle = (byte)newStyle;

			if (cbTnsStyle.Items.Count != tnsStyle)
				cbTnsStyle.SelectedIndex =
					(tnsStyle >= 0 && tnsStyle < cbTnsStyle.Items.Count)
						? tnsStyle
						: -1;

			internalchg = false;
		}

		private void setScope(int newScope)
		{
			internalchg = true;

			scope = (Scope)newScope;

			if (cbScope.SelectedIndex != newScope)
				cbScope.SelectedIndex =
					(newScope >= 0 && newScope < cbScope.Items.Count) ? newScope : -1;

			for (int i = 0; i < messages.Length; i++)
				setString(i, messages[i]);

			internalchg = false;
		}

		private void setIconType(int newType)
		{
			internalchg = true;

			iconType = (byte)newType;

			if (cbIconType.SelectedIndex != iconType)
				cbIconType.SelectedIndex =
					(iconType >= 0 && iconType < cbIconType.Items.Count)
						? iconType
						: -1;
			tbIconID.Enabled = (iconType == 3);
			btnStrIcon.Enabled = (iconType == 4);

			internalchg = false;
		}

		private void setTempVar(int newTempVar)
		{
			internalchg = true;

			tempVar = (byte)newTempVar;
			if (cbTempVar.SelectedIndex != tempVar)
				cbTempVar.SelectedIndex =
					(tempVar >= 0 && tempVar < cbTempVar.Items.Count) ? tempVar : -1;

			internalchg = false;
		}

		private void setBlockBHAV(bool newFlag)
		{
			internalchg = true;

			nowait = !newFlag;
			this.cbBlockBHAV.Checked = newFlag;

			internalchg = false;
		}

		private void setBlockSim(bool newFlag)
		{
			internalchg = true;

			noblock = !newFlag;
			this.cbBlockSim.Checked = newFlag;

			internalchg = false;
		}

		private void setIconID(int newIconID)
		{
			iconID = (byte)newIconID;

			if (internalchg)
				return;
			internalchg = true;

			this.tbIconID.Text = "0x" + SimPe.Helper.HexString((byte)newIconID);

			internalchg = false;
		}

		private void setString(int which, int strnum)
		{
			messages[which] = (ushort)strnum;

			if (!states[which])
			{
				internalchg = true;
				((ComboBox)alCBTempVar[which]).SelectedIndex = -1;
				((TextBox)alHex16[which]).Text = "";
				internalchg = false;

				((TextBox)alTextBox[which]).Text = "";

				((ComboBox)this.alCBTempVar[which]).Enabled =
					((CheckBox)this.alCBUseTemp[which]).Enabled =
					((TextBox)alHex16[which]).Enabled =
					((Button)alStrBtn[which]).Enabled =
					((Button)alDefBtn[which]).Enabled =
					((TextBox)alTextBox[which]).Enabled =
						false;

				return;
			}

			((CheckBox)this.alCBUseTemp[which]).Enabled = true;

			if (useTemp[which])
			{
				ComboBox c = (ComboBox)alCBTempVar[which];
				internalchg = true;
				c.SelectedIndex = c.Items.Count > strnum ? strnum : -1;
				((TextBox)alHex16[which]).Text = "";
				internalchg = false;

				((TextBox)alTextBox[which]).Text = "";

				((CheckBox)this.alCBUseTemp[which]).Checked = (
					(ComboBox)this.alCBTempVar[which]
				).Enabled = true;
				((TextBox)alHex16[which]).Enabled =
					((Button)alStrBtn[which]).Enabled =
					((Button)alDefBtn[which]).Enabled =
					((TextBox)alTextBox[which]).Enabled =
						false;
			}
			else
			{
				if (!internalchg)
				{
					internalchg = true;
					((ComboBox)this.alCBTempVar[which]).SelectedIndex = -1;
					((TextBox)alHex16[which]).Text =
						"0x" + SimPe.Helper.HexString((ushort)strnum);
					internalchg = false;
				}

				((TextBox)alTextBox[which]).Text =
					(strnum <= 0)
						? "[" + pjse.Localization.GetString("none") + "]"
						: ((BhavWiz)inst).readStr(
							scope,
							GS.GlobalStr.DialogString,
							(ushort)(strnum - 1),
							-1,
							pjse.Detail.ErrorNames
						);

				((CheckBox)this.alCBUseTemp[which]).Checked = (
					(ComboBox)this.alCBTempVar[which]
				).Enabled = false;
				((TextBox)alHex16[which]).Enabled =
					((Button)alStrBtn[which]).Enabled =
					((TextBox)alTextBox[which]).Enabled =
						true;
				((Button)alDefBtn[which]).Enabled = (strnum != 0);
			}
		}

		private void setUseTemp(int which, bool newFlag)
		{
			useTemp[which] = newFlag;
			setString(which, messages[which]);
		}

		private void setPriority(int newPriority)
		{
			priority = (byte)newPriority;

			if (internalchg)
				return;
			internalchg = true;

			this.tbPriority.Text = "0x" + SimPe.Helper.HexString((byte)newPriority);

			internalchg = false;
		}

		private void setTimeout(int newTimeout)
		{
			timeout = (byte)newTimeout;

			if (internalchg)
				return;
			internalchg = true;

			this.tbTimeout.Text = "0x" + SimPe.Helper.HexString((byte)newTimeout);

			internalchg = false;
		}

		private void setLocalVar(int newLocalVar)
		{
			localVar = (byte)newLocalVar;

			if (internalchg)
				return;
			internalchg = true;

			this.tbLocalVar.Text = "0x" + SimPe.Helper.HexString((byte)newLocalVar);

			internalchg = false;
		}

		private void doStrChooser(int which)
		{
			pjse.FileTable.Entry[] items = pjse.FileTable.GFT[
				(uint)SimPe.Data.MetaData.STRING_FILE,
				inst.Parent.GroupForScope(scope),
				(uint)GS.GlobalStr.DialogString
			];

			if (items == null || items.Length == 0)
			{
				MessageBox.Show(
					pjse.Localization.GetString("bow_noStrings")
						+ " ("
						+ pjse.Localization.GetString(scope.ToString())
						+ ")"
				);
				return; // eek!
			}

			SimPe.PackedFiles.Wrapper.StrWrapper str = new StrWrapper();
			str.ProcessData(items[0].PFD, items[0].Package);

			int i = (new StrChooser()).Strnum(str);
			if (i >= 0)
			{
				if (messages.Length > which)
				{
					setString(which, i + 1);
				}
				else
				{
					switch (which)
					{
						case 5:
							setIconID(i + 1);
							break;
					}
				}
			}
		}

		#region iBhavOperandWizForm
		public Panel WizPanel
		{
			get
			{
				return this.pnWiz0x0024;
			}
		}

		public void Execute(Instruction inst)
		{
			this.inst = inst;

			wrappedByteArray ops1 = inst.Operands;
			wrappedByteArray ops2 = inst.Reserved1;

			setType(ops1[5]);

			setTnsStyle(ops2[4]);

			if ((ops2[0] & 0x01) != 0)
				setScope((int)Scope.SemiGlobal);
			else if ((ops2[0] & 0x40) != 0)
				setScope((int)Scope.Global);
			else
				setScope((int)Scope.Private);

			setIconID(ops1[0x01]);

			if (inst.NodeVersion == 0)
			{
				setString(0, ops1[2]); // message
				setString(3, ops1[0]); // cancel
			}
			else
			{
				setString(0, BhavWiz.ToShort(ops2[5], ops2[6])); // message
				setString(3, BhavWiz.ToShort(ops1[0], ops1[2])); // cancel
			}
			setString(1, ops1[3]); // Yes
			setString(2, ops1[4]); // No
			setString(4, ops1[6]); // Title

			setBlockBHAV((ops1[7] & 0x01) == 0);
			setIconType((ops1[7] >> 1) & 0x07);
			setTempVar((ops1[7] >> 4) & 0x07);
			setBlockSim((ops1[7] & 0x80) == 0);

			setUseTemp(0, (ops2[0] & 0x02) != 0); // Message
			setUseTemp(1, (ops2[0] & 0x04) != 0); // Yes
			setUseTemp(2, (ops2[0] & 0x08) != 0); // No
			setUseTemp(3, (ops2[0] & 0x20) != 0); // Cancel
			setUseTemp(4, (ops2[0] & 0x10) != 0); // Title

			setPriority(ops2[1] + 1);
			setTimeout(ops2[2]);
			setLocalVar(ops2[3]);
		}

		public Instruction Write(Instruction inst)
		{
			if (inst != null)
			{
				wrappedByteArray ops1 = inst.Operands;
				wrappedByteArray ops2 = inst.Reserved1;

				ops1[0x01] = iconID;

				if (inst.NodeVersion == 0)
				{
					ops1[2] = (byte)messages[0]; // message
					ops1[0] = (byte)messages[3]; // cancel
				}
				else
				{
					BhavWiz.FromShort(ref ops2, 5, messages[0]); // message
					byte[] lohi = { 0, 0 };
					BhavWiz.FromShort(ref lohi, 0, messages[3]); // cancel
					ops1[0] = lohi[0];
					ops1[2] = lohi[1];
				}
				ops1[3] = (byte)messages[1]; // Yes
				ops1[4] = (byte)messages[2]; // No
				ops1[6] = (byte)messages[4]; // Title

				ops1[5] = dialog;

				ops1[7] &= 0xfe;
				ops1[7] |= (byte)(nowait ? 0x01 : 0);
				ops1[7] &= 0xf1;
				ops1[7] |= (byte)((iconType & 0x07) << 1);
				ops1[7] &= 0x8f;
				ops1[7] |= (byte)((tempVar & 0x07) << 4);
				ops1[7] &= 0x7f;
				ops1[7] |= (byte)(noblock ? 0x80 : 0);

				ops2[0] &= 0xfd;
				ops2[0] |= (byte)(useTemp[0] ? 0x02 : 0); // Message
				ops2[0] &= 0xfb;
				ops2[0] |= (byte)(useTemp[1] ? 0x04 : 0); // Yes
				ops2[0] &= 0xf7;
				ops2[0] |= (byte)(useTemp[2] ? 0x08 : 0); // No
				ops2[0] &= 0xdf;
				ops2[0] |= (byte)(useTemp[3] ? 0x20 : 0); // Cancel
				ops2[0] &= 0xef;
				ops2[0] |= (byte)(useTemp[4] ? 0x10 : 0); // Title

				ops2[0] &= 0xbe;
				if (scope == Scope.SemiGlobal)
					ops2[0] |= 0x01;
				else if (scope == Scope.Global)
					ops2[0] |= 0x40;

				ops2[1] = (byte)(priority - 1);
				ops2[2] = timeout;
				ops2[3] = localVar;
				ops2[4] = tnsStyle;
			}
			return inst;
		}

		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Erforderliche Methode f�r die Designerunterst�tzung.
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor ge�ndert werden.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources =
				new System.ComponentModel.ComponentResourceManager(typeof(UI));
			this.pnWiz0x0024 = new System.Windows.Forms.Panel();
			this.btnDefTitle = new System.Windows.Forms.Button();
			this.btnDefButton3 = new System.Windows.Forms.Button();
			this.btnDefButton2 = new System.Windows.Forms.Button();
			this.btnDefButton1 = new System.Windows.Forms.Button();
			this.btnDefMessage = new System.Windows.Forms.Button();
			this.btnStrTitle = new System.Windows.Forms.Button();
			this.btnStrButton3 = new System.Windows.Forms.Button();
			this.btnStrButton2 = new System.Windows.Forms.Button();
			this.btnStrButton1 = new System.Windows.Forms.Button();
			this.btnStrMessage = new System.Windows.Forms.Button();
			this.tbStrTitle = new System.Windows.Forms.TextBox();
			this.tbStrButton3 = new System.Windows.Forms.TextBox();
			this.tbStrButton2 = new System.Windows.Forms.TextBox();
			this.tbTitle = new System.Windows.Forms.TextBox();
			this.tbMessage = new System.Windows.Forms.TextBox();
			this.tbButton3 = new System.Windows.Forms.TextBox();
			this.cbTVMessage = new System.Windows.Forms.ComboBox();
			this.tbButton2 = new System.Windows.Forms.TextBox();
			this.lbMessage = new System.Windows.Forms.Label();
			this.tbButton1 = new System.Windows.Forms.TextBox();
			this.cbBlockBHAV = new System.Windows.Forms.CheckBox();
			this.cbBlockSim = new System.Windows.Forms.CheckBox();
			this.cbUTTitle = new System.Windows.Forms.CheckBox();
			this.cbUTButton3 = new System.Windows.Forms.CheckBox();
			this.lbIconType = new System.Windows.Forms.Label();
			this.cbUTButton2 = new System.Windows.Forms.CheckBox();
			this.cbIconType = new System.Windows.Forms.ComboBox();
			this.cbUTButton1 = new System.Windows.Forms.CheckBox();
			this.tbStrButton1 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.tbStrMessage = new System.Windows.Forms.TextBox();
			this.tbIconID = new System.Windows.Forms.TextBox();
			this.btnStrIcon = new System.Windows.Forms.Button();
			this.cbTVTitle = new System.Windows.Forms.ComboBox();
			this.cbTVButton3 = new System.Windows.Forms.ComboBox();
			this.cbTVButton2 = new System.Windows.Forms.ComboBox();
			this.cbTVButton1 = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.cbUTMessage = new System.Windows.Forms.CheckBox();
			this.cbScope = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.lbTitle = new System.Windows.Forms.Label();
			this.lbButton3 = new System.Windows.Forms.Label();
			this.lbButton2 = new System.Windows.Forms.Label();
			this.lbButton1 = new System.Windows.Forms.Label();
			this.lbType = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.cbType = new System.Windows.Forms.ComboBox();
			this.pnLocalVar = new System.Windows.Forms.Panel();
			this.tbLocalVar = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.pnTempVar = new System.Windows.Forms.Panel();
			this.cbTempVar = new System.Windows.Forms.ComboBox();
			this.lbTempVar = new System.Windows.Forms.Label();
			this.pnTNS = new System.Windows.Forms.Panel();
			this.tbPriority = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.tbTimeout = new System.Windows.Forms.TextBox();
			this.lbTnsStyle = new System.Windows.Forms.Label();
			this.cbTnsStyle = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.pnWiz0x0024.SuspendLayout();
			this.pnLocalVar.SuspendLayout();
			this.pnTempVar.SuspendLayout();
			this.pnTNS.SuspendLayout();
			this.SuspendLayout();
			//
			// pnWiz0x0024
			//
			this.pnWiz0x0024.Controls.Add(this.btnDefTitle);
			this.pnWiz0x0024.Controls.Add(this.btnDefButton3);
			this.pnWiz0x0024.Controls.Add(this.btnDefButton2);
			this.pnWiz0x0024.Controls.Add(this.btnDefButton1);
			this.pnWiz0x0024.Controls.Add(this.btnDefMessage);
			this.pnWiz0x0024.Controls.Add(this.btnStrTitle);
			this.pnWiz0x0024.Controls.Add(this.btnStrButton3);
			this.pnWiz0x0024.Controls.Add(this.btnStrButton2);
			this.pnWiz0x0024.Controls.Add(this.btnStrButton1);
			this.pnWiz0x0024.Controls.Add(this.btnStrMessage);
			this.pnWiz0x0024.Controls.Add(this.tbStrTitle);
			this.pnWiz0x0024.Controls.Add(this.tbStrButton3);
			this.pnWiz0x0024.Controls.Add(this.tbStrButton2);
			this.pnWiz0x0024.Controls.Add(this.tbTitle);
			this.pnWiz0x0024.Controls.Add(this.tbMessage);
			this.pnWiz0x0024.Controls.Add(this.tbButton3);
			this.pnWiz0x0024.Controls.Add(this.cbTVMessage);
			this.pnWiz0x0024.Controls.Add(this.tbButton2);
			this.pnWiz0x0024.Controls.Add(this.lbMessage);
			this.pnWiz0x0024.Controls.Add(this.tbButton1);
			this.pnWiz0x0024.Controls.Add(this.cbBlockBHAV);
			this.pnWiz0x0024.Controls.Add(this.cbBlockSim);
			this.pnWiz0x0024.Controls.Add(this.cbUTTitle);
			this.pnWiz0x0024.Controls.Add(this.cbUTButton3);
			this.pnWiz0x0024.Controls.Add(this.lbIconType);
			this.pnWiz0x0024.Controls.Add(this.cbUTButton2);
			this.pnWiz0x0024.Controls.Add(this.cbIconType);
			this.pnWiz0x0024.Controls.Add(this.cbUTButton1);
			this.pnWiz0x0024.Controls.Add(this.tbStrButton1);
			this.pnWiz0x0024.Controls.Add(this.label5);
			this.pnWiz0x0024.Controls.Add(this.tbStrMessage);
			this.pnWiz0x0024.Controls.Add(this.tbIconID);
			this.pnWiz0x0024.Controls.Add(this.btnStrIcon);
			this.pnWiz0x0024.Controls.Add(this.cbTVTitle);
			this.pnWiz0x0024.Controls.Add(this.cbTVButton3);
			this.pnWiz0x0024.Controls.Add(this.cbTVButton2);
			this.pnWiz0x0024.Controls.Add(this.cbTVButton1);
			this.pnWiz0x0024.Controls.Add(this.label4);
			this.pnWiz0x0024.Controls.Add(this.cbUTMessage);
			this.pnWiz0x0024.Controls.Add(this.cbScope);
			this.pnWiz0x0024.Controls.Add(this.label3);
			this.pnWiz0x0024.Controls.Add(this.lbTitle);
			this.pnWiz0x0024.Controls.Add(this.lbButton3);
			this.pnWiz0x0024.Controls.Add(this.lbButton2);
			this.pnWiz0x0024.Controls.Add(this.lbButton1);
			this.pnWiz0x0024.Controls.Add(this.lbType);
			this.pnWiz0x0024.Controls.Add(this.label1);
			this.pnWiz0x0024.Controls.Add(this.cbType);
			this.pnWiz0x0024.Controls.Add(this.pnLocalVar);
			this.pnWiz0x0024.Controls.Add(this.pnTempVar);
			this.pnWiz0x0024.Controls.Add(this.pnTNS);
			resources.ApplyResources(this.pnWiz0x0024, "pnWiz0x0024");
			this.pnWiz0x0024.Name = "pnWiz0x0024";
			//
			// btnDefTitle
			//
			resources.ApplyResources(this.btnDefTitle, "btnDefTitle");
			this.btnDefTitle.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnDefTitle.Name = "btnDefTitle";
			this.btnDefTitle.Click += new System.EventHandler(this.btnDef_Click);
			//
			// btnDefButton3
			//
			resources.ApplyResources(this.btnDefButton3, "btnDefButton3");
			this.btnDefButton3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnDefButton3.Name = "btnDefButton3";
			this.btnDefButton3.Click += new System.EventHandler(this.btnDef_Click);
			//
			// btnDefButton2
			//
			resources.ApplyResources(this.btnDefButton2, "btnDefButton2");
			this.btnDefButton2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnDefButton2.Name = "btnDefButton2";
			this.btnDefButton2.Click += new System.EventHandler(this.btnDef_Click);
			//
			// btnDefButton1
			//
			resources.ApplyResources(this.btnDefButton1, "btnDefButton1");
			this.btnDefButton1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnDefButton1.Name = "btnDefButton1";
			this.btnDefButton1.Click += new System.EventHandler(this.btnDef_Click);
			//
			// btnDefMessage
			//
			resources.ApplyResources(this.btnDefMessage, "btnDefMessage");
			this.btnDefMessage.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnDefMessage.Name = "btnDefMessage";
			this.btnDefMessage.Click += new System.EventHandler(this.btnDef_Click);
			//
			// btnStrTitle
			//
			resources.ApplyResources(this.btnStrTitle, "btnStrTitle");
			this.btnStrTitle.Name = "btnStrTitle";
			this.btnStrTitle.Click += new System.EventHandler(this.btnStr_Click);
			//
			// btnStrButton3
			//
			resources.ApplyResources(this.btnStrButton3, "btnStrButton3");
			this.btnStrButton3.Name = "btnStrButton3";
			this.btnStrButton3.Click += new System.EventHandler(this.btnStr_Click);
			//
			// btnStrButton2
			//
			resources.ApplyResources(this.btnStrButton2, "btnStrButton2");
			this.btnStrButton2.Name = "btnStrButton2";
			this.btnStrButton2.Click += new System.EventHandler(this.btnStr_Click);
			//
			// btnStrButton1
			//
			resources.ApplyResources(this.btnStrButton1, "btnStrButton1");
			this.btnStrButton1.Name = "btnStrButton1";
			this.btnStrButton1.Click += new System.EventHandler(this.btnStr_Click);
			//
			// btnStrMessage
			//
			resources.ApplyResources(this.btnStrMessage, "btnStrMessage");
			this.btnStrMessage.Name = "btnStrMessage";
			this.btnStrMessage.Click += new System.EventHandler(this.btnStr_Click);
			//
			// tbStrTitle
			//
			this.tbStrTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
			resources.ApplyResources(this.tbStrTitle, "tbStrTitle");
			this.tbStrTitle.Name = "tbStrTitle";
			this.tbStrTitle.ReadOnly = true;
			this.tbStrTitle.TabStop = false;
			//
			// tbStrButton3
			//
			this.tbStrButton3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			resources.ApplyResources(this.tbStrButton3, "tbStrButton3");
			this.tbStrButton3.Name = "tbStrButton3";
			this.tbStrButton3.ReadOnly = true;
			this.tbStrButton3.TabStop = false;
			//
			// tbStrButton2
			//
			this.tbStrButton2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			resources.ApplyResources(this.tbStrButton2, "tbStrButton2");
			this.tbStrButton2.Name = "tbStrButton2";
			this.tbStrButton2.ReadOnly = true;
			this.tbStrButton2.TabStop = false;
			//
			// tbTitle
			//
			resources.ApplyResources(this.tbTitle, "tbTitle");
			this.tbTitle.Name = "tbTitle";
			this.tbTitle.Validated += new System.EventHandler(this.hex16_Validated);
			this.tbTitle.Validating += new System.ComponentModel.CancelEventHandler(
				this.hex16_Validating
			);
			this.tbTitle.TextChanged += new System.EventHandler(this.hex16_TextChanged);
			//
			// tbMessage
			//
			resources.ApplyResources(this.tbMessage, "tbMessage");
			this.tbMessage.Name = "tbMessage";
			this.tbMessage.Validated += new System.EventHandler(this.hex16_Validated);
			this.tbMessage.Validating += new System.ComponentModel.CancelEventHandler(
				this.hex16_Validating
			);
			this.tbMessage.TextChanged += new System.EventHandler(
				this.hex16_TextChanged
			);
			//
			// tbButton3
			//
			resources.ApplyResources(this.tbButton3, "tbButton3");
			this.tbButton3.Name = "tbButton3";
			this.tbButton3.Validated += new System.EventHandler(this.hex16_Validated);
			this.tbButton3.Validating += new System.ComponentModel.CancelEventHandler(
				this.hex16_Validating
			);
			this.tbButton3.TextChanged += new System.EventHandler(
				this.hex16_TextChanged
			);
			//
			// cbTVMessage
			//
			this.cbTVMessage.DropDownStyle = System
				.Windows
				.Forms
				.ComboBoxStyle
				.DropDownList;
			this.cbTVMessage.Items.AddRange(
				new object[]
				{
					resources.GetString("cbTVMessage.Items"),
					resources.GetString("cbTVMessage.Items1"),
					resources.GetString("cbTVMessage.Items2"),
					resources.GetString("cbTVMessage.Items3"),
					resources.GetString("cbTVMessage.Items4"),
					resources.GetString("cbTVMessage.Items5"),
					resources.GetString("cbTVMessage.Items6"),
					resources.GetString("cbTVMessage.Items7"),
				}
			);
			resources.ApplyResources(this.cbTVMessage, "cbTVMessage");
			this.cbTVMessage.Name = "cbTVMessage";
			this.cbTVMessage.Sorted = true;
			this.cbTVMessage.SelectedIndexChanged += new System.EventHandler(
				this.cbTempVar_SelectedIndexChanged
			);
			//
			// tbButton2
			//
			resources.ApplyResources(this.tbButton2, "tbButton2");
			this.tbButton2.Name = "tbButton2";
			this.tbButton2.Validated += new System.EventHandler(this.hex16_Validated);
			this.tbButton2.Validating += new System.ComponentModel.CancelEventHandler(
				this.hex16_Validating
			);
			this.tbButton2.TextChanged += new System.EventHandler(
				this.hex16_TextChanged
			);
			//
			// lbMessage
			//
			resources.ApplyResources(this.lbMessage, "lbMessage");
			this.lbMessage.Name = "lbMessage";
			//
			// tbButton1
			//
			resources.ApplyResources(this.tbButton1, "tbButton1");
			this.tbButton1.Name = "tbButton1";
			this.tbButton1.Validated += new System.EventHandler(this.hex16_Validated);
			this.tbButton1.Validating += new System.ComponentModel.CancelEventHandler(
				this.hex16_Validating
			);
			this.tbButton1.TextChanged += new System.EventHandler(
				this.hex16_TextChanged
			);
			//
			// cbBlockBHAV
			//
			resources.ApplyResources(this.cbBlockBHAV, "cbBlockBHAV");
			this.cbBlockBHAV.Name = "cbBlockBHAV";
			this.cbBlockBHAV.CheckedChanged += new System.EventHandler(
				this.cbBlockBHAV_CheckedChanged
			);
			//
			// cbBlockSim
			//
			resources.ApplyResources(this.cbBlockSim, "cbBlockSim");
			this.cbBlockSim.Name = "cbBlockSim";
			this.cbBlockSim.CheckedChanged += new System.EventHandler(
				this.cbBlockSim_CheckedChanged
			);
			//
			// cbUTTitle
			//
			resources.ApplyResources(this.cbUTTitle, "cbUTTitle");
			this.cbUTTitle.Name = "cbUTTitle";
			this.cbUTTitle.CheckedChanged += new System.EventHandler(
				this.cbUT_CheckedChanged
			);
			//
			// cbUTButton3
			//
			resources.ApplyResources(this.cbUTButton3, "cbUTButton3");
			this.cbUTButton3.Name = "cbUTButton3";
			this.cbUTButton3.CheckedChanged += new System.EventHandler(
				this.cbUT_CheckedChanged
			);
			//
			// lbIconType
			//
			resources.ApplyResources(this.lbIconType, "lbIconType");
			this.lbIconType.Name = "lbIconType";
			//
			// cbUTButton2
			//
			resources.ApplyResources(this.cbUTButton2, "cbUTButton2");
			this.cbUTButton2.Name = "cbUTButton2";
			this.cbUTButton2.CheckedChanged += new System.EventHandler(
				this.cbUT_CheckedChanged
			);
			//
			// cbIconType
			//
			this.cbIconType.DropDownStyle = System
				.Windows
				.Forms
				.ComboBoxStyle
				.DropDownList;
			this.cbIconType.DropDownWidth = 120;
			resources.ApplyResources(this.cbIconType, "cbIconType");
			this.cbIconType.Name = "cbIconType";
			this.cbIconType.SelectedIndexChanged += new System.EventHandler(
				this.cbIconType_SelectedIndexChanged
			);
			//
			// cbUTButton1
			//
			resources.ApplyResources(this.cbUTButton1, "cbUTButton1");
			this.cbUTButton1.Name = "cbUTButton1";
			this.cbUTButton1.CheckedChanged += new System.EventHandler(
				this.cbUT_CheckedChanged
			);
			//
			// tbStrButton1
			//
			this.tbStrButton1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			resources.ApplyResources(this.tbStrButton1, "tbStrButton1");
			this.tbStrButton1.Name = "tbStrButton1";
			this.tbStrButton1.ReadOnly = true;
			this.tbStrButton1.TabStop = false;
			//
			// label5
			//
			resources.ApplyResources(this.label5, "label5");
			this.label5.Name = "label5";
			//
			// tbStrMessage
			//
			this.tbStrMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
			resources.ApplyResources(this.tbStrMessage, "tbStrMessage");
			this.tbStrMessage.Name = "tbStrMessage";
			this.tbStrMessage.ReadOnly = true;
			this.tbStrMessage.TabStop = false;
			//
			// tbIconID
			//
			resources.ApplyResources(this.tbIconID, "tbIconID");
			this.tbIconID.Name = "tbIconID";
			this.tbIconID.Validated += new System.EventHandler(this.hex8_TextChanged);
			this.tbIconID.Validating += new System.ComponentModel.CancelEventHandler(
				this.hex8_Validating
			);
			this.tbIconID.TextChanged += new System.EventHandler(this.hex8_TextChanged);
			//
			// btnStrIcon
			//
			resources.ApplyResources(this.btnStrIcon, "btnStrIcon");
			this.btnStrIcon.Name = "btnStrIcon";
			this.btnStrIcon.Click += new System.EventHandler(this.btnStr_Click);
			//
			// cbTVTitle
			//
			this.cbTVTitle.DropDownStyle = System
				.Windows
				.Forms
				.ComboBoxStyle
				.DropDownList;
			this.cbTVTitle.Items.AddRange(
				new object[]
				{
					resources.GetString("cbTVTitle.Items"),
					resources.GetString("cbTVTitle.Items1"),
					resources.GetString("cbTVTitle.Items2"),
					resources.GetString("cbTVTitle.Items3"),
					resources.GetString("cbTVTitle.Items4"),
					resources.GetString("cbTVTitle.Items5"),
					resources.GetString("cbTVTitle.Items6"),
					resources.GetString("cbTVTitle.Items7"),
				}
			);
			resources.ApplyResources(this.cbTVTitle, "cbTVTitle");
			this.cbTVTitle.Name = "cbTVTitle";
			this.cbTVTitle.Sorted = true;
			this.cbTVTitle.SelectedIndexChanged += new System.EventHandler(
				this.cbTempVar_SelectedIndexChanged
			);
			//
			// cbTVButton3
			//
			this.cbTVButton3.DropDownStyle = System
				.Windows
				.Forms
				.ComboBoxStyle
				.DropDownList;
			this.cbTVButton3.Items.AddRange(
				new object[]
				{
					resources.GetString("cbTVButton3.Items"),
					resources.GetString("cbTVButton3.Items1"),
					resources.GetString("cbTVButton3.Items2"),
					resources.GetString("cbTVButton3.Items3"),
					resources.GetString("cbTVButton3.Items4"),
					resources.GetString("cbTVButton3.Items5"),
					resources.GetString("cbTVButton3.Items6"),
					resources.GetString("cbTVButton3.Items7"),
				}
			);
			resources.ApplyResources(this.cbTVButton3, "cbTVButton3");
			this.cbTVButton3.Name = "cbTVButton3";
			this.cbTVButton3.Sorted = true;
			this.cbTVButton3.SelectedIndexChanged += new System.EventHandler(
				this.cbTempVar_SelectedIndexChanged
			);
			//
			// cbTVButton2
			//
			this.cbTVButton2.DropDownStyle = System
				.Windows
				.Forms
				.ComboBoxStyle
				.DropDownList;
			this.cbTVButton2.Items.AddRange(
				new object[]
				{
					resources.GetString("cbTVButton2.Items"),
					resources.GetString("cbTVButton2.Items1"),
					resources.GetString("cbTVButton2.Items2"),
					resources.GetString("cbTVButton2.Items3"),
					resources.GetString("cbTVButton2.Items4"),
					resources.GetString("cbTVButton2.Items5"),
					resources.GetString("cbTVButton2.Items6"),
					resources.GetString("cbTVButton2.Items7"),
				}
			);
			resources.ApplyResources(this.cbTVButton2, "cbTVButton2");
			this.cbTVButton2.Name = "cbTVButton2";
			this.cbTVButton2.Sorted = true;
			this.cbTVButton2.SelectedIndexChanged += new System.EventHandler(
				this.cbTempVar_SelectedIndexChanged
			);
			//
			// cbTVButton1
			//
			this.cbTVButton1.DropDownStyle = System
				.Windows
				.Forms
				.ComboBoxStyle
				.DropDownList;
			this.cbTVButton1.Items.AddRange(
				new object[]
				{
					resources.GetString("cbTVButton1.Items"),
					resources.GetString("cbTVButton1.Items1"),
					resources.GetString("cbTVButton1.Items2"),
					resources.GetString("cbTVButton1.Items3"),
					resources.GetString("cbTVButton1.Items4"),
					resources.GetString("cbTVButton1.Items5"),
					resources.GetString("cbTVButton1.Items6"),
					resources.GetString("cbTVButton1.Items7"),
				}
			);
			resources.ApplyResources(this.cbTVButton1, "cbTVButton1");
			this.cbTVButton1.Name = "cbTVButton1";
			this.cbTVButton1.Sorted = true;
			this.cbTVButton1.SelectedIndexChanged += new System.EventHandler(
				this.cbTempVar_SelectedIndexChanged
			);
			//
			// label4
			//
			resources.ApplyResources(this.label4, "label4");
			this.label4.Name = "label4";
			//
			// cbUTMessage
			//
			resources.ApplyResources(this.cbUTMessage, "cbUTMessage");
			this.cbUTMessage.Name = "cbUTMessage";
			this.cbUTMessage.CheckedChanged += new System.EventHandler(
				this.cbUT_CheckedChanged
			);
			//
			// cbScope
			//
			this.cbScope.DropDownStyle = System
				.Windows
				.Forms
				.ComboBoxStyle
				.DropDownList;
			this.cbScope.Items.AddRange(
				new object[]
				{
					resources.GetString("cbScope.Items"),
					resources.GetString("cbScope.Items1"),
					resources.GetString("cbScope.Items2"),
				}
			);
			resources.ApplyResources(this.cbScope, "cbScope");
			this.cbScope.Name = "cbScope";
			this.cbScope.SelectedIndexChanged += new System.EventHandler(
				this.cbScope_SelectedIndexChanged
			);
			//
			// label3
			//
			resources.ApplyResources(this.label3, "label3");
			this.label3.Name = "label3";
			//
			// lbTitle
			//
			resources.ApplyResources(this.lbTitle, "lbTitle");
			this.lbTitle.Name = "lbTitle";
			//
			// lbButton3
			//
			resources.ApplyResources(this.lbButton3, "lbButton3");
			this.lbButton3.Name = "lbButton3";
			//
			// lbButton2
			//
			resources.ApplyResources(this.lbButton2, "lbButton2");
			this.lbButton2.Name = "lbButton2";
			//
			// lbButton1
			//
			resources.ApplyResources(this.lbButton1, "lbButton1");
			this.lbButton1.Name = "lbButton1";
			//
			// lbType
			//
			resources.ApplyResources(this.lbType, "lbType");
			this.lbType.Name = "lbType";
			//
			// label1
			//
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			//
			// cbType
			//
			this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbType.DropDownWidth = 160;
			resources.ApplyResources(this.cbType, "cbType");
			this.cbType.Name = "cbType";
			this.cbType.SelectedIndexChanged += new System.EventHandler(
				this.cbType_SelectedIndexChanged
			);
			//
			// pnLocalVar
			//
			resources.ApplyResources(this.pnLocalVar, "pnLocalVar");
			this.pnLocalVar.Controls.Add(this.tbLocalVar);
			this.pnLocalVar.Controls.Add(this.label8);
			this.pnLocalVar.Name = "pnLocalVar";
			//
			// tbLocalVar
			//
			resources.ApplyResources(this.tbLocalVar, "tbLocalVar");
			this.tbLocalVar.Name = "tbLocalVar";
			this.tbLocalVar.Validated += new System.EventHandler(this.hex8_Validated);
			this.tbLocalVar.Validating += new System.ComponentModel.CancelEventHandler(
				this.hex8_Validating
			);
			this.tbLocalVar.TextChanged += new System.EventHandler(
				this.hex8_TextChanged
			);
			//
			// label8
			//
			resources.ApplyResources(this.label8, "label8");
			this.label8.Name = "label8";
			//
			// pnTempVar
			//
			resources.ApplyResources(this.pnTempVar, "pnTempVar");
			this.pnTempVar.Controls.Add(this.cbTempVar);
			this.pnTempVar.Controls.Add(this.lbTempVar);
			this.pnTempVar.Name = "pnTempVar";
			//
			// cbTempVar
			//
			this.cbTempVar.DropDownStyle = System
				.Windows
				.Forms
				.ComboBoxStyle
				.DropDownList;
			this.cbTempVar.Items.AddRange(
				new object[]
				{
					resources.GetString("cbTempVar.Items"),
					resources.GetString("cbTempVar.Items1"),
					resources.GetString("cbTempVar.Items2"),
					resources.GetString("cbTempVar.Items3"),
					resources.GetString("cbTempVar.Items4"),
					resources.GetString("cbTempVar.Items5"),
					resources.GetString("cbTempVar.Items6"),
					resources.GetString("cbTempVar.Items7"),
				}
			);
			resources.ApplyResources(this.cbTempVar, "cbTempVar");
			this.cbTempVar.Name = "cbTempVar";
			this.cbTempVar.Sorted = true;
			this.cbTempVar.SelectedIndexChanged += new System.EventHandler(
				this.cbTempVar_SelectedIndexChanged
			);
			//
			// lbTempVar
			//
			resources.ApplyResources(this.lbTempVar, "lbTempVar");
			this.lbTempVar.Name = "lbTempVar";
			//
			// pnTNS
			//
			resources.ApplyResources(this.pnTNS, "pnTNS");
			this.pnTNS.Controls.Add(this.tbPriority);
			this.pnTNS.Controls.Add(this.label6);
			this.pnTNS.Controls.Add(this.label7);
			this.pnTNS.Controls.Add(this.tbTimeout);
			this.pnTNS.Controls.Add(this.lbTnsStyle);
			this.pnTNS.Controls.Add(this.cbTnsStyle);
			this.pnTNS.Name = "pnTNS";
			//
			// tbPriority
			//
			resources.ApplyResources(this.tbPriority, "tbPriority");
			this.tbPriority.Name = "tbPriority";
			this.tbPriority.Validated += new System.EventHandler(this.hex8_Validated);
			this.tbPriority.Validating += new System.ComponentModel.CancelEventHandler(
				this.hex8_Validating
			);
			this.tbPriority.TextChanged += new System.EventHandler(
				this.hex8_TextChanged
			);
			//
			// label6
			//
			resources.ApplyResources(this.label6, "label6");
			this.label6.Name = "label6";
			//
			// label7
			//
			resources.ApplyResources(this.label7, "label7");
			this.label7.Name = "label7";
			//
			// tbTimeout
			//
			resources.ApplyResources(this.tbTimeout, "tbTimeout");
			this.tbTimeout.Name = "tbTimeout";
			this.tbTimeout.Validated += new System.EventHandler(this.hex8_Validated);
			this.tbTimeout.Validating += new System.ComponentModel.CancelEventHandler(
				this.hex8_Validating
			);
			this.tbTimeout.TextChanged += new System.EventHandler(
				this.hex8_TextChanged
			);
			//
			// lbTnsStyle
			//
			resources.ApplyResources(this.lbTnsStyle, "lbTnsStyle");
			this.lbTnsStyle.Name = "lbTnsStyle";
			//
			// cbTnsStyle
			//
			resources.ApplyResources(this.cbTnsStyle, "cbTnsStyle");
			this.cbTnsStyle.DropDownStyle = System
				.Windows
				.Forms
				.ComboBoxStyle
				.DropDownList;
			this.cbTnsStyle.Name = "cbTnsStyle";
			this.cbTnsStyle.SelectedIndexChanged += new System.EventHandler(
				this.cbTnsStyle_SelectedIndexChanged
			);
			//
			// label2
			//
			resources.ApplyResources(this.label2, "label2");
			this.label2.Name = "label2";
			//
			// button1
			//
			resources.ApplyResources(this.button1, "button1");
			this.button1.Name = "button1";
			//
			// UI
			//
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.pnWiz0x0024);
			this.Name = "UI";
			this.pnWiz0x0024.ResumeLayout(false);
			this.pnWiz0x0024.PerformLayout();
			this.pnLocalVar.ResumeLayout(false);
			this.pnLocalVar.PerformLayout();
			this.pnTempVar.ResumeLayout(false);
			this.pnTempVar.PerformLayout();
			this.pnTNS.ResumeLayout(false);
			this.pnTNS.PerformLayout();
			this.ResumeLayout(false);
		}
		#endregion

		private void cbType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (internalchg)
				return;

			setType(((ComboBox)sender).SelectedIndex);
		}

		private void cbTnsStyle_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (internalchg)
				return;

			setTnsStyle(((ComboBox)sender).SelectedIndex);
		}

		private void cbScope_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (internalchg)
				return;

			setScope(((ComboBox)sender).SelectedIndex);
		}

		private void cbIconType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (internalchg)
				return;

			setIconType(((ComboBox)sender).SelectedIndex);
		}

		private void cbBlockBHAV_CheckedChanged(object sender, System.EventArgs e)
		{
			if (internalchg)
				return;

			setBlockBHAV(((CheckBox)sender).Checked);
		}

		private void cbBlockSim_CheckedChanged(object sender, System.EventArgs e)
		{
			if (internalchg)
				return;

			setBlockSim(((CheckBox)sender).Checked);
		}

		private void cbUT_CheckedChanged(object sender, System.EventArgs e)
		{
			if (internalchg)
				return;

			setUseTemp(alCBUseTemp.IndexOf(sender), ((CheckBox)sender).Checked);
		}

		private void cbTempVar_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (internalchg)
				return;

			int i = this.alCBTempVar.IndexOf(sender);
			if (i >= 0)
				setString(i, ((ComboBox)sender).SelectedIndex);
			else
				setTempVar(((ComboBox)sender).SelectedIndex);
		}

		private void btnStr_Click(object sender, System.EventArgs e)
		{
			doStrChooser(alStrBtn.IndexOf(sender));
		}

		private void btnDef_Click(object sender, System.EventArgs e)
		{
			this.setString(alDefBtn.IndexOf(sender), 0);
		}

		private void hex8_TextChanged(object sender, System.EventArgs ev)
		{
			if (internalchg)
				return;
			if (!hex8_IsValid(sender))
				return;

			byte val = Convert.ToByte(((TextBox)sender).Text, 16);
			int i = alHex8.IndexOf(sender);

			internalchg = true;

			switch (i)
			{
				case 0:
					setPriority(val);
					break;
				case 1:
					setTimeout(val);
					break;
				case 2:
					setLocalVar(val);
					break;
				case 3:
					setIconID(val);
					break;
			}

			internalchg = false;
		}

		private void hex8_Validating(
			object sender,
			System.ComponentModel.CancelEventArgs e
		)
		{
			if (hex8_IsValid(sender))
				return;

			e.Cancel = true;

			byte val = 0;
			int i = alHex8.IndexOf(sender);

			switch (i)
			{
				case 0:
					val = priority;
					break;
				case 1:
					val = timeout;
					break;
				case 2:
					val = localVar;
					break;
				case 3:
					val = iconID;
					break;
			}

			bool origstate = internalchg;
			internalchg = true;
			((TextBox)sender).Text = "0x" + SimPe.Helper.HexString(val);
			((TextBox)sender).SelectAll();
			internalchg = origstate;
		}

		private void hex8_Validated(object sender, System.EventArgs e)
		{
			bool origstate = internalchg;
			internalchg = true;
			((TextBox)sender).Text =
				"0x"
				+ SimPe.Helper.HexString(Convert.ToByte(((TextBox)sender).Text, 16));
			((TextBox)sender).SelectAll();
			internalchg = origstate;
		}

		private void hex16_TextChanged(object sender, System.EventArgs ev)
		{
			if (internalchg)
				return;
			if (!hex16_IsValid(sender))
				return;

			internalchg = true;
			setString(
				alHex16.IndexOf(sender),
				Convert.ToUInt16(((TextBox)sender).Text, 16)
			);
			internalchg = false;
		}

		private void hex16_Validating(
			object sender,
			System.ComponentModel.CancelEventArgs e
		)
		{
			if (hex16_IsValid(sender))
				return;

			e.Cancel = true;

			bool origstate = internalchg;
			internalchg = true;
			((TextBox)sender).Text =
				"0x" + SimPe.Helper.HexString(messages[alHex16.IndexOf(sender)]);
			((TextBox)sender).SelectAll();
			internalchg = origstate;
		}

		private void hex16_Validated(object sender, System.EventArgs e)
		{
			bool origstate = internalchg;
			internalchg = true;
			((TextBox)sender).Text =
				"0x"
				+ SimPe.Helper.HexString(Convert.ToUInt16(((TextBox)sender).Text, 16));
			((TextBox)sender).SelectAll();
			internalchg = origstate;
		}
	}
}

namespace pjse.BhavOperandWizards
{
	public class BhavOperandWiz0x0024 : pjse.ABhavOperandWiz
	{
		public BhavOperandWiz0x0024(Instruction i)
			: base(i)
		{
			myForm = new Wiz0x0024.UI();
		}

		#region IDisposable Members
		public override void Dispose()
		{
			if (myForm != null)
				myForm = null;
		}
		#endregion
	}
}
