using Posto.ApplicationCore.Entities;
using Posto.ApplicationCore.ViewModels;

namespace Posto.ApplicationCore.Interfaces.Services
{
    public interface IProdutoService : IBaseService<Produto>
    {
        void SalvarProduto(ProdutoVM produtoVM);
        void UpdateProduto(ProdutoVM produtoVM);
        void RemoverProduto(int idEmpresa, int id_Serie, int id_Produto);
    }
}