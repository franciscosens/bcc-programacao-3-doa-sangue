using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace DoaSangueWS.Controllers
{
    public class HomeController: Controller
    {

        public void Index()
        {
            string texto = Server.MapPath("~/");
            texto = Path.GetFullPath(Path.Combine(texto, "..\\..\\..\\frontend\\DoaSangueWeb\\"));
            texto = texto.Replace("\\", "/");
            texto = "file:///" + texto + "login.html";
            System.Diagnostics.Process.Start(texto);
            
        }
    }
}