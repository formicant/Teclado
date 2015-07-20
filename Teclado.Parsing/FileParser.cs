using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using Sprache;
using Formicant;
using Teclado.Common;
using Teclado.Parsing.Expressions;

namespace Teclado.Parsing
{
	public class FileParser
	{
		public FileParser(string fileContent)
		{
			FileContent = fileContent;
		}

		public string FileContent { get; }

		public IEnumerable<Rule> Rules => Translate(ParseFile.Parse(FileContent));

		#region Auxillary

		static readonly Parser<string> ParseWhiteSpace =
			Parse.Chars(" \t").AtLeastOnce().Text();

		static readonly Parser<string> ParseComment =
			Parse.AnyChar.Except(Parse.LineTerminator).Many().Text().PrecededBy(Parse.Char('/'));

		static readonly Parser<string> ParseLineEnd =
			from whiteSpace in ParseWhiteSpace.Optional()
			from comment in ParseComment.Optional()
			from lineTerminator in Parse.LineTerminator
			select comment.GetOrElse("");

		static readonly Parser<int> ParseHex =
			from digits in Parse.Chars("0123456789ABCDEFabcdef").Named("hexadecimal digit").AtLeastOnce().Text()
			select digits.ParseHexInt();

		static readonly Parser<string> ParseCodePoint =
			from codePoint in ParseHex.Contained(Parse.Char('{'), Parse.Char('}'))
			select Encoding.UTF32.GetString(BitConverter.GetBytes(codePoint));

		#endregion

		#region Items

		static readonly Parser<string> ParseName =
			from parts in
				Parse.CharExcept("\r\n\t /{}[]+-|\\#.!'\"*_=").AtLeastOnce().Text().Or(
				Parse.String("{{").Return("{")).Or(
				Parse.String("}}").Return("}")).Or(
				ParseCodePoint)
					.AtLeastOnce()
			select string.Concat(parts);

		static readonly Parser<string> ParseQuotedString =
			from parts in
				Parse.CharExcept(@"{""}").AtLeastOnce().Text().Or(
				Parse.String("{{").Return("{")).Or(
				Parse.String("}}").Return("}")).Or(
				Parse.String("\"\"").Return("\"")).Or(
				ParseCodePoint)
					.AtLeastOnce()
					.Contained(Parse.Char('"'), Parse.Char('"'))
			select string.Concat(parts);

		static readonly Parser<Scancode> ParseScancodeItem =
			from firstLetter in Parse.Upper
			from rest in Parse.LetterOrDigit.Many().Text()
			select new Scancode(firstLetter + rest);

		static readonly Parser<VirtKey> ParseVirtKeyItem =
			from firstLetter in Parse.Lower
			from rest in Parse.LetterOrDigit.Many().Text()
			select new VirtKey(firstLetter + rest);

		static readonly Parser<Layout> ParseLayoutItem =
			from lead in Parse.Char('#')
			from name in ParseName
			select new Layout(0); // todo: add layout name parsing

		static readonly Parser<string> ParseVariableItem =
			ParseName.PrecededBy(Parse.Char('.'));

		static readonly Parser<string> ParseSpecialItem =
			ParseName.PrecededBy(Parse.Char('!'));

		static readonly Parser<string> ParseStringItem =
			ParseName.PrecededBy(Parse.Char('\'')).Or(
			ParseQuotedString);

		#endregion

		#region Trigger types

		static readonly Parser<ConditionTriggerType> ParseConditionTriggerType =
			Parse.Char('+').Return(ConditionTriggerType.True).Or(
			Parse.Char('-').Return(ConditionTriggerType.False)).Or(
			Parse.Char('[').Return(ConditionTriggerType.ToTrue)).Or(
			Parse.Char(']').Return(ConditionTriggerType.ToFalse));

		static readonly Parser<ReactionTriggerType> ParseReactionTriggerType =
			Parse.Char('[').Return(ReactionTriggerType.ToTrue).Or(
			Parse.Char(']').Return(ReactionTriggerType.ToFalse));

		#endregion

		#region Conditions

		static readonly Parser<Condition> ParseScancodeCondition =
			from type in ParseConditionTriggerType
			from item in ParseScancodeItem
			select new ScancodeCondition(type, item);

		static readonly Parser<Condition> ParseVirtKeyCondition =
			from type in ParseConditionTriggerType
			from item in ParseVirtKeyItem
			select new VirtKeyCondition(type, item);

		static readonly Parser<Condition> ParseLayoutCondition =
			from type in ParseConditionTriggerType.Optional()
			from item in ParseLayoutItem
			select new LayoutCondition(type.GetOrElse(ConditionTriggerType.True), item);

		static readonly Parser<Condition> ParseVariableCondition =
			from type in ParseConditionTriggerType.Optional()
			from item in ParseVariableItem
			select new VariableCondition(type.GetOrElse(ConditionTriggerType.True), item);

		static readonly Parser<Condition> ParseSpecialCondition =
			from type in ParseConditionTriggerType.Optional()
			from item in ParseSpecialItem
			select new SpecialCondition(type.GetOrElse(ConditionTriggerType.True), item);

		static readonly Parser<Condition> ParseStringCondition =
			from type in ParseConditionTriggerType.Optional()
			from item in ParseStringItem
			select new StringCondition(type.GetOrElse(ConditionTriggerType.ToTrue), item);

