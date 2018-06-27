using System;
using System.Collections.Generic;
using GeradorChaveAcesso.Dominio.Common;

namespace GeradorChaveAcesso.Dominio
{
    public class Cnpj : ValueObject<Cnpj>
    {
        public const int TAMANHO = 14;
        
        public Cnpj(string numeroCnpj)
        {
            if (string.IsNullOrWhiteSpace(numeroCnpj))
                throw new ArgumentException($"CNPJ não informado.", numeroCnpj);

            NumeroCnpjSemPontuacao = RemoverPontuacao(numeroCnpj);
            NumeroCnpjFormatado = Formatar(numeroCnpj);

            if (!EhValido())
                throw new ArgumentException($"O CNPJ '{numeroCnpj}' é inválido.", numeroCnpj);
        }

        public string NumeroCnpjSemPontuacao { get; private set; }
        public string NumeroCnpjFormatado {get; private set;}
        
        public static string RemoverPontuacao(string cnpjComPontuacao)
        {
            string resultado = string.Empty;

            if (!string.IsNullOrWhiteSpace(cnpjComPontuacao))
            {
                foreach (char c in cnpjComPontuacao)
                {
                    if (char.IsDigit(c))
                        resultado += c;
                }
            }

            return resultado;
        }

        public static string Formatar(string cnpj)
        {
            cnpj = RemoverPontuacao(cnpj);
            return Convert.ToUInt64(cnpj).ToString(@"00\.000\.000\/0000\-00");
        }

        public bool EhValido()
        {
            if (string.IsNullOrWhiteSpace(NumeroCnpjSemPontuacao))
                return false;

            if (NumeroCnpjSemPontuacao.Length != TAMANHO)
                return false;

            switch (NumeroCnpjSemPontuacao)
            {
                case "00000000000000":
                case "11111111111111":
                case "22222222222222":
                case "33333333333333":
                case "44444444444444":
                case "55555555555555":
                case "66666666666666":
                case "77777777777777":
                case "88888888888888":
                case "99999999999999":
                    return false;
            }                

            string digito = CalcularDigitoVerificador(NumeroCnpjSemPontuacao);
            return NumeroCnpjSemPontuacao.EndsWith(digito);
        }

        protected static string CalcularDigitoVerificador(string numeroCnpj)
        {
            string digito = string.Empty;
            string cnpj = numeroCnpj.Substring(0, 12);

            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(cnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            cnpj = cnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(cnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            
            return digito;
        }

        public static Cnpj Gerar()
        {
            string novoCnpj = NumeroAleatorio.Novo(10).ToString() +
                              NumeroAleatorio.Novo(10).ToString() +
                              NumeroAleatorio.Novo(10).ToString() +
                              NumeroAleatorio.Novo(10).ToString() +
                              NumeroAleatorio.Novo(10).ToString() +                                                                                          
                              NumeroAleatorio.Novo(10).ToString() +
                              NumeroAleatorio.Novo(10).ToString() +                                                            
                              NumeroAleatorio.Novo(10).ToString() +       
                              NumeroAleatorio.Novo(100, 4);

            novoCnpj = novoCnpj + CalcularDigitoVerificador(novoCnpj);

            try
            {
                return new Cnpj(novoCnpj);
            }
            catch(ArgumentException)
            {
                return Gerar();
            }
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return NumeroCnpjSemPontuacao;
            yield return NumeroCnpjFormatado;
        }
    }    
}