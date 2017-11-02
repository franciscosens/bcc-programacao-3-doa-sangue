using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Interface
{
    public interface IEntityBase<T>
    {
        List<T> GetAll();

        T GetById(int id);

        int Insert(T item);

        int Update(T item);

        bool Exists(T item);

        bool Delete(int id);

    }
}
