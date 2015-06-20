using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formicant
{
	public class HeadTail<T> : IEnumerable<T>
	{
		public static HeadTail<T> Create(IEnumerable<T> seqence)
		{
			return Create(seqence.GetEnumerator());
		}

		public static HeadTail<T> Create(IEnumerator<T> enumerator)
		{
			return enumerator.MoveNext()
				? new HeadTail<T>(enumerator.Current, enumerator)
				: null;
		}

		public HeadTail(T head, HeadTail<T> tail)
		{
			Head = head;
			_tail = tail;
		}

		HeadTail(T head, IEnumerator<T> enumerator)
		{
			Head = head;
			_enumerator = enumerator;
		}

		public T Head { get; private set; }

		public HeadTail<T> Tail
		{
			get
			{
				if(_enumerator != null)
				{
					_tail = Create(_enumerator);
					_enumerator = null;
				}
				return _tail;
			}
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public IEnumerator<T> GetEnumerator()
		{
			yield return Head;
			if(Tail != null)
				foreach(var item in Tail)
					yield return item;
		}

		public IEnumerable<T> EnumerateBackwards()
		{
			if(Tail != null)
				foreach(var item in Tail.EnumerateBackwards())
					yield return item;
			yield return Head;
		}

		IEnumerator<T> _enumerator;
		HeadTail<T> _tail;
	}

	public static class HeadTailExtensions
	{
		public static HeadTail<T> ToHeadTail<T>(this IEnumerable<T> seq)
		{
			return HeadTail<T>.Create(seq);
		}
	}
}