		static readonly Parser<Condition> ParseCondition =
			ParseScancodeCondition.Or(
			ParseVirtKeyCondition).Or(
			ParseLayoutCondition).Or(
			ParseVariableCondition).Or(
			ParseSpecialCondition).Or(
			ParseStringCondition);

		static readonly Parser<IEnumerable<Condition>> ParseConditionSet =
			Parse.Char('_').Return(Enumerable.Empty<Condition>()).Or(
			ParseCondition.AtLeastOnce());

		#endregion

		#region Reactions

		static readonly Parser<Reaction> ParseScancodeReaction =
			from type in ParseReactionTriggerType
			from item in ParseScancodeItem
			select new ScancodeReaction(type, item);

		static readonly Parser<Reaction> ParseVirtKeyReaction =
			from type in ParseReactionTriggerType
			from item in ParseVirtKeyItem
			select new VirtKeyReaction(type, item);

		static readonly Parser<Reaction> ParseLayoutReaction =
			from type in ParseReactionTriggerType.Optional()
			from item in ParseLayoutItem
			select new LayoutReaction(type.GetOrElse(ReactionTriggerType.ToTrue), item);

		static readonly Parser<Reaction> ParseVariableReaction =
			from type in ParseReactionTriggerType.Optional()
			from item in ParseVariableItem
			select new VariableReaction(type.GetOrElse(ReactionTriggerType.ToTrue), item);

		static readonly Parser<Reaction> ParseSpecialReaction =
			from type in ParseReactionTriggerType.Optional()
			from item in ParseSpecialItem
			select new SpecialReaction(type.GetOrElse(ReactionTriggerType.ToTrue), item);

		static readonly Parser<Reaction> ParseStringReaction =
			(
				from type in ParseReactionTriggerType.Optional()
				from item in ParseStringItem
				select new StringReaction(type.GetOrElse(ReactionTriggerType.ToTrue), item)
			)
			.Or
			(
				from item in ParseName
				select new StringReaction(ReactionTriggerType.ToTrue, item)
			);

		static readonly Parser<Reaction> ParseReaction =
			ParseScancodeReaction.Or(
			ParseVirtKeyReaction).Or(
			ParseLayoutReaction).Or(
			ParseVariableReaction).Or(
			ParseSpecialReaction).Or(
			ParseStringReaction);

		static readonly Parser<IEnumerable<Reaction>> ParseReactionSequence =
			Parse.Char('_').Return(Enumerable.Empty<Reaction>()).Or(
			ParseReaction.AtLeastOnce());

		#endregion

		#region Rule sets

		static readonly Parser<RuleSet> ParseSingleRuleSet =
			from leadingWhiteSpace in ParseWhiteSpace.Optional()
			from conditionSet in ParseConditionSet
			from reactionSequenceList in
				ParseReactionSequence.PrecededBy(ParseWhiteSpace).Many()
			from lineEnd in ParseLineEnd
			select new SingleRuleSet(conditionSet, reactionSequenceList);

		static Parser<RuleSet> ParseGroupRuleSet(int maxLevel) =>
			from leadingWhiteSpace in ParseWhiteSpace.Optional()
			from groupLevel in Parse.Char('=').Repeat(1, maxLevel).Select(c => c.Count())
			from conditionSetList in
				ParseConditionSet.PrecededBy(ParseWhiteSpace).Many()
			from lineEnd in ParseLineEnd
			from innerRuleSetList in ParseRuleSetList(groupLevel - 1)
			select new GroupRuleSet(groupLevel, conditionSetList, innerRuleSetList);

		static Parser<IEnumerable<RuleSet>> ParseRuleSetList(int maxLevel = 8) =>
			from ruleSets in
				ParseLineEnd.Return(null as SingleRuleSet).Or(
				ParseSingleRuleSet)
					.If(maxLevel > 0, p => p.Or(ParseGroupRuleSet(maxLevel)))
					.Many()
			select ruleSets.WithoutNulls();

		static readonly Parser<IEnumerable<RuleSet>> ParseFile =
			ParseRuleSetList().End();

		#endregion

		#region Translation

		static IEnumerable<Rule> Translate(IEnumerable<RuleSet> ruleSets, IEnumerable<IEnumerable<Condition>> additionalConditions = null)
		{
			var additionalConditionList = (additionalConditions ?? Enumerable.Empty<IEnumerable<Condition>>()).ToList();
			var firstAdditionalCondition = additionalConditionList.FirstOrDefault() ?? Enumerable.Empty<Condition>();

			return ruleSets
				.SelectMany(ruleSet => ruleSet is SingleRuleSet
					? (ruleSet as SingleRuleSet).ReactionSequenceList.Select((reactionSequence, i) =>
						new Rule(
							(additionalConditionList.Count > i ? additionalConditionList[i] : Enumerable.Empty<Condition>())
								.Concat((ruleSet as SingleRuleSet).ConditionSet),
							reactionSequence))
					: Translate(
						(ruleSet as GroupRuleSet).InnerRuleSets,
						(ruleSet as GroupRuleSet).ConditionSetList.IsNotEmpty()
							? (ruleSet as GroupRuleSet).ConditionSetList.Select(c =>
								firstAdditionalCondition.Concat(c))
							: firstAdditionalCondition.Yield())
				)
				.Where(r => r.ConditionSet.IsNotEmpty() && r.ReactionSequence.IsNotEmpty());
		}

		#endregion
	}
}
