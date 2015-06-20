using System.Collections.Generic;

namespace Formicant
{
	public static partial class ArrayExtensions
	{
		public static IEnumerable<T> IterateBackwards<T>(this T[] array)
		{
			for(int i = array.Length - 1; i >= 0; i--)
				yield return array[i];
		}

		public static T Cyclic<T>(this T[] array, int index)
		{
			return array[index.Mod(array.Length)];
		}
	}
}
