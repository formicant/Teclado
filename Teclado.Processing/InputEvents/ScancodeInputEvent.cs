using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teclado.Common;
using Teclado.WinApi;

namespace Teclado.Processing.InputEvents
{
	class ScancodeInputEvent : InputEvent
	{
		public ScancodeInputEvent(KeyState keyState, Layout layout, bool down, Scancode scancode, VirtKey virtKey = default(VirtKey))
			: base(keyState, layout)
		{
			Down = down;
			Scancode = scancode;
			VirtKey = virtKey;
		}

		public bool Down { get; private set; }
		public Scancode Scancode { get; private set; }
		public VirtKey VirtKey { get; private set; }

		public override InputEvent ChangeLayout(Layout layout)
		{
			return new ScancodeInputEvent(KeyState, layout, Down, Scancode, VirtKey /* Consider to use VirtKey.None here! */);
		}

		public override void Send()
		{
			Sending.SendScancode(Down, Scancode, VirtKey);
		}
	}
}
