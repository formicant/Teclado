using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Formicant
{
	public static partial class StringOperationExtensions
	{
		public static string ToTitleCase(this string str)
		{
			return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str);
		}

		public static string ToTitleCase(this string str, CultureInfo culture)
		{
			return culture.TextInfo.ToTitleCase(str);
		}

		public static string ToTitleCaseInvariant(this string str)
		{
			return CultureInfo.InvariantCulture.TextInfo.ToTitleCase(str);
		}

		public static string StringJoin<T>(this IEnumerable<T> items, string separator = "")
		{
			if(items.IsNull())
				throw new ArgumentNullException("items");

			var sb = new StringBuilder();
			bool first = true;
			foreach(var item in items)
			{
				if(first) first = false;
				else sb.Append(separator);
				sb.Append(item.ToInvariantString());
			}
			return sb.ToString();
		}

		public static KeyValuePair<char, string> DetachFirstChar(this string str)
		{
			return str.IsNotEmpty()
				? new KeyValuePair<char, string>(str[0], str.Substring(1))
				: new KeyValuePair<char, string>(default(char), "");
		}

		public static KeyValuePair<string, string> KeyValueSplit(this string str, char delimiter, bool trim = false)
		{
			return str.IsNotEmpty()
				? KeyValueSplitByPosition(str, str.IndexOf(delimiter), 1, trim)
				: new KeyValuePair<string, string>("", "");
		}

		public static KeyValuePair<string, string> KeyValueSplitByLastEntry(this string str, char delimiter, bool trim = false)
		{
			return str.IsNotEmpty()
				? KeyValueSplitByPosition(str, str.LastIndexOf(delimiter), 1, trim)
				: new KeyValuePair<string, string>("", "");
		}

		public static KeyValuePair<string, string> KeyValueSplit(this string str, string delimiter, bool trim = false)
		{
			if(delimiter.IsNull())
				throw new ArgumentNullException("delimiter");
			return str.IsNotEmpty()
				? KeyValueSplitByPosition(str, str.IndexOf(delimiter, StringComparison.Ordinal), delimiter.Length, trim)
				: new KeyValuePair<string, string>("", "");
		}

		public static KeyValuePair<string, string> KeyValueSplitByLastEntry(this string str, string delimiter, bool trim = false)
		{
			if(delimiter.IsNull())
				throw new ArgumentNullException("delimiter");
			return str.IsNotEmpty()
				? KeyValueSplitByPosition(str, str.LastIndexOf(delimiter, StringComparison.Ordinal), delimiter.Length, trim)
				: new KeyValuePair<string, string>("", "");
		}

		static KeyValuePair<string, string> KeyValueSplitByPosition(this string str, int delimiterStart, int delimiterLength, bool trim)
		{
			int delimiterEnd = delimiterStart + delimiterLength;
			return delimiterStart >= 0 && delimiterEnd <= str.Length
				? trim
					? new KeyValuePair<string, string>(str.Substring(0, delimiterStart).Trim(), str.Substring(delimiterEnd).Trim())
					: new KeyValuePair<string, string>(str.Substring(0, delimiterStart), str.Substring(delimiterEnd))
				: trim
					? new KeyValuePair<string, string>(str.Trim(), "")
					: new KeyValuePair<string, string>(str, "");
		}
	}
}
