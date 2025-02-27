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
using System.Windows.Forms;

using SimPe.PackedFiles.Wrapper;

namespace pjse.BhavOperandWizards.Wiz0x0024
{
	/// <summary>
	/// Zusammenfassung f�r BhavInstruction.
	/// </summary>
	internal class UI : Form, iBhavOperandWizForm
	{
		#region Form variables

		internal Panel pnWiz0x0024;
		private ComboBox cbType;
		private Label label1;
		private Label label2;
		private Label lbType;
		private Label lbMessage;
		private Label lbTitle;
		private Label label3;
		private ComboBox cbScope;
		private Label lbIconType;
		private CheckBox cbBlockBHAV;
		private CheckBox cbBlockSim;
		private Button button1;
		private Label label4;
		private CheckBox cbUTMessage;
		private CheckBox cbUTButton1;
		private CheckBox cbUTButton2;
		private CheckBox cbUTButton3;
		private CheckBox cbUTTitle;
		private ComboBox cbIconType;
		private Label label5;
		private TextBox tbIconID;
		private Button btnStrIcon;
		private Panel pnTNS;
		private TextBox tbPriority;
		private Label label6;
		private Label label7;
		private TextBox tbTimeout;
		private Label lbTnsStyle;
		private ComboBox cbTnsStyle;
		private Panel pnTempVar;
		private Label lbTempVar;
		private Panel pnLocalVar;
		private Label label8;
		private ComboBox cbTempVar;
		private ComboBox cbTVMessage;
		private ComboBox cbTVButton1;
		private ComboBox cbTVButton2;
		private ComboBox cbTVButton3;
		private ComboBox cbTVTitle;
		private TextBox tbLocalVar;
		private TextBox tbMessage;
		private TextBox tbButton1;
		private TextBox tbButton2;
		private TextBox tbButton3;
		private TextBox tbTitle;
		private TextBox tbStrMessage;
		private TextBox tbStrButton1;
		private TextBox tbStrButton2;
		private TextBox tbStrButton3;
		private TextBox tbStrTitle;
		private Label lbButton3;
		private Label lbButton2;
		private Label lbButton1;
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
			{
				typeDescriptions = BhavWiz.readStr(GS.BhavStr.DialogDesc);
			}

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
			{
				throw new Exception(
					"hex8_IsValid not applicable to control " + sender.ToString()
				);
			}

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
			{
				throw new Exception(
					"hex16_IsValid not applicable to control " + sender.ToString()
				);
			}

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
			{
				cbType.SelectedIndex = (cbType.Items.Count > dialog) ? dialog : -1;
			}

			lbType.Text =
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

			pnTempVar.Visible = tvState;
			pnTNS.Visible = tnsState;
			pnLocalVar.Visible = lvState;

			internalchg = false;

			// Make the display match the help text
			for (int i = 0; i < states.Length; i++)
			{
				setString(i, messages[i]);
			}
		}

		private void setTnsStyle(int newStyle)
		{
			internalchg = true;

			tnsStyle = (byte)newStyle;

			if (cbTnsStyle.Items.Count != tnsStyle)
			{
				cbTnsStyle.SelectedIndex =
					(tnsStyle >= 0 && tnsStyle < cbTnsStyle.Items.Count)
						? tnsStyle
						: -1;
			}

			internalchg = false;
		}

		private void setScope(int newScope)
		{
			internalchg = true;

			scope = (Scope)newScope;

			if (cbScope.SelectedIndex != newScope)
			{
				cbScope.SelectedIndex =
					(newScope >= 0 && newScope < cbScope.Items.Count) ? newScope : -1;
			}

			for (int i = 0; i < messages.Length; i++)
			{
				setString(i, messages[i]);
			}

			internalchg = false;
		}

		private void setIconType(int newType)
		{
			internalchg = true;

			iconType = (byte)newType;

			if (cbIconType.SelectedIndex != iconType)
			{
				cbIconType.SelectedIndex =
					(iconType >= 0 && iconType < cbIconType.Items.Count)
						? iconType
						: -1;
			}

			tbIconID.Enabled = (iconType == 3);
			btnStrIcon.Enabled = (iconType == 4);

			internalchg = false;
		}

		private void setTempVar(int newTempVar)
		{
			internalchg = true;

			tempVar = (byte)newTempVar;
			if (cbTempVar.SelectedIndex != tempVar)
			{
				cbTempVar.SelectedIndex =
					(tempVar >= 0 && tempVar < cbTempVar.Items.Count) ? tempVar : -1;
			}

			internalchg = false;
		}

