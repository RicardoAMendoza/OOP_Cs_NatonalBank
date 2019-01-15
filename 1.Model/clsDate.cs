using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjWin_NationalBank_Rm
{
    public class clsDate
    {
        private int Day;
        private int Month;
        private int Year;
        private DateTime Today;

        public clsDate(int vDay, int vMonth, int vYear)
        {
            Day = vDay;
            Month = vMonth;
            Year = vYear;
        }
        public clsDate()
        {
            Day = Today.Day;
            Month = Today.Month;
            Year = Today.Year; ;
        }
        public int vDay
        { get { return Day; } set { Day = value; } }

        public int vMonth
        { get { return Month; } set { Month = value; } }

        public int vYear
        { get { return Year; } set { Year = value; } }

        public void fncCreateDate(int vDay, int vMonth, int vYear)
        {
            Day = vDay; Month = vMonth; Year = vYear;
        }
        public string fncPrintDate()
        {
            return Year + " / " + Month + " / " + Day;
        }
    }
}
