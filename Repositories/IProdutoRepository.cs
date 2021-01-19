using System;
using System.Collections.Generic;
using kodigos.api.Models;

namespace kodigos.api.Repositories 
{
    public interface IProdutoRepository 
    {
        void adicionar(Produto prod);

        void alterar(Produto prod);

        IEnumerable<Produto> listarProdutos();

        Produto buscarProduto(int id);
        
        void RemoverProduto(Produto prod);
    }
}