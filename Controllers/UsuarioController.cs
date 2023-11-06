using Microsoft.AspNetCore.Mvc;
using models;
using repositorios;
namespace tp9.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
  

    private readonly ILogger<UsuarioController> _logger;
    UsuarioRepositorio Repo;
    TableroRepositorios RepoTablero;
    public UsuarioController(ILogger<UsuarioController> logger)
    {
        Repo = new UsuarioRepositorio();
        RepoTablero = new TableroRepositorios();
        _logger = logger;
    }
    [HttpGet("GetAllUsers")]
    public ActionResult<List<Usuario>> Getall(){
       
        List<Usuario> ListaUsuarios = Repo.GetAll();
        if (ListaUsuarios.Count() == 0){
            return BadRequest("No se ha podido hallar Usuarios");
        }
        return Ok(ListaUsuarios);
    }
      [HttpPost("CreateUsers")]
        public ActionResult Create(Usuario usuario){
            Repo.Crear(usuario);
            return Ok();

        }
    [HttpPut("UpdateUsers")]
        public ActionResult Modificar(int id, Usuario UsuarioNuevo){
            Repo.Modificar(id,UsuarioNuevo);
            return Ok();
        }
    [HttpDelete("DeleteUser")]
        public ActionResult Eliminar(int id){
            Repo.eliminar(id);
            return Ok();
        }
    [HttpGet("GetUserById")]
    public ActionResult<Usuario> GetUsuarioById(int id){
        Usuario usu = Repo.GetById(id);
        if(usu == null){
            return BadRequest("No se halló el usuario");
        }
        return Ok(usu);
    }


    // Preguntar como dividir los controladores

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
