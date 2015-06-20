using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Teclado.Common
{
	public struct Layout : IEquatable<Layout>
	{
		public Layout(uint id) : this()
		{
			Id = id;
		}

		public uint Id { get; }

		#region Equality

		public bool Equals(Layout other)
		{
			return Id.Equals(other.Id);
		}

		public override bool Equals(object obj)
		{
			return obj is Layout && Equals((Layout)obj);
		}

		public override int GetHashCode()
		{
			return Id.GetHashCode();
		}

		public static bool operator ==(Layout sc1, Layout sc2)
		{
			return sc1.Equals(sc2);
		}

		public static bool operator !=(Layout sc1, Layout sc2)
		{
			return !sc1.Equals(sc2);
		}

		#endregion
	}
}
