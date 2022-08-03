using ConvertDatabase.WinApp.Models;
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
using System.Reflection;
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


        public static DataTable MappColumn(DataTable source, DataTable target, List<MapColumn> maps)
        {
            //var source = GetDataTable(ConvertDto.SourceData);
            //var target = GetDataTable(ConvertDto.TargetData);
            //var maps = ConvertDto.SourceData.MappingColumns;
            var counter = 0;

            foreach (DataRow item in source.Rows)
            {
                foreach (MapColumn map in maps)
                {
                    target.Rows[counter][map.TargetValue] = item[map.SourceValue];
                }
                counter++;
            }

            return target;
        }

        public static List<T> GetList<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }

        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }


    }
}
