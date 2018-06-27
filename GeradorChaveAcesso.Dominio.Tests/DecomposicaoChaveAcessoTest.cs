using System;
using System.Linq;
using Xunit;

namespace GeradorChaveAcesso.Dominio.Tests
{
    public class DecomposicaoChaveAcessoTest
    {
        public const string Chave = "35180630229261000149550010000024991002708951";
        public const string ChaveInvalida = "99999999999999999999999999999999999999999999";

        // -----------------------------------------------
        // Estado
        [Fact]
        public void Estado_ChaveValida_UfIdentificado()
        {
            // Arrange
            // Act
            var decomposicao = new DecomposicaoChaveAcesso(Chave);

            // Assert
            Assert.Equal(Estado.SaoPaulo.Codigo, decomposicao.Estado.Codigo);
        }

        [Fact]
        public void Estado_ChaveInvalida_UfNaoIdentificado()
        {
            // Arrange
            // Act
            var decomposicao = new DecomposicaoChaveAcesso(ChaveInvalida);

            // Assert
            Assert.Null(decomposicao.Estado);
            Assert.True(decomposicao.Erros.Any(w => w.StartsWith("Estado")));
        }        

        // -----------------------------------------------
        // Data Emissao
        [Fact]
        public void DataEmissao_ChaveValida_DataIdentificado()
        {
            // Arrange
            // Act
            var decomposicao = new DecomposicaoChaveAcesso(Chave);

            // Assert
            Assert.Equal(6, decomposicao.DataEmissao.Month);
            Assert.Equal(2018, decomposicao.DataEmissao.Year);
        }

        [Fact]
        public void DataEmissao_ChaveInvalida_DataNaoIdentificado()
        {
            // Arrange
            // Act
            var decomposicao = new DecomposicaoChaveAcesso(ChaveInvalida);

            // Assert
            Assert.Equal(default(DateTime), decomposicao.DataEmissao);
            Assert.True(decomposicao.Erros.Any(w => w.StartsWith("Data")));
        }               
        
        // -----------------------------------------------        
        // Emitente
        [Fact]
        public void Emitente_ChaveValida_CnpjIdentificado()
        {
            // Arrange
            // Act
            var decomposicao = new DecomposicaoChaveAcesso(Chave);

            // Assert
            Assert.Equal("30229261000149", decomposicao.Emitente.NumeroCnpjSemPontuacao);
        }

        [Fact]
        public void Emitente_ChaveInvalida_CnpjNaoIdentificado()
        {
            // Arrange
            // Act
            var decomposicao = new DecomposicaoChaveAcesso(ChaveInvalida);

            // Assert
            Assert.Null(decomposicao.Emitente);
            Assert.True(decomposicao.Erros.Any(w => w.StartsWith("CNPJ")));
        }        

        // -----------------------------------------------        
        // Modelo
        [Fact]
        public void Modelo_ChaveValida_ModeloIdentificado()
        {
            // Arrange
            // Act
            var decomposicao = new DecomposicaoChaveAcesso(Chave);

            // Assert
            Assert.Equal(Modelo.NFe.Codigo, decomposicao.Modelo.Codigo);
        }

        [Fact]
        public void Modelo_ChaveInvalida_ModeloNaoIdentificado()
        {
            // Arrange
            // Act
            var decomposicao = new DecomposicaoChaveAcesso(ChaveInvalida);

            // Assert
            Assert.Null(decomposicao.Modelo);
            Assert.True(decomposicao.Erros.Any(w => w.StartsWith("Modelo")));
        }  

        // -----------------------------------------------
        // Serie
        [Fact]
        public void Serie_ChaveValida_SerieIdentificado()
        {
            // Arrange
            // Act
            var decomposicao = new DecomposicaoChaveAcesso(Chave);

            // Assert
            Assert.Equal(1, decomposicao.Serie);
        }

        [Fact]
        public void Serie_ChaveInvalida_SerieNaoIdentificado()
        {
            // Arrange
            // Act
            var decomposicao = new DecomposicaoChaveAcesso("99999999999999999");

            // Assert
            Assert.Equal(default(UInt16), decomposicao.Serie);
        }               
        
        // -----------------------------------------------
        // Número
        [Fact]
        public void Numero_ChaveValida_NumeroIdentificado()
        {
            // Arrange
            // Act
            var decomposicao = new DecomposicaoChaveAcesso(Chave);

            // Assert
            Assert.Equal((uint)2499, decomposicao.Numero);
        }

        [Fact]
        public void Numero_ChaveInvalida_NumeroNaoIdentificado()
        {
            // Arrange
            // Act
            var decomposicao = new DecomposicaoChaveAcesso("99999999999999999");

            // Assert
            Assert.Equal(default(uint), decomposicao.Numero);
        }   

        // -----------------------------------------------        
        // Forma de Emissao
        [Fact]
        public void FormaEmissao_ChaveValida_FormaEmissaoIdentificado()
        {
            // Arrange
            // Act
            var decomposicao = new DecomposicaoChaveAcesso(Chave);

            // Assert
            Assert.Equal(FormaEmissao.Normal.Codigo, decomposicao.FormaEmissao.Codigo);
        }

        [Fact]
        public void FormaEmissao_ChaveInvalida_FormaEmissaoNaoIdentificado()
        {
            // Arrange
            // Act
            var decomposicao = new DecomposicaoChaveAcesso(ChaveInvalida);

            // Assert
            Assert.Null(decomposicao.FormaEmissao);
            Assert.True(decomposicao.Erros.Any(w => w.StartsWith("Forma")));
        }  

        // -----------------------------------------------
        // Codigo Numerico
        [Fact]
        public void CodigoNumerico_ChaveValida_CodigoNumericoIdentificado()
        {
            // Arrange
            // Act
            var decomposicao = new DecomposicaoChaveAcesso(Chave);

            // Assert
            Assert.Equal((uint)270895, decomposicao.CodigoNumerico);
        }

        [Fact]
        public void CodigoNumerico_ChaveInvalida_CodigoNumericoNaoIdentificado()
        {
            // Arrange
            // Act
            var decomposicao = new DecomposicaoChaveAcesso("99999999999999999");

            // Assert
            Assert.Equal(default(uint), decomposicao.CodigoNumerico);
        }

        // -----------------------------------------------
        // Digito
        [Fact]
        public void Digito_ChaveValida_DigitoIdentificado()
        {
            // Arrange
            // Act
            var decomposicao = new DecomposicaoChaveAcesso(Chave);

            // Assert
            Assert.Equal((byte)1, decomposicao.Digito);
        }

        [Fact]
        public void Digito_ChaveInvalida_DigitoNaoIdentificado()
        {
            // Arrange
            // Act
            var decomposicao = new DecomposicaoChaveAcesso("99999");

            // Assert
            Assert.Equal(default(byte), decomposicao.Digito);
        }        

        // IsValid
        [Fact]
        public void IsValid_ChaveValida_True()
        {
            // Arrange
            // Act
            var decomposicao = new DecomposicaoChaveAcesso(Chave);

            // Assert
            Assert.True(decomposicao.IsValid);
        }        

        [Fact]
        public void IsValid_ChaveInvalida_False()
        {
            // Arrange
            // Act
            var decomposicao = new DecomposicaoChaveAcesso(ChaveInvalida);

            // Assert
            Assert.False(decomposicao.IsValid);
        }                  
    }
}