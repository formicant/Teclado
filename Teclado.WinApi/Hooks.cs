using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Formicant;
using Teclado.Common;

namespace Teclado.WinApi
{
	public static class Hooks
	{
		#region Public methods

		public delegate bool LowLevelMouseHookDelegate(bool? down, MouseButton mouseButton, int wheelAmount, Point point);
		public delegate bool LowLevelKeyboardHookDelegate(bool down, Scancode scancode, VirtKey virtKey);

		public static event LowLevelMouseHookDelegate LowLevelMouseHookEvent;
		public static event LowLevelKeyboardHookDelegate LowLevelKeyboardHookEvent;

		public static void LowLevelMouseStart()
		{
			if(_lowLevelMouseHook == IntPtr.Zero)
				_lowLevelMouseHook = SetWindowsHookEx(HookType.MouseLowLevel, LowLevelMouseProc, HUser32, 0);
		}

		public static void LowLevelMouseStop()
		{
			if(_lowLevelMouseHook != IntPtr.Zero)
			{
				UnhookWindowsHookEx(_lowLevelMouseHook);
				_lowLevelMouseHook = IntPtr.Zero;
			}
		}

		public static void LowLevelKeyboardStart()
		{
			if(_lowLevelKeyboardHook == IntPtr.Zero)
				_lowLevelKeyboardHook = SetWindowsHookEx(HookType.KeyboardLowLevel, LowLevelKeyboardProc, HUser32, 0);
		}

		public static void LowLevelKeyboardStop()
		{
			if(_lowLevelKeyboardHook != IntPtr.Zero)
			{
				UnhookWindowsHookEx(_lowLevelKeyboardHook);
				_lowLevelKeyboardHook = IntPtr.Zero;
			}
		}

		#endregion

		#region Aux methods

		static IntPtr LowLevelMouseProc(int code, IntPtr message, ref LowLevelMouseHookStruct inputStruct)
		{
			if(code < 0 || inputStruct.Flags.HasFlag(MouseEventFlags.Injected))
				return CallNextHookEx(IntPtr.Zero, code, message, ref inputStruct);

			var point = inputStruct.Point;
			var xButton = (XButtonFlags)inputStruct.MouseData;

			var wheelAmount = 0;
			bool? down = null;
			var button = MouseButton.None;
			switch((MouseMessage)message)
			{
				case MouseMessage.LeftDown:   button = MouseButton.Left;   down = true;  break;
				case MouseMessage.LeftUp:     button = MouseButton.Left;   down = false; break;
				case MouseMessage.RightDown:  button = MouseButton.Right;  down = true;  break;
				case MouseMessage.RightUp:    button = MouseButton.Right;  down = false; break;
				case MouseMessage.MiddleDown: button = MouseButton.Middle; down = true;  break;
				case MouseMessage.MiddleUp:   button = MouseButton.Middle; down = false; break;
				case MouseMessage.XDown:
					if(     xButton.HasFlag(XButtonFlags.XButton1)) { button = MouseButton.XButton1; down = true; }
					else if(xButton.HasFlag(XButtonFlags.XButton2)) { button = MouseButton.XButton2; down = true; }
					break;
				case MouseMessage.XUp:
					if(     xButton.HasFlag(XButtonFlags.XButton1)) { button = MouseButton.XButton1; down = false; }
					else if(xButton.HasFlag(XButtonFlags.XButton2)) { button = MouseButton.XButton2; down = false; }
					break;
				case MouseMessage.Wheel:
					wheelAmount = inputStruct.MouseData / WheelDelta;
					break;
			}

			bool passThrough = LowLevelMouseHookEvent == null ||
				LowLevelMouseHookEvent(down, button, wheelAmount, point);

			return passThrough
				? CallNextHookEx(IntPtr.Zero, code, message, ref inputStruct)
				: (IntPtr)1;
		}

		static IntPtr LowLevelKeyboardProc(int code, IntPtr message, ref LowLevelKeyboardHookStruct inputStruct)
		{
			if(code < 0 || inputStruct.Flags.HasFlag(KeyboardEventFlags.Injected))
				return CallNextHookEx(IntPtr.Zero, code, message, ref inputStruct);

			var scancode = new Scancode((byte)(inputStruct.Scancode | ((uint)(inputStruct.Flags & KeyboardEventFlags.ExtendedKey) << 7)));
			var virtKey = new VirtKey((byte)inputStruct.VirtKey);
			var down = inputStruct.Flags.HasFlag(KeyboardEventFlags.KeyUp);

			var passThrough = LowLevelKeyboardHookEvent == null ||
				LowLevelKeyboardHookEvent(down, scancode, virtKey);

			return passThrough
				? CallNextHookEx(IntPtr.Zero, code, message, ref inputStruct)
				: (IntPtr)1;
		}

