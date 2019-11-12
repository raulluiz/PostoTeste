using Microsoft.AspNetCore.Identity;
using Posto.ApplicationCore.Entities;
using Posto.ApplicationCore.ViewModels;

namespace Posto.ApplicationCore.Interfaces.Services
{
    public interface IUsuarioService : IBaseService<Usuario>
    {
        //UsuarioIdentityVM GetFullUserIdentity(IdentityUser identityUser, UsuarioIdentityVM usuario);
    }
}