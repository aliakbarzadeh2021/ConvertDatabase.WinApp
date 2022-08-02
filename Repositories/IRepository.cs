using System;
using System.Collections.Generic;
using System.Text;

namespace ConvertDatabase.WinApp.Repositories
{
    public interface IRepository
    {
        object GetAll();
        void Export();
    }
}
