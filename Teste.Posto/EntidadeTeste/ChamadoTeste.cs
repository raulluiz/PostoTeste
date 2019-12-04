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
        public void pegarChamado()
        {
            // Arrange
            Chamado teclado = new Chamado(1,1,1,1,"2019/12/03","2019/12/25","2020/01/01","Rachadura","Fissura","cobre com cimento","resolveu","tempo de cura",1,"rodrigo","1");
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
