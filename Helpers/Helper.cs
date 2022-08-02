using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace ConvertDatabase.WinApp.Helpers
{
    public static class Helper
    {
        
        public static string ConvertToMiladi(string shamsi)
        {
            PersianCalendar pc = new PersianCalendar();
            var shamsiArray = shamsi.Split('/');
            int year = int.Parse(shamsiArray[0]);
            int month = int.Parse(shamsiArray[1]);
            int day = int.Parse(shamsiArray[2]);
            DateTime date = new DateTime(year, month, day, pc);
            return date.ToString();
        }

        public static string PersianDateFormat(string date)
        {
            return string.Format("{0}/{1}/{2}", date.Substring(0, 4), date.Substring(4, 2), date.Substring(6, 2));
        }

        public static string GetDate(string date)
        {
            var dateArray = date.Split('/');
            int year = int.Parse(dateArray[2]);
            int month = int.Parse(dateArray[1]);
            int day = int.Parse(dateArray[0]);

            return $"{year}/{month}/{day}";
        }

        public static string ConvertToShamsi(string miladiDate)
        {
            DateTime date = DateTime.Parse(miladiDate);
            PersianCalendar pc = new PersianCalendar();
            return string.Format($"{pc.GetYear(date)}/{pc.GetMonth(date)}/{pc.GetDayOfMonth(date)}");
        }

        

    }
}
