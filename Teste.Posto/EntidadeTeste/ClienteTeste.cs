using Newtonsoft.Json;
using Posto.ApplicationCore.Entities;
using Posto.ApplicationCore.Enum;
using Posto.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Teste.Posto.EntidadeTeste
{
    public class ClienteTeste
    {
        public void pegarCliente()
        {
            // Arrange
            Cliente rodrigo = new Cliente("");
            rodrigo.Id_Equipamento = 1;
            PostoContext postoContext = new PostoContext();
            // Act
            UsuarioRepositoryTeste repo = new UsuarioRepositoryTeste(postoContext);
            var rodrigoRepository = repo.GetById(1);

            // Assert
            var obj1Str = JsonConvert.SerializeObject(rodrigoRepository);
            var obj2Str = JsonConvert.SerializeObject(rodrigo);
            Assert.Equal(obj1Str, obj2Str);
        }
    }
}
