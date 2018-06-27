using System.Collections.Generic;

namespace GeradorChaveAcesso.Dominio
{
    public class FormaEmissao
    {
        private FormaEmissao(int codigo, string nome)
        {
            Codigo = codigo;
            Nome = nome;
        }
        public int Codigo { get; private set; }
        public string Nome { get; private set; }

        public static readonly FormaEmissao Normal = new FormaEmissao(1, "Normal");
        public static readonly FormaEmissao ContigenciaFS = new FormaEmissao(2, "Contingência em Formulário de Segurança ");
        public static readonly FormaEmissao ContigenciaEPEC = new FormaEmissao(4, "Contigência EPEC");
        public static readonly FormaEmissao ContigenciaFSDA = new FormaEmissao(5, "Contingência em Formulário de Segurança FS-DA");
        public static readonly FormaEmissao ContigenciaSVCAN = new FormaEmissao(6, "Contingência SVC-AN");
        public static readonly FormaEmissao ContigenciaSVCRS = new FormaEmissao(7, "Contingência SVC-RS");
        public static readonly FormaEmissao ContigenciaSVCSP = new FormaEmissao(8, "Contingência SVC-SP");

        public static readonly IReadOnlyList<FormaEmissao> Todos = new List<FormaEmissao>()
        {
            Normal,
            ContigenciaFS,
            ContigenciaEPEC, 
            ContigenciaFSDA,
            ContigenciaSVCAN,
            ContigenciaSVCRS,
            ContigenciaSVCSP
        };
    }
}