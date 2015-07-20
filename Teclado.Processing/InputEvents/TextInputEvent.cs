using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teclado.Common;
using Teclado.WinApi;

namespace Teclado.Processing.InputEvents
{
	class TextInputEvent : InputEvent
	{
		public TextInputEvent(KeyState keyState, Layout layout, string text)
			: base(keyState, layout)
		{
			Text = text;
		}

		public string Text { get; }

		public override InputEvent ChangeLayout(Layout layout) =>
			new TextInputEvent(KeyState, layout, Text);

		public override void Send()
		{
			Sending.SendString(Text);
		}
	}
}
