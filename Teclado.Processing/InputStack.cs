using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teclado.Common;
using Teclado.Processing.InputEvents;
using Teclado.WinApi;

namespace Teclado.Processing
{
	public class InputStack
	{
		public void Enqueue(InputEvent inputEvent)
		{
			_inputEvents.AddLast(inputEvent);
		}

		LinkedList<InputEvent> _inputEvents = new LinkedList<InputEvent>();

		string _text = "";

		//public const int MaxLength = 1024;
	}
}
