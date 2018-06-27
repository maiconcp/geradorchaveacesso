using System;
using Xunit;

namespace GeradorChaveAcesso.Dominio.Tests
{
    public class EstadoTest
    {
        [Fact]
        public void Deve_Ter_27_Estados_Na_Lista_Todos()
        {
            // Arrange
            // Act
            // Assert
            Assert.Equal(27, Estado.Todos.Count);
        }
    }
}