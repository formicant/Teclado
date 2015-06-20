using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Teclado.Common
{
	[Flags]
	public enum MouseButton : uint
	{
		None     = 0x00000000,
		Left     = 0x00100000,
		Right    = 0x00200000,
		Middle   = 0x00400000,
		XButton1 = 0x00800000,
		XButton2 = 0x01000000,
	}
}
