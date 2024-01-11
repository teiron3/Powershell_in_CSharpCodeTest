using System;
using System.Management.Automation;
namespace pwshtest
{
	class pwshtest
	{
		static void Main()
		{
			string source01 = @"$a=4";
			string source02 = @"$a + 5";
			string source03 = @"$input|%{$a+=$_};$a";

			string source04 = @"$input|%{$a+$_}";

			using (var invoker = new RunspaceInvoke())
			{
				invoker.Invoke(source01, null);
				invoker.Invoke(source02, null);
				var result = invoker.Invoke(source03, new[] { 1, 2, 3, 100 });
				//result の型を int[] に変換する
				var resultArray = (int)result[0].BaseObject;
				Console.WriteLine(resultArray);


				var result02 = invoker.Invoke(source04, new[] { 1, 2, 3, 5 });
				foreach (var item in result02)
				{
					Console.WriteLine(item);
				}
			}
		}
	}
}