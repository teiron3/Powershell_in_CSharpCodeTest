using System;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

namespace pwtest
{
	public static partial class MethodClass
	{
		public static async Task executePwsh(ViewModel vm, object parameter)
		{
			try
			{
				using (var runspace = RunspaceFactory.CreateRunspace())
				{
					runspace.Open();
					using (var ps = PowerShell.Create())
					{
						vm.result = string.Empty;
						ps.Runspace = runspace;
						ps.AddScript(vm.pwshscript);
						var results = await Task.Run(() => ps.Invoke());
						foreach (var result in results)
						{
							vm.result += result + Environment.NewLine;
						}
					}
				}
			}
			catch (Exception ex)
			{
				vm.result = ex.ToString();
			}
		}
	}
}

