using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Models;
using Microsoft.AspNetCore.Cors;
namespace Backend.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly UserDBContext _userDBContext;

        public UserController(UserDBContext _context)
        {
           _userDBContext = _context;
        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            List<Usuario> usuarioList = new List<Usuario>();

            try
            {
                usuarioList = _userDBContext.Usuario.ToList();
                //  usuarioList = _userDBContext.Usuario.Include(c => c.Id_Perfil).ToList();
                return StatusCode(StatusCodes.Status200OK, new {  respuesta = usuarioList });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, respuesta = usuarioList });
            }
           
        }
        [HttpGet]
        [Route("Perfiles")]
        public IActionResult Perfiles()
        {
            List<Perfil> perfillist = new List<Perfil>();

            try
            {
                perfillist = _userDBContext.Perfil.ToList();
                //  usuarioList = _userDBContext.Usuario.Include(c => c.Id_Perfil).ToList();
                return StatusCode(StatusCodes.Status200OK, new { respuesta = perfillist });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, respuesta = perfillist });
            }

        }



        [HttpGet]
        [Route("Obtener/{idUsuario:int}")]
        public IActionResult Obtener(int idUsuario)
        {
           Usuario usuario= _userDBContext.Usuario.Find(idUsuario);

            if(usuario == null)
            {
                return BadRequest("Usuario no encontrado");
            }
            try
            {
                usuario = _userDBContext.Usuario.FirstOrDefault();
              //  usuario = _userDBContext.Usuario.Include(c => c.Id_Perfil).Where(p => p.IdUsuario == idUsuario).FirstOrDefault();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = usuario });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, resonse = usuario });
            }

        }
        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] Usuario usuario)
        {
            DateTime thisDay = DateTime.Today;

          
            try
            {
                if (usuario.NombreUsuario == null || usuario.NombreUsuario == "")
                {
                    return StatusCode(StatusCodes.Status404NotFound, new { mensaje = "el usuario no puede ser null", resonse = usuario });
                }
               
                else
                {
                _userDBContext.Usuario.Add(usuario);
                _userDBContext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = usuario });
                }

          

            }catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, resonse = usuario });

            }
        }
    }
}
