using CRUD_Vue.js.Datos;
using CRUD_Vue.js.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Vue.js.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        DAtosUsuario _admin = new DAtosUsuario();
        
        [HttpGet]
        public IEnumerable<Usuario> Get()
        {
            return _admin.Conultar();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            Usuario usuario =  _admin.ConsultarUNO(id);
            if (usuario == null)
            {
                return NotFound();
            }
                return usuario;
        }

        [HttpPost]
        public  IActionResult Agregar(Usuario usuario)
        {
              _admin.Agregar(usuario);
            return CreatedAtAction(nameof(Agregar), usuario);
        }

        [HttpPut("{id}")]
        public IActionResult Actualizar(int id ,Usuario usuario)
        {
            if(id != usuario.Id)
            {
                return BadRequest();
            }
            _admin.Actualizar(usuario);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Eliminar(int id)
        {
             _admin.Eliminar(id);
            return NoContent();
        }
    }
}
