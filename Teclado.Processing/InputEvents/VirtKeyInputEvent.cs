using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teclado.Common;
using Teclado.WinApi;

namespace Teclado.Processing.InputEvents
{
	class VirtKeyInputEvent : InputEvent
	{
		public VirtKeyInputEvent(KeyState keyState, Layout layout, bool down, VirtKey virtKey)
			: base(keyState, layout)
		{
			Down = down;
			VirtKey = virtKey;
		}

		public bool Down { get; }
		public VirtKey VirtKey { get; }

		public override InputEvent ChangeLayout(Layout layout) =>
			new VirtKeyInputEvent(KeyState, layout, Down, VirtKey);

		public override void Send()
		{
			Sending.SendVirtKey(Down, VirtKey);
		}
	}
}
