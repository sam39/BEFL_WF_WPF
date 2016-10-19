using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPF.Infrastrucrure;


namespace WPF.ViewModels
{
    class empsViewModel : ViewModelBase 
    {
        BL.UnitOfWork UoW = new BL.UnitOfWork();

        BL.Emp _currentEmp;
        public BL.Emp CurrentEmp
        {
            get
            {
                if (_currentEmp == null)
                    _currentEmp = new BL.Emp();
                return _currentEmp;
            }
            set
            {
                _currentEmp = value;
                OnPropertyChanged("CurrentEmp");
            }
        }

        ObservableCollection<BL.Emp> _emps;
        public ObservableCollection<BL.Emp> Emps
        {
            get
            {
                if (_emps == null)
                    _emps = new ObservableCollection<BL.Emp>(UoW.EmpRepository.GetAll());
                return _emps;
            }
        }

        ObservableCollection<BL.Pos> _poss;
        public ObservableCollection<BL.Pos> Poss
        {
            get
            {
                if (_poss == null)
                    _poss = UoW.PosRepository.GetAll() as ObservableCollection<BL.Pos>;
                return _poss;
            }
        }

        ObservableCollection<BL.Dep> _deps;
        public ObservableCollection<BL.Dep> Deps
        {
            get
            {
                if (_deps == null)
                    _deps = UoW.DivisionRepository.GetAll() as ObservableCollection<BL.Dep>;
                return _deps;
            }
        }



        RelayCommand _saveEmpCommand;
        public ICommand SaveEmp
        {
            get
            {
                if (_saveEmpCommand == null)
                    _saveEmpCommand = new RelayCommand(ExecuteSaveEmpCommand, CanExecuteAddClientCommand);
                return _saveEmpCommand;
            }
        }

        RelayCommand _addEmpCommand;
        public ICommand AddEmp
        {
            get
            {
                if (_addEmpCommand == null)
                    _addEmpCommand = new RelayCommand(ExecuteAddClientCommand, CanExecuteAddClientCommand);
                return _addEmpCommand;
            }
        }

        public void ExecuteSaveEmpCommand(object parameter)
        {
            UoW.Save();
            //Clients.Add(CurrentClient);
            //CurrentClient = null;
        }

        public void ExecuteAddClientCommand(object parameter)
        {
            Emps.Add(CurrentEmp);
            //Clients.Add(CurrentClient);
            //CurrentClient = null;
        }

        public bool CanExecuteAddClientCommand(object parameter)
        {
            //if (string.IsNullOrEmpty(CurrentClient.FirstName) ||
            //    string.IsNullOrEmpty(CurrentClient.LastName))
            //    return false;
            return true;
        }

        protected override void OnDispose()
        {
            //this.Clients.Clear();
        }

    }
}
