using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace DoaSangueWS.Controllers
{
    public class DoacaoController: IWSBase<Hemocentro>
    {
        HemocentroBLL hemocentroBLL = new HemocentroBLL();

        [HttpDelete]
        [Route("")]
        public HttpResponseMessage Delete(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("hemocentro")]
        public HttpResponseMessage GetAll()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("hemocentro/{id}")]
        public HttpResponseMessage GetById(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("hemocentro")]
        public HttpResponseMessage Insert([FromBody] Hemocentro item)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        [Route("hemocentro/{id}")]
        public HttpResponseMessage Update([FromBody]Hemocentro item)
        {
            throw new NotImplementedException();
        }

    }
}
