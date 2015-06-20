using System;

namespace Formicant
{
	public static partial class Number
	{
		public static bool IsBetweenUnstrict<T>(this T value, T lowest, T highest)
			where T : IComparable<T>
		{
			return value.CompareTo(lowest) >= 0 && value.CompareTo(highest) <= 0;
		}

		public static bool IsBetweenStrict<T>(this T value, T lowest, T highest)
			where T : IComparable<T>
		{
			return value.CompareTo(lowest) > 0 && value.CompareTo(highest) < 0;
		}

		public static bool IsBetweenRightStrict<T>(this T value, T lowest, T highest)
			where T : IComparable<T>
		{
			return value.CompareTo(lowest) >= 0 && value.CompareTo(highest) < 0;
		}

		public static bool IsBetweenLeftStrict<T>(this T value, T lowest, T highest)
			where T : IComparable<T>
		{
			return value.CompareTo(lowest) > 0 && value.CompareTo(highest) <= 0;
		}
	}
}
