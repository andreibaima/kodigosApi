using System;
using kodigos.api.Models;
using kodigos.api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace kodigos.api.Controllers 
{
    public class EstoqueController: Controller
    {
        private readonly IProdutoRepository _produto;

        // __________________________________________________
        private readonly IEstoqueRepository _repositorioEst;

        public EstoqueController(IEstoqueRepository repositorioEst, IProdutoRepository produto)
        {
            _repositorioEst = repositorioEst;
            _produto = produto;

        }

        [HttpGet("v1/Estoque")]
        public IActionResult listarEstoque()
        {
            return Ok(
                _repositorioEst.listarProdEstoque()
            );
        }

        [HttpPost("v1/Estoque/")]
        public IActionResult adicionarProdEstoque([FromBody]Estoque estoque) 
        {

            var prod_pesq = _produto.buscarProduto(estoque.id_prod);

            if (prod_pesq == null) {
                return NotFound();
            }

            
            // -----------------------------------------*/
            _repositorioEst.adicionarProdEstoque(estoque);
            return Ok();
        }

        [HttpPut("v1/Estoque/{id}")]
        public IActionResult alterarProdEstoque(Guid id, [FromBody] Estoque estoque) 
        {
            var estoque_pesq = _repositorioEst.buscarProdEstoque(id);
            if(estoque_pesq == null) {
                // return NotFound();
                 return NotFound();
            }
            estoque_pesq.id_prod = estoque.id_prod;
            estoque_pesq.qtd = estoque.qtd;
            _repositorioEst.alterarProdEstoque(estoque_pesq);
            return Ok();
        }

        [HttpGet("v1/Estoque/{id}")]
        public IActionResult bucarProdEstoque(Guid id) {
            var estoque_pesq = _repositorioEst.buscarProdEstoque(id);

            if (estoque_pesq == null) {
                return NotFound();
            }

            return Ok(estoque_pesq);
        }

        [HttpDelete("v1/Estoque/{id}")]
        public IActionResult removerProdEstoque(Guid id) {
            var estoque_pesq = _repositorioEst.buscarProdEstoque(id);
            
            if (estoque_pesq == null) {
                return NotFound();
            }

            _repositorioEst.removerProdEstoque(estoque_pesq);
            return Ok();
        }

        [HttpGet("v1/Estoque/Produto")]
        
        public IActionResult listarProd()
        {
            return Ok(
                _produto.listarProdutos()
            );
        }
    }
}