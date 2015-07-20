using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teclado.Common;
using Teclado.WinApi;

namespace Teclado.Processing.InputEvents
{
	class ScancodeDownUpInputEvent : InputEvent
	{
		public ScancodeDownUpInputEvent(KeyState keyState, Layout layout, Scancode scancode, VirtKey virtKey = default(VirtKey))
			: base(keyState, layout)
		{
			Scancode = scancode;
			VirtKey = virtKey;
		}

		public Scancode Scancode { get; }
		public VirtKey VirtKey { get; }

		public override InputEvent ChangeLayout(Layout layout) =>
			new ScancodeDownUpInputEvent(KeyState, layout, Scancode, VirtKey /* Consider using VirtKey.None here! */);

		public override void Send()
		{
			Sending.SendScancodeDownUp(Scancode, VirtKey);
		}
	}
}
