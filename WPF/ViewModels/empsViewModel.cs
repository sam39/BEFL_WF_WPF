﻿using System.Collections.ObjectModel;
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
    public class empsViewModel : ViewModelBase<BL.Emp> 
    {
        public empsViewModel()
        {

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

        //ObservableCollection<BL.Pos> _poss;
        //public ObservableCollection<BL.Pos> Poss
        //{
        //    get
        //    {
        //        if (_poss == null)
        //            _poss = new ObservableCollection<BL.Pos>(UoW.PosRepository.GetAll());
        //        return _poss;
        //    }
        //}

        //ObservableCollection<BL.Dep> _deps;
        //public ObservableCollection<BL.Dep> Deps
        //{
        //    get
        //    {
        //        if (_deps == null)
        //            _deps = new ObservableCollection<BL.Dep>(UoW.DivisionRepository.GetAll());
        //        return _deps;
        //    }
        //}

        #region Выбор отдела
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
            Messenger.Default.Send<PageMessage>
                (new PageMessage { Action = MessageAction.Select, PageType = typeof(View.deps) });


            Messenger.Default.Register(this, new Action<BL.Dep>(SetDepForCurrentEmp));
        }

        private void SetDepForCurrentEmp(BL.Dep dep)
        {
            if (Selected != null)
            {
                if (dep != null)
                {
                    BL.Emp emp = Selected as BL.Emp;
                    //Получаем объект из локального репозитория
                    BL.Dep dep_local = UoW.DivisionRepository.GetByID(dep.Id);
                    emp.Dep = dep_local;
                }
                //Отписываемся от сообщения
                Messenger.Default.Unregister(this, new Action<BL.Dep>(SetDepForCurrentEmp));
            }
        }

        public bool CanExecuteSetDepCommand(object parametr)
        {
            if (EditMode) return true;
            else return false;
        }
        #endregion Выбор отдела

        #region Выбор должности
        RelayCommand _setPos;
        public ICommand SetPos
        {
            get
            {
                if (_setPos == null)
                    _setPos = new RelayCommand(ExecuteSetPosCommand, CanExecuteSetPosCommand);
                return _setPos;
            }
        }

        public void ExecuteSetPosCommand(object parameter)
        {
            Messenger.Default.Send<PageMessage>
                (new PageMessage { Action = MessageAction.Select, PageType = typeof(View.poss) });


            Messenger.Default.Register(this, new Action<BL.Pos>(SetPosForCurrentEmp));
        }

        private void SetPosForCurrentEmp(BL.Pos pos)
        {
            if (Selected != null)
            {
                BL.Emp emp = Selected as BL.Emp;
                //Получаем объект из локального репозитория
                BL.Pos pos_local = UoW.PosRepository.GetByID(pos.Id);
                emp.Pos = pos_local;
                Messenger.Default.Unregister(this, new Action<BL.Pos>(SetPosForCurrentEmp));
            }
        }

        public bool CanExecuteSetPosCommand(object parametr)
        {
            if (EditMode) return true;
            else return false;
        }
        #endregion Выбор должности

        public override bool CanExecuteSaveCommand(object parametr)
        {
            bool result = false;
            if (Selected != null)
            {
                if (EditMode && (Selected as BL.Emp).Pos != null && (Selected as BL.Emp).Dep != null)
                    result = true;
            }
            return result;

        }

        protected override void OnDispose()
        {

        }

    }
}
