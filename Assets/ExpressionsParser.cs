using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using UnityEngine;

namespace GreenElephant
{
	class Expression
	{
		static Dictionary<string, Func<float, float>> functions = new Dictionary<string, Func<float, float>>
		{
			["ln"] = x => (float)Math.Log(x),
			["sin"] = x => (float)Math.Sin(x),
			["cos"] = x => (float)Math.Cos(x),
			["tan"] = x => (float)Math.Tan(x),
			["log10"] = x => (float)Math.Log10(x),
			["log"] = x => (float)Math.Log(x),
			["asin"] = x => (float)Math.Asin(x),
			["acos"] = x => (float)Math.Acos(x),
			["atan"] = x => (float)Math.Atan(x),
			["arcsin"] = x => (float)Math.Asin(x),
			["arccos"] = x => (float)Math.Acos(x),
			["arctan"] = x => (float)Math.Atan(x),
			["exp"] = x => (float)Math.Exp(x),
			["sign"] = x => Math.Sign(x),
			["floor"] = x => (float)Math.Floor(x),
			["ceil"] = x => (float)Math.Ceiling(x),
			["round"] = x => (float)Math.Round(x)
		};

		public static Dictionary<string, float> variables = new Dictionary<string, float>
		{
			["x"] = 10,
			["y"] = 23.4f,
			["pi"] = (float)Math.PI,
			["e"] = (float)Math.E
		};

		public virtual float evaluate()
		{
			return float.PositiveInfinity;
		}

		public static Expression ParseExpression(string str)
		{
			str = prepare_for_parse(str);

			int brackets = 0;
			for (int i = 0; i < str.Length; i++)
			{
				char c = str[i];

				switch (c)
				{
					case '(':
						brackets++;
						break;
					case ')':
						brackets--;
						break;
				}

				if (brackets == 0)
				{
					switch (c)
					{
						case '+':
							return new Add(str.Substring(0, i), str.Substring(i + 1));
						case '-':
							return new Sub(str.Substring(0, i), str.Substring(i + 1));
					}
				}
			}

			brackets = 0;
			for (int i = 0; i < str.Length; i++)
			{
				char c = str[i];

				switch (c)
				{
					case '(':
						brackets++;
						break;
					case ')':
						brackets--;
						break;
				}

				if (brackets == 0)
				{
					switch (c)
					{
						case '*':
							return new Mult(str.Substring(0, i), str.Substring(i + 1));
						case '-':
							return new Div(str.Substring(0, i), str.Substring(i + 1));
					}
				}
			}

			brackets = 0;
			for (int i = 0; i < str.Length; i++)
			{
				char c = str[i];

				switch (c)
				{
					case '(':
						brackets++;
						break;
					case ')':
						brackets--;
						break;
				}

				if (brackets == 0)
				{
					switch (c)
					{
						case '^':
							return new Pow(str.Substring(0, i), str.Substring(i + 1));
					}
				}
			}

			if (str.Contains('(') && !GreenString.is_digit(str[0]) && str[0] != '(')
			{
				string func_name = str.Split('(')[0];

				Func<float, float> func = functions[func_name];

				return new Function(func, str.Substring(func_name.Length));
			}

			if (!GreenString.is_digit(str[0]))
			{
				return new Variable(str);
			}
			#region old number code
			/*			brackets = 0;
						string number = String.Empty;
						for (int i = 0; i < str.Length; i++)
						{
							char c = str[i];

							switch (c)
							{
								case '(':
									brackets++;
									break;
								case ')':
									brackets--;
									break;
							}

							if (brackets == 0)
							{
								if ((c >= 48 && c <= 57) *//*check if c is digit*//* || c == '.')
								{
									number += c;
								}
							}
						}*/
			#endregion
			return new Number(GreenMath.ParseFloat(str));
		}

