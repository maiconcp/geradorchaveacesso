using System;

namespace GeradorChaveAcesso.Dominio
{
    public class CalculadoraDigitoVerificadorChaveAcesso
    {
        public int Calcular(string chave)
        {
            chave = chave.Substring(0, 43);
            int[] multiplicadores = { 2, 3, 4, 5, 6, 7, 8, 9, 2, 3, 4, 5, 6, 7, 8, 9 };
            int indexMult = 0;
            int somaAcumulada = 0;

            for (int indexChave = chave.Length - 1; indexChave >= 0; indexChave--)
            {
                somaAcumulada += Convert.ToInt32(chave[indexChave].ToString()) * multiplicadores[indexMult];
                if (indexMult == 9)
                {
                    indexMult = 2;
                }
                else
                {
                    indexMult++;
                }
            }

            int digitoVerificador = (somaAcumulada * 10) % 11; ;

            if (digitoVerificador >= 10)
            {
                digitoVerificador = 0;
            }

            return digitoVerificador;
        }
    }
}