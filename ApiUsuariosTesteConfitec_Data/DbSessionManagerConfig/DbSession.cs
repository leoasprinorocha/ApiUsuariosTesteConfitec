using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsuariosTesteConfitec_Data.DbSessionManagerConfig
{
    public sealed class DbSession : IDisposable
    {
        private Guid _id;
        public IDbConnection Connection { get; }
        public IDbTransaction Transaction { get; set; }
        public IConfiguration Configuration { get; }

        public DbSession(IConfiguration configuration)
        {
            Configuration = configuration;
            _id = Guid.NewGuid();
            Connection = new SqlConnection(Configuration.GetConnectionString("SqlServerDbConnection"));
            Connection.Open();
        }

        public void Dispose() => Connection?.Dispose();
    }
}
