using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.ViewModels
{
    public class depsViewModel : ViewModelBase<BL.Dep>
    {
        public depsViewModel()
        {
            //SelectionMode = true;
        }
        protected override bool Filter(object item)
        {
            BL.Dep dep = item as BL.Dep;
            bool result = true;
            if (!string.IsNullOrWhiteSpace(FindText) && 
                !(dep.Name ?? string.Empty).ToLower().Contains(FindText.ToLower()) && 
                !(dep.Id.ToString() ?? string.Empty).ToLower().Contains(FindText.ToLower())
                )
            {
                result = false;
            }
            return result;
        }
    }
}
