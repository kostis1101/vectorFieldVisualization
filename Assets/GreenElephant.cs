using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace GreenElephant
{
	class GreenMath
	{
		public const float PI = (float)Math.PI;
		public const float E = 2.71828182845904523f;
		public const float ln10 = 2.30258509299404568401799f;
		public static double Fi = (1 + Math.Sqrt(5)) / 2;

		/// <summary>
		/// returns nth Fibonacci number
		/// </summary>
		/// <param name="n"></param>
		/// <returns>unsigned 64bit long / ulong</returns>
		/*public static ulong getFibonacci(int n)
		{
			ulong result = 0;

			ulong lastNum = 1;
			ulong lastTwoNum = 0;

			for (int i = 0; i < n; i++)
			{
				result = lastNum + lastTwoNum;

				lastTwoNum = lastNum;
				lastNum = result;
			}

			if (n == 0)
			{
				result = 1;
			}

			return result;
		}*/
		public static Complex getFibonacci(Complex c)
		{
			return (Complex.Pow((float)Fi, c) - (Complex.Pow(new Complex(-1f / (float)Fi, 0), c))) / ((float)Math.Sqrt(5));
		}

		/// <summary>
		/// converts string to float
		/// </summary>
		/// <param name="n"></param>
		/// <returns>unsigned 64bit long / ulong</returns>
		public static float ParseFloat(string stringToParse)
		{
			float result = 1;

			if (!stringToParse.Contains("."))
			{
				return Int32.Parse(stringToParse);
			}
			else
			{
				if (stringToParse.StartsWith("-"))
				{
					result = -1;
					stringToParse = stringToParse.Substring(1);
				}

				if (stringToParse.StartsWith("."))
					stringToParse = "0" + stringToParse;

				result *= float.Parse(stringToParse);
			}

			return result;
		}

		/// <summary>
		/// converts string to float
		/// </summary>
		/// <param name="n"></param>
		/// <returns>unsigned 64bit long / ulong</returns>
		public static float ParseFloat(string stringToParse, char splitChar)
		{
			float result = 0;



			try
			{
				string[] nums = stringToParse.Split(splitChar);
				int intPart = Int32.Parse(nums[0]);
				float decimalPart = (float)Int32.Parse(nums[1]) / (float)Math.Pow(10, nums[1].Length);

				result = intPart + decimalPart;
			}
			catch
			{
				if (!stringToParse.Contains('.'))
				{
					try
					{
						return Int32.Parse(stringToParse);
					}
					catch
					{
						Console.WriteLine("Error: couldn't covert to float, undefined character.");
					}
				}
			}

			return result;
		}

		/// <summary>
		/// converts string to double
		/// </summary>
		/// <param name="n"></param>
		/// <returns>unsigned 64bit long / ulong</returns>
		public static double ParseDouble(string stringToParse)
		{
			double result = 0;

			if (!stringToParse.Contains("."))
			{
				return Int32.Parse(stringToParse);
			}

			try
			{
				string[] nums = stringToParse.Split('.');
				int intPart = Int32.Parse(nums[0]);
				double decimalPart = (double)Int32.Parse(nums[1]) / (double)Math.Pow(10, nums[1].Length);

				result = intPart + decimalPart;
			}
			catch
			{
				if (!stringToParse.Contains('.'))
				{
					try
					{
						return Int32.Parse(stringToParse);
					}
					catch
					{
						throw new Exception("ConvertError: couldn't covert Complex to float, undefined character.");
					}
				}
			}

			return result;
		}
		/// <summary>
		/// converts string to double
		/// </summary>
		/// <param name="n"></param>
		/// <returns>unsigned 64bit long / ulong</returns>
		public static double ParseDouble(string stringToParse, char splitChar)
		{
			double result = 0;

			try
			{
				string[] nums = stringToParse.Split(splitChar);
				int intPart = Int32.Parse(nums[0]);
				double decimalPart = (double)Int32.Parse(nums[1]) / (double)Math.Pow(10, nums[1].Length);

				result = intPart + decimalPart;
			}
			catch
			{
				if (!stringToParse.Contains('.'))
				{
					try
					{
						return Int32.Parse(stringToParse);
					}
					catch
					{
						Console.WriteLine("Error: couldn't covert to float, undefined character.");
					}
				}
			}

			return result;
		}

		/// <summary>
		/// converts string to decimal
		/// </summary>
		/// <param name="n"></param>
		/// <returns>unsigned 64bit long / ulong</returns>
		public static decimal ParseDecimal(string stringToParse)
		{
			decimal result = 0;

			if (!stringToParse.Contains("."))
			{
				return Int32.Parse(stringToParse);
			}

			try
			{
				string[] nums = stringToParse.Split('.');
				int intPart = Int32.Parse(nums[0]);
				decimal decimalPart = (decimal)Int32.Parse(nums[1]) / (decimal)Math.Pow(10, nums[1].Length);

				result = intPart + decimalPart;
			}
			catch
			{
				if (!stringToParse.Contains('.'))
				{
					try
					{
						return Int32.Parse(stringToParse);
					}
					catch
					{
						Console.WriteLine("Error: couldn't covert to float, undefined character.");
					}
				}
			}

			return result;
		}
		/// <summary>
		/// converts string to decimal
		/// </summary>
		/// <param name="n"></param>
		/// <returns>unsigned 64bit long / ulong</returns>
		public static decimal ParseDecimal(string stringToParse, char splitChar)
		{
			decimal result = 0;

			try
			{
				string[] nums = stringToParse.Split(splitChar);
				int intPart = Int32.Parse(nums[0]);
				decimal decimalPart = (decimal)Int32.Parse(nums[1]) / (decimal)Math.Pow(10, nums[1].Length);

				result = intPart + decimalPart;
			}
			catch
			{
				if (!stringToParse.Contains('.'))
				{
					try
					{
						return Int32.Parse(stringToParse);
					}
					catch
					{
						Console.WriteLine("Error: couldn't covert to float, undefined character.");
					}
				}
			}

			return result;
		}

		public static void CartesianToPolar(float x, float y, out float a, out float d)
		{
			a = (float)Math.Atan((y / x));
			if (x < 0)
			{
				a = (float)Math.PI - a;
			}
			d = (float)Math.Sqrt((x * x + y * y));
		}
		public static void CartesianToPolar(float x, float y, out float a)
		{
			a = (float)Math.Atan((y / x));
			if (x < 0)
			{
				a = (float)Math.PI - a;
			}
		}

		public static void PolarToCartesian(float a, float d, out float x, out float y)
		{
			x = (float)Math.Cos(a) * d;
			y = (float)Math.Sin(a) * d;
		}

		public static float RadiansToDegrees(float radians)
		{
			return (float)(radians / (Math.PI / 180));
		}

		public static float DegreesToRadians(float degrees)
		{
			return (float)(degrees * (Math.PI / 180));
		}

		public static double ToBaseTen(double numToSwicht, int correntBase = 2)
		{
			double result = 0;

			double _numToSwicht = numToSwicht;

			if (numToSwicht < 0)
				numToSwicht = -numToSwicht;

			if (numToSwicht % 1 == 0)
			{
				string numText = numToSwicht.ToString();

				for (int dig = numText.Length - 1; dig >= 0; dig--)
				{
					int _dig = Int32.Parse(numText[dig].ToString());
					result += _dig * Math.Pow(correntBase, numText.Length - dig - 1);
				}
			}
			else
			{
				string numText = numToSwicht.ToString();
				string[] parts = numText.Split(',');

				//integer part
				for (int dig = parts[0].Length - 1; dig >= 0; dig--)
				{
					int _dig = Int32.Parse(parts[0][dig].ToString());
					result += _dig * Math.Pow(correntBase, parts[0].Length - dig - 1);
				}

				//decimal part
				for (int dig = parts[1].Length - 1; dig >= 0; dig--)
				{
					int _dig = Int32.Parse(parts[1][dig].ToString());
					result += _dig * Math.Pow(correntBase, -dig - 1);
				}
			}

			if (_numToSwicht < 0)
				return -result;

			return result;
		}

		public static double sigmoid(double x)
		{
			return (1 / (1 + Math.Pow(Math.E, -x)));
		}

		public static float map(float num, float fromMin, float fromMax, float toMin, float toMax)
		{
			return ((num - fromMin) / (fromMax - fromMin)) * (toMax - toMin) + toMin;
		}

		public static float Factorial(float num, int idurations = 100)
		{
			float result = 1;

			if (num % 1 == 0)
			{
				for (int i = (int)num; i > 1; i--)
				{
					result *= i;
				}
			}
			else
			{
				result = GammaFunction(num + 1);
			}
			return result;
		}

		public static float GammaFunction(float num)
		{
			Func<float, float> func = x => (float)(Math.Pow(x, num - 1) * Math.Pow(Math.E, -x));

			return Integral(func, 0.0001f, 30, 10000);
		}

		public static float Integral(Func<float, float> func, float minBounds, float maxBounds, float detail)
		{
			float result = 0;

			detail = 1f / detail;

			for (float x = minBounds; x < maxBounds; x += detail)
			{
				result += func(x) * detail;
			}

			return result;
		}

		public static float Derivative(Func<float, float> func, float x, float accuracy)
		{
			return (func(x + accuracy) - func(x)) / accuracy;
		}

		public static bool isPrime(int num)
		{
			if (num == 2)
				return true;
			if (num <= 1 || num % 2 == 0)
				return false;

			for (int i = 3; i <= Math.Sqrt(num); i += 2)
			{
				if (num % i == 0)
				{
					return false;
				}
			}

			return true;
		}

		public static bool isPrime(uint num)
		{
			if (num == 2)
				return true;
			if (num <= 1 || num % 2 == 0)
				return false;

			for (uint i = 3; i <= Math.Sqrt(num); i += 2)
			{
				if (num % i == 0)
				{
					return false;
				}
			}

			return true;
		}

		public static bool isPrime(long num)
		{
			if (num == 2)
				return true;
			if (num <= 1 || num % 2 == 0)
				return false;

			for (long i = 3; i <= Math.Sqrt(num); i += 2)
			{
				if (num % i == 0)
				{
					return false;
				}
			}

			return true;
		}

		public static bool isPrime(ulong num)
		{
			if (num == 2)
				return true;
			if (num <= 1 || num % 2 == 0)
				return false;

			for (ulong i = 3; i <= Math.Sqrt(num); i += 2)
			{
				if (num % i == 0)
				{
					return false;
				}
			}

			return true;
		}

		public static int[] getPrimeDivisors(int num)
		{
			List<int> result = new List<int>();

			for (int i = 1; i <= num; i++)
			{
				int correntPrime = getNthPrime(i);

				while (num % correntPrime == 0)
				{
					result.Add(correntPrime);
					num /= correntPrime;
				}
			}

			return result.ToArray();
		}

		public static int getNthPrime(int n)
		{
			int numOfPrimes = 0;
			int i = 2;
			while (numOfPrimes < n)
			{
				if (isPrime(i))
				{
					numOfPrimes++;
				}

				i++;
			}

			return --i;
		}

		public static int getSign(float n)
		{
			return n > 0 ? 1 : n < 0 ? -1 : 0;
		}
	}

	class GreenString
	{
		/// <summary>
		/// returns the reverce of a string
		/// </summary>
		/// <param name="stringToRevese"></param>
		/// <returns></returns>
		public static string ReverceString(string stringToRevese)
		{
			string result;
			char[] charsInString = stringToRevese.ToCharArray();
			charsInString = charsInString.Reverse().ToArray();
			result = new string(charsInString);
			return result;
		}

		public static string ArrayToString<T>(T[] arr)
		{
			string result = "[";

			for (int i = 0; i < arr.Length; i++)
			{
				if (i == arr.Length - 1)
				{
					result += arr[i].ToString();
					break;
				}
				result += arr[i].ToString() + ", ";
			}

			return result + "]";
		}
		public static string ListToString<T>(List<T> arr)
		{
			string result = "[";

			for (int i = 0; i < arr.Count; i++)
			{
				if (i == arr.Count - 1)
				{
					result += arr[i].ToString();
					break;
				}
				result += arr[i].ToString() + ", ";
			}

			return result + "]";
		}
		public static string DictionaryToString<K, V>(Dictionary<K, V> dict)
		{
			string result = "{";

			for (int i = 0; i < dict.Count; i++)
			{
				K key = dict.Keys.ToArray()[i];
				if (i == dict.Count - 1)
				{
					result += $"{key}: {dict[key]}";
					break;
				}
				result += $"{key}: {dict[key]}, ";
			}
			return result + "}";
		}

		public static bool is_digit(char character)
		{
			return character >= 48 && character <= 57;
		}
	}

	class Complex
	{
		public float r = 0;
		public float i = 0;
		private Complex _normalized = null;

		private float _abs = -1;

		public Complex(float real, float imaginary, bool precalculate_abs = false, bool precalculate_normalized = false)
		{
			r = real;
			i = imaginary;

			if (precalculate_normalized)
			{
				_normalized = this / abs;
			}

			if (precalculate_abs)
			{
				_abs = (float)Math.Sqrt(r * r + i * i);
			}
		}

		public Complex()
		{
			r = 0;
			i = 0;
		}

		#region algorithms
		public static Complex Add(Complex a, Complex b)
		{
			Complex result = new Complex(0, 0);

			result.r = a.r + b.r;
			result.i = a.i + b.i;

			return result;
		}

		public static Complex Add(float a, Complex b)
		{
			Complex result = new Complex(0, 0);

			result.r = a + b.r;
			result.i = b.i;

			return result;
		}

		public static Complex Add(Complex a, float b)
		{
			Complex result = new Complex(0, 0);

			result.r = b + a.r;
			result.i = a.i;

			return result;
		}

		public static Complex Subtract(Complex a, Complex b)
		{
			Complex result = new Complex(0, 0);

			result.r = a.r - b.r;
			result.i = a.i - b.i;

			return result;
		}

		public static Complex Subtract(Complex a, float b)
		{
			Complex result = new Complex(0, 0);

			result.r = a.r - b;
			result.i = a.i;

			return result;
		}

		public static Complex Subtract(float a, Complex b)
		{
			Complex result = new Complex(0, 0);

			result.r = a - b.r;
			result.i = -b.i;

			return result;
		}

		public static Complex Multiply(Complex a, Complex b)
		{
			return new Complex((a.r * b.r - a.i * b.i), (a.r * b.i + a.i * b.r));
		}

		public static Complex Multiply(Complex a, float b)
		{
			return new Complex(a.r * b, a.i * b);
		}

		public static Complex Multiply(float a, Complex b)
		{
			return new Complex(b.r * a, b.i * a);
		}

		public static Complex Divide(Complex a, Complex b)
		{
			if (b == 0)
			{
				throw new DivideByZeroException();
			}

			return a * new Complex(b.r, -b.i) / (b.r * b.r + b.i * b.i);
		}

		public static Complex Divide(float a, Complex b)
		{
			if (b == 0)
			{
				throw new DivideByZeroException();
			}

			return a * new Complex(b.r, -b.i) / (b.r * b.r + b.i * b.i);
		}

		public static Complex Divide(Complex a, float b)
		{
			if (b == 0)
			{
				throw new DivideByZeroException();
			}
			Complex result = new Complex();

			result.r = a.r / b;
			result.i = a.i / b;

			return result;
		}

		public static Complex Parse(string stringToParse)
		{
			Complex result = new Complex(0, 0);

			stringToParse = stringToParse.Replace(" ", string.Empty);
			string[] parts = stringToParse.Split(',');
			float realPart = GreenMath.ParseFloat(parts[0]);
			float imaginaryPart = GreenMath.ParseFloat(parts[1]);

			result.r = realPart;
			result.i = imaginaryPart;

			return result;
		}

		public static void print(Complex complex)
		{
			string sign;
			float imaginaryPart = complex.i;

			if (complex.i >= 0)
			{
				sign = " + ";
			}
			else
			{
				sign = " - ";
				imaginaryPart *= -1;
			}

			Console.Write(complex.r + sign + imaginaryPart + "i");
		}

		public static void print(Complex complex, CultureInfo cultureInfo)
		{
			string sign;
			float imaginaryPart = complex.i;

			if (imaginaryPart >= 0)
			{
				sign = " + ";
			}
			else
			{
				sign = " - ";
				imaginaryPart *= -1;
			}

			Console.Write(complex.r + sign + imaginaryPart + "i", cultureInfo);
		}

		public static void println(Complex complex)
		{
			string sign;
			float imaginaryPart = complex.i;

			if (imaginaryPart >= 0)
			{
				sign = " + ";
			}
			else
			{
				sign = " - ";
				imaginaryPart *= -1;
			}

			Console.WriteLine(complex.r + sign + imaginaryPart + "i");
		}

		public static void println(Complex complex, CultureInfo cultureInfo)
		{
			string sign;
			float imaginaryPart = complex.i;

			if (imaginaryPart >= 0)
			{
				sign = " + ";
			}
			else
			{
				sign = " - ";
				imaginaryPart *= -1;
			}

			Console.WriteLine(complex.r + sign + imaginaryPart + "i", cultureInfo);
		}

		public static bool containsMandelbrodSet(Complex complex, int iterations)
		{
			Complex z = new Complex(0, 0);

			for (int i = 0; i < iterations; i++)
			{
				z = z * z + complex;

				if (Abs(z) > 2)
				{
					return false;
				}
			}

			return true;
		}

		public static bool containsMandelbrodSet(Complex complex, int idurations, out int exitValue)
		{
			Complex z = new Complex(0, 0);

			for (int i = 0; i < idurations; i++)
			{
				z = Add(Pow(z, 2), complex);

				if (Abs(z) > 2)
				{
					exitValue = i;
					return false;
				}
			}

			exitValue = idurations;
			return true;
		}

		public static List<Complex> MandelbrodSetEscapingPoints(Complex complex, int iterations)
		{
			Complex z = new Complex(0, 0);

			List<Complex> result = new List<Complex>();

			for (int i = 0; i < iterations; i++)
			{
				z = Add(Pow(z, 2), complex);

				result.Add(new Complex((float)Math.Floor((Multiply(z, new Complex(300, 0))).r), (float)Math.Round(Multiply(z, new Complex(300, 0)).i)));
				if (Abs(z) >= 2)
				{
					return result;
				}
			}

			return new List<Complex>();
		}

		public static bool containsJuliaSet(Complex z, Complex c, int iterations)
		{
			for (int i = 0; i < iterations; i++)
			{
				z = Add(Pow(z, 2), c);

				if (Abs(z) > 2)
				{
					return false;
				}
			}

			return true;
		}

		public static bool containsJuliaSet(Complex z, Complex c, int iterations, out int exitValue)
		{
			for (int i = 0; i < iterations; i++)
			{
				z = Add(Pow(z, 2), c);

				if (Abs(z) > 2)
				{
					exitValue = i;
					return false;
				}
			}

			exitValue = iterations;
			return true;
		}

		public static double Abs(Complex complex)
		{
			return Math.Sqrt(complex.r * complex.r + complex.i * complex.i);
		}

		public static Complex Normalize(Complex complex)
		{
			Complex result = new Complex();

			float ra;
			float rd;
			GreenMath.CartesianToPolar(complex.r, complex.i, out ra, out rd);
			GreenMath.PolarToCartesian(ra, 1, out result.r, out result.i);

			return complex;
		}

		public static Complex Pow(Complex Base, float Exponent)
		{
			return exp(ln(Base) * Exponent);
		}

		public static Complex Pow(float Base, Complex Exponent)
		{
			if (Base == 0)
				return new Complex();
			return exp(Exponent * Math.Log(Base));
		}

		public static Complex Pow(Complex Base, Complex Exponent)
		{
			Complex result = new Complex();
			Complex realPart = new Complex();
			realPart = Pow(Base, Exponent.r);

			Complex imaginaryPart = new Complex();
			imaginaryPart = Pow((float)Math.E, Multiply(ln(Base), new Complex(0, Exponent.i)));

			result = Multiply(imaginaryPart, realPart);
			return result;
		}

		public static Complex exp(Complex exponent)
		{
			return Math.Pow(Math.E, exponent.r) * new Complex((float)Math.Cos(exponent.i), (float)Math.Sin(exponent.i));
		}

		public static Complex ln(Complex complex)
		{
			/* old argorithm (slow)
			Complex result = new Complex();
			float a;
			float d;

			GreenMath.CartesianToPolar(complex.r, complex.i, out a, out d);
			result.i = a;
			result.r = (float)Math.Log(d);

			return result;
			*/

			//new algorithm (faster)
			return 0.5f * Math.Log(complex.r * complex.r + complex.i * complex.i) + new Complex(0, 1) * complex.Arg();
		}

		public static Complex Log10(Complex complex)
		{
			return ln(complex) / GreenMath.ln10;
		}

		public static Complex Log(Complex complex, float Base = GreenMath.E)
		{
			return ln(complex) / Math.Log(Base);
		}

		public static string ToString(Complex complex)
		{
			string result = "";
			string sign;

			float imaginaryPart = complex.i;

			if (imaginaryPart >= 0)
			{
				sign = " + ";
			}
			else
			{
				sign = " - ";
				imaginaryPart *= -1;
			}

			result += complex.r.ToString();
			result += sign;
			result += imaginaryPart.ToString();
			result += "i";

			return result;
		}

		public static Complex cos(Complex complex)
		{
			Complex result;

			result = Divide(Add(Pow((float)Math.E, Multiply(complex, new Complex(0, 1))), Pow((float)Math.E, Multiply(Multiply(complex, new Complex(0, 1)), new Complex(-1, 0)))), new Complex(2, 0));

			return result;
		}

		public static Complex sin(Complex complex)
		{
			Complex result;

			result = Divide(Subtract(Pow((float)Math.E, Multiply(complex, new Complex(0, 1))), Pow((float)Math.E, Multiply(Multiply(complex, new Complex(0, 1)), new Complex(-1, 0)))), Multiply(new Complex(2, 0), new Complex(0, 1)));

			result = Multiply(result, new Complex(-1, 0));

			return result;
		}

		public static Complex tan(Complex complex)
		{
			return Divide(sin(complex), cos(complex));
		}

		public static Complex asin(Complex complex)
		{
			return new Complex(0, 1) * ln(Sqrt(1 - Pow(complex, 2)) + complex * new Complex(0, 1));
		}

		public static Complex acos(Complex complex)
		{
			return asin(complex) + Math.PI / 2;
		}

		public static Complex atan(Complex complex)
		{
			return new Complex(0, 0.5f) * (ln(1 + new Complex(0, 1) * complex) - ln(1 - new Complex(0, 1) * complex));
		}

		public static Complex Sqrt(Complex complex)
		{
			return Pow(complex, 0.5f);
		}

		public static Complex[] Roots(Complex complex, int root)
		{
			Complex[] results = new Complex[root];

			for (int j = 0; j < root; j++)
			{
				Complex result = new Complex();

				GreenMath.PolarToCartesian((complex.Arg() + GreenMath.PI * j) / root, complex.abs, out result.r, out result.i);

				results[j] = result;
			}

			return results;
		}

		#endregion

		#region opperators
		public static Complex operator +(Complex c) => c;
		public static Complex operator -(Complex c) => Multiply(c, -1);

		public static Complex operator +(Complex a, Complex b) => Add(a, b);
		public static Complex operator +(float a, Complex b) => Add(a, b);
		public static Complex operator +(Complex a, float b) => Add(a, b);
		public static Complex operator +(Complex a, int b) => Add(a, b);
		public static Complex operator +(int a, Complex b) => Add(a, b);
		public static Complex operator +(Complex a, double b) => Add(a, (float)b);
		public static Complex operator +(double a, Complex b) => Add((float)a, b);
		public static Complex operator +(Complex a, decimal b) => Add(a, (float)b);
		public static Complex operator +(decimal a, Complex b) => Add((float)a, b);

		public static Complex operator -(Complex a, Complex b) => Subtract(a, b);
		public static Complex operator -(float a, Complex b) => Subtract(a, b);
		public static Complex operator -(Complex a, float b) => Subtract(a, b);
		public static Complex operator -(Complex a, int b) => Subtract(a, b);
		public static Complex operator -(int a, Complex b) => Subtract(a, b);
		public static Complex operator -(Complex a, double b) => Subtract(a, (float)b);
		public static Complex operator -(double a, Complex b) => Subtract((float)a, b);
		public static Complex operator -(Complex a, decimal b) => Subtract(a, (float)b);
		public static Complex operator -(decimal a, Complex b) => Subtract((float)a, b);

		public static Complex operator *(Complex a, Complex b) => Multiply(a, b);
		public static Complex operator *(Complex a, float b) => Multiply(a, b);
		public static Complex operator *(float a, Complex b) => Multiply(a, b);
		public static Complex operator *(int a, Complex b) => Multiply(a, b);
		public static Complex operator *(Complex a, int b) => Multiply(a, b);
		public static Complex operator *(double a, Complex b) => Multiply((float)a, b);
		public static Complex operator *(Complex a, double b) => Multiply(a, (float)b);
		public static Complex operator *(decimal a, Complex b) => Multiply((float)a, b);
		public static Complex operator *(Complex a, decimal b) => Multiply(a, (float)b);

		public static Complex operator /(Complex a, Complex b) => Divide(a, b);
		public static Complex operator /(float a, Complex b) => Divide(a, b);
		public static Complex operator /(Complex a, float b) => Divide(a, b);
		public static Complex operator /(int a, Complex b) => Divide(a, b);
		public static Complex operator /(Complex a, int b) => Divide(a, b);
		public static Complex operator /(double a, Complex b) => Divide((float)a, b);
		public static Complex operator /(Complex a, double b) => Divide(a, (float)b);
		public static Complex operator /(decimal a, Complex b) => Divide((float)a, b);
		public static Complex operator /(Complex a, decimal b) => Divide(a, (float)b);

		public static bool operator ==(Complex a, Complex b)
		{
			if (b == null)
				return a is null;
			if (a.r == b.r && a.i == b.i)
			{
				return true;
			}

			return false;
		}
		public static bool operator !=(Complex a, Complex b)
		{
			if (b == null)
				return !(a is null);
			if (a.r == b.r && a.i == b.i)
			{
				return false;
			}

			return true;
		}

		public static bool operator ==(float a, Complex b)
		{
			if (a == b.r && 0 == b.i)
			{
				return true;
			}

			return false;
		}
		public static bool operator !=(float a, Complex b)
		{
			if (a == b.r && 0 == b.i)
			{
				return false;
			}

			return true;
		}

		public static bool operator ==(Complex a, float b)
		{
			if (a.r == b && a.i == 0)
			{
				return true;
			}

			return false;
		}
		public static bool operator !=(Complex a, float b)
		{
			if (a.r == b && a.i == 0)
			{
				return false;
			}

			return true;
		}
		#endregion

		public override string ToString()
		{
			return ToString(new Complex(r, i));
		}

		public float Arg()
		{
			float angle = (float)Math.Atan(i / r);

			if (r > 0)
				return angle * GreenMath.getSign(r);
			else if (r < 0)
			{
				if (i != 0)
					return angle + GreenMath.PI * GreenMath.getSign(i);
				else
					return GreenMath.PI;
			}
			else
				return GreenMath.PI / 2 * GreenMath.getSign(i);
		}

		public float abs
		{
			get
			{
				if (_abs == -1)
					return (float)Math.Sqrt(r * r + i * i);
				else
					return _abs;
			}
		}

		public Complex normalized
		{
			get
			{
				if (!(_normalized is null))
					return _normalized;
				else
					return this / abs;
			}
		}

		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}

	class Vector2
	{
		public float x;
		public float y;

		public float magnetude
		{
			get
			{
				return (float)Math.Sqrt(x * x + y * y);
			}
			set
			{
				float multiplier = value / (float)Math.Sqrt(x * x + y * y);
				x *= multiplier;
				y *= multiplier;
			}
		}

		public float angle
		{
			get
			{
				float angle = (float)Math.Atan(y / x);

				if (x > 0)
					return angle * GreenMath.getSign(x);
				else if (x < 0)
				{
					if (x != 0)
						return angle + GreenMath.PI * GreenMath.getSign(x);
					else
						return GreenMath.PI;
				}
				else
					return GreenMath.PI / 2 * GreenMath.getSign(y);
			}
		}

		public Vector2(float _x, float _y)
		{
			x = _x;
			y = _y;
		}

		public Vector2()
		{
			x = 0;
			y = 0;
		}

		public static Vector2 Add(Vector2 v1, Vector2 v2)
		{
			return new Vector2(v1.x + v2.x, v1.y + v2.y);
		}
		public static Vector2 Subtract(Vector2 v1, Vector2 v2)
		{
			return new Vector2(v1.x - v2.x, v1.y - v2.y);
		}

		public static Vector2 Multiply(Vector2 v, float m)
		{
			return new Vector2(v.x * m, v.y * m);
		}
		public static Vector2 Multiply(float m, Vector2 v)
		{
			return new Vector2(v.x * m, v.y * m);
		}
		public static Vector2 Divide(Vector2 v, float d)
		{
			return new Vector2(v.x / d, v.y / d);
		}
		public static float Dot(Vector2 v1, Vector2 v2)
		{
			return v1.x * v2.x + v1.y + v2.y;
		}
		public static float Angle(Vector2 v1, Vector2 v2)
		{
			//return (float)Math.Acos(((v1 - v2).x * (v1 - v2).x + (v1 - v2).y * (v1 - v2).y - v1.x * v1.x - v1.y * v1.y - v2.x * v2.x - v2.y * v2.y) / (-2 * Math.Sqrt((v1.x * v1.x + v1.y * v1.y) * (v2.x * v2.x + v2.y * v2.y))));
			return v1.angle - v2.angle;
		}
		public static float Cross(Vector2 v1, Vector2 v2)
		{
			return v1.magnetude * v2.magnetude * (float)Math.Sin(Angle(v1, v2));
		}

		public static Vector2 Multiply(Vector2 v1, Matrix2x2 matrix)
		{
			return v1.x * new Vector2(matrix[0, 0], matrix[1, 0]) + v1.y * new Vector2(matrix[0, 1], matrix[1, 1]);
		}
		public static Vector2 Multiply(Matrix2x2 matrix, Vector2 v1)
		{
			return v1.x * new Vector2(matrix[0, 0], matrix[1, 0]) + v1.y * new Vector2(matrix[0, 1], matrix[1, 1]);
		}

		public override string ToString()
		{
			return $"[{x}, {y}]";
		}

		public static Vector2 operator +(Vector2 v1, Vector2 v2) => Add(v1, v2);
		public static Vector2 operator -(Vector2 v1, Vector2 v2) => Subtract(v1, v2);
		public static Vector2 operator *(Vector2 v, float m) => Multiply(v, m);
		public static Vector2 operator *(float m, Vector2 v) => Multiply(v, m);
		public static Vector2 operator *(Matrix2x2 m, Vector2 v) => Multiply(v, m);
		public static Vector2 operator *(Vector2 v, Matrix2x2 m) => Multiply(v, m);
		public static Vector2 operator /(Vector2 v, float d) => Divide(v, d);

		public static explicit operator Complex(Vector2 v)
		{
			return new Complex(v.x, v.y);
		}

		public static explicit operator Vector2(Complex c)
		{
			return new Vector2(c.r, c.i);
		}

		public static bool operator ==(Vector2 v1, Vector2 v2)
		{
			return v1.x == v2.x && v1.y == v2.y;
		}

		public static bool operator !=(Vector2 v1, Vector2 v2)
		{
			return v1.x != v2.x || v1.y != v2.y;
		}
	}

	class Matrix2x2
	{
		public float[,] values = new float[2, 2];

		public float det
		{
			get
			{
				return values[0, 0] * values[1, 1] - values[1, 0] * values[0, 1];
			}
		}

		public Matrix2x2(float[,] _values)
		{
			values = _values;
		}

		public Matrix2x2(float A1, float B1, float A2, float B2)
		{
			values[0, 0] = A1;
			values[1, 0] = B1;
			values[0, 1] = A2;
			values[1, 1] = B2;
		}

		public Matrix2x2()
		{
			values[0, 0] = 0;
			values[1, 0] = 0;
			values[0, 1] = 0;
			values[1, 1] = 0;
		}

		public static Matrix2x2 exp(Matrix2x2 m, int iterations = 10)
		{
			Matrix2x2 result = new Matrix2x2();

			for (int i = 0; i < iterations; i++)
			{
				result = Add(result,
							 Multiply(
								 intPow(m, i),
								 1 / GreenMath.Factorial(i)
								)
							 );
			}

			return result;
		}

		public static Matrix2x2 intPow(Matrix2x2 m, int pow)
		{
			Matrix2x2 result = m;

			if (pow == 0)
				return new Matrix2x2(1, 0, 0, 1);

			for (int i = 0; i < pow - 1; i++)
			{
				result = Multiply(result, m);
			}

			return result;
		}

		public static Matrix2x2 Multiply(Matrix2x2 m1, Matrix2x2 m2)
		{
			return new Matrix2x2(m1[0, 0] * m2[0, 0] + m1[1, 0] * m2[0, 1],
								 m1[0, 0] * m2[1, 0] + m1[1, 0] * m2[1, 1],
								 m1[0, 1] * m2[0, 0] + m1[1, 1] * m2[0, 1],
								 m1[0, 1] * m2[1, 0] + m1[1, 1] * m2[1, 1]);
		}

		public static Matrix2x2 Multiply(Matrix2x2 m, float x)
		{
			m[0, 0] *= x;
			m[1, 0] *= x;
			m[0, 1] *= x;
			m[1, 1] *= x;
			return m;
		}

		public static Matrix2x2 Add(Matrix2x2 m1, Matrix2x2 m2)
		{
			m1[0, 0] += m2[0, 0];
			m1[1, 0] += m2[1, 0];
			m1[0, 1] += m2[0, 1];
			m1[1, 1] += m2[1, 1];

			return m1;
		}

		public override string ToString()
		{
			return $"[[{values[0, 0]}, {values[1, 0]}]\n [{values[0, 1]}, {values[1, 1]}]]";
		}

		public float this[int x, int y]
		{
			get
			{
				return values[x, y];
			}
			set
			{
				values[x, y] = value;
			}
		}
	}
}