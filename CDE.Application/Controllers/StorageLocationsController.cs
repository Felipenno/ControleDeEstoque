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
    public class StorageLocationsController : Controller
    {
        private readonly IStorageLocationService _storageLocationService;

        public StorageLocationsController(IStorageLocationService storageLocationService)
        {
            _storageLocationService = storageLocationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _storageLocationService.GetAllAsync());
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao buscar localizacoes ({ex})");
            }
        }

        [HttpPost]
        public async Task<IActionResult> NewStorageLocation(StorageLocationCreateViewModel storageLocation)
        {
            try
            {
                var success = await _storageLocationService.AddAsync(storageLocation);
                if (success)
                {
                    return Created("", storageLocation);
                }

                return BadRequest($"Erro ao criar local");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStorageLocation(StorageLocationUpdateViewModel storageLocation)
        {
            try
            {
                var success = await _storageLocationService.UpdateAsync(storageLocation);
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
        public async Task<IActionResult> RemoveStorageLocation(int id)
        {
            try
            {
                var success = await _storageLocationService.RemoveAsync(id);
                if (success)
                {
                    return Ok();
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

    }
}
