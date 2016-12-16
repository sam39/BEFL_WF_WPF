using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using WPF.Infrastrucrure;
using System.Windows.Input;

namespace WPF.ViewModels
{
    public class printerViewModel: ViewModelBase<BL.Printer>
    {
        protected override bool Filter(object item)
        {
            BL.Printer prn = item as BL.Printer;
            bool result = true;
            if (!string.IsNullOrWhiteSpace(FindText) &&
                !(prn.Model ?? string.Empty).ToLower().Contains(FindText.ToLower()) &&
                !(prn.InvNum ?? string.Empty).ToLower().Contains(FindText.ToLower()) &&
                !(prn.EmpFIO ?? string.Empty).ToLower().Contains(FindText.ToLower()) &&
                !(prn.Id.ToString() ?? string.Empty).ToLower().Contains(FindText.ToLower())
                )
            {
                result = false;
            }
            return result;
        }

        #region Команды
        #region Выбор пользователя
        RelayCommand _setEmp;
        public ICommand SetEmp
        {
            get
            {
                if (_setEmp == null)
                    _setEmp = new RelayCommand(ExecuteSetEmpCommand, CanExecuteSetEmpCommand);
                return _setEmp;
            }
        }

        public void ExecuteSetEmpCommand(object parameter)
        {
            Messenger.Default.Send<PageMessage>
                (new PageMessage { Action = MessageAction.Select, PageType = typeof(View.emps) });


            Messenger.Default.Register(this, new Action<BL.Emp>(SetDepForCurrentEmp));
        }

        private void SetDepForCurrentEmp(BL.Emp emp)
        {
            if (Selected != null)
            {
                if (emp != null)
                {
                    BL.Printer entity = Selected as BL.Printer;
                    //Получаем объект из локального репозитория
                    BL.Emp emp_local = UoW.EmpRepository.GetByID(emp.Id);
                    entity.Emp = emp_local;
                }
                //Отписываемся от сообщения
                Messenger.Default.Unregister(this, new Action<BL.Emp>(SetDepForCurrentEmp));
            }
        }

        public bool CanExecuteSetEmpCommand(object parametr)
        {
            if (EditMode) return true;
            else return false;
        }
        #endregion Выбор пользователя

        //#region Выбор Диагонали
        //RelayCommand _setDiagonal;
        //public ICommand SetDiagonal
        //{
        //    get
        //    {
        //        if (_setDiagonal == null)
        //            _setDiagonal = new RelayCommand(ExecuteSetCompTypeCommand, CanExecuteSetCompTypeCommand);
        //        return _setDiagonal;
        //    }
        //}

        //public void ExecuteSetCompTypeCommand(object parameter)
        //{
        //    Messenger.Default.Send<BL.Dic>(BL.Dic.ДиагональЭкрана);

        //    Messenger.Default.Register(this, new Action<BL.DicData>(setDiagonal));
        //}

        //private void setDiagonal(BL.DicData dd)
        //{
        //    if (Selected != null)
        //    {
        //        if (dd != null)
        //        {
        //            BL.Monitor monitor = Selected as BL.Monitor;
        //            //Получаем объект из локального репозитория
        //            BL.DicData diag_local = UoW.DicDataRepository.GetByID(dd.Id);
        //            monitor.Diagonal = diag_local;
        //        }
        //        //Отписываемся от сообщения
        //        Messenger.Default.Unregister(this, new Action<BL.DicData>(setDiagonal));
        //    }
        //}

        //public bool CanExecuteSetCompTypeCommand(object parametr)
        //{
        //    if (EditMode) return true;
        //    else return false;
        //}
        //#endregion Выбор Диагонали
        #endregion Команды


    }
}
