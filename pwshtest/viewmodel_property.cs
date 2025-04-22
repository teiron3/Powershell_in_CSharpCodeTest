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

 namespace pwtest
{ public partial class ViewModel{
 		private string _pwshscript = "";
        public string pwshscript{
            get{ return _pwshscript;}
            set{
                if(_pwshscript == value){
                    return;
                }else{
                    _pwshscript = value;
		    Application.Current.Dispatcher.Invoke(
                     () => NotifyPropertyChanged("pwshscript")
                    );
                }
            }
        }
		private string _result = "";
        public string result{
            get{ return _result;}
            set{
                if(_result == value){
                    return;
                }else{
                    _result = value;
		    Application.Current.Dispatcher.Invoke(
                     () => NotifyPropertyChanged("result")
                    );
                }
            }
        }
	}
}
