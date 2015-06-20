using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Teclado.Common
{
	public struct Scancode : IEquatable<Scancode>
	{
		public Scancode(byte code) : this()
		{
			Code = code;
		}

		public byte Code { get; }

		public bool IsNotNone => Code != 0;

		public bool IsNone => Code == 0;

		public static readonly Scancode None = default(Scancode);

		#region Equality

		public bool Equals(Scancode other)
		{
			return Code.Equals(other.Code);
		}

		public override bool Equals(object obj)
		{
			return obj is Scancode && Equals((Scancode)obj);
		}

		public override int GetHashCode()
		{
			return Code.GetHashCode();
		}

		public static bool operator ==(Scancode sc1, Scancode sc2)
		{
			return sc1.Equals(sc2);
		}

		public static bool operator !=(Scancode sc1, Scancode sc2)
		{
			return !sc1.Equals(sc2);
		}

		#endregion
	}
}
