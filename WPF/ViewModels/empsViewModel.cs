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

        public bool EditMode { get; set;}

        BL.Emp _currentEmp;
        public BL.Emp CurrentEmp
        {
            get
            {
                if (_currentEmp == null)
                    _currentEmp = new BL.Emp{LastName = "" };
                return _currentEmp;
            }
            set
            {
                _currentEmp = value;
                OnPropertyChanged("CurrentEmp");
            }
        }

        int _selectedRow = 3;
        public int SelectedRow
        {   
            get
            {
                return _selectedRow;
            }
            set
            {
                _selectedRow = value;
            }
        }

        BL.Emp _selectedEmp;
        public BL.Emp SelectedEmp
        {
            get
            {
                return _selectedEmp;
            }
            set
            {
                _selectedEmp = value;
                OnPropertyChanged("SelectedEmp");
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
                    _poss = new ObservableCollection<BL.Pos>(UoW.PosRepository.GetAll());
                return _poss;
            }
        }

        ObservableCollection<BL.Dep> _deps;
        public ObservableCollection<BL.Dep> Deps
        {
            get
            {
                if (_deps == null)
                    _deps = new ObservableCollection<BL.Dep>(UoW.DivisionRepository.GetAll());
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

        RelayCommand _searchCommand;
        public ICommand Search
        {
            get
            {
                if (_searchCommand == null)
                    _searchCommand = new RelayCommand(ExecuteSearchCommand, CanExecuteSearchCommand);
                return _searchCommand;
            }
        }

        RelayCommand _deleteCommand;
        public ICommand DeleteEmp
        {
            get
            {
                if (_deleteCommand == null)
                    _deleteCommand = new RelayCommand(ExecuteDeleteEmpCommand, CanExecuteDeleteClientCommand);
                return _deleteCommand;
            }
        }

        public void ExecuteDeleteEmpCommand(object parameter)
        {
            BL.Emp empToDel = parameter as BL.Emp;
            Emps.Remove(empToDel);
            UoW.EmpRepository.Delete(empToDel);
            OnPropertyChanged("Emps");
        }

        public bool CanExecuteDeleteClientCommand(object parametr)
        {
            return true;
        }


        public void ExecuteSaveEmpCommand(object parameter)
        {
            UoW.Save();
            OnPropertyChanged("Emps");
        }

        public void ExecuteAddClientCommand(object parameter)
        {
            BL.Emp emp = new BL.Emp();
            emp.DepId = 1;
            emp.PosId = 1;
            Emps.Add(emp);
            UoW.EmpRepository.Insert(emp);
            SelectedEmp = emp;
            OnPropertyChanged("SelectedEmp");
            EditMode = true;
            OnPropertyChanged("EditMode");
            //OnPropertyChanged("Emps");
        }

        public void ExecuteSearchCommand(object parameter)
        {
            //_emps.Where(s => s.LastName.Contains(CurrentEmp.LastName));

            //_emps = new ObservableCollection<BL.Emp>(UoW.EmpRepository.Get(filter: emp => emp.LastName.Contains("Анц")));
            //Emps.Add(new BL.Emp());
        }


        public bool CanExecuteAddClientCommand(object parameter)
        {
            //if (string.IsNullOrEmpty(CurrentClient.FirstName) ||
            //    string.IsNullOrEmpty(CurrentClient.LastName))
            //    return false;
            return true;
        }

        public bool CanExecuteSearchCommand(object parametr)
        {
            return true;
        }


        protected override void OnDispose()
        {
            //this.Clients.Clear();
        }

    }
}
