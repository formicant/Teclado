using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formicant
{
	public class CachedEnumerable<T> : IEnumerable<T>
	{
		public CachedEnumerable(IEnumerable<T> seq)
		{
			_cachedSeq = CacheHelper(seq.GetEnumerator());
		}

		public IEnumerator<T> GetEnumerator()
		{
			return _cachedSeq.GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		static IEnumerable<T> CacheHelper(IEnumerator<T> source)
		{
			var isEmpty = new Lazy<bool>(() => !source.MoveNext());
			var head = new Lazy<T>(() => source.Current);
			var tail = new Lazy<IEnumerable<T>>(() => CacheHelper(source));

			return CacheHelper(isEmpty, head, tail);
		}

		static IEnumerable<T> CacheHelper(
			Lazy<bool> isEmpty,
			Lazy<T> head,
			Lazy<IEnumerable<T>> tail)
		{
			if(isEmpty.Value)
				yield break;

			yield return head.Value;
			foreach(var value in tail.Value)
				yield return value;
		}

		readonly IEnumerable<T> _cachedSeq;
	}
}
