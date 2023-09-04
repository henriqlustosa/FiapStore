using FiapStore.Entity;

namespace FiapStore.Interface
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Usuario GetWithOrders(int id);

        Usuario GetByUsernameAndPassword(string NomeUsuario, string password);

    }
}
