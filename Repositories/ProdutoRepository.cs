using System;
using System.Collections.Generic;
using System.Linq;
using kodigos.api.Models;

namespace kodigos.api.Repositories 
{
    public class ProdutoRepository: IProdutoRepository
    {

        private int cont = 1;

        private readonly List<Produto> _prods;

        public ProdutoRepository()
        {
            //Criando para que não seja nulo
            _prods = new List<Produto>();
        }

        public void adicionar(Produto prod)
        {
            prod.id = this.cont++;
            // __________________
            _prods.Add(prod);
        }

        public void alterar(Produto prod)
        {
            var index = _prods.FindIndex(0, x => x.id == prod.id);

            _prods[index] = prod;
        }

        public Produto buscarProduto(int id)
        {
            //expressão lampida compara todos os elementos da lista
            return _prods.FirstOrDefault(x => x.id == id);
        }

        public IEnumerable<Produto> listarProdutos()
        {
            return _prods;
        }

        public void RemoverProduto(Produto prod)
        {
           _prods.Remove(prod);
        }
    }
}