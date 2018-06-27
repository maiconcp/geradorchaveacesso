using System;
using Xunit;

namespace GeradorChaveAcesso.Dominio.Tests
{
    public class CnpjTest
    {
        [Theory]
        [InlineData("15.959.574/0001-69", "15959574000169")]
        [InlineData("15959574/0001-69", "15959574000169")]
        [InlineData("159595740001-69", "15959574000169")]
        [InlineData("15959574000169", "15959574000169")]
        [InlineData("00.578.003/0001-07", "00578003000107")]
        public void SemPontuacao_CpnjComPontuacao_CnpjSemPontuacao(string numeroCnpj, string cnpjSemFormatacaoEsperado)
        {
            // Arrange
            var cnpj = new Cnpj(numeroCnpj);

            // Act
            string cnpjSemPontuacao = cnpj.NumeroCnpjSemPontuacao;

            // Assert
            Assert.Equal(cnpjSemFormatacaoEsperado, cnpjSemPontuacao);
        }

        [Theory]
        [InlineData("15.959.574/0001-69", "15.959.574/0001-69")]
        [InlineData("15959574/0001-69", "15.959.574/0001-69")]
        [InlineData("159595740001-69", "15.959.574/0001-69")]
        [InlineData("15959574000169", "15.959.574/0001-69")]
        [InlineData("00578003000107", "00.578.003/0001-07")]
        public void Formatado_CpnjComESemPontuacao_CnpjFormatado(string numeroCnpj, string cnpjFormatadoEsperado)
        {
            // Arrange
            var cnpj = new Cnpj(numeroCnpj);

            // Act
            string cnpjFormatado = cnpj.NumeroCnpjFormatado;

            // Assert
            Assert.Equal(cnpjFormatadoEsperado, cnpjFormatado);
        }

        [Theory]
        [InlineData("15.959.574/0001-69", "15.959.574/0001-69")]
        [InlineData("15.959.574/0001-69", "15959574/0001-69")]
        [InlineData("15.959.574/0001-69", "159595740001-69")]
        [InlineData("15.959.574/0001-69", "15959574000169")]
        public void Equals_CnpjsComPontuacaoDiferenteMasMesmoNumero_Iguais(string numeroCnpj1, string numeroCnpj2)
        {
            // Arrange
            var cnpj1 = new Cnpj(numeroCnpj1);
            var cnpj2 = new Cnpj(numeroCnpj2);

            // Act
            // Assert
            Assert.True(cnpj1 == cnpj2);
        }

        [Theory]
        [InlineData("37.221.403/0001-70", "15.959.574/0001-69")]
        [InlineData("37.221.403/0001-70", "15959574/0001-69")]
        [InlineData("37.221.403/0001-70", "159595740001-69")]
        [InlineData("37.221.403/0001-70", "15959574000169")]
        public void NotEquals_CnpjsNumerosDiferentes_Diferentes(string numeroCnpj1, string numeroCnpj2)
        {
            // Arrange
            var cnpj1 = new Cnpj(numeroCnpj1);
            var cnpj2 = new Cnpj(numeroCnpj2);

            // Act
            // Assert
            Assert.True(cnpj1 != cnpj2);
        }


        [Theory]
        [InlineData("37.221.403/0001-70")]
        [InlineData("15.959.574/0001-69")]
        public void EhValido_CnpjValido_SemExcecao(string numeroCnpj)
        {
            // Arrange
            // Act
            // Assert
            new Cnpj(numeroCnpj);
        }        

        [Theory]
        [InlineData("11.221.403/0001-70")]
        [InlineData("11.959.574/0001-69")]
        [InlineData("11.111.111/1111-11")]
        [InlineData("1234")]
        [InlineData("")]
        public void EhValido_CnpjInvalido_Exception(string numeroCnpj)
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => 
            {
                new Cnpj(numeroCnpj);
            });
        }

        [Fact]
        public void Deve_Gerar_Novo_Cnpj_Valido()
        {
            // Arrange
            // Act
            var novoCnpj = Cnpj.Gerar();            
            Console.WriteLine(novoCnpj.NumeroCnpjFormatado);

            // Assert
            Assert.NotNull(novoCnpj);
            Assert.Equal(Cnpj.TAMANHO, novoCnpj.NumeroCnpjSemPontuacao.Length);
        }
    }
}
