using Dapper;
using FiapStore.Entity;
using FiapStore.Interface;
using System.Data.SqlClient;
using static Dapper.SqlMapper;
namespace FiapStore.Repository
{
    public class UsuarioRepositoryDapper : DapperRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepositoryDapper(IConfiguration configuration) : base(configuration)
        {
        }

        public override void Update(Usuario usuario)
        {
            using var dbconnection = new SqlConnection(ConnectionString);
            var query = "UPDATE [Usuario] SET [Nome] = @Nome WHERE Id = @Id";
            dbconnection.Query(query, usuario);
        }

        public override void Add(Usuario usuario)
        {
            using var dbconnection = new SqlConnection(ConnectionString);
            var query = "INSERT INTO [Usuario]([Nome]) VALUES(@Nome)";
            dbconnection.Execute(query, usuario);
        }
       public override void Delete(int id)
        {
                using var dbconnection = new SqlConnection(ConnectionString);
                var query = "DELETE FROM [Usuario] WHERE Id = @Id";
                dbconnection.Execute(query, new { Id = id });
        }

        public override IList<Usuario> GetAll()
        {
            using var dbconnection = new SqlConnection(ConnectionString);
            var query = "SELECT * FROM [Usuario]";
            return dbconnection.Query<Usuario>(query).ToList();
        }

        public override Usuario GetById(int id)
        {
            using var dbconnection = new SqlConnection(ConnectionString);
            var query = "SELECT * FROM [Usuario] Where Id = @Id";
            return dbconnection.Query<Usuario>(query, new { Id = id }).FirstOrDefault();
        }
        public Usuario ObterPedidosPorUsuario(int id)
        {
            using var dbconnection = new SqlConnection(ConnectionString);
            var query = @"SELECT
                            U.Id,
                            U.Name,
                            O.Id,
                            O.ProductName,
                            O.UserId
                        FROM
                            [User] U
                            LEFT JOIN [Order] O ON U.Id = O.UserId
                        WHERE 
                            U.Id = @Id";

            var result = new Dictionary<int, Usuario>();
            var param = new { Id = id };

            dbconnection.Query<Usuario, Pedido, Usuario>(query,
                (user, order) =>
                {
                    if (!result.TryGetValue(user.Id, out var existingUser))
                    {
                        existingUser = user;
                        existingUser.Pedidos = new List<Pedido>();
                        result.Add(user.Id, existingUser);
                    }

                    if (order != null)
                        existingUser.Pedidos.Add(order);

                    return existingUser;
                }, param, splitOn: "Id");

            return result.Values.FirstOrDefault();
        }

        public Usuario ObterUsuarioPorNomeDoUsuarioSenha(string userName, string password)
        {
            throw new NotImplementedException();
        }
    }
}
