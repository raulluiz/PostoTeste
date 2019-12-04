using Newtonsoft.Json;
using Posto.ApplicationCore.Entities;
using Posto.ApplicationCore.Enum;
using Posto.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;
using Teste.Posto.RepositoryTeste;
using Xunit;

namespace Teste.Posto.EntidadeTeste
{
    public class ClienteTeste
    {
        public void pegarCliente()
        {
            // Arrange
            Cliente cliente = new Cliente();
            cliente.Id_Equipamento = 1;
            PostoContext postoContext = new PostoContext();
            // Act
            ClienteRepositoryTeste repo = new ClienteRepositoryTeste(postoContext);
            var clienteRepository = repo.GetById(1);

            // Assert
            var obj1Str = JsonConvert.SerializeObject(clienteRepository);
            var obj2Str = JsonConvert.SerializeObject(cliente);
            Assert.Equal(obj1Str, obj2Str);
        }
    }
}
