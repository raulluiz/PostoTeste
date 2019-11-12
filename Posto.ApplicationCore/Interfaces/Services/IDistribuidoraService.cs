using Microsoft.AspNetCore.Identity;
using Posto.ApplicationCore.Entities;
using Posto.ApplicationCore.ViewModels;

namespace Posto.ApplicationCore.Interfaces.Services
{
    public interface IDistribuidoraService : IBaseService<Distribuidora>
    {
        Usuario AddUsuarioDistribuidora(IdentityUser usuarioIdentity, DistribuidoraVM distribuidora, string empresa_Global);
        Distribuidora AddDistribuidora(DistribuidoraVM distribuidora);
        void UpdateDistribuidora(DistribuidoraVM obj);
        void RemoverDistribuidora(int id);
    }
}