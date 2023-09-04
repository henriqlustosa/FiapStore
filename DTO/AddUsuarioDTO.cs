using FiapStore.Enums;

namespace FiapStore.DTO
{
    public class AddUsuarioDTO
    {
        public string Nome { get; set; }
        public string NomeUsuario { get; set; }
        public string Password { get; set; }
        public Permissoes Permissao { get; set; }
    }
}
