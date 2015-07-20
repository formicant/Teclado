using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Teclado.Common;
using Teclado.Processing.InputEvents;
using Teclado.WinApi;

namespace Teclado.Processing
{
	public class ActualInputProcessing
	{
		public bool LowLevelKeyboardHookEvent(bool down, Scancode scancode, VirtKey virtKey) =>
			_virtualInputProcessing.Process(
				new ScancodeInputEvent(Layouts.GetKeyState(), Layouts.GetCurrentLayout(), down, scancode, virtKey));

		public bool LowLevelMouseHookEvent(bool? down, MouseButton mouseButton, int wheelAmount, Point point) =>
			(!down.HasValue || _virtualInputProcessing.Process(
				new MouseButtonInputEvent(Layouts.GetKeyState(), Layouts.GetCurrentLayout(), down.Value, mouseButton))) &&
			(wheelAmount == 0 || _virtualInputProcessing.Process(
				new MouseWheelInputEvent(Layouts.GetKeyState(), Layouts.GetCurrentLayout(), wheelAmount)));

		VirtualInputProcessing _virtualInputProcessing = new VirtualInputProcessing();
	}
}
