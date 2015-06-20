using System;
using System.Collections.Generic;
using System.Linq;

namespace Formicant
{
	public static partial class DictionaryExtensions
	{
		public static TValue GetValueOrDefault<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> pairs, TKey key)
		{
#if !DOTNET_BELOW_4_5
			var readOnlyDictionary = pairs as IReadOnlyDictionary<TKey, TValue>;
			if(readOnlyDictionary.IsNotNull())
				return readOnlyDictionary.ContainsKey(key)
					? readOnlyDictionary[key]
					: default(TValue);
#endif
			var dictionary = pairs as IDictionary<TKey, TValue>;
			if(dictionary.IsNotNull())
				return dictionary.ContainsKey(key)
					? dictionary[key]
					: default(TValue);

			try
			{
				return pairs.Single(pair => pair.Key.Equals(key)).Value;
			}
			catch(InvalidOperationException)
			{
				return default(TValue);
			}
		}

		public static TValue? GetNullableValue<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> pairs, TKey key)
			where TValue : struct
		{
#if !DOTNET_BELOW_4_5
			var readOnlyDictionary = pairs as IReadOnlyDictionary<TKey, TValue>;
			if(readOnlyDictionary.IsNotNull())
				return readOnlyDictionary.ContainsKey(key)
					? (TValue?)readOnlyDictionary[key]
					: null;
#endif
			var dictionary = pairs as IDictionary<TKey, TValue>;
			if(dictionary.IsNotNull())
				return dictionary.ContainsKey(key)
					? (TValue?)dictionary[key]
					: null;

			try
			{
				return pairs.Single(pair => pair.Key.Equals(key)).Value;
			}
			catch(InvalidOperationException)
			{
				return null;
			}
		}

		public static bool AddIfAbsent<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue value)
		{
			if(dictionary.ContainsKey(key))
				return false;
			else
			{
				dictionary.Add(key, value);
				return true;
			}
		}

		public static bool AddIfAbsent<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TValue> valueFunc)
		{
			if(dictionary.ContainsKey(key))
				return false;
			else
			{
				dictionary.Add(key, valueFunc());
				return true;
			}
		}

		public static FreeDic<TKey, TValue> ToFreeDic<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
		{
			return new FreeDic<TKey, TValue>(dictionary);
		}
	}
}