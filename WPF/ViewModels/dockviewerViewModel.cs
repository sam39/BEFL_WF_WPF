using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace WPF.ViewModels
{
    public class dockviewerViewModel
    {
        private FixedDocument _document ;

        public FixedDocument Document
        {
            get { return _document; }
            set { _document = value; }
        }

    }
}
