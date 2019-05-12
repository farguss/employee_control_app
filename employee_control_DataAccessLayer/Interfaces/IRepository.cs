using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employee_control_DataAccessLayer.Interfaces
{

    interface IRepository<T> where T : class
    {
        void Create(T item);
        T Get(int id);
        List<T> GetAll();
    }

}
