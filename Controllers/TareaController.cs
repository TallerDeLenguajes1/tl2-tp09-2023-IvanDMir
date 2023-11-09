using Microsoft.AspNetCore.Mvc;
using models;
using repositorios;
namespace tp9.Controllers;


[ApiController]
[Route("[controller]")]
public class TareaController : ControllerBase {
        private readonly ILogger<TareaController> _logger;
        TareaRepositorios RepoTarea;

         public TareaController(ILogger<TareaController> logger)
    {

        RepoTarea = new TareaRepositorios();
        _logger = logger;
    }

     [HttpPost("CreateTarea")]
    public ActionResult CreateTarea(Tarea tarea){
        RepoTarea.Crear(tarea);
        return Ok();

    }
     [HttpPut("UpdateTarea")]
        public ActionResult Modificar(int id, Tarea tarea){
            RepoTarea.Update(id,tarea);
            return Ok();
        }
    [HttpGet("GetTareaById")]
    public ActionResult<Tarea> GetUsuarioById(int id){
        Tarea tarea= RepoTarea.GetById(id);
        if(tarea == null){
            return BadRequest("No se halló la tarea");
        }
        return Ok(tarea);
    }
    [HttpDelete("Deletetarea")]
        public ActionResult Delete(int id){
            RepoTarea.Delete(id);
            return Ok();
        }
    [HttpGet("GetTareaByTablero")]
    public ActionResult<List<Tarea>> GetTareaByTablero(int idtablero){
        List<Tarea> Lista = RepoTarea.GetByTablero(idtablero);
        if(Lista == null){
            return BadRequest("No se hallaron tareas");
        }
        return Ok(Lista);
    }
     [HttpGet("GetTareaByUser")]
    public ActionResult<List<Tarea>> GetTareaByUser(int idUsuario){
        List<Tarea> Lista = RepoTarea.GetByTablero(idUsuario);
        if(Lista == null){
            return BadRequest("No se hallaron tareas");
        }
        return Ok(Lista);
    }
    


}