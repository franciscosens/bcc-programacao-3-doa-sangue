using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace DoaSangueWS.Controllers
{
    public class DoacaoController : ApiController
    {
        DoacaoBLL doacaoBLL = new DoacaoBLL();

        [HttpDelete]
        [Route("doacao/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            doacaoBLL.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, "Deletado com sucesso");
        }

        [HttpGet]
        [Route("doacao")]
        public HttpResponseMessage GetAll()
        {
            return Request.CreateResponse(HttpStatusCode.OK, doacaoBLL.GetAll());
        }

        [HttpGet]
        [Route("doacao/{id}")]
        public HttpResponseMessage GetById(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, doacaoBLL.GetById(id));
        }

        [HttpPost]
        [Route("doacao")]
        public HttpResponseMessage Insert([FromBody] Doacao item)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, doacaoBLL.Insert(item));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPut]
        [Route("doacao/{id}")]
        public HttpResponseMessage Update([FromBody]Doacao item)
        {
            try
            {
                doacaoBLL.Update(item);
                return Request.CreateResponse(HttpStatusCode.OK, "Daoção alterada com sucesso");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

    }
}
