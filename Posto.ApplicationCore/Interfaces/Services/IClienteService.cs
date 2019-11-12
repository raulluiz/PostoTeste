using Microsoft.AspNetCore.Identity;
using Posto.ApplicationCore.Entities;
using Posto.ApplicationCore.ViewModels;

namespace Posto.ApplicationCore.Interfaces.Services
{
    public interface IClienteService : IBaseService<Cliente>
    {
        //List<Empresa> GetEmpresaPorAtivo(string nome);
        Usuario AddUsuarioCliente(IdentityUser usuarioIdentity, ClienteVM cliente, int id_Endereco, string empresa_Global);
        Endereco AddEnderecoCliente(ClienteVM cliente);
        Cliente AddCliente(ClienteVM cliente);
        ClienteVM GetCliente(int id);
        Usuario UpdateUsuario(ClienteVM cliente);
        void UpdateEndereco(ClienteVM cliente);
        void UpdateCliente(ClienteVM cliente);
        void RemoveCliente(int id);
    }
}