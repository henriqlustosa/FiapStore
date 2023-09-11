using FiapStore.Interface;
using Microsoft.AspNetCore.Mvc;

using FiapStore.Services;
using FiapStore.DTO;

namespace FiapStore.Controllers
{
    [ApiController]
    [Route("login")]
    public class LoginController: ControllerBase
    {
        private readonly IUsuarioRepository _userRepository;
        private readonly ITokenService _tokenService;

        public LoginController(IUsuarioRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        /// <summary>
        /// Autenticacao com nome de usuario e senha
        /// </summary>
        /// <param name="loginDTO"></param>
        /// <returns></returns>
        /// <response code = "200">Returns Success</response>
        /// <response code = "400">Bad Request</response>
        [HttpPost]
        public IActionResult Authenticate([FromBody] LoginDTO loginDTO)
        {
            var user = _userRepository.ObterUsuarioPorNomeDoUsuarioSenha(loginDTO.NomeUsuario, loginDTO.Senha);

            if (user == null)
                return BadRequest("UserName or Password invalid!");

            var token = _tokenService.GenerateToken(user);

            user.Senha = null;
            return Ok(new
            {
                User = user,
                Token = token,
            });
        }
    }
}
