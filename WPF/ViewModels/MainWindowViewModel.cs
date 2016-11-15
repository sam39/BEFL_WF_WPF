using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF.Infrastrucrure;

namespace WPF.ViewModels
{
    class MainWindowViewModel
    {
        RelayCommand _editCommand;
        public ICommand EditEmp
        {
            get
            {
                if (_editCommand == null)
                    _editCommand = new RelayCommand(ExecuteEditEmpCommand, CanExecuteEditEmpCommand);
                return _editCommand;
            }
        }

        public void ExecuteEditEmpCommand(object parameter)
        {
            //EditMode = true;
        }

        public bool CanExecuteEditEmpCommand(object parametr)
        {
            return true;
        }



    }
}
