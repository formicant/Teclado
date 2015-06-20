using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Formicant;
using Teclado.Common;

namespace Teclado.WinApi
{
	public static class Layouts
	{
		#region Public methods

		public static KeyState GetKeyState()
		{
			var keyStateArray = new byte[256];
			var success = GetKeyboardState(keyStateArray);
			return new KeyState(success ? keyStateArray : null);
		}

		public static List<Layout> GetLayoutList()
		{
			uint count = GetKeyboardLayoutList(0, null);
			var layoutIds = new IntPtr[count];
			GetKeyboardLayoutList(layoutIds.Length, layoutIds);
			return layoutIds.Select(l => new Layout((uint)l)).ToList();
		}

		public static Layout GetCurrentLayout()
		{
			return new Layout(GetKeyboardLayout(GetWindowThreadProcessId(GetForegroundWindow())));
		}

		public static void ChangeCurrentLayout(Layout layout)
		{
			ChangeCurrentLayout(LayoutChange.None, layout);
		}

		public static string CodeToString(Scancode scanCode, VirtKey virtKey, KeyState keyState, Layout layout)
		{
			var sb = new StringBuilder(16);
			int rc = ToUnicodeEx(virtKey.Code, scanCode.Code, keyState.Array, sb, sb.Capacity, 0, layout.Id);
			return sb.ToString();
		}

		#endregion

		#region Aux methods

		static void ChangeCurrentLayout(LayoutChange layoutChange, Layout layout)
		{
			PostMessage(GetForegroundWindow(), (uint)WindowsMessage.InputLangChangeRequest, (IntPtr)layoutChange, (IntPtr)(layout.Id & 0xFFFF));
		}

		#endregion

		#region WinApi types

		[Flags]
		enum LayoutChange : uint
		{
			None       = 0x00,
			SysCharSet = 0x01,
			Forward    = 0x02,
			Backward   = 0x04,
		}

		enum WindowsMessage : uint
		{
			InputLangChangeRequest = 0x50,
		}

		#endregion

		#region WinApi methods

		// BOOL WINAPI GetKeyboardState(_Out_ PBYTE lpKeyState);
		[DllImport("user32.dll", ExactSpelling = true)]
		static extern bool GetKeyboardState(byte[] keyStates);

		// int WINAPI GetKeyboardLayoutList(_In_ int nBuff, _Out_ HKL *lpList);
		[DllImport("user32.dll")]
		static extern uint GetKeyboardLayoutList(int bufferLength, [Out] IntPtr[] lpList);

		// int WINAPI ToUnicodeEx(_In_ UINT wVirtKey, _In_ UINT wScanCode, _In_ const BYTE *lpKeyState, _Out_ LPWSTR pwszBuff, _In_ int cchBuff, _In_ UINT wFlags, _In_opt_ HKL dwhkl);
		[DllImport("user32.dll", CharSet = CharSet.Unicode)]
		static extern int ToUnicodeEx(
			uint virtKey,
			uint scancode,
			byte[] keyState,
			[Out] StringBuilder outString,
			int outStringMaxLength,
			uint flags,
			uint layoutId);

		[DllImport("user32.dll", ExactSpelling = true)]
		static extern uint GetKeyboardLayout(uint threadId);

		// HWND WINAPI GetForegroundWindow(void);
		[DllImport("user32.dll")]
		static extern IntPtr GetForegroundWindow();

		// DWORD WINAPI GetWindowThreadProcessId(_In_ HWND hWnd, _Out_opt_ LPDWORD lpdwProcessId);
		[DllImport("user32.dll")]
		static extern uint GetWindowThreadProcessId(IntPtr windowHandler, IntPtr outProcessId = default(IntPtr));

		// BOOL WINAPI PostMessage(_In_opt_ HWND hWnd, _In_ UINT Msg, _In_ WPARAM wParam, _In_ LPARAM lParam);
		[DllImport("user32.dll")]
		static extern bool PostMessage(IntPtr windowHandler, uint message, IntPtr wParam, IntPtr lParam);

		#endregion
	}
}
