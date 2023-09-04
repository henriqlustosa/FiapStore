using FiapStore.DTO;
using FiapStore.Enums;

namespace FiapStore.Entity
{
    public class Usuario : Entidade
    {

        public string Nome { get; set; }
        public string NomeUsuario { get; set; }
        public string Password { get; set; }
        public Permissoes Permissao { get; set; }

        public ICollection<Pedido> Pedidos { get; set; }

        public Usuario()
        {
        }

        public Usuario(AddUsuarioDTO addUserDTO)
        {
            Nome = addUserDTO.Nome;
            NomeUsuario = addUserDTO.NomeUsuario;
            Password = addUserDTO.Password;
            Permissao = addUserDTO.Permissao;
        }

        public Usuario(UpdateUsuarioDTO updateUserDTO)
        {
            Nome = updateUserDTO.NomeUsuario;
            Id = updateUserDTO.Id;
        }
    }
}
