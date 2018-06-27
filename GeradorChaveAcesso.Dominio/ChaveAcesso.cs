using System;
using System.Linq;

namespace GeradorChaveAcesso.Dominio
{
    public class ChaveAcesso
    {
        public ChaveAcesso(Estado estado, DateTime dataEmissao, Cnpj emitente, Modelo modelo, UInt16 serie, UInt32 numero, FormaEmissao formaEmissao, UInt32 codigoNumerico)
        {
            Estado = estado;
            DataEmissao = dataEmissao;
            Emitente = emitente;
            Modelo = modelo;
            Serie = serie;
            Numero = numero;
            FormaEmissao = formaEmissao;
            CodigoNumerico = codigoNumerico;
            Chave = MontarChaveSemDigito();
            Digito = (byte)new CalculadoraDigitoVerificadorChaveAcesso().Calcular(Chave);
            Chave += Digito.ToString();
        }
        public Estado Estado { get; private set; }
        public DateTime DataEmissao { get; private set; }
        public Cnpj Emitente { get; private set; }
        public Modelo Modelo { get; private set; }
        public UInt16 Serie { get; private set; }
        public UInt32 Numero { get; private set; }
        public FormaEmissao FormaEmissao { get; private set; }
        public UInt32 CodigoNumerico { get; private set; }
        public byte Digito { get; private set; }
        public string Chave { get; private set; }

        private string MontarChaveSemDigito()
        {
            return Estado.Codigo.ToString("D2") +
                   DataEmissao.ToString("yyMM") +
                   Emitente.NumeroCnpjSemPontuacao + 
                   Modelo.Codigo.ToString("D2") +
                   Serie.ToString("D3") +
                   Numero.ToString("D9") + 
                   FormaEmissao.Codigo.ToString() + 
                   CodigoNumerico.ToString("D8");
        }
    }
}