using Newtonsoft.Json;
using Posto.ApplicationCore.Entities;
using Posto.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Teste.Posto.EntidadeTeste
{
    public class TecnicoTeste
    {
        public void PegarTecnicoTeste()
        {
            // Arrange
            Tecnico raul = new Tecnico(3,"",new DateTime(),1);
            raul.Id_Usuario = 2;
            PostoContext postoContext = new PostoContext();
            // Act
            UsuarioRepositoryTeste repo = new UsuarioRepositoryTeste(postoContext);
            var raulRepository = repo.GetById(2);

            // Assert
            var obj1Str = JsonConvert.SerializeObject(raulRepository);
            var obj2Str = JsonConvert.SerializeObject(raul);
            Assert.Equal(obj1Str, obj2Str);
        }
    }
}
