
using System.Globalization;

namespace Formicant
{
	public static partial class BasicExtensions
	{
		public static byte ParseByte(this string str)
		{
			return byte.Parse(str, NumberStyles.Integer, CultureInfo.InvariantCulture);
		}

		public static byte ParseByte(this string str, byte defaultValue)
		{
			byte val;
			return byte.TryParse(str, NumberStyles.Integer, CultureInfo.InvariantCulture, out val) ? val : defaultValue;
		}

		public static byte? ParseNullableByte(this string str)
		{
			byte val;
			return byte.TryParse(str, NumberStyles.Integer, CultureInfo.InvariantCulture, out val) ? (byte?)val : null;
		}

		public static byte ParseHexByte(this string str)
		{
			return byte.Parse(str, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
		}

		public static byte ParseHexByte(this string str, byte defaultValue)
		{
			byte val;
			return byte.TryParse(str, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out val) ? val : defaultValue;
		}

		public static byte? ParseNullableHexByte(this string str)
		{
			byte val;
			return byte.TryParse(str, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out val) ? (byte?)val : null;
		}

		public static ushort ParseUshort(this string str)
		{
			return ushort.Parse(str, NumberStyles.Integer, CultureInfo.InvariantCulture);
		}

		public static ushort ParseUshort(this string str, ushort defaultValue)
		{
			ushort val;
			return ushort.TryParse(str, NumberStyles.Integer, CultureInfo.InvariantCulture, out val) ? val : defaultValue;
		}

		public static ushort? ParseNullableUshort(this string str)
		{
			ushort val;
			return ushort.TryParse(str, NumberStyles.Integer, CultureInfo.InvariantCulture, out val) ? (ushort?)val : null;
		}

		public static ushort ParseHexUshort(this string str)
		{
			return ushort.Parse(str, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
		}

		public static ushort ParseHexUshort(this string str, ushort defaultValue)
		{
			ushort val;
			return ushort.TryParse(str, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out val) ? val : defaultValue;
		}

		public static ushort? ParseNullableHexUshort(this string str)
		{
			ushort val;
			return ushort.TryParse(str, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out val) ? (ushort?)val : null;
		}

		public static uint ParseUint(this string str)
		{
			return uint.Parse(str, NumberStyles.Integer, CultureInfo.InvariantCulture);
		}

		public static uint ParseUint(this string str, uint defaultValue)
		{
			uint val;
			return uint.TryParse(str, NumberStyles.Integer, CultureInfo.InvariantCulture, out val) ? val : defaultValue;
		}

		public static uint? ParseNullableUint(this string str)
		{
			uint val;
			return uint.TryParse(str, NumberStyles.Integer, CultureInfo.InvariantCulture, out val) ? (uint?)val : null;
		}

		public static uint ParseHexUint(this string str)
		{
			return uint.Parse(str, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
		}

		public static uint ParseHexUint(this string str, uint defaultValue)
		{
			uint val;
			return uint.TryParse(str, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out val) ? val : defaultValue;
		}

		public static uint? ParseNullableHexUint(this string str)
		{
			uint val;
			return uint.TryParse(str, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out val) ? (uint?)val : null;
		}

		public static ulong ParseUlong(this string str)
		{
			return ulong.Parse(str, NumberStyles.Integer, CultureInfo.InvariantCulture);
		}

		public static ulong ParseUlong(this string str, ulong defaultValue)
		{
			ulong val;
			return ulong.TryParse(str, NumberStyles.Integer, CultureInfo.InvariantCulture, out val) ? val : defaultValue;
		}

		public static ulong? ParseNullableUlong(this string str)
		{
			ulong val;
			return ulong.TryParse(str, NumberStyles.Integer, CultureInfo.InvariantCulture, out val) ? (ulong?)val : null;
		}

		public static ulong ParseHexUlong(this string str)
		{
			return ulong.Parse(str, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
		}

		public static ulong ParseHexUlong(this string str, ulong defaultValue)
		{
			ulong val;
			return ulong.TryParse(str, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out val) ? val : defaultValue;
		}

		public static ulong? ParseNullableHexUlong(this string str)
		{
			ulong val;
			return ulong.TryParse(str, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out val) ? (ulong?)val : null;
		}

		public static sbyte ParseSbyte(this string str)
		{
			return sbyte.Parse(str, NumberStyles.Integer, CultureInfo.InvariantCulture);
		}

		public static sbyte ParseSbyte(this string str, sbyte defaultValue)
		{
			sbyte val;
			return sbyte.TryParse(str, NumberStyles.Integer, CultureInfo.InvariantCulture, out val) ? val : defaultValue;
		}

		public static sbyte? ParseNullableSbyte(this string str)
		{
			sbyte val;
			return sbyte.TryParse(str, NumberStyles.Integer, CultureInfo.InvariantCulture, out val) ? (sbyte?)val : null;
		}

		public static sbyte ParseHexSbyte(this string str)
		{
			return sbyte.Parse(str, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
		}

		public static sbyte ParseHexSbyte(this string str, sbyte defaultValue)
		{
			sbyte val;
			return sbyte.TryParse(str, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out val) ? val : defaultValue;
		}

		public static sbyte? ParseNullableHexSbyte(this string str)
		{
			sbyte val;
			return sbyte.TryParse(str, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out val) ? (sbyte?)val : null;
		}

		public static short ParseShort(this string str)
		{
			return short.Parse(str, NumberStyles.Integer, CultureInfo.InvariantCulture);
		}

		public static short ParseShort(this string str, short defaultValue)
		{
			short val;
			return short.TryParse(str, NumberStyles.Integer, CultureInfo.InvariantCulture, out val) ? val : defaultValue;
		}

		public static short? ParseNullableShort(this string str)
		{
			short val;
			return short.TryParse(str, NumberStyles.Integer, CultureInfo.InvariantCulture, out val) ? (short?)val : null;
		}

		public static short ParseHexShort(this string str)
		{
			return short.Parse(str, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
		}

		public static short ParseHexShort(this string str, short defaultValue)
		{
			short val;
			return short.TryParse(str, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out val) ? val : defaultValue;
		}

		public static short? ParseNullableHexShort(this string str)
		{
			short val;
			return short.TryParse(str, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out val) ? (short?)val : null;
		}

		public static int ParseInt(this string str)
		{
			return int.Parse(str, NumberStyles.Integer, CultureInfo.InvariantCulture);
		}

		public static int ParseInt(this string str, int defaultValue)
		{
			int val;
			return int.TryParse(str, NumberStyles.Integer, CultureInfo.InvariantCulture, out val) ? val : defaultValue;
		}

		public static int? ParseNullableInt(this string str)
		{
			int val;
			return int.TryParse(str, NumberStyles.Integer, CultureInfo.InvariantCulture, out val) ? (int?)val : null;
		}

		public static int ParseHexInt(this string str)
		{
			return int.Parse(str, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
		}

		public static int ParseHexInt(this string str, int defaultValue)
		{
			int val;
			return int.TryParse(str, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out val) ? val : defaultValue;
		}

		public static int? ParseNullableHexInt(this string str)
		{
			int val;
			return int.TryParse(str, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out val) ? (int?)val : null;
		}

		public static long ParseLong(this string str)
		{
			return long.Parse(str, NumberStyles.Integer, CultureInfo.InvariantCulture);
		}

		public static long ParseLong(this string str, long defaultValue)
		{
			long val;
			return long.TryParse(str, NumberStyles.Integer, CultureInfo.InvariantCulture, out val) ? val : defaultValue;
		}

		public static long? ParseNullableLong(this string str)
		{
			long val;
			return long.TryParse(str, NumberStyles.Integer, CultureInfo.InvariantCulture, out val) ? (long?)val : null;
		}

		public static long ParseHexLong(this string str)
		{
			return long.Parse(str, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
		}

		public static long ParseHexLong(this string str, long defaultValue)
		{
			long val;
			return long.TryParse(str, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out val) ? val : defaultValue;
		}

		public static long? ParseNullableHexLong(this string str)
		{
			long val;
			return long.TryParse(str, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out val) ? (long?)val : null;
		}

		public static float ParseFloat(this string str)
		{
			return float.Parse(str, NumberStyles.Float, CultureInfo.InvariantCulture);
		}

		public static float ParseFloat(this string str, float defaultValue)
		{
			float val;
			return float.TryParse(str, NumberStyles.Float, CultureInfo.InvariantCulture, out val) ? val : defaultValue;
		}

		public static float? ParseNullableFloat(this string str)
		{
			float val;
			return float.TryParse(str, NumberStyles.Float, CultureInfo.InvariantCulture, out val) ? (float?)val : null;
		}

		public static double ParseDouble(this string str)
		{
			return double.Parse(str, NumberStyles.Float, CultureInfo.InvariantCulture);
		}

		public static double ParseDouble(this string str, double defaultValue)
		{
			double val;
			return double.TryParse(str, NumberStyles.Float, CultureInfo.InvariantCulture, out val) ? val : defaultValue;
		}

		public static double? ParseNullableDouble(this string str)
		{
			double val;
			return double.TryParse(str, NumberStyles.Float, CultureInfo.InvariantCulture, out val) ? (double?)val : null;
		}

		public static decimal ParseDecimal(this string str)
		{
			return decimal.Parse(str, NumberStyles.Float, CultureInfo.InvariantCulture);
		}

		public static decimal ParseDecimal(this string str, decimal defaultValue)
		{
			decimal val;
			return decimal.TryParse(str, NumberStyles.Float, CultureInfo.InvariantCulture, out val) ? val : defaultValue;
		}

		public static decimal? ParseNullableDecimal(this string str)
		{
			decimal val;
			return decimal.TryParse(str, NumberStyles.Float, CultureInfo.InvariantCulture, out val) ? (decimal?)val : null;
		}

		public static bool ParseBool(this string str)
		{
			return bool.Parse(str);
		}

		public static bool ParseBool(this string str, bool defaultValue)
		{
			bool val;
			return bool.TryParse(str, out val) ? val : defaultValue;
		}

		public static bool? ParseNullableBool(this string str)
		{
			bool val;
			return bool.TryParse(str, out val) ? (bool?)val : null;
		}
	}
}