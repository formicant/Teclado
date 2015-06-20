using System;

namespace Formicant
{
	public static partial class Number
	{
		#region Constants

		public const double π = Math.PI;
		public const double τ = 2D * Math.PI;
		public const double e = Math.E;
		public const double φ = 1.6180339887498948482;

		public const double ln2 = 0.6931471805599453094;

		public const double ε0 = 2.2250738585072014e-308; // = 2⁻¹⁰²²
		public const double ε1 = 2.2204460492503131e-16;  // = 2⁻⁵²
		public const double ε  = 3.5527136788005096e-15;  // = 2⁻⁴⁸ = 16∙ε₁

		#endregion

		#region Floating point extensions

		public static bool IsFinite(this float x)
		{
			return !float.IsNaN(x) && !float.IsInfinity(x);
		}

		public static bool IsFinite(this double x)
		{
			return !double.IsNaN(x) && !double.IsInfinity(x);
		}

		#endregion

		#region Functions

		#region Misc

		public static int Abs(this int x)
		{
			return Math.Abs(x);
		}

		public static int Sign(this int x)
		{
			return Math.Sign(x);
		}

		public static double Abs(this double x)
		{
			return Math.Abs(x);
		}

		public static double Sign(this double x)
		{
			return Math.Sign(x);
		}

		public static double Floor(this double x)
		{
			return Math.Floor(x);
		}

		public static double Celing(this double x)
		{
			return Math.Ceiling(x);
		}

		public static double Round(this double x)
		{
			return Math.Round(x);
		}

		public static double Round(this double x, int decimals)
		{
			return Math.Round(x, decimals);
		}

		public static int FloorToInt(this double x)
		{
			return (int)Math.Floor(x);
		}

		public static int CelingToInt(this double x)
		{
			return (int)Math.Ceiling(x);
		}

		public static int RoundToInt(this double x)
		{
			return (int)Math.Round(x);
		}

		public static double SymmetricMod(this double x, double y)
		{
			return Math.IEEERemainder(x, y);
		}

		public static double WrapAngle(this double x)
		{
			return x.SymmetricMod(τ);
		}

		public static double ToDouble(this int i)
		{
			return (double)i;
		}

		public static double FractionOf(this int i, int n)
		{
			return (double)i / (double)n;
		}

		#endregion

		#region Power, exponent

		public static double Inv(this double x)
		{
			return 1D / x;
		}

		public static int Sq(this int x)
		{
			return x * x;
		}

		public static long Sq(this long x)
		{
			return x * x;
		}

		public static double Sq(this double x)
		{
			return x * x;
		}

		public static int Cube(this int x)
		{
			return x * x * x;
		}

		public static long Cube(this long x)
		{
			return x * x * x;
		}

		public static double Cube(this double x)
		{
			return x * x * x;
		}

		public static double Sqrt(this double x)
		{
			return Math.Sqrt(x);
		}

		public static int Pow(this int x, int n)
		{
			if(n < 0) throw new ArgumentOutOfRangeException("n");
			int ret = 1;
			while(n != 0)
			{
				if((n & 1) == 1)
					ret *= x;
				x *= x;
				n >>= 1;
			}
			return ret;
		}

		public static long Pow(this long x, int n)
		{
			if(n < 0) throw new ArgumentOutOfRangeException("n");
			long ret = 1;
			while(n != 0)
			{
				if((n & 1) == 1)
					ret *= x;
				x *= x;
				n >>= 1;
			}
			return ret;
		}

		public static double Pow(this double x, double y)
		{
			return Math.Pow(x, y);
		}

		public static double Exp(this double x)
		{
			return Math.Exp(x);
		}

		public static double Ln(this double x)
		{
			return Math.Log(x);
		}

		public static double Lb(this double x)
		{
			return Math.Log(x) / ln2;
		}

		#endregion

		#region Trigonometric

		public static double Sin(this double x)
		{
			return Math.Sin(x);
		}

		public static double Cos(this double x)
		{
			return Math.Cos(x);
		}

		public static double Tg(this double x)
		{
			return Math.Tan(x);
		}

		public static double Ctg(this double x)
		{
			return Math.Tan(x).Inv();
		}

		public static double Sinh(this double x)
		{
			return Math.Sinh(x);
		}

		public static double Cosh(this double x)
		{
			return Math.Cosh(x);
		}

		public static double Tgh(this double x)
		{
			return Math.Tanh(x);
		}

		public static double Ctgh(this double x)
		{
			return Math.Tanh(x).Inv();
		}

		public static double Asin(this double x)
		{
			return Math.Asin(x);
		}

		public static double Acos(this double x)
		{
			return Math.Acos(x);
		}

		public static double Atg(this double x)
		{
			return Math.Atan(x);
		}

		public static double AtgTo(this double x, double y)
		{
			return Math.Atan2(x, y);
		}

		public static double Actg(this double x)
		{
			return Math.Atan(x.Inv());
		}

		public static double ActgTo(this double x, double y)
		{
			return Math.Atan2(y, x);
		}

		public static double Asinh(this double x)
		{
			return Math.Log(x + Math.Sqrt(x.Sq() + 1D));
		}

		public static double Acosh(this double x)
		{
			return Math.Log(x + Math.Sqrt(x.Sq() - 1D));
		}

		public static double Atgh(this double x)
		{
			return (Math.Log(1D + x) - Math.Log(1D - x)) / 2D;
		}

		public static double Actgh(this double x)
		{
			return (Math.Log(1D + x.Inv()) - Math.Log(1D - x.Inv())) / 2D;
		}

		#endregion

		#region Number theory

		public static int Gcd(this int a, int b)
		{
			while(b != 0)
			{
				int t = b;
				b = a.Mod(b);
				a = t;
			}
			return a;
		}

		public static long Gcd(this long a, long b)
		{
			while(b != 0)
			{
				long t = b;
				b = a.Mod(b);
				a = t;
			}
			return a;
		}

		public static int Lcm(this int a, int b)
		{
			return a * b / Gcd(a, b);
		}

		public static long Lcm(this long a, long b)
		{
			return a * b / Gcd(a, b);
		}

		#endregion

		#endregion
	}
}
