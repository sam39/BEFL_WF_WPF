using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using System.Xml.Serialization;
using System.IO;

namespace Mobile
{
    public interface IBeflRepository
    {
        IEnumerable<BL.Emp> GetEmps();
    }




}
