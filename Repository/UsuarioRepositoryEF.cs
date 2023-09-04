using FiapStore.Entity;
using FiapStore.Interface;
using Microsoft.EntityFrameworkCore;

namespace FiapStore.Repository
{
    public class UsuarioRepositoryEF :EFRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepositoryEF(ApplicationDbContext context) : base(context)
        {
        }
        public Usuario GetWithOrders(int id)
        {
            return _context.Usuario
                    .Include(u => u.Pedidos)
                    .Where(x => x.Id == id)
                    .ToList()
                    .Select(user =>
                    {
                        user.Pedidos = user.Pedidos.Select(pedido => new Pedido(pedido)).ToList();
                        return user;
                    })
                    .FirstOrDefault();
        }

        //password validation this way for didactic purposes
        public Usuario GetByUsernameAndPassword(string userName, string password)
        {
            return _context.Usuario.FirstOrDefault(u => u.NomeUsuario == userName && u.Password == password);
        }
    }
}
