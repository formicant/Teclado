using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sprache;
using Formicant;

namespace Teclado.Parsing
{
	static class SpracheExtensions
	{
		public static Parser<T> PrecededBy<T, U>(this Parser<T> parser, Parser<U> preceding) =>
			from u in preceding
			from t in parser
			select t;

		public static Parser<T> FollowedBy<T, U>(this Parser<T> parser, Parser<U> following) =>
			from t in parser
			from u in following
			select t;
	}
}
