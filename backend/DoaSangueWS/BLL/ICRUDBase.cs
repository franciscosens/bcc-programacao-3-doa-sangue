using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    interface ICRUDBase<T>
    {

        HttpResponseMessage GetAll();

        HttpResponseMessage GetById();

        HttpResponseMessage Exists(T item);

        HttpResponseMessage Insert(T item);

        HttpResponseMessage Update(T item);

        HttpResponseMessage Delete(T item);

    }
}
