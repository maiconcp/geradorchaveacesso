using System;
using Xunit;

namespace GeradorChaveAcesso.Dominio.Tests
{
    public class ChaveAcessoTest
    {
        [Fact]
        public void Deve_Gerar_Uma_Chave_Valida()
        {
            // Arrange
            // Act
            var chave = new ChaveAcesso(Estado.SaoPaulo,
                                        new DateTime(2018, 6, 1), 
                                        new Cnpj("30229261000149"),
                                        Modelo.NFe,
                                        1,
                                        2499,
                                        FormaEmissao.Normal,
                                        270895);

            // Assert
            Assert.Equal("35180630229261000149550010000024991002708951", chave.Chave);
        }
    }
}