using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Formicant;
using Teclado.WinApi;
using Teclado.Common;

namespace Teclado.Processing.InputEvents
{
	class ScancodeCombinationInputEvent : InputEvent
	{
		public ScancodeCombinationInputEvent(KeyState keyState, Layout layout, IEnumerable<Scancode> scancodes)
			: base(keyState, layout)
		{
			_scancodes = scancodes.ToList();
		}

		public IEnumerable<Scancode> Scancodes => _scancodes;

		readonly List<Scancode> _scancodes;

		public override InputEvent ChangeLayout(Layout layout) =>
			new ScancodeCombinationInputEvent(KeyState, layout, Scancodes);

		public override void Send()
		{
			foreach(var scancode in _scancodes)
				Sending.SendScancode(true, scancode);
			foreach(var scancode in _scancodes.IterateBackwards())
				Sending.SendScancode(false, scancode);
		}
	}
}
