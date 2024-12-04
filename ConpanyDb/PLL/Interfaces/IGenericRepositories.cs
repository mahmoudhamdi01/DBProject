using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IGenericRepositories<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int Id);
        int add(T item);
        int update(T item);
        int delete(T item);
    }
}
