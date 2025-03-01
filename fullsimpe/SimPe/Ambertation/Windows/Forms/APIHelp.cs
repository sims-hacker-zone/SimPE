// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later

using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Ambertation.Windows.Forms
{
	public class APIHelp
	{
		[Serializable]
		public struct RECT
		{
			public int Left;

			public int Top;

			public int Right;

			public int Bottom;

			public int Height => Bottom - Top;

			public int Width => Right - Left;

			public Size Size => new Size(Width, Height);

			public Point Location => new Point(Left, Top);

			public RECT(int left_, int top_, int right_, int bottom_)
			{
				Left = left_;
				Top = top_;
				Right = right_;
				Bottom = bottom_;
			}

			public Rectangle ToRectangle()
			{
				return Rectangle.FromLTRB(Left, Top, Right, Bottom);
			}

			public static RECT FromRectangle(Rectangle rectangle)
			{
				return new RECT(rectangle.Left, rectangle.Top, rectangle.Right, rectangle.Bottom);
			}

			public override int GetHashCode()
			{
				return Left ^ ((Top << 13) | (Top >> 19)) ^ ((Width << 26) | (Width >> 6)) ^ ((Height << 7) | (Height >> 25));
			}

			public static implicit operator Rectangle(RECT rect)
			{
				return Rectangle.FromLTRB(rect.Left, rect.Top, rect.Right, rect.Bottom);
			}

			public static implicit operator RECT(Rectangle rect)
			{
				return new RECT(rect.Left, rect.Top, rect.Right, rect.Bottom);
			}
		}

		public struct NCCALCSIZE_PARAMS
		{
			public RECT rgrc0;

			public RECT rgrc1;

			public RECT rgrc2;

			public IntPtr lppos;
		}

		public struct WINDOWPOS
		{
			public IntPtr hwnd;

			public IntPtr hwndInsertAfter;

			public int x;

			public int y;

			public int cx;

			public int cy;

			public int flags;
		}

		public enum Bool
		{
			False,
			True
		}

		public struct Point
		{
			public int x;

			public int y;

			public Point(int x, int y)
			{
				this.x = x;
				this.y = y;
			}
		}

		public struct Size
		{
			public int cx;

			public int cy;

			public Size(int cx, int cy)
			{
				this.cx = cx;
				this.cy = cy;
			}
		}

		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		private struct ARGB
		{
			public byte Blue;

			public byte Green;

			public byte Red;

			public byte Alpha;
		}

		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		public struct BLENDFUNCTION
		{
			public byte BlendOp;

			public byte BlendFlags;

			public byte SourceConstantAlpha;

			public byte AlphaFormat;
		}

		public struct WINDOWINFO
		{
			public uint cbSize;

			public RECT rcWindow;

			public RECT rcClient;

			public uint dwStyle;

			public uint dwExStyle;

			public uint dwWindowStatus;

			public uint cxWindowBorders;

			public uint cyWindowBorders;

			public ushort atomWindowType;

			public ushort wCreatorVersion;
		}

		public enum WindowsVersion
		{
			Unknown,
			Windows95,
			Windows98,
			Windows98SE,
			WindowsME,
			WindowsCE,
			WindowsNT35,
			WindowsNT4,
			Windows2000,
			WindowsServer2003,
			WindowsXP,
			Vista
		}

		public enum VirtualKeyStates
		{
			VK_LBUTTON = 1,
			VK_RBUTTON = 2,
			VK_CANCEL = 3,
			VK_MBUTTON = 4,
			VK_XBUTTON1 = 5,
			VK_XBUTTON2 = 6,
			VK_BACK = 8,
			VK_TAB = 9,
			VK_CLEAR = 12,
			VK_RETURN = 13,
			VK_SHIFT = 16,
			VK_CONTROL = 17,
			VK_MENU = 18,
			VK_PAUSE = 19,
			VK_CAPITAL = 20,
			VK_KANA = 21,
			VK_HANGEUL = 21,
			VK_HANGUL = 21,
			VK_JUNJA = 23,
			VK_FINAL = 24,
			VK_HANJA = 25,
			VK_KANJI = 25,
			VK_ESCAPE = 27,
			VK_CONVERT = 28,
			VK_NONCONVERT = 29,
			VK_ACCEPT = 30,
			VK_MODECHANGE = 31,
			VK_SPACE = 32,
			VK_PRIOR = 33,
			VK_NEXT = 34,
			VK_END = 35,
			VK_HOME = 36,
			VK_LEFT = 37,
			VK_UP = 38,
			VK_RIGHT = 39,
			VK_DOWN = 40,
			VK_SELECT = 41,
			VK_PRINT = 42,
			VK_EXECUTE = 43,
			VK_SNAPSHOT = 44,
			VK_INSERT = 45,
			VK_DELETE = 46,
			VK_HELP = 47,
			VK_LWIN = 91,
			VK_RWIN = 92,
			VK_APPS = 93,
			VK_SLEEP = 95,
			VK_NUMPAD0 = 96,
			VK_NUMPAD1 = 97,
			VK_NUMPAD2 = 98,
			VK_NUMPAD3 = 99,
			VK_NUMPAD4 = 100,
			VK_NUMPAD5 = 101,
			VK_NUMPAD6 = 102,
			VK_NUMPAD7 = 103,
			VK_NUMPAD8 = 104,
			VK_NUMPAD9 = 105,
			VK_MULTIPLY = 106,
			VK_ADD = 107,
			VK_SEPARATOR = 108,
			VK_SUBTRACT = 109,
			VK_DECIMAL = 110,
			VK_DIVIDE = 111,
			VK_F1 = 112,
			VK_F2 = 113,
			VK_F3 = 114,
			VK_F4 = 115,
			VK_F5 = 116,
			VK_F6 = 117,
			VK_F7 = 118,
			VK_F8 = 119,
			VK_F9 = 120,
			VK_F10 = 121,
			VK_F11 = 122,
			VK_F12 = 123,
			VK_F13 = 124,
			VK_F14 = 125,
			VK_F15 = 126,
			VK_F16 = 127,
			VK_F17 = 128,
			VK_F18 = 129,
			VK_F19 = 130,
			VK_F20 = 131,
			VK_F21 = 132,
			VK_F22 = 133,
			VK_F23 = 134,
			VK_F24 = 135,
			VK_NUMLOCK = 144,
			VK_SCROLL = 145,
			VK_OEM_NEC_EQUAL = 146,
			VK_OEM_FJ_JISHO = 146,
			VK_OEM_FJ_MASSHOU = 147,
			VK_OEM_FJ_TOUROKU = 148,
			VK_OEM_FJ_LOYA = 149,
			VK_OEM_FJ_ROYA = 150,
			VK_LSHIFT = 160,
			VK_RSHIFT = 161,
			VK_LCONTROL = 162,
			VK_RCONTROL = 163,
			VK_LMENU = 164,
			VK_RMENU = 165,
			VK_BROWSER_BACK = 166,
			VK_BROWSER_FORWARD = 167,
			VK_BROWSER_REFRESH = 168,
			VK_BROWSER_STOP = 169,
			VK_BROWSER_SEARCH = 170,
			VK_BROWSER_FAVORITES = 171,
			VK_BROWSER_HOME = 172,
			VK_VOLUME_MUTE = 173,
			VK_VOLUME_DOWN = 174,
			VK_VOLUME_UP = 175,
			VK_MEDIA_NEXT_TRACK = 176,
			VK_MEDIA_PREV_TRACK = 177,
			VK_MEDIA_STOP = 178,
			VK_MEDIA_PLAY_PAUSE = 179,
			VK_LAUNCH_MAIL = 180,
			VK_LAUNCH_MEDIA_SELECT = 181,
			VK_LAUNCH_APP1 = 182,
			VK_LAUNCH_APP2 = 183,
			VK_OEM_1 = 186,
			VK_OEM_PLUS = 187,
			VK_OEM_COMMA = 188,
			VK_OEM_MINUS = 189,
			VK_OEM_PERIOD = 190,
			VK_OEM_2 = 191,
			VK_OEM_3 = 192,
			VK_OEM_4 = 219,
			VK_OEM_5 = 220,
			VK_OEM_6 = 221,
			VK_OEM_7 = 222,
			VK_OEM_8 = 223,
			VK_OEM_AX = 225,
			VK_OEM_102 = 226,
			VK_ICO_HELP = 227,
			VK_ICO_00 = 228,
			VK_PROCESSKEY = 229,
			VK_ICO_CLEAR = 230,
			VK_PACKET = 231,
			VK_OEM_RESET = 233,
			VK_OEM_JUMP = 234,
			VK_OEM_PA1 = 235,
			VK_OEM_PA2 = 236,
			VK_OEM_PA3 = 237,
			VK_OEM_WSCTRL = 238,
			VK_OEM_CUSEL = 239,
			VK_OEM_ATTN = 240,
			VK_OEM_FINISH = 241,
			VK_OEM_COPY = 242,
			VK_OEM_AUTO = 243,
			VK_OEM_ENLW = 244,
			VK_OEM_BACKTAB = 245,
			VK_ATTN = 246,
			VK_CRSEL = 247,
			VK_EXSEL = 248,
			VK_EREOF = 249,
			VK_PLAY = 250,
			VK_ZOOM = 251,
			VK_NONAME = 252,
			VK_PA1 = 253,
			VK_OEM_CLEAR = 254
		}

		public const int WM_ACTIVATE = 6;

		public const int WM_ACTIVATEAPP = 28;

		public const int WM_ACTIVATEAPP_EXT = 49395;

		public const int WM_AFXFIRST = 864;

		public const int WM_AFXLAST = 895;

		public const int WM_APP = 32768;

		public const int WM_ASKCBFORMATNAME = 780;

		public const int WM_CANCELJOURNAL = 75;

		public const int WM_CANCELMODE = 31;

		public const int WM_CAPTURECHANGED = 533;

		public const int WM_CHANGECBCHAIN = 781;

		public const int WM_CHANGEUISTATE = 295;

		public const int WM_CHAR = 258;

		public const int WM_CHARTOITEM = 47;

		public const int WM_CHILDACTIVATE = 34;

		public const int WM_CLEAR = 771;

		public const int WM_CLOSE = 16;

		public const int WM_COMMAND = 273;

		public const int WM_COMPACTING = 65;

		public const int WM_COMPAREITEM = 57;

		public const int WM_CONTEXTMENU = 123;

		public const int WM_COPY = 769;

		public const int WM_COPYDATA = 74;

		public const int WM_CREATE = 1;

		public const int WM_CTLCOLORBTN = 309;

		public const int WM_CTLCOLORDLG = 310;

		public const int WM_CTLCOLOREDIT = 307;

		public const int WM_CTLCOLORLISTBOX = 308;

		public const int WM_CTLCOLORMSGBOX = 306;

		public const int WM_CTLCOLORSCROLLBAR = 311;

		public const int WM_CTLCOLORSTATIC = 312;

		public const int WM_CUT = 768;

		public const int WM_DEADCHAR = 259;

		public const int WM_DELETEITEM = 45;

		public const int WM_DESTROY = 2;

		public const int WM_DESTROYCLIPBOARD = 775;

		public const int WM_DEVICECHANGE = 537;

		public const int WM_DEVMODECHANGE = 27;

		public const int WM_DISPLAYCHANGE = 126;

		public const int WM_DRAWCLIPBOARD = 776;

		public const int WM_DRAWITEM = 43;

		public const int WM_DROPFILES = 563;

		public const int WM_ENABLE = 10;

		public const int WM_ENDSESSION = 22;

		public const int WM_ENTERIDLE = 289;

		public const int WM_ENTERMENULOOP = 529;

		public const int WM_ENTERSIZEMOVE = 561;

		public const int WM_ERASEBKGND = 20;

		public const int WM_EXITMENULOOP = 530;

		public const int WM_EXITSIZEMOVE = 562;

		public const int WM_FONTCHANGE = 29;

		public const int WM_GETDLGCODE = 135;

		public const int WM_GETFONT = 49;

		public const int WM_GETHOTKEY = 51;

		public const int WM_GETICON = 127;

		public const int WM_GETMINMAXINFO = 36;

		public const int WM_GETOBJECT = 61;

		public const int WM_GETTEXT = 13;

		public const int WM_GETTEXTLENGTH = 14;

		public const int WM_HANDHELDFIRST = 856;

		public const int WM_HANDHELDLAST = 863;

		public const int WM_HELP = 83;

		public const int WM_HOTKEY = 786;

		public const int WM_HSCROLL = 276;

		public const int WM_HSCROLLCLIPBOARD = 782;

		public const int WM_ICONERASEBKGND = 39;

		public const int WM_IME_CHAR = 646;

		public const int WM_IME_COMPOSITION = 271;

		public const int WM_IME_COMPOSITIONFULL = 644;

		public const int WM_IME_CONTROL = 643;

		public const int WM_IME_ENDCOMPOSITION = 270;

		public const int WM_IME_KEYDOWN = 656;

		public const int WM_IME_KEYLAST = 271;

		public const int WM_IME_KEYUP = 657;

		public const int WM_IME_NOTIFY = 642;

		public const int WM_IME_REQUEST = 648;

		public const int WM_IME_SELECT = 645;

		public const int WM_IME_SETCONTEXT = 641;

		public const int WM_IME_STARTCOMPOSITION = 269;

		public const int WM_INITDIALOG = 272;

		public const int WM_INITMENU = 278;

		public const int WM_INITMENUPOPUP = 279;

		public const int WM_INPUTLANGCHANGE = 81;

		public const int WM_INPUTLANGCHANGEREQUEST = 80;

		public const int WM_KEYDOWN = 256;

		public const int WM_KEYFIRST = 256;

		public const int WM_KEYLAST = 264;

		public const int WM_KEYUP = 257;

		public const int WM_KILLFOCUS = 8;

		public const int WM_LBUTTONDBLCLK = 515;

		public const int WM_LBUTTONDOWN = 513;

		public const int WM_LBUTTONUP = 514;

		public const int WM_MBUTTONDBLCLK = 521;

		public const int WM_MBUTTONDOWN = 519;

		public const int WM_MBUTTONUP = 520;

		public const int WM_MDIACTIVATE = 546;

		public const int WM_MDICASCADE = 551;

		public const int WM_MDICREATE = 544;

		public const int WM_MDIDESTROY = 545;

		public const int WM_MDIGETACTIVE = 553;

		public const int WM_MDIICONARRANGE = 552;

		public const int WM_MDIMAXIMIZE = 549;

		public const int WM_MDINEXT = 548;

		public const int WM_MDIREFRESHMENU = 564;

		public const int WM_MDIRESTORE = 547;

		public const int WM_MDISETMENU = 560;

		public const int WM_MDITILE = 550;

		public const int WM_MEASUREITEM = 44;

		public const int WM_MENUCHAR = 288;

		public const int WM_MENUCOMMAND = 294;

		public const int WM_MENUDRAG = 291;

		public const int WM_MENUGETOBJECT = 292;

		public const int WM_MENURBUTTONUP = 290;

		public const int WM_MENUSELECT = 287;

		public const int WM_MOUSEACTIVATE = 33;

		public const int WM_MOUSEFIRST = 512;

		public const int WM_MOUSEHOVER = 673;

		public const int WM_MOUSELAST = 522;

		public const int WM_MOUSELEAVE = 675;

		public const int WM_MOUSEMOVE = 512;

		public const int WM_MOUSEWHEEL = 522;

		public const int WM_MOVE = 3;

		public const int WM_MOVING = 534;

		public const int WM_NCACTIVATE = 134;

		public const int WM_NCCALCSIZE = 131;

		public const int WM_NCCREATE = 129;

		public const int WM_NCDESTROY = 130;

		public const int WM_NCHITTEST = 132;

		public const int WM_NCLBUTTONDBLCLK = 163;

		public const int WM_NCLBUTTONDOWN = 161;

		public const int WM_NCLBUTTONUP = 162;

		public const int WM_NCMBUTTONDBLCLK = 169;

		public const int WM_NCMBUTTONDOWN = 167;

		public const int WM_NCMBUTTONUP = 168;

		public const int WM_NCMOUSEMOVE = 160;

		public const int WM_NCPAINT = 133;

		public const int WM_NCRBUTTONDBLCLK = 166;

		public const int WM_NCRBUTTONDOWN = 164;

		public const int WM_NCRBUTTONUP = 165;

		public const int WM_NEXTDLGCTL = 40;

		public const int WM_NEXTMENU = 531;

		public const int WM_NOTIFY = 78;

		public const int WM_NOTIFYFORMAT = 85;

		public const int WM_NULL = 0;

		public const int WM_PAINT = 15;

		public const int WM_PAINTCLIPBOARD = 777;

		public const int WM_PAINTICON = 38;

		public const int WM_PALETTECHANGED = 785;

		public const int WM_PALETTEISCHANGING = 784;

		public const int WM_PARENTNOTIFY = 528;

		public const int WM_PASTE = 770;

		public const int WM_PENWINFIRST = 896;

		public const int WM_PENWINLAST = 911;

		public const int WM_POWER = 72;

		public const int WM_POWERBROADCAST = 536;

		public const int WM_PRINT = 791;

		public const int WM_PRINTCLIENT = 792;

		public const int WM_QUERYDRAGICON = 55;

		public const int WM_QUERYENDSESSION = 17;

		public const int WM_QUERYNEWPALETTE = 783;

		public const int WM_QUERYOPEN = 19;

		public const int WM_QUEUESYNC = 35;

		public const int WM_QUIT = 18;

		public const int WM_RBUTTONDBLCLK = 518;

		public const int WM_RBUTTONDOWN = 516;

		public const int WM_RBUTTONUP = 517;

		public const int WM_RENDERALLFORMATS = 774;

		public const int WM_RENDERFORMAT = 773;

		public const int WM_SETCURSOR = 32;

		public const int WM_SETFOCUS = 7;

		public const int WM_SETFONT = 48;

		public const int WM_SETHOTKEY = 50;

		public const int WM_SETICON = 128;

		public const int WM_SETREDRAW = 11;

		public const int WM_SETTEXT = 12;

		public const int WM_SETTINGCHANGE = 26;

		public const int WM_SHOWWINDOW = 24;

		public const int WM_SIZE = 5;

		public const int WM_SIZECLIPBOARD = 779;

		public const int WM_SIZING = 532;

		public const int WM_SPOOLERSTATUS = 42;

		public const int WM_STYLECHANGED = 125;

		public const int WM_STYLECHANGING = 124;

		public const int WM_SYNCPAINT = 136;

		public const int WM_SYSCHAR = 262;

		public const int WM_SYSCOLORCHANGE = 21;

		public const int WM_SYSCOMMAND = 274;

		public const int WM_SYSDEADCHAR = 263;

		public const int WM_SYSKEYDOWN = 260;

		public const int WM_SYSKEYUP = 261;

		public const int WM_TCARD = 82;

		public const int WM_TIMECHANGE = 30;

		public const int WM_TIMER = 275;

		public const int WM_UNDO = 772;

		public const int WM_UNINITMENUPOPUP = 293;

		public const int WM_USER = 1024;

		public const int WM_USERCHANGED = 84;

		public const int WM_VKEYTOITEM = 46;

		public const int WM_VSCROLL = 277;

		public const int WM_VSCROLLCLIPBOARD = 778;

		public const int WM_WINDOWPOSCHANGED = 71;

		public const int WM_WINDOWPOSCHANGING = 70;

		public const int WM_WININICHANGE = 26;

		public const int WS_EX_LAYERED = 524288;

		public const int HTCAPTION = 2;

		public const int WM_NCMOUSEHOVER = 672;

		public const int WM_NCMOUSELEAVE = 674;

		public const int ULW_ALPHA = 2;

		public const byte AC_SRC_OVER = 0;

		public const byte AC_SRC_ALPHA = 1;

		public const int WS_EX_TOOLWINDOW = 128;

		public const int WS_EX_APPWINDOW = 262144;

		public const int WS_BORDER = -8388609;

		public const int WS_EX_CLIENTEDGE = -513;

		public const int RDW_FRAME = 1024;

		public const int RDW_UPDATENOW = 256;

		public const int RDW_INVALIDATE = 1;

		public const uint SWP_NOSIZE = 1u;

		public const uint SWP_NOMOVE = 2u;

		public const uint SWP_NOZORDER = 4u;

		public const uint SWP_NOREDRAW = 8u;

		public const uint SWP_NOACTIVATE = 16u;

		public const uint SWP_FRAMECHANGED = 32u;

		public const uint SWP_SHOWWINDOW = 64u;

		public const uint SWP_HIDEWINDOW = 128u;

		public const uint SWP_NOCOPYBITS = 256u;

		public const uint SWP_NOOWNERZORDER = 512u;

		public const uint SWP_NOSENDCHANGING = 1024u;

		public static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);

		public static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);

		public static readonly IntPtr HWND_TOP = new IntPtr(0);

		public static readonly IntPtr HWND_BOTTOM = new IntPtr(1);

		public static bool CanUseLayeredWindows
		{
			get
			{
				bool canUse = false;

				switch (GetVersionEx())
				{
					case WindowsVersion.Vista:
					case WindowsVersion.WindowsXP:
					case WindowsVersion.Windows2000:
					case WindowsVersion.WindowsServer2003:
						canUse = true;
						break;
					default:
						canUse = false;
						break;
				}

				return canUse;
			}
		}


		[DllImport("User32.dll")]
		public static extern IntPtr GetWindowDC(IntPtr hWnd);

		[DllImport("User32.dll")]
		public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

		public static WindowsVersion GetVersionEx()
		{
			OperatingSystem oSVersion = Environment.OSVersion;
			switch (oSVersion.Platform)
			{
				case PlatformID.Win32Windows:
					switch (oSVersion.Version.Minor)
					{
						case 0:
							return WindowsVersion.Windows95;
						case 10:
							if (oSVersion.Version.Revision.ToString() == "2222A")
							{
								return WindowsVersion.Windows98SE;
							}

							return WindowsVersion.Windows98;
						case 90:
							return WindowsVersion.WindowsME;
					}

					break;
				case PlatformID.Win32NT:
					switch (oSVersion.Version.Major)
					{
						case 5:
							if (oSVersion.Version.Minor == 0)
							{
								return WindowsVersion.Windows2000;
							}

							if (oSVersion.Version.Minor == 1)
							{
								return WindowsVersion.WindowsXP;
							}

							if (oSVersion.Version.Minor == 2)
							{
								return WindowsVersion.WindowsServer2003;
							}

							break;
						case 3:
							return WindowsVersion.WindowsNT35;
						case 4:
							return WindowsVersion.WindowsNT4;
						case 6:
							return WindowsVersion.Vista;
					}

					break;
			}

			return WindowsVersion.Unknown;
		}

		[DllImport("user32.dll")]
		public static extern bool GetWindowInfo(IntPtr hwnd, ref WINDOWINFO pwi);

		public static Bool CallUpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref Point pptDst, ref Size psize, IntPtr hdcSrc, ref Point pprSrc, int crKey, ref BLENDFUNCTION pblend, int dwFlags)
		{
			if (CanUseLayeredWindows)
			{
				return UpdateLayeredWindow(hwnd, hdcDst, ref pptDst, ref psize, hdcSrc, ref pprSrc, crKey, ref pblend, dwFlags);
			}

			return Bool.True;
		}

		[DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
		protected static extern Bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref Point pptDst, ref Size psize, IntPtr hdcSrc, ref Point pprSrc, int crKey, ref BLENDFUNCTION pblend, int dwFlags);

		[DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
		public static extern IntPtr CreateCompatibleDC(IntPtr hDC);

		[DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
		public static extern IntPtr GetDC(IntPtr hWnd);

		[DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
		public static extern Bool DeleteDC(IntPtr hdc);

		[DllImport("gdi32.dll", ExactSpelling = true)]
		public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);

		[DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
		public static extern Bool DeleteObject(IntPtr hObject);

		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr handle, uint message, int wParam, int lParam);

		[DllImport("user32.dll")]
		public static extern bool ReleaseCapture();

		[DllImport("user32.dll")]
		public static extern int ReleaseCapture(IntPtr hwnd);

		[DllImport("user32.dll")]
		public static extern IntPtr SetCapture(IntPtr hWnd);

		[DllImport("user32.dll")]
		public static extern bool RedrawWindow(IntPtr hWnd, [In] ref RECT lprcUpdate, IntPtr hrgnUpdate, uint flags);

		[DllImport("user32.dll")]
		public static extern short GetKeyState(VirtualKeyStates nVirtKey);

		[DllImport("user32.dll")]
		public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
	}
}
