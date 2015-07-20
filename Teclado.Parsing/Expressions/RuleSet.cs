using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Teclado.Parsing.Expressions
{
	abstract class RuleSet
	{
		protected RuleSet(int level)
		{
			Level = level;
		}

		public int Level { get; }
	}
}
