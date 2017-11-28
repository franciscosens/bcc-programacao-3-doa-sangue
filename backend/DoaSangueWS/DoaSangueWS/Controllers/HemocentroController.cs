using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DoaSangueWS.Controllers
{
    [DisableCors]
    public class HemocentroController: ApiController
    {
        HemocentroBLL hemocentroBLL = new HemocentroBLL();

        [HttpPost]
        [Route("hemocentro/delete/{id}")]
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

        [HttpPost]
        [Route("hemocentro/update")]
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