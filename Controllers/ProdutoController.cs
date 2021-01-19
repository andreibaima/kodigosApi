using System;
using System.Collections.Generic;
using kodigos.api.Models;
using kodigos.api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace kodigos.api.Controllers
{
    public class ProdutoController: Controller
    {
        // essa propriedade depois de instanciada não pode ser alterada
        private readonly IProdutoRepository _repositorio;

        public ProdutoController(IProdutoRepository repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet("v1/Produto")]
        public IActionResult listarProduto() {
            return Ok(
                _repositorio.listarProdutos()
            );
        }
    
        [HttpPost("v1/Produto")]
        public IActionResult adicionarProduto([FromBody]Produto prod) 
        {
            // prod.id = 0;
            _repositorio.adicionar(prod);
            return Ok();
        }

        [HttpPut("v1/Produto/{id}")]
        public IActionResult alterarProduto(int id, [FromBody]Produto prod) 
        {
            //resgatar o fundo
            var prod_pesq = _repositorio.buscarProduto(id);
            if (prod_pesq == null) {
                return NotFound();
            }
            prod_pesq.nome = prod.nome;
            prod_pesq.descricao = prod.descricao;
            prod_pesq.uniMedida = prod.uniMedida;
            _repositorio.alterar(prod_pesq);
            return Ok();
        }

        [HttpGet("v1/Produto/{id}")]
        public IActionResult buscarProduto(int id) 
        {
            var prod_pesq = _repositorio.buscarProduto(id);
            if (prod_pesq == null) {
                return NotFound();
            }

            return Ok(prod_pesq);
        }

        [HttpDelete("v1/Produto/{id}")]
        public IActionResult deletarProduto(int id) 
        {
            var prod_pesq = _repositorio.buscarProduto(id);
            if (prod_pesq == null) {
                return NotFound();
            }

            _repositorio.RemoverProduto(prod_pesq);
            return Ok();
        }

    }
}