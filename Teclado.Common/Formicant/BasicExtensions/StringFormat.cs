using System;
using System.Globalization;
using JetBrains.Annotations;

namespace Formicant
{
	public static partial class BasicExtensions
	{
		/// <summary>
		/// Extension-method synonym of <c>string.Format</c> using the invariant culture.
		/// </summary>
		/// <param name="format">A composite format string.</param>
		/// <param name="args">An object array that contains zero or more objects to format.</param>
		/// <returns>A copy of <paramref name="format"/> in which the format items have been replaced by the string representation of the corresponding objects in <paramref name="args"/>.</returns>
		/// <exception cref="T:System.ArgumentNullException"><paramref name="format"/> or <paramref name="args"/> is null.</exception>
		/// <exception cref="T:System.FormatException"><paramref name="format"/> is invalid.-or- The index of a format item is less than zero, or greater than or equal to the length of the <paramref name="args"/> array.</exception>
		[StringFormatMethod("format")]
		public static string Fmt(this string format, params object[] args)
		{
			return string.Format(CultureInfo.InvariantCulture, format, args);
		}

		/// <summary>
		/// Gets the culture-invariant string representation of an IFormattable object.
		/// </summary>
		/// <param name="obj">An IFormattable object.</param>
		/// <returns>The culture-invariant string representation of <paramref name="obj"/>.</returns>
		public static string ToInvariantString(this IFormattable obj)
		{
			return obj.ToString(null, CultureInfo.InvariantCulture);
		}

		/// <summary>
		/// Gets the culture-invariant string representation of an IFormattable object.
		/// </summary>
		/// <param name="obj">An IFormattable object.</param>
		/// <param name="format">The format to use.</param>
		/// <returns>The culture-invariant string representation of <paramref name="obj"/>.</returns>
		public static string ToInvariantString(this IFormattable obj, string format)
		{
			return obj.ToString(format, CultureInfo.InvariantCulture);
		}

		/// <summary>
		/// Gets the culture-invariant string representation of an object.
		/// </summary>
		/// <param name="obj">An object.</param>
		/// <returns>The culture-invariant string representation of <paramref name="obj"/>.</returns>
		public static string ToInvariantString(this object obj)
		{
			return obj is IFormattable
				? (obj as IFormattable).ToInvariantString()
				: obj.ToString();
		}
	}
}
