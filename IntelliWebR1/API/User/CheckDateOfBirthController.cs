using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IntelliWebR1.API
{
    public class CheckDateOfBirthController : ApiController
    {
        //date and age verification
        public bool Post([FromBody]SelectedDate m_Date)
        {
            try
            {
                string _date = m_Date.Day + "/" + m_Date.Month + "/" + m_Date.Year;
                DateTime _fromDateValue;
                if (DateTime.TryParseExact(_date, "dd/mm/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _fromDateValue))
                {
                    DateTime now = DateTime.Now;
                    DateTime _Dob = Convert.ToDateTime(_date);
                    int _Age = new DateTime(DateTime.Now.Subtract(_Dob).Ticks).Year - 1;
                    if (_Age >= 21 && _Age <= 99)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }

    public class SelectedDate
    {
        public string Day { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
    }


}
