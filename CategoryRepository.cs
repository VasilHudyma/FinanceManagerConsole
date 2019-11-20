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
    class CategoryRepository:ICategoryRepository
    {
        private IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);
        public bool Add(Category category)
        {
            try
            {
                string sql = "INSERT INTO Categories(Name,Description) values(@Name, @Description); SELECT CAST(SCOPE_IDENTITY() as int)";
                var returnId = this.db.Query<int>(sql, category).SingleOrDefault();
                category.Id = returnId;
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool Delete(int id)
        {
            var affectedrows = this.db.Execute("Delete from Categories where Id=@Id", new { Id = id });
            return affectedrows > 0;
        }

        public List<Category> GetAll()
        {
            return this.db.Query<Category>("Select * From Categories").ToList();
        }

        public Category GetById(int id)
        {
            return this.db.Query<Category>("Select * From Categories Where Id=@Id", new { Id = id }).FirstOrDefault();
        }

        public bool Update(Category category, string ColumnName)
        {
            string query = "update Categories set " + ColumnName + "=@" + ColumnName + " Where Id=@Id";
            var count = this.db.Execute(query, category);
            return count > 0;
        }

    }
}
