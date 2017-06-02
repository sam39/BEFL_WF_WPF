using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace WPF
{
    public class ExportToXml
    {
        protected BL.UnitOfWork UoW = new BL.UnitOfWork();

        public void Emps()
        {
            string filepath = "D:\\tmp\\emp.xml";
            IEnumerable<BL.Emp> yourlist = UoW.EmpRepository.GetAll(false);
            XmlSerializer serializer = new XmlSerializer(typeof(List<BL.Emp>));//initialises the serialiser
            Stream writer = new FileStream(filepath, FileMode.Create);//initialises the writer
            
            serializer.Serialize(writer, yourlist);//Writes to the file
            writer.Close();//Closes the writer
        }

        public void Deps()
        {
            string filepath = "D:\\tmp\\deps.xml";
            IEnumerable<BL.Dep> yourlist = UoW.DivisionRepository.GetAll();
            XmlSerializer serializer = new XmlSerializer(typeof(List<BL.Dep>));//initialises the serialiser
            Stream writer = new FileStream(filepath, FileMode.Create);//initialises the writer

            serializer.Serialize(writer, yourlist);//Writes to the file
            writer.Close();//Closes the writer
        }
    }
}
