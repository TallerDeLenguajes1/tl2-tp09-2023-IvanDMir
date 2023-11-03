using Microsoft.AspNetCore.Mvc;
using models;
using repositorios;
namespace tp9.Controllers;

[ApiController]
[Route("[controller]")]
public class TareaController : ControllerBase
{
  

    private readonly ILogger<TareaController> _logger;

    public TareaController(ILogger<TareaController> logger)
    {
        _logger = logger;
    }

    [HttpGet("GetAllUsers")]
    public ActionResult<List<Usuario>> Getall(){
        UsuarioRepositorio Repo = new UsuarioRepositorio();
        List<Usuario> ListaUsuarios = Repo.GetAll();
        if (ListaUsuarios.Count() == 0){
            return BadRequest("No se ha podido hallar Usuarios");
        }
        return Ok(ListaUsuarios);
    }

    
}
