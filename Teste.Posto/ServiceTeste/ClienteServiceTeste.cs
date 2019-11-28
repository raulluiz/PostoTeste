using Microsoft.AspNetCore.Identity;
using Posto.ApplicationCore.Entities;
using Posto.ApplicationCore.Interfaces.Services;
using Posto.ApplicationCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Teste.Posto.ServiceTeste 
{
    class ClienteServiceTeste : BaseService<Cliente>, IClienteService
    {
        public Cliente Add(Cliente entity)
        {
            throw new NotImplementedException();
        }

        public Cliente AddCliente(ClienteVM cliente)
        {
            throw new NotImplementedException();
        }

        public Endereco AddEnderecoCliente(ClienteVM cliente)
        {
            throw new NotImplementedException();
        }

        public Usuario AddUsuarioCliente(IdentityUser usuarioIdentity, ClienteVM cliente, int id_Endereco, string empresa_Global)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cliente> Get(Expression<Func<Cliente, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cliente> GetAll()
        {
            throw new NotImplementedException();
        }

        public Cliente GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ClienteVM GetCliente(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Cliente entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveCliente(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Cliente entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateCliente(ClienteVM cliente)
        {
            throw new NotImplementedException();
        }

        public void UpdateEndereco(ClienteVM cliente)
        {
            throw new NotImplementedException();
        }

        public Usuario UpdateUsuario(ClienteVM cliente)
        {
            throw new NotImplementedException();
        }
    }
}
