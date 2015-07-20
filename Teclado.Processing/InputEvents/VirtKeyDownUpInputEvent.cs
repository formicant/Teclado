using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teclado.Common;
using Teclado.WinApi;

namespace Teclado.Processing.InputEvents
{
	class VirtKeyDownUpInputEvent : InputEvent
	{
		public VirtKeyDownUpInputEvent(KeyState keyState, Layout layout, VirtKey virtKey)
			: base(keyState, layout)
		{
			VirtKey = virtKey;
		}

		public VirtKey VirtKey { get; }

		public override InputEvent ChangeLayout(Layout layout) =>
			new VirtKeyDownUpInputEvent(KeyState, layout, VirtKey);

		public override void Send()
		{
			Sending.SendVirtKeyDownUp(VirtKey);
		}
	}
}
