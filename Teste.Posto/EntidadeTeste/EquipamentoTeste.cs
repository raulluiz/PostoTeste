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
    public class EquipamentoTeste
    {
        public void pegarEquipamento()
        {
            // Arrange
            Equipamento teclado = new Equipamento("Teclado", EnumTipoSerie.Dupla,"0001", 1);
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
