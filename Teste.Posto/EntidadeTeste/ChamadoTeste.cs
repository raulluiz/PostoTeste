using Microsoft.AspNetCore.Mvc.Rendering;
using Moq;
using Newtonsoft.Json;
using Posto.ApplicationCore.Entities;
using Posto.ApplicationCore.Interfaces.Services;
using Posto.ApplicationCore.ViewModels;
using Posto.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Teste.Posto.EntidadeTeste
{
    public class ChamadoTeste
    {
        [Fact]
        public void PegarChamado()
        {
            // Arrange
            Chamado chamado = new Chamado(1, 1, 1, 1, new DateTime(), null, null, "Rachadura", "Fissura", null, null, null, null, "rodrigo", true);
            chamado.Id_Chamado = 1;
            Mock<IChamadoService> mock = new Mock<IChamadoService>();
            mock.Setup(ie => ie.GetById(It.IsAny<int>())).Returns(chamado);

            // Act
            var resultadoEsperado = mock.Object.GetById(1);
            var resultado = chamado;

            // Assert
            Assert.Equal(resultado, resultadoEsperado);
        }

        [Fact]
        public void SalvarChamado()
        {
            // Arrange
            Chamado chamado = new Chamado(1, 1, 1, 1, new DateTime(), null, null, "Rachadura", "Fissura", null, null, null, null, "rodrigo", true);
            chamado.Id_Chamado = 1;
            Mock<IChamadoService> mock = new Mock<IChamadoService>();
            mock.Setup(ie => ie.SalvarChamado(It.IsAny<ChamadoVM>(), It.IsAny<int>())).Returns(chamado);

            ChamadoVM chamadoVM = new ChamadoVM();

            // Act
            var resultadoEsperado = mock.Object.SalvarChamado(chamadoVM,1);
            var resultado = chamado;

            // Assert
            Assert.Equal(resultado, resultadoEsperado);
        }

        [Fact]
        public void PegarProdutosDoChamado()
        {
            // Arrange
            List<SelectListItem> lista = new List<SelectListItem>();
            Mock<IChamadoService> mock = new Mock<IChamadoService>();
            mock.Setup(ie => ie.GetProdutosChamado(It.IsAny<ChamadoVM>())).Returns(lista);

            ChamadoVM chamadoVM = new ChamadoVM();

            // Act
            var resultadoEsperado = mock.Object.GetProdutosChamado(chamadoVM);
            var resultado = lista;

            // Assert
            Assert.Equal(resultado, resultadoEsperado);
        }

        [Fact]
        public void PegarTodosChamados()
        {
            // Arrange
            List<Chamado> lista = new List<Chamado>();
            Mock<IChamadoService> mock = new Mock<IChamadoService>();
            mock.Setup(ie => ie.GetAll()).Returns(lista);

            ChamadoVM chamadoVM = new ChamadoVM();

            // Act
            var resultadoEsperado = mock.Object.GetAll();
            var resultado = lista;

            // Assert
            Assert.Equal(resultado, resultadoEsperado);
        }
    }
}
