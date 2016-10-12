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

        IEnumerable <BL.Emp> _emps;
        public IEnumerable<BL.Emp> Emps
        {
            get
            {
                if (_emps == null)
                    _emps = UoW.EmpRepository.GetAll();
                return _emps;
            }
        }

        IEnumerable<BL.Pos> _poss;
        public IEnumerable<BL.Pos> Poss
        {
            get
            {
                if (_poss == null)
                    _poss = UoW.PosRepository.GetAll();
                return _poss;
            }
        }

        IEnumerable<BL.Dep> _deps;
        public IEnumerable<BL.Dep> Deps
        {
            get
            {
                if (_deps == null)
                    _deps = UoW.DivisionRepository.GetAll();
                return _deps;
            }
        }



        RelayCommand _addClientCommand;
        public ICommand AddClient
        {
            get
            {
                if (_addClientCommand == null)
                    _addClientCommand = new RelayCommand(ExecuteAddClientCommand, CanExecuteAddClientCommand);
                return _addClientCommand;
            }
        }

        public void ExecuteAddClientCommand(object parameter)
        {
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
