using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AllCobineWithAjax.ContextAndRepo
{
    public class DapperContext
    {
        private readonly IConfiguration _confiq;
        public  readonly string connectionString;

        public DapperContext(IConfiguration confiq)
        {
            _confiq = confiq;
            connectionString = _confiq.GetConnectionString("DefaultConnection");


        }
        public IDbConnection Connection() => new SqlConnection(connectionString);
    }
}
