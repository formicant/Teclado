using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Teclado.Common
{
	public struct VirtKey : IEquatable<VirtKey>
	{
		public VirtKey(byte code) : this()
		{
			Code = code;
		}

		public byte Code { get; }

		public bool IsNotNone => Code != 0;

		public bool IsNone => Code == 0;

		public static readonly VirtKey None = default(VirtKey);

		#region Equality

		public bool Equals(VirtKey other)
		{
			return Code.Equals(other.Code);
		}

		public override bool Equals(object obj)
		{
			return obj is VirtKey && Equals((VirtKey)obj);
		}

		public override int GetHashCode()
		{
			return Code.GetHashCode();
		}

		public static bool operator ==(VirtKey sc1, VirtKey sc2)
		{
			return sc1.Equals(sc2);
		}

		public static bool operator !=(VirtKey sc1, VirtKey sc2)
		{
			return !sc1.Equals(sc2);
		}

		#endregion
	}
}
