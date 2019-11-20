using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManagerConsole
{
    interface ICategoryRepository
    {
        List<Category> GetAll();
        bool Add(Category contacts);
        Category GetById(int id);
        bool Update(Category contacts, String ColumnWidth);
        bool Delete(int id);
    }
}
