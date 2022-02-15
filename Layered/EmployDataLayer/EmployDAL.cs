using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmployEntity;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace EmployDataLayer
{
    public class EmployDAL
    {
        static List<Employ> employList;
        static EmployDAL()
        {
            employList = new List<Employ>();
        }

        public string ReadEmployFileDAL()
        {
            FileStream fs = new FileStream("d:/files/EmployProject.txt", FileMode.Open, FileAccess.Read);
            BinaryFormatter binf = new BinaryFormatter();
            employList = (List<Employ>)binf.Deserialize(fs);
            fs.Close();
            return "Data Restored...";
        }
        public string WriteEmployFileDAL()
        {
            FileStream fs = new FileStream("d:/files/EmployProject.txt", FileMode.Create, FileAccess.Write);
            BinaryFormatter binf = new BinaryFormatter();
            binf.Serialize(fs, employList);
            fs.Close();
            return "Data Stored in File...";
        }
        public string DeleteEmployDAL(int empno)
        {
            Employ employFound = SeachEmployDAL(empno);
            if (employFound!=null)
            {
                employList.Remove(employFound);
                return "Employ Record Deleted...";
            }
            return "Employ Record Not Found...";
        }
        public Employ SeachEmployDAL(int empno)
        {
            foreach(Employ employ in employList)
            {
                if (employ.Empno == empno)
                {
                    return employ;
                }
            }
            return null;
        }
        public string AddEmployDAL(Employ employ)
        {
            employList.Add(employ);
            return "Employ Record Added...";
        }

        public List<Employ> ShowEmployDAL()
        {
            return employList;
        }
    }
}
