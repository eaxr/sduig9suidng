using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Sduig9suidng.Models;
using Sduig9suidng.Models.Crud;


namespace Sduig9suidng.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPet PetRepo;

        public PetController(IPet PetRepo)
        {
            this.PetRepo = PetRepo;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                return Ok(await PetRepo.GetAll());
            }
            catch (Exception)
            {
                return StatusCode
                (
                    StatusCodes.Status500InternalServerError,
                        "StatusCode"
                );
            }
        }

        [HttpPost]
        public async Task<ActionResult<Pet>> Create(Pet pet)
        {
            try
            {
                if (pet == null)
                {
                    return BadRequest();
                }

                return Ok(await PetRepo.Create(pet));
            }
            catch (Exception)
            {
                return StatusCode
                (
                    StatusCodes.Status500InternalServerError,
                        "StatusCode"
                );
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Pet>> Get(int id)
        {
            try
            {
                return Ok(await PetRepo.Get(id));
            }
            catch (Exception)
            {
                return StatusCode
                (
                    StatusCodes.Status500InternalServerError,
                        "$Pet with Id = {id} not found"
                );
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Pet>> Update(int id, Pet pet)
        {
            try
            {
                var _pet = await PetRepo.Get(id);

                if (_pet == null)
                {
                    return NotFound($"Pet with Id = {id} not found");
                }
                else
                {
                    _pet.Name = pet.Name;
                    _pet.ClientId = pet.ClientId;
                    return Ok(await PetRepo.Save(_pet));
                }
            }
            catch (Exception)
            {
                return StatusCode
                (
                    StatusCodes.Status500InternalServerError,
                        "StatusCode"
                );
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Pet>> Delete(int id)
        {
            try
            {
                var _pet = await PetRepo.Get(id);

                if (_pet == null)
                {
                    return NotFound($"Pet with Id = {id} not found");
                }
                else
                {
                    return Ok(await PetRepo.Delete(_pet));
                }
            }
            catch (Exception)
            {
                return StatusCode
                (
                    StatusCodes.Status500InternalServerError,
                        "StatusCode"
                );
            }
        }
    }
}