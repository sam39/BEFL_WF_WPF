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

namespace WPF.ViewModels
{
    class empsViewModel : ViewModelBase<BL.Emp> 
    {
        //BL.UnitOfWork UoW = new BL.UnitOfWork();

        //private bool _editMode;
        //public bool EditMode
        //{
        //    get
        //    {
        //        return _editMode;
        //    }
        //    set
        //    {
        //        _editMode = value;
        //        OnPropertyChanged("EditMode");
        //    }
        //}


        //private string _findText;
        //public string FindText
        //{
        //    get
        //    {
        //        if (_findText == null)
        //            _findText = "";
        //        return _findText;
        //    }
        //    set
        //    {
        //        _findText = value;
        //        _empCollectionView.Filter = null;
        //        _empCollectionView.Filter = EmpFilter;
        //    }
        //}


        //BL.Emp _selected;
        //public BL.Emp Selected
        //{
        //    get
        //    {
        //        return _selected;
        //    }
        //    set
        //    {
        //        _selected = value;
        //        OnPropertyChanged("SelectedEmp");
        //    }
        //}

        //private ICollectionView _empCollectionView {get; set;}

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

        //private void FilterRebind()
        //{
        //    _empCollectionView.Filter = null;
        //    _empCollectionView.Filter = EmpFilter;
        //}


        //ObservableCollection<BL.Emp> _emps;
        //public ObservableCollection<BL.Emp> Emps
        //{
        //    get
        //    {
        //        if (_emps == null)
        //        {
        //            _emps = new ObservableCollection<BL.Emp>(UoW.EmpRepository.GetAll());
        //            _empCollectionView = CollectionViewSource.GetDefaultView(_emps);
        //            _empCollectionView.Filter = EmpFilter;
        //        }
        //        return _emps;
        //    }
        //}

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

        //#region Команды
        //#region Добавление
        //RelayCommand _addCommand;
        //public ICommand Add
        //{
        //    get
        //    {
        //        if (_addCommand == null)
        //            _addCommand = new RelayCommand(ExecuteAddCommand, CanExecuteAddCommand);
        //        return _addCommand;
        //    }
        //}

        //public void ExecuteAddCommand(object parameter)
        //{
        //    BL.Emp emp = new BL.Emp();
        //    emp.DepId = 1;
        //    emp.PosId = 1;
        //    Emps.Add(emp);
        //    UoW.EmpRepository.Insert(emp);
        //    Selected = emp;
        //    OnPropertyChanged("SelectedEmp");
        //    EditMode = true;
        //    OnPropertyChanged("EditMode");
        //}

        //public bool CanExecuteAddCommand(object parameter)
        //{
        //    if (!EditMode) return true;
        //    else return false;
        //}
        //#endregion Добавление

        //#region Редактироване
        //RelayCommand _editCommand;
        //public ICommand Edit
        //{
        //    get
        //    {
        //        if (_editCommand == null)
        //            _editCommand = new RelayCommand(ExecuteEditCommand, CanExecuteEditCommand);
        //        return _editCommand;
        //    }
        //}

        //public void ExecuteEditCommand(object parameter)
        //{
        //    EditMode = true;
        //}

        //public bool CanExecuteEditCommand(object parametr)
        //{
        //    if (!EditMode) return true;
        //    else return false;
        //}
        //#endregion Редактирование

        //#region Отмена редактирования
        //RelayCommand _cancelCommand;
        //public ICommand Cancel
        //{
        //    get
        //    {
        //        if (_cancelCommand == null)
        //            _cancelCommand = new RelayCommand(ExecuteCancelCommand, CanExecuteCancelCommand);
        //        return _cancelCommand;
        //    }
        //}

        //public void ExecuteCancelCommand(object parameter)
        //{
        //    BL.Emp empToDel = parameter as BL.Emp;
        //    Emps.Remove(empToDel);
        //    UoW.EmpRepository.Delete(empToDel);
        //    OnPropertyChanged("Emps");
        //}

        //public bool CanExecuteCancelCommand(object parametr)
        //{
        //    if (EditMode) return true;
        //    else return false;
        //}
        //#endregion

        //#region Удаление
        //RelayCommand _deleteCommand;
        //public ICommand Delete
        //{
        //    get
        //    {
        //        if (_deleteCommand == null)
        //            _deleteCommand = new RelayCommand(ExecuteDeleteCommand, CanExecuteDeleteCommand);
        //        return _deleteCommand;
        //    }
        //}

        //public void ExecuteDeleteCommand(object parameter)
        //{
        //    BL.Emp empToDel = parameter as BL.Emp;
        //    Emps.Remove(empToDel);
        //    UoW.EmpRepository.Delete(empToDel);
        //    OnPropertyChanged("Emps");
        //}

        //public bool CanExecuteDeleteCommand(object parametr)
        //{
        //    if (!EditMode) return true;
        //    else return false;
        //}
        //#endregion Удаление

        //#region Сохранение
        //RelayCommand _saveCommand;
        //public ICommand Save
        //{
        //    get
        //    {
        //        if (_saveCommand == null)
        //            _saveCommand = new RelayCommand(ExecuteSaveCommand, CanExecuteSaveCommand);
        //        return _saveCommand;
        //    }
        //}

        //public void ExecuteSaveCommand(object parameter)
        //{
        //    UoW.Save();
        //    EditMode = false;
        //    OnPropertyChanged("Emps");
        //}

        //public bool CanExecuteSaveCommand(object parametr)
        //{
        //    if (EditMode) return true;
        //    else return false;
        //}
        //#endregion Сохранение
        //#endregion Команды

        protected override void OnDispose()
        {

        }

    }
}
