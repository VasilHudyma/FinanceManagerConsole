using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManagerConsole
{
    interface ITransactionRepository
    {
        List<Transaction> GetAll();
        bool Add(Transaction transaction);
        Transaction GetById(int id);
        bool Update(Transaction transaction, String ColumnWidth);
        bool Delete(int id);
    }
}
