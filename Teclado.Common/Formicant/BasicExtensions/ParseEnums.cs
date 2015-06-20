using System;

namespace Formicant
{
	public static class ParseEnums
	{
		public static T ParseEnum<T>(this string str, bool caseSensitive = false)
			where T : struct
		{
			return (T)Enum.Parse(typeof(T), str, !caseSensitive);
		}

		public static T ParseEnum<T>(this string str, T defaultValue, bool caseSensitive = false)
			where T : struct
		{
			T val;
			return Enum.TryParse(str, !caseSensitive, out val) ? val : defaultValue;
		}

		public static T? ParseNullableEnum<T>(this string str, bool caseSensitive = false)
			where T : struct
		{
			T val;
			return Enum.TryParse(str, !caseSensitive, out val) ? (T?)val : null;
		}
	}
}
