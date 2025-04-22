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

namespace pwtest{
    public partial class ViewModel{
        private ICommand _executePwsh; public ICommand executePwsh{
            get{
                if(_executePwsh == null){
                    _executePwsh = new MakeCommandClass(this, new Func<ViewModel, object, Task>(MethodClass.executePwsh));
                }
                return _executePwsh;
            }
        } 	}
}
