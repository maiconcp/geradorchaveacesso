using System.Collections.Generic;

namespace GeradorChaveAcesso.Dominio
{
    public class Modelo
    {
        private Modelo(int codigo, string nome)
        {
            Codigo = codigo;
            Nome = nome;
        }
        public int Codigo { get; private set; }
        public string Nome { get; private set; }

        public static readonly Modelo NFe = new Modelo(55, "NF-e");
        public static readonly Modelo NFCe = new Modelo(65, "NFC-e");
        public static readonly Modelo CTe = new Modelo(57, "CT-e");
        public static readonly Modelo CTeOutros = new Modelo(67, "CT-e Outros Serviços");
        public static readonly Modelo MDFe = new Modelo(58, "MDF-e");
        public static readonly IReadOnlyList<Modelo> Todos = new List<Modelo>()
        {
            NFe,
            NFCe,
            CTe,
            CTeOutros,
            MDFe
        };
    }
}