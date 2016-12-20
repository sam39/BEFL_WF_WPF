using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BL
{
    public class Comp : MC
    {
        public string Ip { get; set;}
        public string NetName { get; set;}
        public string CPU { get; set;}
        public string MainBoard { get; set;}
        public string RAM { get; set;}
        public string HDD {get; set;}
        public string CDROM { get; set;}
        public BL.Emp User { get; set; }
        public int UserId { get; set; }
        public string UserName 
        { 
            get 
            {
                if (User != null) return User.LastName + " " + User.Name + " " + User.SName;
                else
                    return "Не определен";
            } 
        }
    }
}