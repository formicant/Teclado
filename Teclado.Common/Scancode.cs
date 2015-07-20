using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Formicant;

namespace Teclado.Common
{
	public struct Scancode : IEquatable<Scancode>
	{
		public Scancode(byte code) : this()
		{
			Code = code;
		}

		public Scancode(string name) : this()
		{
			Code = ByName.GetValueOrDefault(name.ToLowerInvariant());
		}

		public byte Code { get; }

		public bool IsNotNone => Code != 0;

		public bool IsNone => Code == 0;

		public string Name =>
			Names.GetValueOrDefault(Code)?[0] ?? $"K{Code:X2}";

		public static readonly Scancode None = default(Scancode);

		#region Equality

		public bool Equals(Scancode other) =>
			Code.Equals(other.Code);

		public override bool Equals(object obj) =>
			obj is Scancode && Equals((Scancode)obj);

		public override int GetHashCode() =>
			Code.GetHashCode();

		public static bool operator ==(Scancode sc1, Scancode sc2) =>
			sc1.Equals(sc2);

		public static bool operator !=(Scancode sc1, Scancode sc2) =>
			!sc1.Equals(sc2);

		#endregion

		public override string ToString() => Name;

		internal static readonly Dictionary<byte, string[]> Names = new Dictionary<byte, string[]>
		{
			#region Scancode names
			[0x01] = new[] { "Esc", "Escape" },
			[0x3B] = new[] { "F1" },
			[0x3C] = new[] { "F2" },
			[0x3D] = new[] { "F3" },
			[0x3E] = new[] { "F4" },
			[0x3F] = new[] { "F5" },
			[0x40] = new[] { "F6" },
			[0x41] = new[] { "F7" },
			[0x42] = new[] { "F8" },
			[0x43] = new[] { "F9" },
			[0x44] = new[] { "F10" },
			[0x57] = new[] { "F11" },
			[0x58] = new[] { "F12" },
			[0x29] = new[] { "Grave", "Backtick" },
			[0x02] = new[] { "D1", "Digit1", "One" },
			[0x03] = new[] { "D2", "Digit2", "Two" },
			[0x04] = new[] { "D3", "Digit3", "Three" },
			[0x05] = new[] { "D4", "Digit4", "Four" },
			[0x06] = new[] { "D5", "Digit5", "Five" },
			[0x07] = new[] { "D6", "Digit6", "Six" },
			[0x08] = new[] { "D7", "Digit7", "Seven" },
			[0x09] = new[] { "D8", "Digit8", "Eight" },
			[0x0A] = new[] { "D9", "Digit9", "Nine" },
			[0x0B] = new[] { "D0", "Digit0", "Zero" },
			[0x0C] = new[] { "Minus", "Hyphen" },
			[0x0D] = new[] { "Equals", "Plus" },
			[0x0E] = new[] { "BackSp", "BackSpace", "BkSpace", "BkSp" },
			[0x0F] = new[] { "Tab" },
			[0x10] = new[] { "Q" },
			[0x11] = new[] { "W" },
			[0x12] = new[] { "E" },
			[0x13] = new[] { "R" },
			[0x14] = new[] { "T" },
			[0x15] = new[] { "Y" },
			[0x16] = new[] { "U" },
			[0x17] = new[] { "I" },
			[0x18] = new[] { "O" },
			[0x19] = new[] { "P" },
			[0x1A] = new[] { "LBrk", "LeftBracket", "LBracket", "LeftBrk" },
			[0x1B] = new[] { "RBrk", "RightBracket", "RBracket", "RightBrk" },
			[0x2B] = new[] { "BSlash", "Backslash" },
			[0x3A] = new[] { "Caps", "CapsLock" },
			[0x1E] = new[] { "A" },
			[0x1F] = new[] { "S" },
			[0x20] = new[] { "D" },
			[0x21] = new[] { "F" },
			[0x22] = new[] { "G" },
			[0x23] = new[] { "H" },
			[0x24] = new[] { "J" },
			[0x25] = new[] { "K" },
			[0x26] = new[] { "L" },
			[0x27] = new[] { "Colon", "Semicolon" },
			[0x28] = new[] { "Quote", "Apostrophe" },
			[0x1C] = new[] { "Enter", "Ent" },
			[0x2A] = new[] { "LShift", "LeftShift" },
			[0x56] = new[] { "Oem102", "Key102" },
			[0x2C] = new[] { "Z" },
			[0x2D] = new[] { "X" },
			[0x2E] = new[] { "C" },
			[0x2F] = new[] { "V" },
			[0x30] = new[] { "B" },
			[0x31] = new[] { "N" },
			[0x32] = new[] { "M" },
			[0x33] = new[] { "Comma" },
			[0x34] = new[] { "Period", "Dot" },
			[0x35] = new[] { "Divide", "Div", "Slash" },
			[0xB6] = new[] { "RShift", "RightShift" },
			[0x1D] = new[] { "LCtrl", "LeftCtrl" },
			[0xDB] = new[] { "LWin", "LeftWin" },
			[0x38] = new[] { "LAlt", "LeftAlt" },
			[0x39] = new[] { "Space" },
			[0xB8] = new[] { "RAlt", "RightAlt" },
			[0xDC] = new[] { "RWin", "RightWin" },
			[0xDD] = new[] { "App", "Application" },
			[0x9D] = new[] { "RCtrl", "RightControl" },
			[0xB7] = new[] { "PrtScr", "PrintScreen", "PrSc", "PrtSc", "PrScr" },
			[0x46] = new[] { "Scroll", "ScrollLock" },
			[0x45] = new[] { "Pause", "Break" },
			[0xD2] = new[] { "Insert" },
			[0xC7] = new[] { "Home" },
			[0xC9] = new[] { "PgUp", "PageUp" },
			[0xD3] = new[] { "Delete", "Del" },
			[0xCF] = new[] { "End" },
			[0xD1] = new[] { "PgDown", "PageDown", "PgDn", "PageDn" },
			[0xC8] = new[] { "Up", "UpArrow" },
			[0xCB] = new[] { "Left", "LeftArrow", "Lf", "Lt" },
			[0xD0] = new[] { "Down", "DownArrow", "Dn" },
			[0xCD] = new[] { "Right", "RightArrow", "Rt" },
			[0xC5] = new[] { "Num", "NumLock" },
			[0xB5] = new[] { "NDiv", "NumDivide", "NumDiv", "NDivide" },
			[0x37] = new[] { "NMult", "NumMultiply", "NumMult", "NMultiply" },
			[0x4A] = new[] { "NMinus", "NumMinus" },
			[0x47] = new[] { "N7", "Num7", "NumSeven", "NSeven" },
			[0x48] = new[] { "N8", "Num8", "NumEight", "NEight" },
			[0x49] = new[] { "N9", "Num9", "NumNine", "NNine" },
			[0x4E] = new[] { "NPlus", "NumPlus" },
			[0x4B] = new[] { "N4", "Num4", "NumFour", "NFour" },
			[0x4C] = new[] { "N5", "Num5", "NumFive", "NFive" },
			[0x4D] = new[] { "N6", "Num6", "NumSix", "NSix" },
			[0x4F] = new[] { "N1", "Num1", "NumOne", "NOne" },
			[0x50] = new[] { "N2", "Num2", "NumTwo", "NTwo" },
			[0x51] = new[] { "N3", "Num3", "NumThree", "NThree" },
			[0x9C] = new[] { "NEnter", "NumEnter", "NumEnt", "NEnt" },
			[0x52] = new[] { "N0", "Num0", "NumZero", "NZero" },
			[0x53] = new[] { "NDot", "NumDot", "NumPeriod", "NPeriod" },
			#endregion
		};

		public static readonly Dictionary<string, byte> ByName =
			Enumerable.Range(0, 0x100)
				.Select(k => new KeyValuePair<byte, string>((byte)k, $"k{k:x2}"))
				.Concat(Names.SelectMany(k => k.Value.Select(name => new KeyValuePair<byte, string>(k.Key, name.ToLowerInvariant()))))
				.ToDictionary(k => k.Value, k => k.Key);
	}
}
