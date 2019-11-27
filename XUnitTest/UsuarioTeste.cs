using Posto.ApplicationCore.Entities;
using Posto.ApplicationCore.Enum;
using Posto.ApplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTest
{
    public class UsuarioTeste
    {
        private readonly Usuario _usuario;
        public UsuarioTeste(Usuario usuarioService)
        {
            _usuario = usuarioService;
        }

        [Fact]
        public void PegarUsuarioEspecifico()
        {
            // Arranje
            Usuario usuario = new Usuario(2,"Raul", true, "09719336420", "ba694ae5-0c7f-4500-9012-e026644467f2", EnumPerfil.Administrador,null);

            // Act
            var usuarioBanco = _usuario.Ativo;

            // Assert
            Assert.Equal(usuario.Nome, "");
        }
    }
}