		public static string prepare_for_parse(string str)
		{
			str = str.Replace(" ", "");

			int brackets_start = 0;
			int brackets_end = 0;

			foreach (char c in str)
			{
				if (c == '(')
					brackets_start++;
				else break;
			}

			for (int i = str.Length - 1; i >= 0; i--)
			{
				if (str[i] == ')')
					brackets_end++;
				else break;
			}


			int brackets = Math.Min(brackets_start, brackets_end);

			str = str.Substring(brackets, str.Length - 2 * brackets);
			for (int i = 0; i < str.Length; i++)
			{
				if (str[i] == '-' && !is_expression(str[i + 1]) && (i == 0 || is_expression(str[i - 1])))
				{
					if (str[i + 1] == '(')
					{
						brackets = 1;
						string _exp = "(";
						foreach (char _c in str.Substring(i + 2))
						{
							switch (_c)
							{
								case '(':
									brackets++;
									break;
								case ')':
									brackets--;
									break;
							}
							_exp += _c;
							if (brackets == 0) break;
						}
						str = str.Substring(0, i) + $"(0-{_exp})" + str.Substring(_exp.Length + 1 + i);
					}
					else
					{
						string number = str[i + 1].ToString();
						foreach (char _c in str.Substring(i + 2))
						{
							if (GreenString.is_digit(_c) || _c == '.')
								number += _c;
							else break;
						}
						str = str.Substring(0, i) + $"(0-{number})" + str.Substring(number.Length + i + 1);
					}
				}
			}

			brackets_start = 0;
			brackets_end = 0;

			foreach (char c in str)
			{
				if (c == '(')
					brackets_start++;
				else break;
			}

			for (int i = str.Length - 1; i >= 0; i--)
			{
				if (str[i] == ')')
					brackets_end++;
				else break;
			}


			brackets = Math.Min(brackets_start, brackets_end);

			str = str.Substring(brackets, str.Length - 2 * brackets);


			return str;
		}
		public static bool is_expression(char c)
		{
			char[] expressions =
			{
				'+', '-', '*', '/', '^'
			};
			return expressions.Contains(c);//c == 42 || c == 43 || c == 45 || c == 47;
		}
	}

	class Add : Expression
	{
		Expression exp1;
		Expression exp2;

		public Add(string _exp1, string _exp2)
		{
			exp1 = ParseExpression(_exp1);
			exp2 = ParseExpression(_exp2);
		}

		public override float evaluate()
		{
			return exp1.evaluate() + exp2.evaluate();
		}
	}

	class Sub : Expression
	{
		Expression exp1;
		Expression exp2;

		public Sub(string _exp1, string _exp2)
		{
			exp1 = ParseExpression(_exp1);
			exp2 = ParseExpression(_exp2);
		}

		public override float evaluate()
		{
			return exp1.evaluate() - exp2.evaluate();
		}
	}

	class Mult : Expression
	{
		Expression exp1;
		Expression exp2;

		public Mult(string _exp1, string _exp2)
		{
			exp1 = ParseExpression(_exp1);
			exp2 = ParseExpression(_exp2);
		}

		public override float evaluate()
		{
			return exp1.evaluate() * exp2.evaluate();
		}
	}

	class Div : Expression
	{
		Expression exp1;
		Expression exp2;

		public Div(string _exp1, string _exp2)
		{
			exp1 = ParseExpression(_exp1);
			exp2 = ParseExpression(_exp2);
		}

		public override float evaluate()
		{
			return exp1.evaluate() / exp2.evaluate();
		}
	}
	class Pow : Expression
	{
		Expression exp1;
		Expression exp2;

		public Pow(string _exp1, string _exp2)
		{
			exp1 = ParseExpression(_exp1);
			exp2 = ParseExpression(_exp2);
		}

		public override float evaluate()
		{
			return (float)Math.Pow(exp1.evaluate(), exp2.evaluate());
		}
	}

	class Number : Expression
	{
		float value;

		public Number(float _value)
		{
			value = _value;
		}

		public override float evaluate()
		{
			return value;
		}
	}

	class Function : Expression
	{
		Expression exp;
		Func<float, float> function;

		public Function(Func<float, float> _func, string _exp)
		{
			exp = ParseExpression(_exp);
			function = _func;
		}

		public override float evaluate()
		{
			return function(exp.evaluate());
		}
	}

	class Variable : Expression
	{
		string name;

		public Variable(string _name)
		{
			name = _name;
		}

		public override float evaluate()
		{
			return variables[name];
		}
	}

}
