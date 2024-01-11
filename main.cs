using System;
using System.Management.Automation;
namespace pwshtest
{
	class pwshtest
	{
		static void Main()
		{
			string source = @"$a=0;$input|%{$a += $_};Write-Output $a";

			using (var invoker = new RunspaceInvoke())
			{
				var result = invoker.Invoke(source, new[] { 1, 2, 3, 4 });
				//result の型を int[] に変換する
				var resultArray = (int)result[0].BaseObject;
				Console.WriteLine(resultArray);
			}
		}
	}
}