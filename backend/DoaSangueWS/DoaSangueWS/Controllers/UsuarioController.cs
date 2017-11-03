using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net.Http;
using BLL;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace DoaSangueWS.Controllers
{
    public class UsuarioController : ApiController, IWSBase<Usuario>
    {
        UsuarioBLL usuarioBLL = new UsuarioBLL();
        private static Dictionary<string, string> usuariosLogados;


        static UsuarioController()
        {
            usuariosLogados = new Dictionary<string, string>();
        }

        [HttpPost]
        [Route("usuario/login")]
        public HttpResponseMessage RealizarLogin([FromBody]JObject data)
        {
            StringBuilder builder = new StringBuilder();
            if (data["login"] == null || data["senha"] == null)
            {
                if (data["login"] == null)
                {
                    builder.AppendLine("Login não foi informado.");
                }
                if (data["senha"] == null)
                {
                    builder.AppendLine("Senha não foi informada.");
                }
                return Request.CreateErrorResponse(HttpStatusCode.MethodNotAllowed, builder.ToString());
            }

            string login = data["login"].ToObject<String>();
            string senha = data["senha"].ToObject<String>();
            Usuario usuario = usuarioBLL.VerifyLogin(login, senha);
            if (usuario != null)
            {
                string token = Utils.GenerateToken(login);
                if (!usuariosLogados.ContainsKey(token))
                {
                    usuariosLogados.Add(token, login);
                }
                Dictionary<string, string> resultados = new Dictionary<string, string>
                {
                    { "token", token },
                    { "nome", usuario.Nome },
                    { "sobrenome", usuario.Sobrenome }
                };
                return Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(resultados));
            }
            return Request.CreateResponse(HttpStatusCode.Forbidden, "Login e/ou senha inválidos.");
        }

        [HttpPost]
        [Route("usuario/logout")]
        public HttpResponseMessage RealizarLogout([FromBody]JObject data)
        {
            string token = data["token"].ToString();
            if (usuariosLogados.ContainsKey(token))
            {
                usuariosLogados.Remove(token);
                return Request.CreateResponse(HttpStatusCode.OK, "Realizado o logout com sucesso.");
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, "Usuário não logado.");
        }

        [HttpPost]
        [Route("usuario/verificarLogin")]
        public HttpResponseMessage VerificarLogado([FromBody]JObject data)
        {
            string token = data["token"].ToString();
            if (usuariosLogados.ContainsKey(token))
            {
                return Request.CreateResponse(HttpStatusCode.OK, "");
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, "Usuário não logado.");
        }

        [HttpGet]
        [Route("usuario")]
        public HttpResponseMessage GetAll() => Request.CreateResponse(HttpStatusCode.OK, usuarioBLL.GetAll());

        [HttpGet]
        [Route("usuario/{id}")]
        public HttpResponseMessage GetById(int id) => Request.CreateResponse(HttpStatusCode.OK, usuarioBLL.GetById(id));

        [HttpPost]
        [Route("usuario")]
        public HttpResponseMessage Insert([FromBody] Usuario item)
        {
            try
            {
                usuarioBLL.Insert(item);
                return Request.CreateResponse(HttpStatusCode.OK, "Usuário cadastrado com sucesso.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPut]
        [Route("usuario/{id}")]
        public HttpResponseMessage Update([FromBody] Usuario item)
        {
            try
            {
                usuarioBLL.Update(item);
                return Request.CreateResponse(HttpStatusCode.OK, "Usuário alterado com sucesso.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpDelete]
        [Route("usuario/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            usuarioBLL.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, "Usuário deletado com sucesso.");
        }

    }
}