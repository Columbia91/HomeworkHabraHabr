using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkStudentXml
{
    [Serializable]
    public class Student
    {
        public string FullName { get; set; }
        public string Homeland { get; set; }
        public int BirthYear { get; set; }

        public Student()
        {

        }
    }
}
