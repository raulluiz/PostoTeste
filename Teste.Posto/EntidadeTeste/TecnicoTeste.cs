using Newtonsoft.Json;
using Posto.ApplicationCore.Entities;
using Posto.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;
using Teste.Posto.RepositoryTeste;
using Xunit;

namespace Teste.Posto.EntidadeTeste
{
    public class TecnicoTeste
    {
        [Fact]
        public void PegarTecnicoTeste()
        {
            // Arrange
            Tecnico tecnico = new Tecnico(1002, 34475046092, Convert.ToDateTime("2019-12-25T13:15:00"), 1);
            tecnico.Id_Tecnico= 1;
            tecnico.Nome = "tecnico";

            PostoContext postoContext = new PostoContext();
            // Act
            TecnicoRepositoryTeste repo = new TecnicoRepositoryTeste(postoContext);
            var tecnicoRepository = repo.GetById(1);

            // Assert
            var obj1Str = JsonConvert.SerializeObject(tecnicoRepository);
            var obj2Str = JsonConvert.SerializeObject(tecnico);
            Assert.Equal(obj1Str, obj2Str);
        }
    }
}
