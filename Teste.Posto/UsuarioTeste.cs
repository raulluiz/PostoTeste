using Moq;
using Posto.ApplicationCore.Entities;
using Posto.ApplicationCore.Enum;
using Posto.ApplicationCore.Interfaces.Services;
using Posto.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Teste.Posto
{
    public class UsuarioTeste
    {
        //#region Injeção de Depenência
        //private readonly IUsuarioService _usuarioService;
        //public UsuarioTeste(IUsuarioService usuarioService)
        //{
        //    _usuarioService = usuarioService;
        //}
        //#endregion

        [Fact]
        public void PegarUsuario()
        {
            // Arrange
            Usuario raul = new Usuario("Raul", true, "09719336420", "", EnumPerfil.Administrador);

            // Act
            var repo = new UsuarioRepositoryTeste();
            var teste = repo.GetById();

            // Assert
            Assert.Equal("", "");
        }

    }
}
