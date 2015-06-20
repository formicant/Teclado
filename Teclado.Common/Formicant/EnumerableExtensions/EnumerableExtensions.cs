using System;
using System.Collections.Generic;
using System.Linq;

namespace Formicant
{
	public static partial class EnumerableExtensions
	{
		public static bool IsNotEmpty<T>(this IEnumerable<T> seq)
		{
			return seq.IsNotNull() && seq.Any();
		}

		public static bool IsEmpty<T>(this IEnumerable<T> seq)
		{
			return seq.IsNull() || !seq.Any();
		}

		public static IEnumerable<T> WithoutNulls<T>(this IEnumerable<T> seq)
			where T : class
		{
			return seq.Where(item => item != null);
		}

		public static IEnumerable<T> WithoutNulls<T>(this IEnumerable<T?> seq)
			where T : struct
		{
			return seq.Where(item => item.HasValue).Select(item => item.Value);
		}

		public static T SingleOrDefaultEvenIfMany<T>(this IEnumerable<T> seq)
		{
			var enumerator = seq.GetEnumerator();
			if(!enumerator.MoveNext())
				return default(T);
			var single = enumerator.Current;
			if(enumerator.MoveNext())
				return default(T);
			return single;
		}

		public static void ForEach<T>(this IEnumerable<T> seq, Action<T> action)
		{
			foreach(var item in seq)
				action(item);
		}

		public static void ForEach<T>(this IEnumerable<T> seq, Action<T, int> action)
		{
			int i = 0;
			foreach(var item in seq)
				action(item, i++);
		}

		public static IEnumerable<T> Yield<T>(this T item)
		{
			yield return item;
		}

		public static IEnumerable<T> Append<T>(this IEnumerable<T> seq, T item)
		{
			return seq.Concat(Enumerable.Repeat(item, 1));
		}

		public static IEnumerable<T> Prepend<T>(this IEnumerable<T> seq, T item)
		{
			return Enumerable.Repeat(item, 1).Concat(seq);
		}

		public static IEnumerable<T> AllExceptAt<T>(this IEnumerable<T> seq, int index)
		{
			return seq.Where((_, i) => i != index);
		}

		public static IEnumerable<IEnumerable<T>> Permute<T>(this IEnumerable<T> seq)
		{
			var array = seq.ToArray();
			if(array.Length <= 1)
				yield return array;
			else
				for(var i = 0; i < array.Length; i++)
				{
					var newFirst = new[] { array[i] };
					foreach(var subPermute in Permute(array.AllExceptAt(i)))
						yield return newFirst.Concat(subPermute);
				}
		}

		public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> seq, bool condition, Func<T, bool> predicate)
		{
			return condition
				? seq.Where(predicate)
				: seq;
		}

		public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> seq, bool condition, Func<T, int, bool> predicate)
		{
			return condition
				? seq.Where(predicate)
				: seq;
		}

		public static CachedEnumerable<T> Cache<T>(this IEnumerable<T> seq)
		{
			return new CachedEnumerable<T>(seq);
		}

		public static HashSet<T> ToSet<T>(this IEnumerable<T> seq)
		{
			return new HashSet<T>(seq);
		}

		public static HashSet<T> ToSet<T, TSeq>(this IEnumerable<TSeq> seq, Func<TSeq, T> selector)
		{
			return new HashSet<T>(seq.Select(selector));
		}
	}
}
