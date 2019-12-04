using Newtonsoft.Json;
using Posto.ApplicationCore.Entities;
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
        public void pegarChamado()
        {
            // Arrange
            Chamado teclado = new Chamado(1,1,1,1,new DateTime(),null,null,"Rachadura","Fissura",null,null,null,null,"rodrigo",true);
            teclado.Id_Equipamento = 1;
            PostoContext postoContext = new PostoContext();
            // Act
            UsuarioRepositoryTeste repo = new UsuarioRepositoryTeste(postoContext);
            var tecladoRepository = repo.GetById(1);

            // Assert
            var obj1Str = JsonConvert.SerializeObject(tecladoRepository);
            var obj2Str = JsonConvert.SerializeObject(teclado);
            Assert.Equal(obj1Str, obj2Str);
        }
    }
}
