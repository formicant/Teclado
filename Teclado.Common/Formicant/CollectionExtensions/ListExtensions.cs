using System.Collections.Generic;

namespace Formicant
{
	public static partial class ListExtensions
	{
		public static IEnumerable<T> IterateBackwards<T>(this IList<T> list)
		{
			for(int i = list.Count - 1; i >= 0; i--)
				yield return list[i];
		}

		public static T Cyclic<T>(this IList<T> list, int index)
		{
			return list[index.Mod(list.Count)];
		}
	}
}
