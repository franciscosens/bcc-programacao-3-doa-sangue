using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;

namespace DoaSangueWS.Controllers
{
    public class DoadorController : ApiController
    {

        DoadorBLL doadorBLL = new DoadorBLL();

        [HttpDelete]
        [Route("doador/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            doadorBLL.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, "Deletado com sucesso");
        }

        [HttpGet]
        [Route("doador")]
        public HttpResponseMessage GetAll()
        {
            return Request.CreateResponse(HttpStatusCode.OK, doadorBLL.GetAll());
        }

        [HttpGet]
        [Route("doador/{id}")]
        public HttpResponseMessage GetById(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, doadorBLL.GetById(id));
        }

        [HttpPost]
        [Route("doador")]
        public HttpResponseMessage Insert([FromBody] Doador item)
        {
            try
            {
                doadorBLL.Insert(item);
                return Request.CreateResponse(HttpStatusCode.OK, "Doador incluido com sucesso");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPut]
        [Route("doador/{id}")]
        public HttpResponseMessage Update([FromBody]Doador item)
        {
            try
            {
                doadorBLL.Update(item);
                return Request.CreateResponse(HttpStatusCode.OK, "Doador alterado com sucesso");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }


    }
}