using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Teclado.Common
{
	public class KeyState
	{
		public KeyState(byte[] array = null)
		{
			Array = array ?? new byte[256];
		}

		public bool this[Scancode scancode] => Array[scancode.Code] != 0;

		public byte[] Array { get; }
	}
}
