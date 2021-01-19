using System;
using System.Collections.Generic;
using kodigos.api.Models;

namespace kodigos.api.Repositories
{
    public interface IEstoqueRepository
    {
        IEnumerable<Estoque> listarProdEstoque();

        void adicionarProdEstoque(Estoque estoque);

        void alterarProdEstoque(Estoque estoque);

        void removerProdEstoque(Estoque estoque);

        Estoque buscarProdEstoque(Guid id);

        IEnumerable<Produto> listarProdutos();
    }
}