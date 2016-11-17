using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPF.Infrastrucrure;
using System.ComponentModel;
using System.Windows.Data;
using GalaSoft.MvvmLight.Messaging;

namespace WPF.ViewModels
{
    class empsViewModel : ViewModelBase<BL.Emp> 
    {
        public empsViewModel()
        {
            Messenger.Default.Register(this, new Action<BL.Dep>(SetDepForCurrentEmp));
        }

        private void SetDepForCurrentEmp(BL.Dep dep)
        {
            if (Selected != null)
            {
                BL.Emp emp = Selected as BL.Emp;
                emp.Dep = dep;
            }
        }

        protected override bool Filter(object item)
        {
            BL.Emp emp = item as BL.Emp;
            bool result = true;
            if (!string.IsNullOrWhiteSpace(FindText) && !(emp.LastName ?? string.Empty).ToLower().Contains(FindText.ToLower()) && !(emp.Name ?? string.Empty).ToLower().Contains(FindText.ToLower()) && !(emp.SName ?? string.Empty).ToLower().Contains(FindText.ToLower()) && !(emp.PosName ?? string.Empty).ToLower().Contains(FindText.ToLower()) && !(emp.DepName ?? string.Empty).ToLower().Contains(FindText.ToLower()) && !(emp.MobileTel ?? string.Empty).ToLower().Contains(FindText.ToLower()) && !(emp.InternalTel ?? string.Empty).ToLower().Contains(FindText.ToLower()))
            {
                result = false;
            }
            return result;
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

        #region Установка отдела
        RelayCommand _setDep;
        public ICommand SetDep
        {
            get
            {
                if (_setDep == null)
                    _setDep = new RelayCommand(ExecuteSetDepCommand, CanExecuteSetDepCommand);
                return _setDep;
            }
        }

        public void ExecuteSetDepCommand(object parameter)
        {
            Messenger.Default.Send<Uri>(new Uri("View\\deps.xaml", UriKind.Relative));
        }

        public bool CanExecuteSetDepCommand(object parametr)
        {
            if (EditMode) return true;
            else return false;
        }
        #endregion Установка отдела

        protected override void OnDispose()
        {

        }

    }
}
