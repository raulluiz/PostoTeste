using Moq;
using Newtonsoft.Json;
using Posto.ApplicationCore.Entities;
using Posto.ApplicationCore.Enum;
using Posto.ApplicationCore.Interfaces.Services;
using Posto.ApplicationCore.ViewModels;
using Posto.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;
using Teste.Posto.RepositoryTeste;
using Xunit;

namespace Teste.Posto.EntidadeTeste
{
    public class EquipamentoTeste
    {
        [Fact]
        public void PegarEquipamento()
        {
            // Arrange
            Equipamento equipamento = new Equipamento("Teclado", EnumTipoSerie.Dupla,"0001", 1);
            equipamento.Id_Equipamento = 1;
            Mock<IEquipamentoService> mock = new Mock<IEquipamentoService>();
            mock.Setup(ie => ie.GetById(It.IsAny<int>())).Returns(equipamento);

            // Act
            var resultadoEsperado = mock.Object.GetById(1);
            var resultado = equipamento;

            // Assert
            Assert.Equal(resultado, resultadoEsperado);
        }

        [Fact]
        public void RemoverEquipamento()
        {
            // Arrange
            
            Mock<IEquipamentoService> mock = new Mock<IEquipamentoService>();
            mock.Setup(ie => ie.RemoverEquipamento(It.IsAny<int>(), It.IsAny<int>())).Returns("Removido com sucesso!");

            // Act
            var resultadoEsperado = mock.Object.RemoverEquipamento(1,1);
            string resultado = "Removido com sucesso!";

            // Assert
            Assert.Equal(resultado, resultadoEsperado);
        }

        [Fact]
        public void SalvarEquipamento()
        {
            // Arrange
            EquipamentoVM equipamentoVM = new EquipamentoVM();
            Mock<IEquipamentoService> mock = new Mock<IEquipamentoService>();
            mock.Setup(ie => ie.SalvarEquipamento(It.IsAny<EquipamentoVM>())).Returns("Salvo com sucesso!");

            // Act
            var resultadoEsperado = mock.Object.SalvarEquipamento(equipamentoVM);
            string resultado = "Salvo com sucesso!";

            // Assert
            Assert.Equal(resultado, resultadoEsperado);
        }

        [Fact]
        public void AlterarEquipamento()
        {
            // Arrange
            EquipamentoVM equipamentoVM = new EquipamentoVM();
            Mock<IEquipamentoService> mock = new Mock<IEquipamentoService>();
            mock.Setup(ie => ie.UpdateEquipamento(It.IsAny<EquipamentoVM>())).Returns("Editado com sucesso!");

            // Act
            var resultadoEsperado = mock.Object.UpdateEquipamento(equipamentoVM);
            string resultado = "Editado com sucesso!";

            // Assert
            Assert.Equal(resultado, resultadoEsperado);
        }

        [Fact]
        public void PegarTodosEquipamentos()
        {
            List<Equipamento> equipamentos = new List<Equipamento>();
            // Arrange
            Mock<IEquipamentoService> mock = new Mock<IEquipamentoService>();
            mock.Setup(ie => ie.GetAll()).Returns(equipamentos);

            // Act
            var resultadoEsperado = mock.Object.GetAll();
            var resultado = equipamentos;

            // Assert
            Assert.Equal(resultado, resultadoEsperado);
        }
    }
}
