using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Formicant;
using Teclado.Common;

namespace Teclado.Parsing.Expressions
{
	class GroupRuleSet : RuleSet
	{
		public GroupRuleSet(
			int level,
			IEnumerable<IEnumerable<Condition>> conditionSetList,
			IEnumerable<RuleSet> innerRuleSets)
			: base(level)
		{
			ConditionSetList = conditionSetList;
			InnerRuleSets = innerRuleSets;
		}

		public IEnumerable<IEnumerable<Condition>> ConditionSetList { get; }
		public IEnumerable<RuleSet> InnerRuleSets { get; }

		public override string ToString() =>
			$"{{\r\n{InnerRuleSets.StringJoin("\r\n")}\r\n}}";
	}
}
