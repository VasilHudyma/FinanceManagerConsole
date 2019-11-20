using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManagerConsole
{
    interface IOperationRepository
    {
        List<Operation> GetAll();
        bool Add(Operation operation);
        Operation GetById(int id);
        bool Update(Operation operation, String ColumnWidth);
        bool Delete(int id);
    }
}
