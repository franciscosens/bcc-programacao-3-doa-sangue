using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace DoaSangueWS.Controllers
{
    interface IWSBase<T>
    {

        HttpResponseMessage GetAll();

        HttpResponseMessage GetById(int id);

        HttpResponseMessage Insert([FromBody] T item);

        HttpResponseMessage Update([FromBody] T item);

        HttpResponseMessage Delete(int id);

    }
}
