﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.ViewModels
{
    class monitorViewModel: ViewModelBase<BL.Monitor>
    {
        protected override bool Filter(object item)
        {
            //BL.Comp comp = item as BL.Comp;
            bool result = true;
            //if (!string.IsNullOrWhiteSpace(FindText) &&
            //    !(comp.NetName ?? string.Empty).ToLower().Contains(FindText.ToLower()) &&
            //    !(comp.CompTypeName ?? string.Empty).ToLower().Contains(FindText.ToLower()) &&
            //    !(comp.EmpLastName ?? string.Empty).ToLower().Contains(FindText.ToLower()) &&
            //    !(comp.Id.ToString() ?? string.Empty).ToLower().Contains(FindText.ToLower())
            //    )
            //{
            //    result = false;
            //}
            return result;
        }
    }
}
