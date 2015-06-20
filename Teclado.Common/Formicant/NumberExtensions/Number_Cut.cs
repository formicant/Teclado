
namespace Formicant
{
	public static partial class Number
	{
		public static byte CutBot(this byte value, byte bottom)
		{
			return value > bottom ? value : bottom;
		}

		public static byte CutTop(this byte value, byte top)
		{
			return value < top ? value : top;
		}

		public static byte Cut(this byte value, byte bottom, byte top)
		{
			return value > bottom ? value < top ? value : top : bottom;
		}

		public static ushort CutBot(this ushort value, ushort bottom)
		{
			return value > bottom ? value : bottom;
		}

		public static ushort CutTop(this ushort value, ushort top)
		{
			return value < top ? value : top;
		}

		public static ushort Cut(this ushort value, ushort bottom, ushort top)
		{
			return value > bottom ? value < top ? value : top : bottom;
		}

		public static uint CutBot(this uint value, uint bottom)
		{
			return value > bottom ? value : bottom;
		}

		public static uint CutTop(this uint value, uint top)
		{
			return value < top ? value : top;
		}

		public static uint Cut(this uint value, uint bottom, uint top)
		{
			return value > bottom ? value < top ? value : top : bottom;
		}

		public static ulong CutBot(this ulong value, ulong bottom)
		{
			return value > bottom ? value : bottom;
		}

		public static ulong CutTop(this ulong value, ulong top)
		{
			return value < top ? value : top;
		}

		public static ulong Cut(this ulong value, ulong bottom, ulong top)
		{
			return value > bottom ? value < top ? value : top : bottom;
		}

		public static sbyte CutBot(this sbyte value, sbyte bottom)
		{
			return value > bottom ? value : bottom;
		}

		public static sbyte CutTop(this sbyte value, sbyte top)
		{
			return value < top ? value : top;
		}

		public static sbyte Cut(this sbyte value, sbyte bottom, sbyte top)
		{
			return value > bottom ? value < top ? value : top : bottom;
		}

		public static short CutBot(this short value, short bottom)
		{
			return value > bottom ? value : bottom;
		}

		public static short CutTop(this short value, short top)
		{
			return value < top ? value : top;
		}

		public static short Cut(this short value, short bottom, short top)
		{
			return value > bottom ? value < top ? value : top : bottom;
		}

		public static int CutBot(this int value, int bottom)
		{
			return value > bottom ? value : bottom;
		}

		public static int CutTop(this int value, int top)
		{
			return value < top ? value : top;
		}

		public static int Cut(this int value, int bottom, int top)
		{
			return value > bottom ? value < top ? value : top : bottom;
		}

		public static long CutBot(this long value, long bottom)
		{
			return value > bottom ? value : bottom;
		}

		public static long CutTop(this long value, long top)
		{
			return value < top ? value : top;
		}

		public static long Cut(this long value, long bottom, long top)
		{
			return value > bottom ? value < top ? value : top : bottom;
		}

		public static float CutBot(this float value, float bottom)
		{
			return value > bottom ? value : bottom;
		}

		public static float CutTop(this float value, float top)
		{
			return value < top ? value : top;
		}

		public static float Cut(this float value, float bottom, float top)
		{
			return value > bottom ? value < top ? value : top : bottom;
		}

		public static double CutBot(this double value, double bottom)
		{
			return value > bottom ? value : bottom;
		}

		public static double CutTop(this double value, double top)
		{
			return value < top ? value : top;
		}

		public static double Cut(this double value, double bottom, double top)
		{
			return value > bottom ? value < top ? value : top : bottom;
		}

		public static decimal CutBot(this decimal value, decimal bottom)
		{
			return value > bottom ? value : bottom;
		}

		public static decimal CutTop(this decimal value, decimal top)
		{
			return value < top ? value : top;
		}

		public static decimal Cut(this decimal value, decimal bottom, decimal top)
		{
			return value > bottom ? value < top ? value : top : bottom;
		}

	}
}