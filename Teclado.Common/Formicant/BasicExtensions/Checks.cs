using JetBrains.Annotations;

namespace Formicant
{
	public static partial class BasicExtensions
	{
		/// <summary>
		/// Extension-method synonym of <c>ReferenceEquals(obj, null)</c>.
		/// </summary>
		/// <param name="obj">The object to compare with null.</param>
		/// <returns>true if <paramref name="obj"/> is null; otherwise, false.</returns>
		[ContractAnnotation("null => true; notnull => false")]
		public static bool IsNull(this object obj)
		{
			return ReferenceEquals(obj, null);
		}

		/// <summary>
		/// Extension-method synonym of <c>!ReferenceEquals(obj, null)</c>.
		/// </summary>
		/// <param name="obj">The object to compare with null.</param>
		/// <returns>true if <paramref name="obj"/> is not null; otherwise, false.</returns>
		[ContractAnnotation("null => false; notnull => true")]
		public static bool IsNotNull(this object obj)
		{
			return !ReferenceEquals(obj, null);
		}

		/// <summary>
		/// Extension-method synonym of <c>string.IsNullOrEmpty(value)</c>.
		/// </summary>
		/// <param name="value">The string to test.</param>
		/// <returns>true if the <paramref name="value"/> parameter is null or an empty string; otherwise, false.</returns>
		[ContractAnnotation("null => true")]
		public static bool IsEmpty(this string value)
		{
			return string.IsNullOrEmpty(value);
		}

		/// <summary>
		/// Extension-method synonym of <c>!string.IsNullOrEmpty(value)</c>.
		/// </summary>
		/// <param name="value">The string to test.</param>
		/// <returns>false if the <paramref name="value"/> parameter is null or an empty string; otherwise, true.</returns>
		[ContractAnnotation("null => false")]
		public static bool IsNotEmpty(this string value)
		{
			return !string.IsNullOrEmpty(value);
		}
	}
}