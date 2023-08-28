using FiapStore.Entidade;
using FiapStore.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FiapStore.Controllers
{
    [ApiController]
    [Route("Usuario")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;
        public UsuarioController(IUsuarioRepository usuarioRepository) {

            _usuarioRepository = usuarioRepository;
        }

        [HttpGet("obter-todos-usuarios")]
        public IActionResult ObterTodosUsuarios()
        {
            var usuarios = _usuarioRepository.ObterTodosUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("obter-usuario-por-id/{id}")]
        public IActionResult ObterUsuarioPorId(int id)
        {
            var usuario = _usuarioRepository.ObterUsuarioPorId(id);
            return Ok("Usuário obtidos com sucesso!");
        }
        [HttpPost]
        public IActionResult CriarUsuario([FromBody] Usuario usuario)
        {
            _usuarioRepository.CadastrarUsuario(usuario);
            return Ok("Usuário adicionado com sucesso!");
        }

        [HttpPut]
        public IActionResult EditarUsuario([FromBody] Usuario usuario)
        { 
            _usuarioRepository.AlterarUsuario(usuario);
            return Ok("Usuário atualizado com sucesso!");
        }

        [HttpDelete("{id}")]
        public IActionResult RemoverUsuario([FromRoute] int id)
        {
            _usuarioRepository.DeletarUsuario(id);
            return Ok("Usuário removido com sucesso!");
        }
    }
}