		#endregion

		#region Static fields

		static IntPtr _lowLevelMouseHook = IntPtr.Zero;
		static IntPtr _lowLevelKeyboardHook = IntPtr.Zero;

		static readonly IntPtr HUser32 = LoadLibrary("User32");

		#endregion

		#region WinApi types

		delegate IntPtr LowLevelMouseProcDelegate(int code, IntPtr message, ref LowLevelMouseHookStruct mouseInputStruct);
		delegate IntPtr LowLevelKeyboardProcDelegate(int code, IntPtr message, ref LowLevelKeyboardHookStruct keyboardInputStruct);

		enum MouseMessage
		{
			Move       = 0x0200,
			LeftDown   = 0x0202,
			LeftUp     = 0x0201,
			RightDown  = 0x0204,
			RightUp    = 0x0205,
			MiddleDown = 0x0207,
			MiddleUp   = 0x0208,
			XDown      = 0x020B,
			XUp        = 0x020C,
			Wheel      = 0x020A,
			HWheel     = 0x020E,
		}

		enum KeyboardMessage
		{
			KeyDown    = 0x0100,
			KeyUp      = 0x0101,
			SysKeyDown = 0x0104,
			SysKeyUp   = 0x0105,
		}

		[Flags]
		enum XButtonFlags : uint
		{
			None     = 0x00,
			XButton1 = 0x01,
			XButton2 = 0x02,
		}

		[Flags]
		enum MouseEventFlags : uint
		{
			None            = 0x0000,
			Injected        = 0x0001,
			LowerIlInjected = 0x0002,
		}

		[Flags]
		enum KeyboardEventFlags : uint
		{
			None            = 0x0000,
			ExtendedKey     = 0x0001,
			LowerIlInjected = 0x0002,
			Injected        = 0x0010,
			AltDown         = 0x0020,
			KeyUp           = 0x0080,
		}

		enum HookType : int
		{
			JournalRecord,
			JournalPlayback,
			Keyboard,
			GetMessage,
			CallWndProc,
			Cbt,
			SysMsgFilter,
			Mouse,
			Hardware,
			Debug,
			Shell,
			ForegroundIdle,
			CallWndProcRet,
			KeyboardLowLevel,
			MouseLowLevel,
			MsgFilter = -1,
		}

		[StructLayout(LayoutKind.Sequential)]
		struct LowLevelMouseHookStruct
		{
			public Point Point;
			public int MouseData;
			public MouseEventFlags Flags;
			public uint Time;
			public IntPtr ExtraInfo;
		}

		[StructLayout(LayoutKind.Sequential)]
		struct LowLevelKeyboardHookStruct
		{
			public uint VirtKey;
			public uint Scancode;
			public KeyboardEventFlags Flags;
			public uint Time;
			public IntPtr ExtraInfo;
		}

		const int WheelDelta = 120;

		#endregion

		#region WinApi methods

		// HHOOK WINAPI SetWindowsHookEx(_In_ int idHook, _In_ HOOKPROC lpfn, _In_ HINSTANCE hMod, _In_ DWORD dwThreadId);
		[DllImport("user32.dll")]
		static extern IntPtr SetWindowsHookEx(HookType hookType, LowLevelMouseProcDelegate mouseProc, IntPtr mod, uint threadId);
		[DllImport("user32.dll")]
		static extern IntPtr SetWindowsHookEx(HookType hookType, LowLevelKeyboardProcDelegate keyboardProc, IntPtr mod, uint threadId);

		// LRESULT WINAPI CallNextHookEx(_In_opt_ HHOOK hhk, _In_ int nCode, _In_ WPARAM wParam, _In_ LPARAM lParam);
		[DllImport("user32.dll")]
		static extern IntPtr CallNextHookEx(IntPtr ignored, int code, IntPtr message, ref LowLevelMouseHookStruct mouseInputStruct);
		[DllImport("user32.dll")]
		static extern IntPtr CallNextHookEx(IntPtr ignored, int code, IntPtr message, ref LowLevelKeyboardHookStruct keyboardInputStruct);

		// BOOL WINAPI UnhookWindowsHookEx(_In_ HHOOK hhk);
		[DllImport("user32.dll")]
		static extern bool UnhookWindowsHookEx(IntPtr hook);

		// HMODULE WINAPI LoadLibrary(_In_ LPCTSTR lpFileName);
		[DllImport("kernel32.dll")]
		static extern IntPtr LoadLibrary(string fileName);

		#endregion
	}
}
