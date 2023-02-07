using BusinessLogic;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace FruitApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FruitsController : ControllerBase
    {
        private IBLFruit _bLFruit;

        public FruitsController(IBLFruit bLFruit)
        {
            _bLFruit = bLFruit;
        }

        [HttpPost]
        public ActionResult<FruitDTO> SaveFruit(FruitDTO input)
        {
            if (!Validator(input))
            {
                return BadRequest();
            }
            return Created(new Uri("/Fruits", UriKind.Relative), _bLFruit.Create(input).Result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FruitDTO>> FindFruitById(long id)
        {
            try
            {
                return Ok(await _bLFruit.FindById(id));
            }
            catch (Exception)
            {
                return NotFound(new ErrorDTO() { status = StatusCodes.Status404NotFound, msg = "Fruit not found", date = DateTime.Now });
            }
        }

        // GET: api/Fruits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FruitDTO>>> FindAllFruits()
        {
            try
            {
                return Ok(await _bLFruit.FindAll());
            }
            catch (Exception)
            {
                return NotFound(new ErrorDTO() { status = StatusCodes.Status404NotFound, msg = "Fruit not found", date = DateTime.Now });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<FruitDTO>> UpdateFruit(long id, FruitDTO input)
        {
            if (!Validator(input))
            {
                return BadRequest();
            }
            try
            {
                var response = await _bLFruit.Update(id, input);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound(new ErrorDTO() { status = StatusCodes.Status404NotFound, msg = "Fruit not found", date = DateTime.Now });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFruit(long id)
        {
            try
            {
                await _bLFruit.Delete(id);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound(new ErrorDTO() { status = StatusCodes.Status404NotFound, msg = "Fruit not found", date = DateTime.Now });
            }
        }

        private bool Validator(FruitDTO fruitDTO)
        {
            if (fruitDTO == null || fruitDTO.Type == null
                || string.IsNullOrEmpty(fruitDTO.Description) || fruitDTO.Description.Length <= 25
                || string.IsNullOrEmpty(fruitDTO.Name))
            {
                return false;
            }
            return true;
        }
    }
}
