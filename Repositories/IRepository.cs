using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ConvertDatabase.WinApp.Repositories
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        DataTable GetData();
        void Export(List<T> input);
    }
}
