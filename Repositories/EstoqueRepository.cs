using System;
using System.Collections.Generic;
using System.Linq;
using kodigos.api.Models;

namespace kodigos.api.Repositories
{
    public class EstoqueRepository: IEstoqueRepository
    {
        private readonly List<Estoque> _estqs;
        // __________________________________________
        private readonly List<Produto> _prods;

        public EstoqueRepository()
        {
            _estqs = new List<Estoque>();
            // _prods = new List<Produto>();
        }

        public void adicionarProdEstoque(Estoque estoque)
        {
            // var index = _prods.FindIndex(0, x => x.id == prod.id);
            _estqs.Add(estoque);
        }

        public void alterarProdEstoque(Estoque estoque)
        {
            var index = _estqs.FindIndex(0, x => x.id == estoque.id);

            _estqs[index] = estoque;
        }

        public Estoque buscarProdEstoque(Guid id)
        {
            return _estqs.FirstOrDefault(x => x.id == id);
        }

        public IEnumerable<Estoque> listarProdEstoque()
        {
            return _estqs;
        }

        public void removerProdEstoque(Estoque estoque)
        {
            _estqs.Remove(estoque);
        }

        public IEnumerable<Produto> listarProdutos() {
            return _prods;
        }

    }
}