using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DoaSangueWS.Controllers
{
    public class HemocentroController: ApiController
    {
        HemocentroBLL hemocentroBLL = new HemocentroBLL();

        [HttpDelete]
        [Route("hemocentro/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            hemocentroBLL.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, "Hemocentro deletado com sucesso");
        }

        [HttpGet]
        [Route("hemocentro")]
        public HttpResponseMessage GetAll() => Request.CreateResponse(HttpStatusCode.OK, hemocentroBLL.GetAll());
        

        [HttpGet]
        [Route("hemocentro/{id}")]
        public HttpResponseMessage GetById(int id) => Request.CreateResponse(HttpStatusCode.OK, hemocentroBLL.GetById(id));

        [HttpPost]
        [Route("hemocentro")]
        public HttpResponseMessage Insert([FromBody] Hemocentro item)
        {
            try
            {
             
                return Request.CreateResponse(HttpStatusCode.OK, hemocentroBLL.Insert(item));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPut]
        [Route("hemocentro/teste")]
        public HttpResponseMessage Update([FromBody]Hemocentro item)
        {
            try
            {
                hemocentroBLL.Update(item);
                return Request.CreateResponse(HttpStatusCode.OK, "Hemocentro alterado com sucesso");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}