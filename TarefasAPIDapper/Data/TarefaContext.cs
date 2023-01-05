using System.Data;

namespace TarefasAPIDapper.Data
{
    public class TarefaContext
    {
        public delegate Task<IDbConnection> GetConnection();
    }
}
