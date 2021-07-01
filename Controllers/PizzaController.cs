using System.Collections.Generic;
using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaController : ControllerBase
    {
        public PizzaController()
        {

        }

        // GET all action
        [HttpGet]
        public ActionResult<List<Pizza>> GetAll() => PizzaService.GetAll(); //return all Pizza

        // GET by Id action
        [HttpGet("{id}")]
        public ActionResult<Pizza> Get(int id)
        {
            var pizza = PizzaService.Get(id);
            if (pizza == null)
                return NotFound();
            return pizza;
        }

        // POST action
        [HttpPost]
        public IActionResult Create(Pizza p)
        {
            PizzaService.Add(p);
            return CreatedAtAction(nameof(Create), new { id = p.Id }, p);
        }

        // PUT action
        [HttpPut("{id}")]
        public IActionResult Update(int id, Pizza p)
        {
            if (id != p.Id)
                return BadRequest();

            if (PizzaService.Get(id) is null)
                return NotFound();

            PizzaService.Update(p);

            return NoContent();
        }

        // DELETE action
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (PizzaService.Get(id) is null)
                return NotFound();

            PizzaService.Delete(id);

            return NoContent();
        }
    }
}