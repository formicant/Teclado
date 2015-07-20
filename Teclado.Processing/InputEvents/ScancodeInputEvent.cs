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

		public bool Down { get; }
		public Scancode Scancode { get; }
		public VirtKey VirtKey { get; }

		public override InputEvent ChangeLayout(Layout layout) =>
			new ScancodeInputEvent(KeyState, layout, Down, Scancode, VirtKey /* Consider using VirtKey.None here! */);

		public override void Send()
		{
			Sending.SendScancode(Down, Scancode, VirtKey);
		}
	}
}
