using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Script.Services;
using System.Web.Services;
using System.Xml.Serialization;

namespace WebServiceForTask5
{
    /// <summary>
    /// Summary description for StudentListWebService
    /// </summary>
    [WebService(Name = "MyWebService", Description = "This Web Service is used to find students in XML file", Namespace = "http://www.mycompany.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [ScriptService]
    public class StudentListWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld(string text)
        {
            return "Hello world! " + text;
        }

        [WebMethod]
        public Student[] GetStudentsGraterThan(float mark)
        {
            var pathToFile = HostingEnvironment.MapPath("~/StudentXML.xml");
            XmlSerializer formatter = new XmlSerializer(typeof(Student[]));
            Student[] newpeople;
            using (FileStream fs = new FileStream(pathToFile, FileMode.OpenOrCreate))
            {
                newpeople = (Student[])formatter.Deserialize(fs);
            }
            return newpeople.Where(s => s.AvgMark > mark).ToArray();
        }
        [WebMethod]
        public Student[] GetStudentsLowerThan(float mark)
        {
            var pathToFile = HostingEnvironment.MapPath("~/StudentXML.xml");
            XmlSerializer formatter = new XmlSerializer(typeof(Student[]));
            Student[] newpeople;
            using (FileStream fs = new FileStream(pathToFile, FileMode.OpenOrCreate))
            {
                newpeople = (Student[])formatter.Deserialize(fs);
            }
            return newpeople.Where(s => s.AvgMark < mark).ToArray();
        }
        [WebMethod]
        public Student[] GetStudentsInRange(float minMark = 0, float maxMark = 5)
        {
            var pathToFile = HostingEnvironment.MapPath("~/StudentXML.xml");
            XmlSerializer formatter = new XmlSerializer(typeof(Student[]));
            Student[] newpeople;
            using (FileStream fs = new FileStream(pathToFile, FileMode.OpenOrCreate))
            {
                newpeople = (Student[])formatter.Deserialize(fs);
            }
            return newpeople.Where(s => s.AvgMark >= minMark && s.AvgMark <= maxMark).ToArray();
        }

    }

    [Serializable]
    public class Student
    {
        public string Name { get; set; }
        public float AvgMark { get; set; }

        public Student() { }

        public Student(string name, float avgMark)
        {
            Name = name;
            AvgMark = avgMark;
        }
    }
}
