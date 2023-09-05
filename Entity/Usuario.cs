using FiapStore.DTO;
using FiapStore.Enums;

namespace FiapStore.Entity
{
    public class Usuario : Entidade
    {

        public string Nome { get; set; }
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
        public TipoPermissao Permissao { get; set; }

        public ICollection<Pedido> Pedidos { get; set; }

        public Usuario()
        {
        }

        public Usuario(AddUsuarioDTO addUserDTO)
        {
            Nome = addUserDTO.Nome;
            NomeUsuario = addUserDTO.NomeUsuario;
            Senha = addUserDTO.Senha;
            Permissao = addUserDTO.Permissao;
        }

        public Usuario(UpdateUsuarioDTO updateUserDTO)
        {
            Nome = updateUserDTO.NomeUsuario;
            Id = updateUserDTO.Id;
        }
    }
}
