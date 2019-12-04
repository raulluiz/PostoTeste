using Moq;
using Newtonsoft.Json;
using Posto.ApplicationCore.Entities;
using Posto.ApplicationCore.Enum;
using Posto.ApplicationCore.Interfaces.Services;
using Posto.Infrastructure.Context;
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
            Usuario raul = new Usuario("Raul", true, "09719336420", "ba694ae5-0c7f-4500-9012-e026644467f2", EnumPerfil.Administrador);
            raul.Id_Usuario = 2;
            PostoContext postoContext = new PostoContext();
            // Act
            UsuarioRepositoryTeste repo = new UsuarioRepositoryTeste(postoContext);
            var raulRepository = repo.GetById(2);

            // Assert
            var obj1Str = JsonConvert.SerializeObject(raulRepository);
            var obj2Str = JsonConvert.SerializeObject(raul);
            Assert.Equal(obj1Str, obj2Str);

            //Assert.Equals(raul, teste);
        }

    }
}
