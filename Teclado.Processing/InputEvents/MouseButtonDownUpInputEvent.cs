using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teclado.Common;
using Teclado.WinApi;

namespace Teclado.Processing.InputEvents
{
	class MouseButtonDownUpInputEvent : InputEvent
	{
		public MouseButtonDownUpInputEvent(KeyState keyState, Layout layout, MouseButton mouseButton)
			: base(keyState, layout)
		{
			MouseButton = mouseButton;
		}

		public MouseButton MouseButton { get; private set; }

		public override InputEvent ChangeLayout(Layout layout)
		{
			return new MouseButtonDownUpInputEvent(KeyState, layout, MouseButton);
		}

		public override void Send()
		{
			Sending.SendMouseButtonDownUp(MouseButton);
		}
	}
}
