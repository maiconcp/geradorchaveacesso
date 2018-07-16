using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebSiteReact.Controllers
{
    [Route("api/[controller]")]
    public class ChaveAcessoController : Controller
    {
        [HttpGet("[action]")]
        public bool EhValida(string chave)
        {
            return chave == "123";
        }
    }
}