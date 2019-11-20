using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManagerConsole
{
    class OperationRepository : IOperationRepository
    {
        private IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);
        public bool Add(Operation operation)
        {
            try
            {
                string sql = "INSERT INTO Operations(Name) values(@Name); SELECT CAST(SCOPE_IDENTITY() as int)";
                var returnId = this.db.Query<int>(sql, operation).SingleOrDefault();
                operation.Id = returnId;
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool Delete(int id)
        {
            var affectedrows = this.db.Execute("Delete from Operations where Id=@Id", new { Id = id });
            return affectedrows > 0;
        }

        public List<Operation> GetAll()
        {
            return this.db.Query<Operation>("Select * From Operations").ToList();
        }

        public Operation GetById(int id)
        {
            return this.db.Query<Operation>("Select * From Operations Where Id=@Id", new { Id = id }).FirstOrDefault();
        }

        public bool Update(Operation operation, string ColumnName)
        {
            string query = "update Operations set " + ColumnName + "=@" + ColumnName + " Where Id=@Id";
            var count = this.db.Execute(query, operation);
            return count > 0;
        }
    }
}
