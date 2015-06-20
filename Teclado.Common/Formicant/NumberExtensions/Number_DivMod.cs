
namespace Formicant
{
	public static partial class Number
	{
		public static byte Div(this byte a, byte b)
		{
			return (byte)(a / b);
		}

		public static byte Mod(this byte a, byte b)
		{
			return (byte)(a % b);
		}

		public static ushort Div(this ushort a, byte b)
		{
			return (ushort)(a / b);
		}

		public static byte Mod(this ushort a, byte b)
		{
			return (byte)(a % b);
		}

		public static ushort Div(this ushort a, ushort b)
		{
			return (ushort)(a / b);
		}

		public static ushort Mod(this ushort a, ushort b)
		{
			return (ushort)(a % b);
		}

		public static uint Div(this uint a, byte b)
		{
			return (uint)(a / b);
		}

		public static byte Mod(this uint a, byte b)
		{
			return (byte)(a % b);
		}

		public static uint Div(this uint a, ushort b)
		{
			return (uint)(a / b);
		}

		public static ushort Mod(this uint a, ushort b)
		{
			return (ushort)(a % b);
		}

		public static uint Div(this uint a, uint b)
		{
			return (uint)(a / b);
		}

		public static uint Mod(this uint a, uint b)
		{
			return (uint)(a % b);
		}

		public static ulong Div(this ulong a, byte b)
		{
			return (ulong)(a / b);
		}

		public static byte Mod(this ulong a, byte b)
		{
			return (byte)(a % b);
		}

		public static ulong Div(this ulong a, ushort b)
		{
			return (ulong)(a / b);
		}

		public static ushort Mod(this ulong a, ushort b)
		{
			return (ushort)(a % b);
		}

		public static ulong Div(this ulong a, uint b)
		{
			return (ulong)(a / b);
		}

		public static uint Mod(this ulong a, uint b)
		{
			return (uint)(a % b);
		}

		public static ulong Div(this ulong a, ulong b)
		{
			return (ulong)(a / b);
		}

		public static ulong Mod(this ulong a, ulong b)
		{
			return (ulong)(a % b);
		}

		public static short Div(this short a, byte b)
		{
			return (short)(a >= 0
				? a / b
				: (a + 1) / b - 1);
		}

		public static byte Mod(this short 
		a, byte b)
		{
			return (byte)(a >= 0
				? a % b
				: (a + 1) % b - 1 + b);
		}

		public static int Div(this int a, byte b)
		{
			return (int)(a >= 0
				? a / b
				: (a + 1) / b - 1);
		}

		public static byte Mod(this int 
		a, byte b)
		{
			return (byte)(a >= 0
				? a % b
				: (a + 1) % b - 1 + b);
		}

		public static int Div(this int a, ushort b)
		{
			return (int)(a >= 0
				? a / b
				: (a + 1) / b - 1);
		}

		public static ushort Mod(this int 
		a, ushort b)
		{
			return (ushort)(a >= 0
				? a % b
				: (a + 1) % b - 1 + b);
		}

		public static long Div(this long a, byte b)
		{
			return (long)(a >= 0
				? a / b
				: (a + 1) / b - 1);
		}

		public static byte Mod(this long 
		a, byte b)
		{
			return (byte)(a >= 0
				? a % b
				: (a + 1) % b - 1 + b);
		}

		public static long Div(this long a, ushort b)
		{
			return (long)(a >= 0
				? a / b
				: (a + 1) / b - 1);
		}

		public static ushort Mod(this long 
		a, ushort b)
		{
			return (ushort)(a >= 0
				? a % b
				: (a + 1) % b - 1 + b);
		}

		public static long Div(this long a, uint b)
		{
			return (long)(a >= 0
				? a / b
				: (a + 1) / b - 1);
		}

		public static uint Mod(this long 
		a, uint b)
		{
			return (uint)(a >= 0
				? a % b
				: (a + 1) % b - 1 + b);
		}

		public static sbyte Div(this sbyte a, sbyte b)
		{
			return (sbyte)(b < 0
				? a > 0
					? (a - 1) / b - 1
					: a / b
				: a < 0
					? (a + 1) / b - 1
					: a / b);
		}

		public static sbyte Mod(this sbyte a, sbyte b)
		{
			return (sbyte)(b < 0
				? a > 0
					? (a - 1) % b + 1 + b
					: a % b
				: a < 0
					? (a + 1) % b - 1 + b
					: a % b);
		}

