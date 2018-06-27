using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace GeradorChaveAcesso.Dominio
{
    public class DecomposicaoChaveAcesso
    {
        public DecomposicaoChaveAcesso(string chave)
        {
            _erros = new List<string>();
            Chave = chave;

            if (string.IsNullOrWhiteSpace(chave) || chave.Length != 44)
            {
                AdicionarErro("A chave informada é inválida. A chave deve conter 44 dígitos.");
                return;
            }

            Estado = ObterParte(ObterEstado, "Estado");
            DataEmissao = ObterParte(ObterDataEmissao, "Data de emissão (ano e mês)");
            Emitente = ObterParte(ObterCnpjEmitente, "CNPJ do emitente");
            Modelo = ObterParte(ObterModelo, "Modelo");
            Serie = ObterParte(ObterSerie, "Série");
            Numero = ObterParte(ObterNumero, "Número");
            FormaEmissao = ObterParte(ObterFormaEmissao, "Forma de emissão");
            CodigoNumerico = ObterParte(ObterCodigoNumerico, "Código numerico");
            Digito = ObterParte(ObterDigito, "Dígito verificador");

            if (Digito.ToString() != new CalculadoraDigitoVerificadorChaveAcesso().Calcular(chave).ToString())
            {
                AdicionarErro("A chave informada contem um dígito verificador inválido.");
            }            
        }

        private string Chave { get; set; }
        public Estado Estado { get; private set; }
        public DateTime DataEmissao { get; private set; }
        public Cnpj Emitente { get; private set; }
        public Modelo Modelo { get; private set; }
        public UInt16 Serie { get; private set; }
        public UInt32 Numero { get; private set; }
        public FormaEmissao FormaEmissao { get; private set; }
        public UInt32 CodigoNumerico { get; private set; }
        public byte Digito { get; private set; }
        private List<string> _erros;
        public IReadOnlyList<string> Erros { get { return _erros; } }
        public bool IsValid { get { return !_erros.Any(); } }

        private void AdicionarErro(string mensagem)
        {
            _erros.Add(mensagem);
        }

        private T ObterParte<T>(Func<T> funcao, string campo)
        {
            try
            {
                return funcao();
            }
            catch (Exception)
            {
                AdicionarErro($"{campo} não identificado.");

                return default(T);
            }
        }

        private Estado ObterEstado()
        {
            string parte = Chave.Substring(0, 2);
            return Estado.Todos.Single(w => w.Codigo == int.Parse(parte));
        }
        private DateTime ObterDataEmissao()
        {
            string ano = Chave.Substring(2, 2);
            string mes = Chave.Substring(4, 2);

            return new DateTime(2000 + int.Parse(ano), int.Parse(mes), 1);
        }
        private Cnpj ObterCnpjEmitente()
        {
            string parte = Chave.Substring(6, 14);
            return new Cnpj(parte);
        }
        private Modelo ObterModelo()
        {
            int modelo = int.Parse(Chave.Substring(20, 2));

            return Modelo.Todos.Single(w => w.Codigo == modelo);
        }
        private UInt16 ObterSerie()
        {
            string parte = Chave.Substring(22, 3);

            return UInt16.Parse(parte);
        }
        private UInt32 ObterNumero()
        {
            return UInt32.Parse(Chave.Substring(25, 9));
        }
        public FormaEmissao ObterFormaEmissao()
        {
            int forma = int.Parse(Chave.Substring(34, 1));

            return FormaEmissao.Todos.Single(s => s.Codigo == forma);
        }
        public UInt32 ObterCodigoNumerico()
        {
            return UInt32.Parse(Chave.Substring(35, 8));
        }
        public byte ObterDigito()
        {
            return byte.Parse(Chave.Substring(43, 1));
        }
    }
}