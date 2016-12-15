using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Infrastrucrure;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Windows.Data;
using GalaSoft.MvvmLight.Messaging;
using System.ComponentModel;

namespace WPF.ViewModels
{
    public class mcViewModel : INotifyPropertyChanged, IDisposable, IViewModel
    {
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

        protected BL.UnitOfWork UoW = new BL.UnitOfWork();

        private bool _addNewMode;


        protected bool Filter(object item)
        {
            BL.Mc mc = item as BL.Mc;
            bool result = true;
            if (!string.IsNullOrWhiteSpace(FindText) &&
                !(mc.EmpFIO ?? string.Empty).ToLower().Contains(FindText.ToLower()) &&
                !(mc.InvNum ?? string.Empty).ToLower().Contains(FindText.ToLower()) &&
                !(mc.Name ?? string.Empty).ToLower().Contains(FindText.ToLower())
                )
            {
                result = false;
            }
            return result;
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

        BL.Mc _selected;
        public BL.Mc Selected
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

        ObservableCollection<BL.Mc> _entityList;
        public ObservableCollection<BL.Mc> EntityList
        {
            get
            {
                if (_entityList == null)
                {
                    _entityList = new ObservableCollection<BL.Mc>(UoW.GetAllMc());
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
            //FindText = string.Empty;
            //OnPropertyChanged("FindText");
            //BL.Mc entity = new BL.Mc();
            //EntityList.Add(entity);
            //Selected = entity;
            //OnPropertyChanged("Selected");
            //EditMode = true;
            //_addNewMode = true;
        }

        public bool CanExecuteAddCommand(object parameter)
        {
            if (!EditMode) return true;
            else return false;
        }
        #endregion Добавление

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
            BL.Mc EntityToCancel = Selected as BL.Mc;
            if (_addNewMode)
            {
                EntityList.Remove(EntityToCancel);
                //UoW.Repository<T>().Delete(EntityToCancel);
                _addNewMode = false;
            }
            else UoW.Repository<BL.Mc>().Reload(EntityToCancel);
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
            BL.Mc ToDel = parameter as BL.Mc;
            if (ToDel != null)
            {
                EntityList.Remove(ToDel);
                UoW.Repository<BL.Mc>().Delete(ToDel);
                UoW.Save();
                OnPropertyChanged("EntityList");
            }

        }

        public bool CanExecuteDeleteCommand(object parametr)
        {
            bool result = false;
            if (Selected != null)
                if (!EditMode)
                    result = true;
            return result;
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
            if (_addNewMode)
            {
                BL.Mc entity = Selected as BL.Mc;
                if (entity != null)
                {
                    //EntityList.Add(entity);
                    UoW.Repository<BL.Mc>().Insert(entity);
                }
            }
            UoW.Save();
            EditMode = false;
            OnPropertyChanged("Emps");
        }

        public virtual bool CanExecuteSaveCommand(object parametr)
        {
            if (EditMode) return true;
            else return false;
        }
        #endregion Сохранение

        #region Выбор/Редактирование
        RelayCommand _selectCommand;
        public ICommand Select
        {
            get
            {
                if (SelectionMode)
                {
                    _selectCommand = new RelayCommand(ExecuteSelectCommand, CanExecuteSelectCommand);
                }
                else _selectCommand = new RelayCommand(ExecuteEditCommand, CanExecuteEditCommand);
                return _selectCommand;
            }
        }

        public void ExecuteSelectCommand(object parameter)
        {
            Messenger.Default.Send<BL.Mc>(Selected);
            SelectionMode = false;
            Messenger.Default.Send<string>("GoBack");
        }

        public bool CanExecuteSelectCommand(object parametr)
        {
            if (SelectionMode) return true;
            else return false;
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
        #endregion Выбор/Редактирование

        #region Назад
        RelayCommand _backCommand;
        public ICommand Back
        {
            get
            {
                if (_backCommand == null)
                    _backCommand = new RelayCommand(ExecuteBackCommand, CanExecuteBackCommand);
                return _backCommand;
            }
        }

        public void ExecuteBackCommand(object parameter)
        {
            //Messenger.Default.Send<T>(Selected);
            SelectionMode = false;
            Messenger.Default.Send<string>("GoBack");
        }

        public bool CanExecuteBackCommand(object parametr)
        {
            if (SelectionMode) return true;
            else return false;
        }
        #endregion Назад

        #endregion Команды





        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void Dispose()
        {
            this.OnDispose();
        }

        protected virtual void OnDispose()
        {
        }
    }
}
