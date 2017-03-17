using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using WPF.Infrastrucrure;

namespace WPF.ViewModels
{
    public class reportViewModel
    {
        public reportViewModel(FlowDocument doc)
        {
            Document = doc; 
        }

        public FlowDocument Document { get; set;}


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
            PrintDialog dialog = new PrintDialog();

            if (dialog.ShowDialog() == true)
            {
                dialog.PrintDocument(((IDocumentPaginatorSource)Document).DocumentPaginator, "Отчет по компьютерам");
            }
        }

        public bool CanExecutePrintCommand(object parametr)
        {
            return true;
        }
        #endregion Печать
    }
}
