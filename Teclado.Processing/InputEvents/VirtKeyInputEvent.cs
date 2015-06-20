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

		public bool Down { get; private set; }
		public VirtKey VirtKey { get; private set; }

		public override InputEvent ChangeLayout(Layout layout)
		{
			return new VirtKeyInputEvent(KeyState, layout, Down, VirtKey);
		}

		public override void Send()
		{
			Sending.SendVirtKey(Down, VirtKey);
		}
	}
}
