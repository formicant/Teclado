using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teclado.Common;
using Teclado.WinApi;

namespace Teclado.Processing.InputEvents
{
	class MouseButtonInputEvent : InputEvent
	{
		public MouseButtonInputEvent(KeyState keyState, Layout layout, bool down, MouseButton mouseButton)
			: base(keyState, layout)
		{
			Down = down;
			MouseButton = mouseButton;
		}

		public bool Down { get; private set; }
		public MouseButton MouseButton { get; private set; }

		public override InputEvent ChangeLayout(Layout layout)
		{
			return new MouseButtonInputEvent(KeyState, layout, Down, MouseButton);
		}

		public override void Send()
		{
			Sending.SendMouseButton(Down, MouseButton);
		}
	}
}
