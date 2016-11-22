using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.ViewModels
{
    class possViewModel : ViewModelBase<BL.Pos>
    {
        protected override bool Filter(object item)
        {
            BL.Pos pos = item as BL.Pos;
            bool result = true;
            if (!string.IsNullOrWhiteSpace(FindText) &&
                !(pos.Name ?? string.Empty).ToLower().Contains(FindText.ToLower()) &&
                !(pos.Id.ToString() ?? string.Empty).ToLower().Contains(FindText.ToLower())
                )
            {
                result = false;
            }
            return result;
        }
    }
}
