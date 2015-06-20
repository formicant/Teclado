using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teclado.Common;
using Teclado.WinApi;

namespace Teclado.Processing.InputEvents
{
	class BackspaceInputEvent : InputEvent
	{
		public BackspaceInputEvent(KeyState keyState, Layout layout, int count = 1)
			: base(keyState, layout)
		{
			Count = count;
		}

		public int Count { get; private set; }

		public override InputEvent ChangeLayout(Layout layout)
		{
			return new BackspaceInputEvent(KeyState, layout, Count);
		}

		public override void Send()
		{
			for(int i = 0; i < Count; i++)
				Sending.SendVirtKeyDownUp(new VirtKey(0x08));
		}
	}
}
