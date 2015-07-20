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
	public static class Sending
	{
		#region Public methods

		public static void SendString(string @string)
		{
			if(@string.IsNotEmpty()) SendInputStructs(GetStringInputStructs(@string));
		}

		public static void SendScancode(bool down, Scancode scancode, VirtKey virtKey = default(VirtKey))
		{
			if(scancode.IsNotNone) SendInputStructs(GetKeyInputStruct(down, scancode, virtKey).Yield());
		}

		public static void SendScancodeDownUp(Scancode scancode, VirtKey virtKey = default(VirtKey))
		{
			if(scancode.IsNotNone) SendInputStructs(GetKeyDownUpInputStruct(scancode, virtKey));
		}

		public static void SendVirtKey(bool down, VirtKey virtKey)
		{
			if(virtKey.IsNotNone) SendInputStructs(GetKeyInputStruct(down, Scancode.None, virtKey).Yield());
		}

		public static void SendVirtKeyDownUp(VirtKey virtKey)
		{
			if(virtKey.IsNotNone) SendInputStructs(GetKeyDownUpInputStruct(Scancode.None, virtKey));
		}

		public static void SendMouseButton(bool down, MouseButton mouseButton)
		{
			if(mouseButton != MouseButton.None) SendInputStructs(GetMouseButtonInputStruct(down, mouseButton).Yield());
		}

		public static void SendMouseButtonDownUp(MouseButton mouseButton)
		{
			if(mouseButton != MouseButton.None) SendInputStructs(GetMouseButtonDownUpInputStruct(mouseButton));
		}

		public static void SendMouseWheel(int wheelAmount)
		{
			SendInputStructs(GetMouseWheelInputStruct(wheelAmount).Yield());
		}

		#endregion

		#region Aux methods

		static IEnumerable<InputStruct> GetStringInputStructs(string @string)
		{
			foreach(char @char in @string)
			{
				yield return GetUnicodeInputStruct(true, @char);
				yield return GetUnicodeInputStruct(false, @char);
			}
		}

		static InputStruct GetUnicodeInputStruct(bool down, char @char) =>
			GetKeyboardInputStruct(
				KeyboardEventFlags.Unicode | (!down).Then(KeyboardEventFlags.KeyUp),
				(ushort)@char);

		static IEnumerable<InputStruct> GetKeyDownUpInputStruct(Scancode scancode, VirtKey virtKey)
		{
			yield return GetKeyInputStruct(true, scancode, virtKey);
			yield return GetKeyInputStruct(false, scancode, virtKey);
		}

		static InputStruct GetKeyInputStruct(bool down, Scancode scancode, VirtKey virtKey) =>
			GetKeyboardInputStruct(
				virtKey.IsNone.Then(KeyboardEventFlags.Scancode) | ((scancode.Code & 0x80) != 0).Then(KeyboardEventFlags.ExtendedKey) | (!down).Then(KeyboardEventFlags.KeyUp),
				(ushort)(scancode.Code & 0x7F | (down ? 0 : 0x80)),
				(ushort)virtKey.Code);

		static IEnumerable<InputStruct> GetMouseButtonDownUpInputStruct(MouseButton button)
		{
			yield return GetMouseButtonInputStruct(true, button);
			yield return GetMouseButtonInputStruct(false, button);
		}

		static InputStruct GetMouseButtonInputStruct(bool down, MouseButton mouseButton)
		{
			var xButton = (int)(mouseButton & (MouseButton.XButton1 | MouseButton.XButton2)) >> 23;
			return GetMouseInputStruct(
				GetMouseEventFlags(down, mouseButton),
				xButton);
		}

		static InputStruct GetMouseWheelInputStruct(int wheelAmount) =>
			GetMouseInputStruct(
				MouseEventFlags.Wheel,
				wheelAmount * WheelDelta);

		static MouseEventFlags GetMouseEventFlags(bool down, MouseButton mouseButton) =>
			(MouseEventFlags)(
				(uint)(
					mouseButton.HasFlag(MouseButton.Left).Then(MouseEventFlags.LeftDown) |
					mouseButton.HasFlag(MouseButton.Right).Then(MouseEventFlags.RightDown) |
					mouseButton.HasFlag(MouseButton.Middle).Then(MouseEventFlags.MiddleDown) |
					mouseButton.HasFlag(MouseButton.XButton1).Then(MouseEventFlags.XDown) |
					mouseButton.HasFlag(MouseButton.XButton2).Then(MouseEventFlags.XDown))
				<< (down ? 0 : 1));

		static InputStruct GetKeyboardInputStruct(KeyboardEventFlags flags, ushort scancode = 0, ushort virtKey = 0) =>
			new InputStruct
			{
				Type = SendInputEventType.Keyboard,
				InputUnion = new MouseKeyboardHardwareInputUnion
				{
					KeyboardInput = new KeyboardInputStruct
					{
						Flags = flags,
						Scancode = scancode,
						VirtKey = virtKey,
					}
				}
			};

		static InputStruct GetMouseInputStruct(MouseEventFlags flags, int mouseData = 0, Point point = default(Point)) =>
			new InputStruct
			{
				Type = SendInputEventType.Mouse,
				InputUnion = new MouseKeyboardHardwareInputUnion
				{
					MouseInput = new MouseInputStruct
					{
						Flags = flags,
						MouseData = mouseData,
						Point = point,
					}
				}
			};

		static void SendInputStructs(IEnumerable<InputStruct> inputStructs)
		{
			var inputStructArray = inputStructs.ToArray();
			SendInput((uint)inputStructArray.Length, inputStructArray, InputStructSize);
		}

		#endregion

		#region WinApi types

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
			None           = 0x0000,
			Move           = 0x0001,
			LeftDown       = 0x0002,
			LeftUp         = 0x0004,
			RightDown      = 0x0008,
			RightUp        = 0x0010,
			MiddleDown     = 0x0020,
			MiddleUp       = 0x0040,
			XDown          = 0x0080,
			XUp            = 0x0100,
			Wheel          = 0x0800,
			HWheel         = 0x1000,
			MoveNoCoalesce = 0x2000,
			VirtualDesk    = 0x4000,
			Absolute       = 0x8000,
		}

		[Flags]
		enum KeyboardEventFlags : uint
		{
			None           = 0x0000,
			ExtendedKey    = 0x0001,
			KeyUp          = 0x0002,
			Unicode        = 0x0004,
			Scancode       = 0x0008,
		}

		enum SendInputEventType : uint
		{
			Mouse,
			Keyboard,
			Hardware,
		}

		[StructLayout(LayoutKind.Sequential)]
		struct MouseInputStruct
		{
			public Point Point;
			public int MouseData;
			public MouseEventFlags Flags;
			public uint Time;
			public IntPtr ExtraInfo;
		}

		[StructLayout(LayoutKind.Sequential)]
		struct KeyboardInputStruct
		{
			public ushort VirtKey;
			public ushort Scancode;
			public KeyboardEventFlags Flags;
			public uint Time;
			public IntPtr ExtraInfo;
		}

		[StructLayout(LayoutKind.Sequential)]
		struct HardwareInputStruct
		{
			public int Message;
			public short ParamL;
			public short ParamH;
		}

		[StructLayout(LayoutKind.Explicit)]
		struct MouseKeyboardHardwareInputUnion
		{
			[FieldOffset(0)] public MouseInputStruct MouseInput;
			[FieldOffset(0)] public KeyboardInputStruct KeyboardInput;
			[FieldOffset(0)] public HardwareInputStruct HardwareInput;
		}

		[StructLayout(LayoutKind.Sequential)]
		struct InputStruct
		{
			public SendInputEventType Type;
			public MouseKeyboardHardwareInputUnion InputUnion;
		}

		static readonly int InputStructSize = Marshal.SizeOf(typeof(InputStruct));

		const int WheelDelta = 120;

		#endregion

		#region WinApi methods

		// UINT WINAPI SendInput(_In_ UINT nInputs, _In_ LPINPUT pInputs, _In_ int cbSize);
		[DllImport("user32.dll")]
		static extern uint SendInput(uint inputStructCount, InputStruct[] inputStructArray, int inputStructSize);

		#endregion
	}
}
