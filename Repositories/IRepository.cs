using System;
using System.Collections.Generic;
using System.Text;

namespace ConvertDatabase.WinApp.Repositories
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        void Export();
    }
}
