using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GeradorChaveAcesso.Dominio;
using Microsoft.AspNetCore.Mvc;

namespace WebSiteReact.Controllers
{
    [Route("api/[controller]")]
    public class ChaveAcessoController : Controller
    {
        [HttpGet("[action]")]
        public bool EhValida(string chave)
        {
            var decomposicao = new DecomposicaoChaveAcesso(chave);
            
            return decomposicao.IsValid;
        }

        [HttpGet("{chave}")]
        public DecomposicaoChaveAcesso Get(string chave)
        {
            return new DecomposicaoChaveAcesso(chave);
        }
    }
}