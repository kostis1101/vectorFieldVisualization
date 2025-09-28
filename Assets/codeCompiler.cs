using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.CSharp;
using UnityEngine;

public static class codeCompiler
{

	static MethodInfo mi;
	static object o;

	public static void CompileCode(string source)
	{
		Debug.LogError("Hellooooo");

		Dictionary<string, string> providerOptions = new Dictionary<string, string>
				{
					{"CompilerVersion", "v3.5"}
				};
		CSharpCodeProvider provider = new CSharpCodeProvider(providerOptions);

		CompilerParameters compilerParams = new CompilerParameters
		{
			GenerateInMemory = true,
			GenerateExecutable = false
		};

		CompilerResults results = provider.CompileAssemblyFromSource(compilerParams, source);

		if (results.Errors.Count != 0)
		{
			Debug.Log("We have got an error:");
			foreach (var e in results.Errors)
			{
				Debug.Log(e.ToString());
			}
		}

		Debug.Log("code has compiled successfully");
		Debug.Log(o);
		Debug.Log(mi);

		o = results.CompiledAssembly.CreateInstance("MyClass");
		mi = o.GetType().GetMethod("MyMethod");
	}

	public static object RunCode(float x, float y)
	{
		object[] param =
		{
			x, y
		};

		Debug.LogError("what???");

		return mi.Invoke(o, param);
	}
}
