using FiapStore.Entity;
using FiapStore.Interface;

namespace FiapStore.Repository
{
    public abstract class DapperRepository<T> : IRepository<T> where T : Entidade
    {
        private readonly string _connectionString;

        protected string ConnectionString => _connectionString;

        public DapperRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetValue<string>("ConnectionStrings:ConnectionString");
        }
        public void Alterar(T entidade)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(T entidade)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public T ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IList<T> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}
