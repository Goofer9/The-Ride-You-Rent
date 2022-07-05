using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTimeApp.Modules
{



    public class Class1
    {

        public DateTime semster { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public int credits { get; set; }
        public double classHours { get; set; }
        public int selfStudy { get; set; }
        public int studyHours { get; set; }
        public static DateTime dateStudied { get; set; }


        public int Calculation(double a, double b, double c)
        {

            double cred = a * 10;
            double stuf = cred / b;
            double d = stuf - c;

            return Convert.ToInt32(d);



        }




    }
}
