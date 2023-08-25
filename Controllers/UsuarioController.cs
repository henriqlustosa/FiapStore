using Microsoft.AspNetCore.Mvc;

namespace FiapStore.Controllers
{
    [ApiController]
    [Route("Usuario")]
    public class UsuarioController : ControllerBase
    {
        [HttpGet("obter-todos-usuarios")]
        public IActionResult ObterTodosUsuarios()
        {
            return Ok("Usuários obtidos com sucesso!");
        }

        [HttpGet("obter-usuario-por-id")]
        public IActionResult ObterUsuarioPorId()
        {
            return Ok("Usuário obtidos com sucesso!");
        }
        [HttpPost]
        public IActionResult CriarUsuario()
        {
            return Ok("Usuário adicionado com sucesso!");
        }

        [HttpPut]
        public IActionResult EditarUsuario()
        {
            return Ok("Usuário atualizado com sucesso!");
        }

        [HttpDelete]
        public IActionResult RemoverUsuario()
        {
            return Ok("Usuário removido com sucesso!");
        }
    }
}
