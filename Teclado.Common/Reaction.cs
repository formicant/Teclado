using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Teclado.Common
{
	public abstract class Reaction
	{
		protected Reaction(ReactionTriggerType triggerType)
		{
			TriggerType = triggerType;
		}

		public ReactionTriggerType TriggerType { get; }
	}

	public class ScancodeReaction : Reaction
	{
		public ScancodeReaction(ReactionTriggerType triggerType, Scancode scancode)
			: base(triggerType)
		{
			Scancode = scancode;
		}

		public Scancode Scancode { get; }

		public override string ToString() => $"{TriggerType}{Scancode}";
	}

	public class VirtKeyReaction : Reaction
	{
		public VirtKeyReaction(ReactionTriggerType triggerType, VirtKey virtKey)
			: base(triggerType)
		{
			VirtKey = virtKey;
		}

		public VirtKey VirtKey { get; }

		public override string ToString() => $"{TriggerType}{VirtKey}";
	}

	public class LayoutReaction : Reaction
	{
		public LayoutReaction(ReactionTriggerType triggerType, Layout layout)
			: base(triggerType)
		{
			Layout = layout;
		}

		public Layout Layout { get; }

		public override string ToString() => $"{TriggerType}#{Layout}";
	}

	public class VariableReaction : Reaction
	{
		public VariableReaction(ReactionTriggerType triggerType, string name)
			: base(triggerType)
		{
			Name = name;
		}

		public string Name { get; }

		public override string ToString() => $"{TriggerType}.{Name}";
	}

	public class SpecialReaction : Reaction
	{
		public SpecialReaction(ReactionTriggerType triggerType, string name)
			: base(triggerType)
		{
			Name = name;
		}

		public string Name { get; }

		public override string ToString() => $"{TriggerType}!{Name}";
	}

	public class StringReaction : Reaction
	{
		public StringReaction(ReactionTriggerType triggerType, string @string)
			: base(triggerType)
		{
			String = @string;
		}

		public string String { get; }

		public override string ToString() => $"{TriggerType}'{String}";
	}
}
