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
    class TransactionRepository:ITransactionRepository
    {
        private IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);
        public bool Add(Transaction transaction)
        {
            try
            {
                string sql = "INSERT INTO Transactions(CategoryId, OperationId, Sum, Description) " +
                    "values(@CategoryId, @OperationId, @Sum, @Description); SELECT CAST(SCOPE_IDENTITY() as int)";
                var returnId = this.db.Query<int>(sql, transaction).SingleOrDefault();
                transaction.Id = returnId;
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool Delete(int id)
        {
            var affectedrows = this.db.Execute("Delete from Transactions where Id=@Id", new { Id = id });
            return affectedrows > 0;
        }

        public List<Transaction> GetAll()
        {
            return this.db.Query<Transaction>("Select * From Transactions").ToList();
        }

        public Transaction GetById(int id)
        {
            return this.db.Query<Transaction>("Select * From Transactions Where Id=@Id", new { Id = id }).FirstOrDefault();
        }

        public bool Update(Transaction transaction, string ColumnName)
        {
            string query = "update Transactions set " + ColumnName + "=@" + ColumnName + " Where Id=@Id";
            var count = this.db.Execute(query, transaction);
            return count > 0;
        }
    }
}
