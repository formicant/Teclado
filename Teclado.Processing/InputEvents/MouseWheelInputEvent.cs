using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teclado.Common;
using Teclado.WinApi;

namespace Teclado.Processing.InputEvents
{
	class MouseWheelInputEvent : InputEvent
	{
		public MouseWheelInputEvent(KeyState keyState, Layout layout, int wheelAmount)
			: base(keyState, layout)
		{
			WheelAmount = wheelAmount;
		}

		public int WheelAmount { get; }

		public override InputEvent ChangeLayout(Layout layout) =>
			new MouseWheelInputEvent(KeyState, layout, WheelAmount);

		public override void Send()
		{
			Sending.SendMouseWheel(WheelAmount);
		}
	}
}
