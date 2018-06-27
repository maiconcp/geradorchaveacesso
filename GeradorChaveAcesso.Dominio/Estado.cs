using System.Collections.Generic;

namespace GeradorChaveAcesso.Dominio
{
    public class Estado
    {
        private Estado(int codigo, string nome)
        {
            Codigo = codigo;
            Nome = nome;
        }

        public int Codigo { get; private set;}
        public string Nome { get; private set; }

        public static readonly Estado Rondonia = new Estado(11, "Rondônia");
        public static readonly Estado Acre = new Estado(12, "Acre");
        public static readonly Estado Amazonas = new Estado(13, "Amazonas");
        public static readonly Estado Roraima = new Estado(14, "Roraima");
        public static readonly Estado Para = new Estado(15, "Pará");
        public static readonly Estado Amapa = new Estado(16, "Amapá");
        public static readonly Estado Tocantins = new Estado(17, "Tocantins");
        public static readonly Estado Maranhao = new Estado(21, "Maranhão");
        public static readonly Estado Piaui = new Estado(22, "Piauí");
        public static readonly Estado Ceara = new Estado(23, "Ceará");
        public static readonly Estado RioGrandeDoNorte = new Estado(24, "Rio Grande do Norte");
        public static readonly Estado Paraiba = new Estado(25, "Paraíba");
        public static readonly Estado Pernambuco = new Estado(26, "Pernambuco");
        public static readonly Estado Alagoas = new Estado(27, "Alagoas");
        public static readonly Estado Sergipe = new Estado(28, "Sergipe");
        public static readonly Estado Bahia = new Estado(29, "Bahia");
        public static readonly Estado MinasGerais = new Estado(31, "Minas Gerais");
        public static readonly Estado EspiritoSanto = new Estado(32, "Espírito Santo");
        public static readonly Estado RioDeJaneiro = new Estado(33, "Rio de Janeiro");
        public static readonly Estado SaoPaulo = new Estado(35, "São Paulo");
        public static readonly Estado Parana = new Estado(41, "Paraná");
        public static readonly Estado SantaCatarina = new Estado(42, "Santa Catarina");
        public static readonly Estado RioGrandeDoSul = new Estado(43, "Rio Grande do Sul");
        public static readonly Estado MatoGrossoDoSul = new Estado(50, "Mato Grosso do Sul");
        public static readonly Estado MatoGrosso = new Estado(51, "Mato Grosso");
        public static readonly Estado Goias = new Estado(52, "Goiás");
        public static readonly Estado DistritoFederal = new Estado(53, "Distrito Federal");
        public static readonly IReadOnlyList<Estado> Todos = new List<Estado>() 
        {
            Rondonia,
            Acre,
            Amazonas,
            Roraima,
            Para,
            Amapa,
            Tocantins,
            Maranhao,
            Piaui,
            Ceara,
            RioGrandeDoNorte,
            Paraiba,
            Pernambuco,
            Alagoas,
            Sergipe,
            Bahia,
            MinasGerais,
            EspiritoSanto,
            RioDeJaneiro,
            SaoPaulo,
            Parana,
            SantaCatarina,
            RioGrandeDoSul,
            MatoGrossoDoSul,
            MatoGrosso,
            Goias,
            DistritoFederal
        };

        public static Estado Aleatorio()
        {
            return Todos[NumeroAleatorio.Novo(Todos.Count)];
        }
    }
}