using FiapStore.Entity;

namespace FiapStore.Interface
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Usuario ObterPedidosPorUsuario(int id);

        Usuario ObterUsuarioPorNomeDoUsuarioSenha(string NomeUsuario, string password);

    }
}
