using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formicant
{
	public class BiDic<TKey, TValue> :
#if !DOTNET_BELOW_4_5
		IReadOnlyDictionary<TKey, TValue>,
#endif
		IDictionary<TKey, TValue>
	{
		#region Constructors

		public BiDic()
		{
			_forward = new Dictionary<TKey, TValue>();
			_backward = new Dictionary<TValue, TKey>();
		}

		public BiDic(IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer)
		{
			_forward = new Dictionary<TKey, TValue>(keyComparer);
			_backward = new Dictionary<TValue, TKey>(valueComparer);
		}

		#endregion

		#region Properties

#if !DOTNET_BELOW_4_5
		public IReadOnlyDictionary<TKey, TValue> Forward
#else
		public IDictionary<TKey, TValue> Forward
#endif
		{
			get { return _forward; }
		}

#if !DOTNET_BELOW_4_5
		public IReadOnlyDictionary<TValue, TKey> Backward
#else
		public IDictionary<TValue, TKey> Backward
#endif
		{
			get { return _backward; }
		}

		#endregion

		#region IReadOnlyDictionary

		public bool ContainsKey(TKey key)
		{
			return _forward.ContainsKey(key);
		}

		public IEnumerable<TKey> Keys
		{
			get { return _forward.Keys; }
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			return _forward.TryGetValue(key, out value);
		}

		public IEnumerable<TValue> Values
		{
			get { return _backward.Keys; }
		}

		public int Count
		{
			get { return _forward.Count; }
		}

		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
		{
			return _forward.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return _forward.GetEnumerator();
		}

		#endregion

		#region IDictionary

		public bool IsReadOnly
		{
			get { return false; }
		}

		ICollection<TKey> IDictionary<TKey, TValue>.Keys
		{
			get { return _forward.Keys; }
		}

		ICollection<TValue> IDictionary<TKey, TValue>.Values
		{
			get { return _backward.Keys; }
		}

		public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
		{
			(_forward as IDictionary<TKey, TValue>).CopyTo(array, arrayIndex);
		}

		public bool Contains(KeyValuePair<TKey, TValue> item)
		{
			return (_forward as IDictionary<TKey, TValue>).Contains(item);
		}

		public void Add(TKey key, TValue value)
		{
			_forward.Add(key, value);
			_backward.Add(value, key);
		}

		public void Add(KeyValuePair<TKey, TValue> item)
		{
			Add(item.Key, item.Value);
		}

		public bool Remove(TKey key)
		{
			if(_forward.ContainsKey(key))
				_backward.Remove(_forward[key]);
			return _forward.Remove(key);
		}

		public bool Remove(KeyValuePair<TKey, TValue> item)
		{
			return Remove(item.Key);
		}

		public void Clear()
		{
			_forward.Clear();
			_backward.Clear();
		}

		public TValue this[TKey key]
		{
			get { return _forward[key]; }
			set
			{
				if(_forward.ContainsKey(key))
					_backward.Remove(_forward[key]);
				if(_backward.ContainsKey(value))
					_forward.Remove(_backward[value]);
				_forward[key] = value;
				_backward[value] = key;
			}
		}

		#endregion

		#region AdditionalMethods

		public void AddIfAbsent(TKey key, TValue value)
		{
			if(!_forward.ContainsKey(key) && !_backward.ContainsKey(value))
				Add(key, value);
		}

		public TValue GetValueOrDefault(TKey key)
		{
			return ContainsKey(key)
				? _forward[key]
				: default(TValue);
		}

		public bool ContainsValue(TValue value)
		{
			return _backward.ContainsKey(value);
		}

		public bool TryGetKeyByValue(TValue value, out TKey key)
		{
			return _backward.TryGetValue(value, out key);
		}

		public TKey GetKeyByValue(TValue value)
		{
			return _backward[value];
		}

		public TKey GetKeyByValueOrDefault(TValue value)
		{
			return ContainsValue(value)
				? _backward[value]
				: default(TKey);
		}

		public bool RemoveByValue(TValue value)
		{
			if(_backward.ContainsKey(value))
				_forward.Remove(_backward[value]);
			return _backward.Remove(value);
		}

		#endregion

		#region private

		readonly Dictionary<TKey, TValue> _forward;
		readonly Dictionary<TValue, TKey> _backward;

		#endregion
	}
}
