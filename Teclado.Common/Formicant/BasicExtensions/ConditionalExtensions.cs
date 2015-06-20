using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formicant
{
	public static partial class ConditionalExtensions
	{
		#region void

		public static void If<TIn>(this TIn obj, Action<TIn> funcIfNotNull)
			where TIn : class
		{
			if(obj != null)
				funcIfNotNull(obj);
		}

		public static void If<TIn>(this TIn? obj, Action<TIn> funcIfNotNull)
			where TIn : struct
		{
			if(obj.HasValue)
				funcIfNotNull(obj.Value);
		}

		public static void If<TIn>(this TIn obj, Action<TIn> funcIfNotNull, Action funcIfNull)
			where TIn : class
		{
			if(obj != null)
				funcIfNotNull(obj);
			else
				funcIfNull();
		}

		public static void If<TIn>(this TIn? obj, Action<TIn> funcIfNotNull, Action funcIfNull)
			where TIn : struct
		{
			if(obj.HasValue)
				funcIfNotNull(obj.Value);
			else
				funcIfNull();
		}

		#endregion

		#region func or null

		public static TOut If<TIn, TOut>(this TIn obj, Func<TIn, TOut> funcIfNotNull)
			where TIn : class
			where TOut : class
		{
			return obj != null
				? funcIfNotNull(obj)
				: null;
		}

		public static TOut? If<TIn, TOut>(this TIn obj, Func<TIn, TOut?> funcIfNotNull)
			where TIn : class
			where TOut : struct
		{
			return obj != null
				? funcIfNotNull(obj)
				: null;
		}

		public static TOut If<TIn, TOut>(this TIn? obj, Func<TIn, TOut> funcIfNotNull)
			where TIn : struct
			where TOut : class
		{
			return obj.HasValue
				? funcIfNotNull(obj.Value)
				: null;
		}

		public static TOut? If<TIn, TOut>(this TIn? obj, Func<TIn, TOut?> funcIfNotNull)
			where TIn : struct
			where TOut : struct
		{
			return obj.HasValue
				? funcIfNotNull(obj.Value)
				: null;
		}

		#endregion

		#region func or val

		public static TOut If<TIn, TOut>(this TIn obj, Func<TIn, TOut> funcIfNotNull, TOut valIfNull)
			where TIn : class
		{
			return obj != null
				? funcIfNotNull(obj)
				: valIfNull;
		}

		public static TOut If<TIn, TOut>(this TIn? obj, Func<TIn, TOut> funcIfNotNull, TOut valIfNull)
			where TIn : struct
		{
			return obj.HasValue
				? funcIfNotNull(obj.Value)
				: valIfNull;
		}

		#endregion

		#region func or func

		public static TOut If<TIn, TOut>(this TIn obj, Func<TIn, TOut> funcIfNotNull, Func<TOut> funcIfNull)
			where TIn : class
		{
			return obj != null
				? funcIfNotNull(obj)
				: funcIfNull();
		}

		public static TOut If<TIn, TOut>(this TIn? obj, Func<TIn, TOut> funcIfNotNull, Func<TOut> funcIfNull)
			where TIn : struct
		{
			return obj.HasValue
				? funcIfNotNull(obj.Value)
				: funcIfNull();
		}

		#endregion

		#region bool

		public static TOut If<TIn, TOut>(this TIn obj, bool condition, Func<TIn, TOut> funcIfTrue, Func<TIn, TOut> funcIfFalse)
		{
			return condition
				? funcIfTrue(obj)
				: funcIfFalse(obj);
		}

		public static T If<T>(this T obj, bool condition, Func<T, T> funcIfTrue)
		{
			return condition
				? funcIfTrue(obj)
				: obj;
		}

		#endregion

		#region then

		public static T Then<T>(this bool condition, T value)
		{
			return condition ? value : default(T);
		}

		#endregion
	}
}
