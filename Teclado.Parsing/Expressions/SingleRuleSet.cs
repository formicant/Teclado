using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Formicant;
using Teclado.Common;

namespace Teclado.Parsing.Expressions
{
	class SingleRuleSet : RuleSet
	{
		public SingleRuleSet(
			IEnumerable<Condition> conditionSet,
			IEnumerable<IEnumerable<Reaction>> reactionSequenceList)
			: base(0)
		{
			ConditionSet = conditionSet;
			ReactionSequenceList = reactionSequenceList;
		}

		public IEnumerable<Condition> ConditionSet { get; }
		public IEnumerable<IEnumerable<Reaction>> ReactionSequenceList { get; }

		public override string ToString() =>
			$"{ConditionSet.StringJoin()}\t{ReactionSequenceList.Select(r => r.StringJoin()).StringJoin("\t")}";
	}
}
