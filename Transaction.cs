using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManagerConsole
{
    class Transaction
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int OperationId { get; set; }
        public decimal Sum { get; set; }
        public string Description { get; set; }
    }
}
