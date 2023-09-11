
using FiapStore.DTO;
using FiapStore.Entity;
using FiapStore.Enums;
using FiapStore.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FiapStore.Controllers
{
    [ApiController]
    [Route("Usuario")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;
        private readonly ILogger<UsuarioController> _logger;
        public UsuarioController(IUsuarioRepository usuarioRepository, ILogger<UsuarioController> logger) {

            _usuarioRepository = usuarioRepository;
            _logger = logger;
        }
        /// <summary>
        /// Obter pedidos por usuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <remarks>
        /// Exemplo:
        /// Enviar 1 o id do usuario
        /// </remarks>
        /// <response code = "200">Returns Success</response>
        /// <response code = "401">Not Authenticated</response>
        /// <response code = "403">Not Authorized</response> 
        [Authorize]
        [Authorize(Roles = Permissoes.Funcionario)]
        [HttpGet("obter-pedidos-por-usuario/{id}")]
        public IActionResult ObterPedidosPorUsuario(int id)
        {
            try
            {
                var usuario = _usuarioRepository.ObterPedidosPorUsuario(id);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,$"Exceção ocorrida no método ObterPedidosPorUsuario(){ex.Message}");
                return BadRequest("Ocorreu um erro ao obter os pedidos do usuário");
            }
        }



        /// <summary>
        /// Retorna todos os usuarios cadastrados
        /// </summary>
        /// <returns></returns>
        /// <response code = "200">Returns Success</response>
        /// <response code = "401">Not Authenticated</response>
        /// <response code = "403">Not Authorized</response>
        [Authorize]
        [Authorize(Roles = Permissoes.Administrador)]
        [HttpGet("obter-todos-usuarios")]
        public IActionResult ObterTodosUsuarios()
        { try
            {
                var usuarios = _usuarioRepository.GetAll();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,$"Exceção ocorrida no método ObterTodosUsuarios(){ex.Message}");
                return BadRequest("Ocorreu um erro ao obter os usuários");
            }
         
        }

        /// <summary>
        /// Obter um usuario especifico através do seu Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <remarks>
        /// Examplo de chamada: /Usuario/ObterUsuarioPorId/1
        /// </remarks>
        /// <response code = "200">Returns Success</response>
        /// <response code = "401">Not Authenticated</response>
        /// <response code = "403">Not Authorized</response>
        [Authorize]
        [Authorize(Roles = Permissoes.Funcionario)]
        [HttpGet("obter-usuario-por-id/{id}")]
        public IActionResult ObterUsuarioPorId(int id)
        {  try
            {
                var usuario = _usuarioRepository.GetById(id);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,$"Exceção ocorrida no método ObterUsuarioPorId(){ex.Message}");
                return BadRequest("Ocorreu um erro ao obter o usuário");
            }   
            
        }
        /// <summary>
        /// Criar um novo usuario
        /// </summary>
        /// <param name="usuarioDto"></param>
        /// <returns></returns>
        /// <response code = "200">Returns Success</response>
        /// <response code = "401">Not Authenticated</response>
        /// <response code = "403">Not Authorized</response>
        [Authorize]
        [Authorize(Roles = $"{Permissoes.Administrador},{Permissoes.Funcionario}")]
        [HttpPost]
        public IActionResult CriarUsuario([FromBody] AddUsuarioDTO usuarioDto)
        { try
            {
                _usuarioRepository.Add(new Usuario(usuarioDto));
                var message = $"Usuário {usuarioDto.Nome} adicionado com sucesso!";
                _logger.LogInformation(message);
                return Ok(message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,$"Exceção ocorrida no método CriarUsuario(){ex.Message}");
                return BadRequest("Ocorreu um erro ao criar o usuário");
            }
       
        }

        /// <summary>
        /// Editar um usuario especifico
        /// </summary>
        /// <param name="usuarioDTO"></param>
        /// <returns></returns>
        /// <response code = "200">Returns Success</response>
        /// <response code = "401">Not Authenticated</response>
        /// <response code = "403">Not Authorized</response>
        [Authorize]
        [Authorize(Roles = Permissoes.Administrador)]
        [HttpPut]
        public IActionResult EditarUsuario([FromBody] UpdateUsuarioDTO usuarioDTO)
        { try
            {
                _usuarioRepository.Update(new Usuario(usuarioDTO));
                var message = $"Usuário {usuarioDTO.Id} atualizado com sucesso!";
                _logger.LogInformation(message);
                return Ok(message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,$"Exceção ocorrida no método EditarUsuario(){ex.Message}");
                return BadRequest("Ocorreu um erro ao atualizar o usuário");
            }   

          
        }

        /// <summary>
        /// Deletar um usuario especifico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        [Authorize(Roles = Permissoes.Administrador)]
        [HttpDelete("{id}")]
        public IActionResult RemoverUsuario([FromRoute] int id)
        {
            try
            {
                _usuarioRepository.Delete(id);
                var message = $"Usuário {id} removido com sucesso!";
                _logger.LogInformation(message);
                return Ok(message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,$"Exceção ocorrida no método RemoverUsuario(){ex.Message}");
                return BadRequest("Ocorreu um erro ao remover o usuário");
            }
            
        }
    }
}