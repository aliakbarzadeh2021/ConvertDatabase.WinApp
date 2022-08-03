using System.Collections.Generic;
using System.Data;

namespace ConvertDatabase.WinApp.Repositories
{
    public class AccessRepository<T> : IRepository<T>
    {
        public void Export(List<T> input)
        {
            throw new System.NotImplementedException();
        }

        public List<T> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public DataTable GetData()
        {
            throw new System.NotImplementedException();
        }
    }
}
