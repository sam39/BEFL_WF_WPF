using System;
using GalaSoft.MvvmLight.Messaging;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Infrastrucrure;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Windows.Data;


namespace WPF.ViewModels
{
    public abstract class ViewModelBase<T> :INotifyPropertyChanged, IDisposable where T : class, new()
    {
        protected ViewModelBase()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected BL.UnitOfWork UoW = new BL.UnitOfWork();

        private bool _addNewMode;

        //Включает(выключает) ражим выбора на форме
        private bool _selectionMode;
        public bool SelectionMode
        {
            get
            {
                return _selectionMode;
            }
            set
            {
                _selectionMode = value;
                OnPropertyChanged("SelectionMode");
            }
        }


        private bool _editMode;
        public bool EditMode
        {
            get
            {
                return _editMode;
            }
            set
            {
                _editMode = value;
                OnPropertyChanged("EditMode");
            }
        }

        T _selected;
        public T Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
                OnPropertyChanged("Selected");
            }
        }

        ObservableCollection<T> _entityList;
        public ObservableCollection<T> EntityList
        {
            get
            {
                if (_entityList == null)
                {
                    _entityList = new ObservableCollection<T>(UoW.Repository<T>().GetAll());
                    _empCollectionView = CollectionViewSource.GetDefaultView(_entityList);
                    _empCollectionView.Filter = Filter;
                }
                return _entityList;
            }
        }

        protected ICollectionView _empCollectionView { get; set; }

        private string _findText;
        public string FindText
        {
            get
            {
                if (_findText == null)
                    _findText = "";
                return _findText;
            }
            set
            {
                _findText = value;
                _empCollectionView.Filter = null;
                _empCollectionView.Filter = Filter;
            }
        }

        protected abstract bool Filter(object item);


        #region Команды
        #region Добавление
        RelayCommand _addCommand;
        public ICommand Add
        {
            get
            {
                if (_addCommand == null)
                    _addCommand = new RelayCommand(ExecuteAddCommand, CanExecuteAddCommand);
                return _addCommand;
            }
        }

        public void ExecuteAddCommand(object parameter)
        {
            T entity = new T();
            ////emp.DepId = 1;
            ////emp.PosId = 1;
            EntityList.Add(entity);
            UoW.Repository<T>().Insert(entity);
            //UoW.EmpRepository.Insert(emp);
            Selected = entity;
            OnPropertyChanged("SelectedEmp");
            EditMode = true;
            _addNewMode = true;
            //OnPropertyChanged("EditMode");
        }

        public bool CanExecuteAddCommand(object parameter)
        {
            if (!EditMode) return true;
            else return false;
        }
        #endregion Добавление

        #region Редактироване
        RelayCommand _editCommand;
        public ICommand Edit
        {
            get
            {
                if (_editCommand == null)
                    _editCommand = new RelayCommand(ExecuteEditCommand, CanExecuteEditCommand);
                return _editCommand;
            }
        }

        public void ExecuteEditCommand(object parameter)
        {
            EditMode = true;
        }

        public bool CanExecuteEditCommand(object parametr)
        {
            if (!EditMode) return true;
            else return false;
        }
        #endregion Редактирование

        #region Отмена редактирования(добавления)
        RelayCommand _cancelCommand;
        public ICommand Cancel
        {
            get
            {
                if (_cancelCommand == null)
                    _cancelCommand = new RelayCommand(ExecuteCancelCommand, CanExecuteCancelCommand);
                return _cancelCommand;
            }
        }

        public void ExecuteCancelCommand(object parameter)
        {
            T EntityToCancel = parameter as T;
            if (_addNewMode)
            {
                EntityList.Remove(EntityToCancel);
                UoW.Repository<T>().Delete(EntityToCancel);
                _addNewMode = false;
            }
            else UoW.Repository<T>().Reload(EntityToCancel);
            EditMode = false;
            OnPropertyChanged("EntityList");
            OnPropertyChanged("Selected");
        }

        public bool CanExecuteCancelCommand(object parametr)
        {
            if (EditMode) return true;
            else return false;
        }
        #endregion

        #region Удаление
        RelayCommand _deleteCommand;
        public ICommand Delete
        {
            get
            {
                if (_deleteCommand == null)
                    _deleteCommand = new RelayCommand(ExecuteDeleteCommand, CanExecuteDeleteCommand);
                return _deleteCommand;
            }
        }

        public void ExecuteDeleteCommand(object parameter)
        {
            T ToDel = parameter as T;
            EntityList.Remove(ToDel);
            UoW.Repository<T>().Delete(ToDel);
            UoW.Save();
            OnPropertyChanged("EntityList");
        }

        public bool CanExecuteDeleteCommand(object parametr)
        {
            if (!EditMode) return true;
            else return false;
        }
        #endregion Удаление

        #region Сохранение
        RelayCommand _saveCommand;
        public ICommand Save
        {
            get
            {
                if (_saveCommand == null)
                    _saveCommand = new RelayCommand(ExecuteSaveCommand, CanExecuteSaveCommand);
                return _saveCommand;
            }
        }

        public void ExecuteSaveCommand(object parameter)
        {
            UoW.Save();
            EditMode = false;
            OnPropertyChanged("Emps");     
        }

        public bool CanExecuteSaveCommand(object parametr)
        {
            if (EditMode) return true;
            else return false;
        }
        #endregion Сохранение

        #region Выбор
        RelayCommand _selectCommand;
        public ICommand Select
        {
            get
            {
                if (_selectCommand == null)
                    _selectCommand = new RelayCommand(ExecuteSelectCommand, CanExecuteSelectCommand);
                return _selectCommand;
            }
        }

        public void ExecuteSelectCommand(object parameter)
        {
            Messenger.Default.Send<T>(Selected);
            Messenger.Default.Send<string>("GoBack");
            //UoW.Save();
            //EditMode = false;
            //OnPropertyChanged("Emps");
        }

        public bool CanExecuteSelectCommand(object parametr)
        {
            if (SelectionMode) return true;
            else return false;
        }
        #endregion Выбор


        #endregion Команды




        public void Dispose()
        {
            this.OnDispose();
        }

        protected virtual void OnDispose()
        {
        }
    }
}
