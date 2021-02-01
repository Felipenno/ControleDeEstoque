using CDE.Domain.Interfaces.Service;
using CDE.Domain.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CDE.Application.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var listaProdutos = await _productService.GetAllAsync();

                return Ok(listaProdutos);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao buscar produtos ({ex})");
            }
        }

        [HttpGet("{productName}")]
        public async Task<IActionResult> SearchByName(string productName)
        {
            try
            {
                var listaProdutos = await _productService.SearchByName(productName);

                return Ok(listaProdutos);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao buscar produtos ({ex})");
            }
        }

        [HttpPost]
        public async Task<IActionResult> NewProduct(ProductCreateViewModel product)
        {
            try
            {
                var success = await _productService.AddAsync(product);
                if (success)
                {
                    return Created("", product);
                }

                return BadRequest($"Erro ao criar novo produto");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(ProductUpdateViewModel atualizarProduto)
        {
            try
            {
                var success = await _productService.UpdateAsync(atualizarProduto);
                if (success)
                {
                    return NoContent();
                }

                return BadRequest($"Erro ao atualizar produto");

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveProduct(int id)
        {
            try
            {
                var success = await _productService.RemoveAsync(id);
                if (success)
                {
                    return Ok();
                }

                return BadRequest($"Erro ao tentar remover produto");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
