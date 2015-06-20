using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teclado.Common;
using Teclado.Processing.InputEvents;
using Teclado.WinApi;

namespace Teclado.Processing
{
	class VirtualInputProcessing
	{
		public bool Process(InputEvent inputEvent)
		{
			_inputStack.Enqueue(inputEvent);
			return true;
		}

		InputStack _inputStack = new InputStack();
	}
}
