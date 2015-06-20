using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teclado.Common;

namespace Teclado.Processing.InputEvents
{
	public abstract class InputEvent
	{
		public InputEvent(KeyState keyState, Layout layout)
		{
			KeyState = keyState;
			Layout = layout;
		}

		public KeyState KeyState { get; private set; }
		public Layout Layout { get; private set; }

		public abstract InputEvent ChangeLayout(Layout layout);

		abstract public void Send();
	}
}