		private void setBlockBHAV(bool newFlag)
		{
			internalchg = true;

			nowait = !newFlag;
			cbBlockBHAV.Checked = newFlag;

			internalchg = false;
		}

		private void setBlockSim(bool newFlag)
		{
			internalchg = true;

			noblock = !newFlag;
			cbBlockSim.Checked = newFlag;

			internalchg = false;
		}

		private void setIconID(int newIconID)
		{
			iconID = (byte)newIconID;

			if (internalchg)
			{
				return;
			}

			internalchg = true;

			tbIconID.Text = "0x" + SimPe.Helper.HexString((byte)newIconID);

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

				((ComboBox)alCBTempVar[which]).Enabled =
					((CheckBox)alCBUseTemp[which]).Enabled =
					((TextBox)alHex16[which]).Enabled =
					((Button)alStrBtn[which]).Enabled =
					((Button)alDefBtn[which]).Enabled =
					((TextBox)alTextBox[which]).Enabled =
						false;

				return;
			}

			((CheckBox)alCBUseTemp[which]).Enabled = true;

			if (useTemp[which])
			{
				ComboBox c = (ComboBox)alCBTempVar[which];
				internalchg = true;
				c.SelectedIndex = c.Items.Count > strnum ? strnum : -1;
				((TextBox)alHex16[which]).Text = "";
				internalchg = false;

				((TextBox)alTextBox[which]).Text = "";

				((CheckBox)alCBUseTemp[which]).Checked = (
					(ComboBox)alCBTempVar[which]
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
					((ComboBox)alCBTempVar[which]).SelectedIndex = -1;
					((TextBox)alHex16[which]).Text =
						"0x" + SimPe.Helper.HexString((ushort)strnum);
					internalchg = false;
				}

				((TextBox)alTextBox[which]).Text =
					(strnum <= 0)
						? "[" + Localization.GetString("none") + "]"
						: ((BhavWiz)inst).readStr(
							scope,
							GS.GlobalStr.DialogString,
							(ushort)(strnum - 1),
							-1,
							Detail.ErrorNames
						);

				((CheckBox)alCBUseTemp[which]).Checked = (
					(ComboBox)alCBTempVar[which]
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
			{
				return;
			}

			internalchg = true;

			tbPriority.Text = "0x" + SimPe.Helper.HexString((byte)newPriority);

			internalchg = false;
		}

		private void setTimeout(int newTimeout)
		{
			timeout = (byte)newTimeout;

			if (internalchg)
			{
				return;
			}

			internalchg = true;

			tbTimeout.Text = "0x" + SimPe.Helper.HexString((byte)newTimeout);

			internalchg = false;
		}

		private void setLocalVar(int newLocalVar)
		{
			localVar = (byte)newLocalVar;

			if (internalchg)
			{
				return;
			}

			internalchg = true;

			tbLocalVar.Text = "0x" + SimPe.Helper.HexString((byte)newLocalVar);

			internalchg = false;
		}

		private void doStrChooser(int which)
		{
			FileTable.Entry[] items = FileTable.GFT[
				SimPe.Data.MetaData.STRING_FILE,
				inst.Parent.GroupForScope(scope),
				(uint)GS.GlobalStr.DialogString
			];

			if (items == null || items.Length == 0)
			{
				MessageBox.Show(
					Localization.GetString("bow_noStrings")
						+ " ("
						+ Localization.GetString(scope.ToString())
						+ ")"
				);
				return; // eek!
			}

			StrWrapper str = new StrWrapper();
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
		public Panel WizPanel => pnWiz0x0024;

		public void Execute(Instruction inst)
		{
			this.inst = inst;

			wrappedByteArray ops1 = inst.Operands;
			wrappedByteArray ops2 = inst.Reserved1;

			setType(ops1[5]);

			setTnsStyle(ops2[4]);

			if ((ops2[0] & 0x01) != 0)
			{
				setScope((int)Scope.SemiGlobal);
			}
			else if ((ops2[0] & 0x40) != 0)
			{
				setScope((int)Scope.Global);
			}
			else
			{
				setScope((int)Scope.Private);
			}

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
				{
					ops2[0] |= 0x01;
				}
				else if (scope == Scope.Global)
				{
					ops2[0] |= 0x40;
				}

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
			pnWiz0x0024 = new Panel();
			btnDefTitle = new Button();
			btnDefButton3 = new Button();
			btnDefButton2 = new Button();
			btnDefButton1 = new Button();
			btnDefMessage = new Button();
			btnStrTitle = new Button();
			btnStrButton3 = new Button();
			btnStrButton2 = new Button();
			btnStrButton1 = new Button();
			btnStrMessage = new Button();
			tbStrTitle = new TextBox();
			tbStrButton3 = new TextBox();
			tbStrButton2 = new TextBox();
			tbTitle = new TextBox();
			tbMessage = new TextBox();
			tbButton3 = new TextBox();
			cbTVMessage = new ComboBox();
			tbButton2 = new TextBox();
			lbMessage = new Label();
			tbButton1 = new TextBox();
			cbBlockBHAV = new CheckBox();
			cbBlockSim = new CheckBox();
			cbUTTitle = new CheckBox();
			cbUTButton3 = new CheckBox();
			lbIconType = new Label();
			cbUTButton2 = new CheckBox();
			cbIconType = new ComboBox();
			cbUTButton1 = new CheckBox();
			tbStrButton1 = new TextBox();
			label5 = new Label();
			tbStrMessage = new TextBox();
			tbIconID = new TextBox();
			btnStrIcon = new Button();
			cbTVTitle = new ComboBox();
			cbTVButton3 = new ComboBox();
			cbTVButton2 = new ComboBox();
			cbTVButton1 = new ComboBox();
			label4 = new Label();
			cbUTMessage = new CheckBox();
			cbScope = new ComboBox();
			label3 = new Label();
			lbTitle = new Label();
			lbButton3 = new Label();
			lbButton2 = new Label();
			lbButton1 = new Label();
			lbType = new Label();
			label1 = new Label();
			cbType = new ComboBox();
			pnLocalVar = new Panel();
			tbLocalVar = new TextBox();
			label8 = new Label();
			pnTempVar = new Panel();
			cbTempVar = new ComboBox();
			lbTempVar = new Label();
			pnTNS = new Panel();
			tbPriority = new TextBox();
			label6 = new Label();
			label7 = new Label();
			tbTimeout = new TextBox();
			lbTnsStyle = new Label();
			cbTnsStyle = new ComboBox();
			label2 = new Label();
			button1 = new Button();
			pnWiz0x0024.SuspendLayout();
			pnLocalVar.SuspendLayout();
			pnTempVar.SuspendLayout();
			pnTNS.SuspendLayout();
			SuspendLayout();
			//
			// pnWiz0x0024
			//
			pnWiz0x0024.Controls.Add(btnDefTitle);
			pnWiz0x0024.Controls.Add(btnDefButton3);
			pnWiz0x0024.Controls.Add(btnDefButton2);
			pnWiz0x0024.Controls.Add(btnDefButton1);
			pnWiz0x0024.Controls.Add(btnDefMessage);
			pnWiz0x0024.Controls.Add(btnStrTitle);
			pnWiz0x0024.Controls.Add(btnStrButton3);
			pnWiz0x0024.Controls.Add(btnStrButton2);
			pnWiz0x0024.Controls.Add(btnStrButton1);
			pnWiz0x0024.Controls.Add(btnStrMessage);
			pnWiz0x0024.Controls.Add(tbStrTitle);
			pnWiz0x0024.Controls.Add(tbStrButton3);
			pnWiz0x0024.Controls.Add(tbStrButton2);
			pnWiz0x0024.Controls.Add(tbTitle);
			pnWiz0x0024.Controls.Add(tbMessage);
			pnWiz0x0024.Controls.Add(tbButton3);
			pnWiz0x0024.Controls.Add(cbTVMessage);
			pnWiz0x0024.Controls.Add(tbButton2);
			pnWiz0x0024.Controls.Add(lbMessage);
			pnWiz0x0024.Controls.Add(tbButton1);
			pnWiz0x0024.Controls.Add(cbBlockBHAV);
			pnWiz0x0024.Controls.Add(cbBlockSim);
			pnWiz0x0024.Controls.Add(cbUTTitle);
			pnWiz0x0024.Controls.Add(cbUTButton3);
			pnWiz0x0024.Controls.Add(lbIconType);
			pnWiz0x0024.Controls.Add(cbUTButton2);
			pnWiz0x0024.Controls.Add(cbIconType);
			pnWiz0x0024.Controls.Add(cbUTButton1);
			pnWiz0x0024.Controls.Add(tbStrButton1);
			pnWiz0x0024.Controls.Add(label5);
			pnWiz0x0024.Controls.Add(tbStrMessage);
			pnWiz0x0024.Controls.Add(tbIconID);
			pnWiz0x0024.Controls.Add(btnStrIcon);
			pnWiz0x0024.Controls.Add(cbTVTitle);
			pnWiz0x0024.Controls.Add(cbTVButton3);
			pnWiz0x0024.Controls.Add(cbTVButton2);
			pnWiz0x0024.Controls.Add(cbTVButton1);
			pnWiz0x0024.Controls.Add(label4);
			pnWiz0x0024.Controls.Add(cbUTMessage);
			pnWiz0x0024.Controls.Add(cbScope);
			pnWiz0x0024.Controls.Add(label3);
			pnWiz0x0024.Controls.Add(lbTitle);
			pnWiz0x0024.Controls.Add(lbButton3);
			pnWiz0x0024.Controls.Add(lbButton2);
			pnWiz0x0024.Controls.Add(lbButton1);
			pnWiz0x0024.Controls.Add(lbType);
			pnWiz0x0024.Controls.Add(label1);
			pnWiz0x0024.Controls.Add(cbType);
			pnWiz0x0024.Controls.Add(pnLocalVar);
			pnWiz0x0024.Controls.Add(pnTempVar);
			pnWiz0x0024.Controls.Add(pnTNS);
			resources.ApplyResources(pnWiz0x0024, "pnWiz0x0024");
			pnWiz0x0024.Name = "pnWiz0x0024";
			//
			// btnDefTitle
			//
			resources.ApplyResources(btnDefTitle, "btnDefTitle");
			btnDefTitle.ForeColor = System.Drawing.SystemColors.ControlText;
			btnDefTitle.Name = "btnDefTitle";
			btnDefTitle.Click += new EventHandler(btnDef_Click);
			//
			// btnDefButton3
			//
			resources.ApplyResources(btnDefButton3, "btnDefButton3");
			btnDefButton3.ForeColor = System.Drawing.SystemColors.ControlText;
			btnDefButton3.Name = "btnDefButton3";
			btnDefButton3.Click += new EventHandler(btnDef_Click);
			//
			// btnDefButton2
			//
			resources.ApplyResources(btnDefButton2, "btnDefButton2");
			btnDefButton2.ForeColor = System.Drawing.SystemColors.ControlText;
			btnDefButton2.Name = "btnDefButton2";
			btnDefButton2.Click += new EventHandler(btnDef_Click);
			//
			// btnDefButton1
			//
			resources.ApplyResources(btnDefButton1, "btnDefButton1");
			btnDefButton1.ForeColor = System.Drawing.SystemColors.ControlText;
			btnDefButton1.Name = "btnDefButton1";
			btnDefButton1.Click += new EventHandler(btnDef_Click);
			//
			// btnDefMessage
			//
			resources.ApplyResources(btnDefMessage, "btnDefMessage");
			btnDefMessage.ForeColor = System.Drawing.SystemColors.ControlText;
			btnDefMessage.Name = "btnDefMessage";
			btnDefMessage.Click += new EventHandler(btnDef_Click);
			//
			// btnStrTitle
			//
			resources.ApplyResources(btnStrTitle, "btnStrTitle");
			btnStrTitle.Name = "btnStrTitle";
			btnStrTitle.Click += new EventHandler(btnStr_Click);
			//
			// btnStrButton3
			//
			resources.ApplyResources(btnStrButton3, "btnStrButton3");
			btnStrButton3.Name = "btnStrButton3";
			btnStrButton3.Click += new EventHandler(btnStr_Click);
			//
			// btnStrButton2
			//
			resources.ApplyResources(btnStrButton2, "btnStrButton2");
			btnStrButton2.Name = "btnStrButton2";
			btnStrButton2.Click += new EventHandler(btnStr_Click);
			//
			// btnStrButton1
			//
			resources.ApplyResources(btnStrButton1, "btnStrButton1");
			btnStrButton1.Name = "btnStrButton1";
			btnStrButton1.Click += new EventHandler(btnStr_Click);
			//
			// btnStrMessage
			//
			resources.ApplyResources(btnStrMessage, "btnStrMessage");
			btnStrMessage.Name = "btnStrMessage";
			btnStrMessage.Click += new EventHandler(btnStr_Click);
			//
			// tbStrTitle
			//
			tbStrTitle.BorderStyle = BorderStyle.None;
			resources.ApplyResources(tbStrTitle, "tbStrTitle");
			tbStrTitle.Name = "tbStrTitle";
			tbStrTitle.ReadOnly = true;
			tbStrTitle.TabStop = false;
			//
			// tbStrButton3
			//
			tbStrButton3.BorderStyle = BorderStyle.None;
			resources.ApplyResources(tbStrButton3, "tbStrButton3");
			tbStrButton3.Name = "tbStrButton3";
			tbStrButton3.ReadOnly = true;
			tbStrButton3.TabStop = false;
			//
			// tbStrButton2
			//
			tbStrButton2.BorderStyle = BorderStyle.None;
			resources.ApplyResources(tbStrButton2, "tbStrButton2");
			tbStrButton2.Name = "tbStrButton2";
			tbStrButton2.ReadOnly = true;
			tbStrButton2.TabStop = false;
			//
			// tbTitle
			//
			resources.ApplyResources(tbTitle, "tbTitle");
			tbTitle.Name = "tbTitle";
			tbTitle.Validated += new EventHandler(hex16_Validated);
			tbTitle.Validating += new System.ComponentModel.CancelEventHandler(
				hex16_Validating
			);
			tbTitle.TextChanged += new EventHandler(hex16_TextChanged);
			//
			// tbMessage
			//
			resources.ApplyResources(tbMessage, "tbMessage");
			tbMessage.Name = "tbMessage";
			tbMessage.Validated += new EventHandler(hex16_Validated);
			tbMessage.Validating += new System.ComponentModel.CancelEventHandler(
				hex16_Validating
			);
			tbMessage.TextChanged += new EventHandler(
				hex16_TextChanged
			);
			//
			// tbButton3
			//
			resources.ApplyResources(tbButton3, "tbButton3");
			tbButton3.Name = "tbButton3";
			tbButton3.Validated += new EventHandler(hex16_Validated);
			tbButton3.Validating += new System.ComponentModel.CancelEventHandler(
				hex16_Validating
			);
			tbButton3.TextChanged += new EventHandler(
				hex16_TextChanged
			);
			//
			// cbTVMessage
			//
			cbTVMessage.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbTVMessage.Items.AddRange(
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
			resources.ApplyResources(cbTVMessage, "cbTVMessage");
			cbTVMessage.Name = "cbTVMessage";
			cbTVMessage.Sorted = true;
			cbTVMessage.SelectedIndexChanged += new EventHandler(
				cbTempVar_SelectedIndexChanged
			);
			//
			// tbButton2
			//
			resources.ApplyResources(tbButton2, "tbButton2");
			tbButton2.Name = "tbButton2";
			tbButton2.Validated += new EventHandler(hex16_Validated);
			tbButton2.Validating += new System.ComponentModel.CancelEventHandler(
				hex16_Validating
			);
			tbButton2.TextChanged += new EventHandler(
				hex16_TextChanged
			);
			//
			// lbMessage
			//
			resources.ApplyResources(lbMessage, "lbMessage");
			lbMessage.Name = "lbMessage";
			//
			// tbButton1
			//
			resources.ApplyResources(tbButton1, "tbButton1");
			tbButton1.Name = "tbButton1";
			tbButton1.Validated += new EventHandler(hex16_Validated);
			tbButton1.Validating += new System.ComponentModel.CancelEventHandler(
				hex16_Validating
			);
			tbButton1.TextChanged += new EventHandler(
				hex16_TextChanged
			);
			//
			// cbBlockBHAV
			//
			resources.ApplyResources(cbBlockBHAV, "cbBlockBHAV");
			cbBlockBHAV.Name = "cbBlockBHAV";
			cbBlockBHAV.CheckedChanged += new EventHandler(
				cbBlockBHAV_CheckedChanged
			);
			//
			// cbBlockSim
			//
			resources.ApplyResources(cbBlockSim, "cbBlockSim");
			cbBlockSim.Name = "cbBlockSim";
			cbBlockSim.CheckedChanged += new EventHandler(
				cbBlockSim_CheckedChanged
			);
			//
			// cbUTTitle
			//
			resources.ApplyResources(cbUTTitle, "cbUTTitle");
			cbUTTitle.Name = "cbUTTitle";
			cbUTTitle.CheckedChanged += new EventHandler(
				cbUT_CheckedChanged
			);
			//
			// cbUTButton3
			//
			resources.ApplyResources(cbUTButton3, "cbUTButton3");
			cbUTButton3.Name = "cbUTButton3";
			cbUTButton3.CheckedChanged += new EventHandler(
				cbUT_CheckedChanged
			);
			//
			// lbIconType
			//
			resources.ApplyResources(lbIconType, "lbIconType");
			lbIconType.Name = "lbIconType";
			//
			// cbUTButton2
			//
			resources.ApplyResources(cbUTButton2, "cbUTButton2");
			cbUTButton2.Name = "cbUTButton2";
			cbUTButton2.CheckedChanged += new EventHandler(
				cbUT_CheckedChanged
			);
			//
			// cbIconType
			//
			cbIconType.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbIconType.DropDownWidth = 120;
			resources.ApplyResources(cbIconType, "cbIconType");
			cbIconType.Name = "cbIconType";
			cbIconType.SelectedIndexChanged += new EventHandler(
				cbIconType_SelectedIndexChanged
			);
			//
			// cbUTButton1
			//
			resources.ApplyResources(cbUTButton1, "cbUTButton1");
			cbUTButton1.Name = "cbUTButton1";
			cbUTButton1.CheckedChanged += new EventHandler(
				cbUT_CheckedChanged
			);
			//
			// tbStrButton1
			//
			tbStrButton1.BorderStyle = BorderStyle.None;
			resources.ApplyResources(tbStrButton1, "tbStrButton1");
			tbStrButton1.Name = "tbStrButton1";
			tbStrButton1.ReadOnly = true;
			tbStrButton1.TabStop = false;
			//
			// label5
			//
			resources.ApplyResources(label5, "label5");
			label5.Name = "label5";
			//
			// tbStrMessage
			//
			tbStrMessage.BorderStyle = BorderStyle.None;
			resources.ApplyResources(tbStrMessage, "tbStrMessage");
			tbStrMessage.Name = "tbStrMessage";
			tbStrMessage.ReadOnly = true;
			tbStrMessage.TabStop = false;
			//
			// tbIconID
			//
			resources.ApplyResources(tbIconID, "tbIconID");
			tbIconID.Name = "tbIconID";
			tbIconID.Validated += new EventHandler(hex8_TextChanged);
			tbIconID.Validating += new System.ComponentModel.CancelEventHandler(
				hex8_Validating
			);
			tbIconID.TextChanged += new EventHandler(hex8_TextChanged);
			//
			// btnStrIcon
			//
			resources.ApplyResources(btnStrIcon, "btnStrIcon");
			btnStrIcon.Name = "btnStrIcon";
			btnStrIcon.Click += new EventHandler(btnStr_Click);
			//
			// cbTVTitle
			//
			cbTVTitle.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbTVTitle.Items.AddRange(
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
			resources.ApplyResources(cbTVTitle, "cbTVTitle");
			cbTVTitle.Name = "cbTVTitle";
			cbTVTitle.Sorted = true;
			cbTVTitle.SelectedIndexChanged += new EventHandler(
				cbTempVar_SelectedIndexChanged
			);
			//
			// cbTVButton3
			//
			cbTVButton3.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbTVButton3.Items.AddRange(
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
			resources.ApplyResources(cbTVButton3, "cbTVButton3");
			cbTVButton3.Name = "cbTVButton3";
			cbTVButton3.Sorted = true;
			cbTVButton3.SelectedIndexChanged += new EventHandler(
				cbTempVar_SelectedIndexChanged
			);
			//
			// cbTVButton2
			//
			cbTVButton2.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbTVButton2.Items.AddRange(
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
			resources.ApplyResources(cbTVButton2, "cbTVButton2");
			cbTVButton2.Name = "cbTVButton2";
			cbTVButton2.Sorted = true;
			cbTVButton2.SelectedIndexChanged += new EventHandler(
				cbTempVar_SelectedIndexChanged
			);
			//
			// cbTVButton1
			//
			cbTVButton1.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbTVButton1.Items.AddRange(
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
			resources.ApplyResources(cbTVButton1, "cbTVButton1");
			cbTVButton1.Name = "cbTVButton1";
			cbTVButton1.Sorted = true;
			cbTVButton1.SelectedIndexChanged += new EventHandler(
				cbTempVar_SelectedIndexChanged
			);
			//
			// label4
			//
			resources.ApplyResources(label4, "label4");
			label4.Name = "label4";
			//
			// cbUTMessage
			//
			resources.ApplyResources(cbUTMessage, "cbUTMessage");
			cbUTMessage.Name = "cbUTMessage";
			cbUTMessage.CheckedChanged += new EventHandler(
				cbUT_CheckedChanged
			);
			//
			// cbScope
			//
			cbScope.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbScope.Items.AddRange(
				new object[]
				{
					resources.GetString("cbScope.Items"),
					resources.GetString("cbScope.Items1"),
					resources.GetString("cbScope.Items2"),
				}
			);
			resources.ApplyResources(cbScope, "cbScope");
			cbScope.Name = "cbScope";
			cbScope.SelectedIndexChanged += new EventHandler(
				cbScope_SelectedIndexChanged
			);
			//
			// label3
			//
			resources.ApplyResources(label3, "label3");
			label3.Name = "label3";
			//
			// lbTitle
			//
			resources.ApplyResources(lbTitle, "lbTitle");
			lbTitle.Name = "lbTitle";
			//
			// lbButton3
			//
			resources.ApplyResources(lbButton3, "lbButton3");
			lbButton3.Name = "lbButton3";
			//
			// lbButton2
			//
			resources.ApplyResources(lbButton2, "lbButton2");
			lbButton2.Name = "lbButton2";
			//
			// lbButton1
			//
			resources.ApplyResources(lbButton1, "lbButton1");
			lbButton1.Name = "lbButton1";
			//
			// lbType
			//
			resources.ApplyResources(lbType, "lbType");
			lbType.Name = "lbType";
			//
			// label1
			//
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			//
			// cbType
			//
			cbType.DropDownStyle = ComboBoxStyle.DropDownList;
			cbType.DropDownWidth = 160;
			resources.ApplyResources(cbType, "cbType");
			cbType.Name = "cbType";
			cbType.SelectedIndexChanged += new EventHandler(
				cbType_SelectedIndexChanged
			);
			//
			// pnLocalVar
			//
			resources.ApplyResources(pnLocalVar, "pnLocalVar");
			pnLocalVar.Controls.Add(tbLocalVar);
			pnLocalVar.Controls.Add(label8);
			pnLocalVar.Name = "pnLocalVar";
			//
			// tbLocalVar
			//
			resources.ApplyResources(tbLocalVar, "tbLocalVar");
			tbLocalVar.Name = "tbLocalVar";
			tbLocalVar.Validated += new EventHandler(hex8_Validated);
			tbLocalVar.Validating += new System.ComponentModel.CancelEventHandler(
				hex8_Validating
			);
			tbLocalVar.TextChanged += new EventHandler(
				hex8_TextChanged
			);
			//
			// label8
			//
			resources.ApplyResources(label8, "label8");
			label8.Name = "label8";
			//
			// pnTempVar
			//
			resources.ApplyResources(pnTempVar, "pnTempVar");
			pnTempVar.Controls.Add(cbTempVar);
			pnTempVar.Controls.Add(lbTempVar);
			pnTempVar.Name = "pnTempVar";
			//
			// cbTempVar
			//
			cbTempVar.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbTempVar.Items.AddRange(
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
			resources.ApplyResources(cbTempVar, "cbTempVar");
			cbTempVar.Name = "cbTempVar";
			cbTempVar.Sorted = true;
			cbTempVar.SelectedIndexChanged += new EventHandler(
				cbTempVar_SelectedIndexChanged
			);
			//
			// lbTempVar
			//
			resources.ApplyResources(lbTempVar, "lbTempVar");
			lbTempVar.Name = "lbTempVar";
			//
			// pnTNS
			//
			resources.ApplyResources(pnTNS, "pnTNS");
			pnTNS.Controls.Add(tbPriority);
			pnTNS.Controls.Add(label6);
			pnTNS.Controls.Add(label7);
			pnTNS.Controls.Add(tbTimeout);
			pnTNS.Controls.Add(lbTnsStyle);
			pnTNS.Controls.Add(cbTnsStyle);
			pnTNS.Name = "pnTNS";
			//
			// tbPriority
			//
			resources.ApplyResources(tbPriority, "tbPriority");
			tbPriority.Name = "tbPriority";
			tbPriority.Validated += new EventHandler(hex8_Validated);
			tbPriority.Validating += new System.ComponentModel.CancelEventHandler(
				hex8_Validating
			);
			tbPriority.TextChanged += new EventHandler(
				hex8_TextChanged
			);
			//
			// label6
			//
			resources.ApplyResources(label6, "label6");
			label6.Name = "label6";
			//
			// label7
			//
			resources.ApplyResources(label7, "label7");
			label7.Name = "label7";
			//
			// tbTimeout
			//
			resources.ApplyResources(tbTimeout, "tbTimeout");
			tbTimeout.Name = "tbTimeout";
			tbTimeout.Validated += new EventHandler(hex8_Validated);
			tbTimeout.Validating += new System.ComponentModel.CancelEventHandler(
				hex8_Validating
			);
			tbTimeout.TextChanged += new EventHandler(
				hex8_TextChanged
			);
			//
			// lbTnsStyle
			//
			resources.ApplyResources(lbTnsStyle, "lbTnsStyle");
			lbTnsStyle.Name = "lbTnsStyle";
			//
			// cbTnsStyle
			//
			resources.ApplyResources(cbTnsStyle, "cbTnsStyle");
			cbTnsStyle.DropDownStyle =
				ComboBoxStyle
				.DropDownList;
			cbTnsStyle.Name = "cbTnsStyle";
			cbTnsStyle.SelectedIndexChanged += new EventHandler(
				cbTnsStyle_SelectedIndexChanged
			);
			//
			// label2
			//
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			//
			// button1
			//
			resources.ApplyResources(button1, "button1");
			button1.Name = "button1";
			//
			// UI
			//
			resources.ApplyResources(this, "$this");
			AutoScaleMode = AutoScaleMode.Dpi;
			Controls.Add(button1);
			Controls.Add(label2);
			Controls.Add(pnWiz0x0024);
			Name = "UI";
			pnWiz0x0024.ResumeLayout(false);
			pnWiz0x0024.PerformLayout();
			pnLocalVar.ResumeLayout(false);
			pnLocalVar.PerformLayout();
			pnTempVar.ResumeLayout(false);
			pnTempVar.PerformLayout();
			pnTNS.ResumeLayout(false);
			pnTNS.PerformLayout();
			ResumeLayout(false);
		}
		#endregion

		private void cbType_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (internalchg)
			{
				return;
			}

			setType(((ComboBox)sender).SelectedIndex);
		}

		private void cbTnsStyle_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (internalchg)
			{
				return;
			}

			setTnsStyle(((ComboBox)sender).SelectedIndex);
		}

		private void cbScope_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (internalchg)
			{
				return;
			}

			setScope(((ComboBox)sender).SelectedIndex);
		}

		private void cbIconType_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (internalchg)
			{
				return;
			}

			setIconType(((ComboBox)sender).SelectedIndex);
		}

		private void cbBlockBHAV_CheckedChanged(object sender, EventArgs e)
		{
			if (internalchg)
			{
				return;
			}

			setBlockBHAV(((CheckBox)sender).Checked);
		}

		private void cbBlockSim_CheckedChanged(object sender, EventArgs e)
		{
			if (internalchg)
			{
				return;
			}

			setBlockSim(((CheckBox)sender).Checked);
		}

		private void cbUT_CheckedChanged(object sender, EventArgs e)
		{
			if (internalchg)
			{
				return;
			}

			setUseTemp(alCBUseTemp.IndexOf(sender), ((CheckBox)sender).Checked);
		}

		private void cbTempVar_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (internalchg)
			{
				return;
			}

			int i = alCBTempVar.IndexOf(sender);
			if (i >= 0)
			{
				setString(i, ((ComboBox)sender).SelectedIndex);
			}
			else
			{
				setTempVar(((ComboBox)sender).SelectedIndex);
			}
		}

		private void btnStr_Click(object sender, EventArgs e)
		{
			doStrChooser(alStrBtn.IndexOf(sender));
		}

		private void btnDef_Click(object sender, EventArgs e)
		{
			setString(alDefBtn.IndexOf(sender), 0);
		}

		private void hex8_TextChanged(object sender, EventArgs ev)
		{
			if (internalchg)
			{
				return;
			}

			if (!hex8_IsValid(sender))
			{
				return;
			}

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
			{
				return;
			}

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

		private void hex8_Validated(object sender, EventArgs e)
		{
			bool origstate = internalchg;
			internalchg = true;
			((TextBox)sender).Text =
				"0x"
				+ SimPe.Helper.HexString(Convert.ToByte(((TextBox)sender).Text, 16));
			((TextBox)sender).SelectAll();
			internalchg = origstate;
		}

		private void hex16_TextChanged(object sender, EventArgs ev)
		{
			if (internalchg)
			{
				return;
			}

			if (!hex16_IsValid(sender))
			{
				return;
			}

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
			{
				return;
			}

			e.Cancel = true;

			bool origstate = internalchg;
			internalchg = true;
			((TextBox)sender).Text =
				"0x" + SimPe.Helper.HexString(messages[alHex16.IndexOf(sender)]);
			((TextBox)sender).SelectAll();
			internalchg = origstate;
		}

		private void hex16_Validated(object sender, EventArgs e)
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
	public class BhavOperandWiz0x0024 : ABhavOperandWiz
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
			{
				myForm = null;
			}
		}
		#endregion
	}
}
