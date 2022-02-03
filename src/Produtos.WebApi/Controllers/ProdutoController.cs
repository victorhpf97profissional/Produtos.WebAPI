using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Produtos.Domain.Interfaces;
using Produtos.Infra.Contexto;
using Produtos.Domain.Models;
using System.Threading.Tasks;
using AutoMapper;
using Produtos.WebApi.ModelsViews;
using Produtos.Domain.Paginacao;

namespace Produtos.WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private IProdutoServico _produtoServico;
        private readonly DbContexto _contexto;
        private readonly IMapper _autoMapper;

        public ProdutoController(DbContexto contexto, IProdutoServico produtoServico, IMapper autoMapper)
        {
            _contexto = contexto;
            _produtoServico = produtoServico;
            _autoMapper = autoMapper;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState.Values);
                var produtosEncontrado = _autoMapper.Map<IEnumerable<ProdutoModelView>>(await _produtoServico.ObterTodosProdutos());
                return Ok(produtosEncontrado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState.Values);
                var produtoEncontrado = _autoMapper.Map<ProdutoModelView>(await _produtoServico.ObterProduto(id));
                if ( produtoEncontrado == null) return NotFound("Produto não encontrado");
                return Ok(produtoEncontrado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("pagianacao/{numeroPagina:int}")]
        public IActionResult GetPagina(int numeroPagina)
        {
            try
            {

                var produtosPorPagina = _contexto.Produtos.GetPaged(numeroPagina, 10);
                return Ok(produtosPorPagina);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete( int id)
        {
            try
            {
                var produtoEncontrado = await _produtoServico.ObterProduto(id);
                if (produtoEncontrado == null) return NotFound("Produto não encontrado");
                produtoEncontrado.SituacaoProduto = 0;
                await _produtoServico.Atualizar(produtoEncontrado);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ProdutoModelView produto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState.Values);
                if (produto.DataFabricacao >= produto.DataValidade) return BadRequest("Data de fabricação deve ser menor que a data de validade");
                var produtoEncontrado = _autoMapper.Map<Produto>(produto);
                await _produtoServico.Atualizar(produtoEncontrado);
                return Ok(produto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProdutoModelView produto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState.Values);
                if (produto.DataFabricacao >= produto.DataValidade) return BadRequest("Data de fabricação deve ser menor que a data de validade");
                var tpProduto = _autoMapper.Map<Produto>(produto);


                await _produtoServico.Adicionar(tpProduto);
                return Ok(produto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
