using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.ViewModels
{
    public class comptypeViewModel: ViewModelBase<BL.CompType>
    {
        protected override bool Filter(object item)
        {
            BL.DicData dd = item as BL.DicData;
            bool result = true;
            if (!string.IsNullOrWhiteSpace(FindText) &&
                !(dd.Name ?? string.Empty).ToLower().Contains(FindText.ToLower()) &&
                !(dd.Id.ToString() ?? string.Empty).ToLower().Contains(FindText.ToLower())
                )
            {
                result = false;
            }
            return result;
        }
    }
}
