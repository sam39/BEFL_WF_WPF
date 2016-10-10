using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Emp
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string SName { get; set; }
        public virtual Pos Pos { get; set; }
        public int PosId { get; set; }
        public string PosName
        {
            get
            { if (Pos != null) return Pos.Name; else return ""; }
        }
        public virtual Dep Dep { get; set; }
        public int DepId { get; set; }
        public string DepName
        {
            get
            { if (Dep != null) return Dep.Name; else return ""; }
        }
        public string InternalTel { get; set;}
        public string MobileTel { get; set; }
        public string Email { get; set; }
        public string EmailPass { get; set;}
        public string DomainPass { get; set; }
        public string TrueCryptPass { get; set; }
        public string ERoomPass { get; set;}
        public string SkypeName { get; set;}
        public string SkypePass { get; set;}
        public string IcqName { get; set; }
        public string IcqPass { get; set; }
        public string Gmail { get; set; }
        public string Mango { get; set; }
        public string Comments { get; set; }
        public Boolean HideInSpr { get; set; }
    }
}
