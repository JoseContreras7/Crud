using ApiBackEnd.Model;
using ApiBackEnd.Service;
using Microsoft.AspNetCore.Mvc;

namespace ApiBackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeopleController : ControllerBase
    {

        private readonly IPeopleService _PeoplesService;
        public PeopleController(IPeopleService peopleService)
        {
            _PeoplesService = peopleService;
        }


        [HttpPost]
        public IActionResult Post(People people)
        {
            try
            {
                if (people == null) return BadRequest();
                if (people.nombre == null) return BadRequest();
                if (people.direccion == null) return BadRequest();

                var newPeople = _PeoplesService.Create(people);
                if (newPeople == null) return BadRequest();
                return Ok(people);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An internal server error occurred." });
            }
        }


        [HttpGet("{name}")]
        public IActionResult Get(string name)
        {
            try
            {
                var ListPeople = _PeoplesService.GetPeople(name);
                if (ListPeople == null) return NotFound();
                
                return Ok(ListPeople);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An internal server error occurred." });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var product = _PeoplesService.GetPeopleId(id);
                if (product == null) return NotFound();
                _PeoplesService.Delete(product);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An internal server error occurred." });
            }
        }

        [HttpPut()]
        public IActionResult Put(People people)
        {
            try
            {
                if (people == null) return BadRequest();
                if (people.nombre == null) return BadRequest();
                if (people.direccion == null) return BadRequest();
                
                _PeoplesService.Update(people);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An internal server error occurred." });
            }
        }
    }
}
