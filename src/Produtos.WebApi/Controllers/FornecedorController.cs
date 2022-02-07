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
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorServico _fornecedorServico;
        private readonly DbContexto _contexto;
        private readonly IMapper _autoMapper;

        public FornecedorController(DbContexto contexto, IFornecedorServico fornecedorServico, IMapper autoMapper)
        {
            _contexto = contexto;
            _fornecedorServico = fornecedorServico;
            _autoMapper = autoMapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState.Values);
                var fornecedoresEncontrado = _autoMapper.Map<IEnumerable<FornecedorModelView>>(await _fornecedorServico.ObterTodosFornecedores());
                return Ok(fornecedoresEncontrado);
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
                var fornecedorEncontrado = _autoMapper.Map<FornecedorModelView>(await _fornecedorServico.ObterFornecedor(id));
                if (fornecedorEncontrado == null) return NotFound("Fornecedor não encontrado");

                return Ok(fornecedorEncontrado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] FornecedorModelView fornecedor)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState.Values);

                var fornecedorEncontrado = _autoMapper.Map<Fornecedor>(fornecedor);
                await _fornecedorServico.Atualizar(fornecedorEncontrado);
                return Ok(fornecedor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _fornecedorServico.Excluir(id);

                var fornecedorEncontrado = _autoMapper.Map<FornecedorModelView>(await _fornecedorServico.ObterFornecedor(id));
                if (fornecedorEncontrado == null) return NotFound("Fornecedor não encontrado");
                await _fornecedorServico.Excluir(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(FornecedorModelView fornecedor)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState.Values);
                var tpFornecedor = _autoMapper.Map<Fornecedor>(fornecedor);
                await _fornecedorServico.Adicionar(tpFornecedor);
                return Ok(tpFornecedor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}