		public static short Div(this short a, sbyte b)
		{
			return (short)(b < 0
				? a > 0
					? (a - 1) / b - 1
					: a / b
				: a < 0
					? (a + 1) / b - 1
					: a / b);
		}

		public static sbyte Mod(this short a, sbyte b)
		{
			return (sbyte)(b < 0
				? a > 0
					? (a - 1) % b + 1 + b
					: a % b
				: a < 0
					? (a + 1) % b - 1 + b
					: a % b);
		}

		public static short Div(this short a, short b)
		{
			return (short)(b < 0
				? a > 0
					? (a - 1) / b - 1
					: a / b
				: a < 0
					? (a + 1) / b - 1
					: a / b);
		}

		public static short Mod(this short a, short b)
		{
			return (short)(b < 0
				? a > 0
					? (a - 1) % b + 1 + b
					: a % b
				: a < 0
					? (a + 1) % b - 1 + b
					: a % b);
		}

		public static int Div(this int a, sbyte b)
		{
			return (int)(b < 0
				? a > 0
					? (a - 1) / b - 1
					: a / b
				: a < 0
					? (a + 1) / b - 1
					: a / b);
		}

		public static sbyte Mod(this int a, sbyte b)
		{
			return (sbyte)(b < 0
				? a > 0
					? (a - 1) % b + 1 + b
					: a % b
				: a < 0
					? (a + 1) % b - 1 + b
					: a % b);
		}

		public static int Div(this int a, short b)
		{
			return (int)(b < 0
				? a > 0
					? (a - 1) / b - 1
					: a / b
				: a < 0
					? (a + 1) / b - 1
					: a / b);
		}

		public static short Mod(this int a, short b)
		{
			return (short)(b < 0
				? a > 0
					? (a - 1) % b + 1 + b
					: a % b
				: a < 0
					? (a + 1) % b - 1 + b
					: a % b);
		}

		public static int Div(this int a, int b)
		{
			return (int)(b < 0
				? a > 0
					? (a - 1) / b - 1
					: a / b
				: a < 0
					? (a + 1) / b - 1
					: a / b);
		}

		public static int Mod(this int a, int b)
		{
			return (int)(b < 0
				? a > 0
					? (a - 1) % b + 1 + b
					: a % b
				: a < 0
					? (a + 1) % b - 1 + b
					: a % b);
		}

		public static long Div(this long a, sbyte b)
		{
			return (long)(b < 0
				? a > 0
					? (a - 1) / b - 1
					: a / b
				: a < 0
					? (a + 1) / b - 1
					: a / b);
		}

		public static sbyte Mod(this long a, sbyte b)
		{
			return (sbyte)(b < 0
				? a > 0
					? (a - 1) % b + 1 + b
					: a % b
				: a < 0
					? (a + 1) % b - 1 + b
					: a % b);
		}

		public static long Div(this long a, short b)
		{
			return (long)(b < 0
				? a > 0
					? (a - 1) / b - 1
					: a / b
				: a < 0
					? (a + 1) / b - 1
					: a / b);
		}

		public static short Mod(this long a, short b)
		{
			return (short)(b < 0
				? a > 0
					? (a - 1) % b + 1 + b
					: a % b
				: a < 0
					? (a + 1) % b - 1 + b
					: a % b);
		}

		public static long Div(this long a, int b)
		{
			return (long)(b < 0
				? a > 0
					? (a - 1) / b - 1
					: a / b
				: a < 0
					? (a + 1) / b - 1
					: a / b);
		}

		public static int Mod(this long a, int b)
		{
			return (int)(b < 0
				? a > 0
					? (a - 1) % b + 1 + b
					: a % b
				: a < 0
					? (a + 1) % b - 1 + b
					: a % b);
		}

		public static long Div(this long a, long b)
		{
			return (long)(b < 0
				? a > 0
					? (a - 1) / b - 1
					: a / b
				: a < 0
					? (a + 1) / b - 1
					: a / b);
		}

		public static long Mod(this long a, long b)
		{
			return (long)(b < 0
				? a > 0
					? (a - 1) % b + 1 + b
					: a % b
				: a < 0
					? (a + 1) % b - 1 + b
					: a % b);
		}

	}
}