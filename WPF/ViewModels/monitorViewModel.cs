using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using WPF.Infrastrucrure;
using System.Windows.Input;
using System.Windows.Documents;
using System.Windows.Media;

namespace WPF.ViewModels
{
    class monitorViewModel: ViewModelBase<BL.Monitor>
    {
        protected override bool Filter(object item)
        {
            BL.Monitor mon = item as BL.Monitor;
            bool result = true;
            if (!string.IsNullOrWhiteSpace(FindText) &&
                !(mon.Model ?? string.Empty).ToLower().Contains(FindText.ToLower()) &&
                !(mon.EmpFIO ?? string.Empty).ToLower().Contains(FindText.ToLower()) &&
                !(mon.DiagName ?? string.Empty).ToLower().Contains(FindText.ToLower()) &&
                !(mon.Id.ToString() ?? string.Empty).ToLower().Contains(FindText.ToLower())
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
                    BL.Monitor mon = Selected as BL.Monitor;
                    //Получаем объект из локального репозитория
                    BL.Emp emp_local = UoW.EmpRepository.GetByID(emp.Id);
                    mon.Emp = emp_local;
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

        #region Выбор Диагонали
        RelayCommand _setDiagonal;
        public ICommand SetDiagonal
        {
            get
            {
                if (_setDiagonal == null)
                    _setDiagonal = new RelayCommand(ExecuteSetCompTypeCommand, CanExecuteSetCompTypeCommand);
                return _setDiagonal;
            }
        }

        public void ExecuteSetCompTypeCommand(object parameter)
        {
            Messenger.Default.Send<BL.Dic>(BL.Dic.ДиагональЭкрана);

            Messenger.Default.Register(this, new Action<BL.DicData>(setDiagonal));
        }

        private void setDiagonal(BL.DicData dd)
        {
            if (Selected != null)
            {
                if (dd != null)
                {
                    BL.Monitor monitor = Selected as BL.Monitor;
                    //Получаем объект из локального репозитория
                    BL.DicData diag_local = UoW.DicDataRepository.GetByID(dd.Id);
                    monitor.Diagonal = diag_local;
                }
                //Отписываемся от сообщения
                Messenger.Default.Unregister(this, new Action<BL.DicData>(setDiagonal));
            }
        }

        public bool CanExecuteSetCompTypeCommand(object parametr)
        {
            if (EditMode) return true;
            else return false;
        }
        #endregion Выбор Диагонали


        #region Печать
        RelayCommand _print;
        public ICommand Print
        {
            get
            {
                if (_print == null)
                    _print = new RelayCommand(ExecutePrintCommand, CanExecutePrintCommand);
                return _print;
            }
        }

        public void ExecutePrintCommand(object parameter)
        {
            FlowDocument document = new FlowDocument();
            Run compName = new Run();
            compName.Text = "Мониторы";
            Paragraph par = new Paragraph();
            par.Inlines.Add(compName);
            document.Blocks.Add(par);

            //Добавляем таблицу
            Table table = new Table();
            table.Columns.Add(new TableColumn { Width = new System.Windows.GridLength(150) });
            table.Columns.Add(new TableColumn { Width = new System.Windows.GridLength(150) });
            table.Columns.Add(new TableColumn { Width = new System.Windows.GridLength(150) });

            table.RowGroups.Add(new TableRowGroup());
            table.RowGroups[0].Rows.Add(new TableRow());
            TableRow currentRow = table.RowGroups[0].Rows[0];
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Модель"))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Инв №"))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Владелец"))));

            //currentRow.FontWeight = FontWeight.;
            currentRow.Background = System.Windows.Media.Brushes.Navy;
            currentRow.Foreground = System.Windows.Media.Brushes.White;
            int counter = 1;
            foreach (BL.Monitor mon in EntityList)
            {

                if (_empCollectionView.Contains(mon))
                {
                    TableRow currRow = new TableRow();
                    currRow.Cells.Add(new TableCell(new Paragraph(new Run(mon.Model))));
                    currRow.Cells.Add(new TableCell(new Paragraph(new Run(mon.InvNum))));
                    currRow.Cells.Add(new TableCell(new Paragraph(new Run(mon.EmpFIO))));
                    if ((counter & 1) == 0)
                    {
                        currRow.Background = Brushes.LightGray;
                        currentRow.Foreground = Brushes.Gray;
                    }
                    else
                    {
                        currRow.Background = Brushes.White;
                        currentRow.Foreground = Brushes.Gray;
                    }


                    table.RowGroups[0].Rows.Add(currRow);
                    counter++;
                }
            }

            document.Blocks.Add(table);

            Messenger.Default.Send<FlowDocument>(document);
        }



        public bool CanExecutePrintCommand(object parametr)
        {
            return true;
        }
        #endregion Печать


        #endregion Команды

    }
}
