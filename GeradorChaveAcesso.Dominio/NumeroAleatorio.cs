using System;

namespace GeradorChaveAcesso.Dominio
{
    public class NumeroAleatorio
    {
        private static readonly Random Gerador = new Random(DateTime.Now.Millisecond); 
        public static int Novo(int ate)
        {
            return Gerador.Next(ate);
        }

        public static string Novo(int ate, int digitos)
        {
            return Novo(ate).ToString($"D{digitos}");
        }
    }
}