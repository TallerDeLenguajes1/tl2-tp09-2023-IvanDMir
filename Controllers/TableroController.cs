using Microsoft.AspNetCore.Mvc;
using models;
using repositorios;
namespace tp9.Controllers;


[ApiController]
[Route("[controller]")]
public class tableroController : ControllerBase {
        private readonly ILogger<tableroController> _logger;
        TableroRepositorios RepoTablero;

         public tableroController(ILogger<tableroController> logger)
    {

        RepoTablero = new TableroRepositorios();
        _logger = logger;
    }
       [HttpPost("CreateTablero")]
    public ActionResult CreateTablero(Tablero tableronuevo){
        RepoTablero.Crear(tableronuevo);
        return Ok();

    }

    [HttpGet("GetAllTablero")]
    public ActionResult<List<Usuario>> GetallTablero(){
       
        List<Tablero> ListaTab = RepoTablero.GetAll();
        if (ListaTab.Count() == 0){
            return BadRequest("No se ha podido hallar Usuarios");
        }
        return Ok(ListaTab);
    }


}