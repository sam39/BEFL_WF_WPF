using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public abstract class Mc
    {
        private string _invNum;
        public string InvNum
        {
            get { return _invNum; }
            set { _invNum = value; }
        }

        public abstract string Name { get;}
    }
}
