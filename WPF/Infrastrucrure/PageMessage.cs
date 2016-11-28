using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Infrastrucrure
{
    public enum MessageAction {Select, Return}
    public class PageMessage
    {
        public MessageAction Action {get; set;}
        public Type PageType { get; set;}
    }
}
