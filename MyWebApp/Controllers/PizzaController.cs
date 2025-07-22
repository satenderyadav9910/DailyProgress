using MyWebApp.Models;
using MyWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace MyWebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PizzaController : ControllerBase
{
    public PizzaController()
    {
    }

    //GET all action
    [HttpGet]
    public ActionResult<List<Pizza>> GetAll() => PizzaService.GetAll();

    //GET by Id action
    [HttpGet("{id}")]
    public ActionResult<Pizza?> Get(int id)
    {
        var pizza = PizzaService.Get(id);
        if (pizza is null)
        {
            return NotFound();
        }
        return pizza;
    }

    //POST action

    //PUT action

    //DELETE action
}