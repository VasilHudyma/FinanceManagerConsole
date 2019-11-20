using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManagerConsole
{
    class Program
    {

        public static IOperationRepository operationRepository = new OperationRepository();
        public static ICategoryRepository categoryRepository = new CategoryRepository();
        public static ITransactionRepository transactionRepository = new TransactionRepository();
        public void OperationInsertData()
        {
            Console.WriteLine(new string('*', 20));
            Console.WriteLine("Enter the Name");
            Console.Write("Name : ");
            String Name = Console.ReadLine();

            //inserting
            Operation operation1 = new Operation
            {
                Name = Name

            };
            operationRepository.Add(operation1);
            OperationShowData();

        }
        public void CategoryInsertData()
        {
            Console.WriteLine(new string('*', 20));
            Console.WriteLine("Enter the Name, Description");
            Console.Write("Name : ");
            String Name = Console.ReadLine();
            Console.Write("Description : ");
            String description = Console.ReadLine();
            
            //inserting
            Category category = new Category
            {
                Name = Name,
                Description = description
                
            };
            categoryRepository.Add(category);
            CategoryShowData();
        }

        public void TransactionInsertData()
        {
            Console.WriteLine(new string('*', 20));
            Console.WriteLine("Enter the CategoryId, OperationId, Sum, Description");
            Console.Write("CategoryId : ");
            int catId = Console.Read();
            Console.Write("OperationId : ");
            int opId = Console.Read();
            Console.Write("Sum : ");
            int sum = Console.Read();
            Console.Write("Description : ");
            String description = Console.ReadLine();

            //inserting
            Transaction transaction = new Transaction
            {
                CategoryId = catId,
                OperationId = opId,
                Sum=sum,
                Description = description

            };
            transactionRepository.Add(transaction);
            TransactionShowData();
        }


        public void OperationShowData()
        {
            Console.WriteLine(new string('*', 20));
            List<Operation> operations = operationRepository.GetAll();
            foreach (var op in operations)
            {
                Console.WriteLine(op.Id + " " + op.Name);
            }
            OperationSelectOption();
        }

        public void CategoryShowData()
        {
            Console.WriteLine(new string('*', 20));
            List<Category> categories = categoryRepository.GetAll();
            foreach (var ct in categories)
            {
                Console.WriteLine(ct.Id + " " + ct.Name+" "+ct.Description);
            }
            CategorySelectOption();
        }

        public void TransactionShowData()
        {
            Console.WriteLine(new string('*', 20));
            List<Transaction> transactions = transactionRepository.GetAll();
            foreach (var tr in transactions)
            {
                Console.WriteLine(tr.Id + " " + tr.CategoryId+" "+tr.OperationId+" "+tr.Sum+" "+tr.Description);
            }
            TransactionSelectOption();
        }
        public void OperationUpdatingData()
        {
            Console.WriteLine(new string('*', 20));
            //Updating
            Console.WriteLine("What Id do you want to Update ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("What do you want to Update....");
            Console.Write("Name press 1 ");

            int ch = Convert.ToInt32(Console.ReadLine());
            Operation operation = operationRepository.GetById(id);
            String Name = null;
            switch (ch)
            {
                case 1:
                    Console.WriteLine("Name : ");
                    string fName = Console.ReadLine();
                    operation.Name = fName;
                    Name = "Name";
                    operationRepository.Update(operation, Name);
                    OperationGetByID(id);
                    break;

                default:
                    Console.WriteLine("Please select a choice atleast");
                    break;
            }
            SelectOption();
        }
        //Get By ID Method
        public void OperationGetByID(int id)
        {
            Console.WriteLine(new string('*', 20));
            Operation contacts2 = operationRepository.GetById(id);
            if (contacts2 != null)
            {
                Console.WriteLine(contacts2.Id + " " + contacts2.Name);
            }
            OperationSelectOption();
        }

        public void CategoryGetByID(int id)
        {
            Console.WriteLine(new string('*', 20));
            Category category = categoryRepository.GetById(id);
            if (category != null)
            {
                Console.WriteLine(category.Id + " " + category.Name+" "+category.Description);
            }
            CategorySelectOption();
        }

        public void TransactionGetByID(int id)
        {
            Console.WriteLine(new string('*', 20));
            Transaction tr = transactionRepository.GetById(id);
            if (tr != null)
            {
                Console.WriteLine(tr.Id + " " + tr.CategoryId + " " + tr.OperationId + " " + tr.Sum + " " + tr.Description);
            }
            TransactionSelectOption();
        }
        //Delete Method
        public void OperationDeleteData()
        {
            Console.WriteLine(new string('*', 20));
            OperationShowData();
            Console.WriteLine(new string('*', 20));

            //Deletion
            Console.Write("What id do you want to delete :");
            int id = Convert.ToInt32(Console.ReadLine());
            operationRepository.Delete(id);
            Operation con = operationRepository.GetById(id);
            if (con == null)
            {
                Console.WriteLine("Operation record is deleted already");
            }
            Console.WriteLine(new string('*', 20));
            OperationShowData();
        }

        public void CategoryDeleteData()
        {
            Console.WriteLine(new string('*', 20));
            CategoryShowData();
            Console.WriteLine(new string('*', 20));

            //Deletion
            Console.Write("What id do you want to delete :");
            int id = Convert.ToInt32(Console.ReadLine());
            categoryRepository.Delete(id);
            Category cat = categoryRepository.GetById(id);
            if (cat == null)
            {
                Console.WriteLine("Category record is deleted already");
            }
            Console.WriteLine(new string('*', 20));
            CategoryShowData();
        }
        public void TransactionDeleteData()
        {
            Console.WriteLine(new string('*', 20));
            TransactionShowData();
            Console.WriteLine(new string('*', 20));

            //Deletion
            Console.Write("What id do you want to delete :");
            int id = Convert.ToInt32(Console.ReadLine());
            transactionRepository.Delete(id);
            Transaction tr = transactionRepository.GetById(id);
            if (tr == null)
            {
                Console.WriteLine("Transaction record is deleted already");
            }
            Console.WriteLine(new string('*', 20));
            TransactionShowData();
        }

        public void TransactionSelectOption() {
            Console.WriteLine();
            Console.WriteLine(new string('*', 20));

            Console.WriteLine("Transaction :");
            Console.WriteLine(new string('*', 20));
            Console.WriteLine("For...");
            Console.WriteLine("Show Data Select 1");
            Console.WriteLine("Insert Data Select 2");
            Console.WriteLine("Update Data Select 3");
            Console.WriteLine("Delete Data Select 4");
            Console.WriteLine("Back to main menu Select 5");
            Console.WriteLine();
            Console.Write("Your Selection :  ");
            int selection = Convert.ToInt32(Console.ReadLine());
            switch (selection)
            {
                case 1:
                    TransactionShowData();
                    break;
                case 2:
                    TransactionInsertData();
                    break;
                case 3:
                    OperationUpdatingData();
                    break;
                case 4:
                    OperationDeleteData();
                    break;
                case 5:
                    SelectOption();
                    break;
                default:
                    break;
            }

            Console.WriteLine(new string('*', 20));
            Console.WriteLine();
        }
        public void OperationSelectOption()
        {
            Console.WriteLine();
            Console.WriteLine(new string('*', 20));

            Console.WriteLine("Operation :");
            Console.WriteLine(new string('*', 20));
            Console.WriteLine("For...");
            Console.WriteLine("Show Data Select 1");
            Console.WriteLine("Insert Data Select 2");
            Console.WriteLine("Update Data Select 3");
            Console.WriteLine("Delete Data Select 4");
            Console.WriteLine("Back to main menu Select 5");
            Console.WriteLine();
            Console.Write("Your Selection :  ");
            int selection = Convert.ToInt32(Console.ReadLine());
            switch (selection)
            {
                case 1:
                    OperationShowData();
                    break;
                case 2:
                    OperationInsertData();
                    break;
                case 3:
                    OperationUpdatingData();
                    break;
                case 4:
                    OperationDeleteData();
                    break;
                case 5:
                    SelectOption();
                    break;
                default:
                    break;
            }

            Console.WriteLine(new string('*', 20));
            Console.WriteLine();
        }
        public void CategorySelectOption()
        {
            Console.WriteLine();
            Console.WriteLine(new string('*', 20));

            Console.WriteLine("Category :");
            Console.WriteLine(new string('*', 20));
            Console.WriteLine("For...");
            Console.WriteLine("Show Data Select 1");
            Console.WriteLine("Insert Data Select 2");
            Console.WriteLine("Update Data Select 3");
            Console.WriteLine("Delete Data Select 4");
            Console.WriteLine("Back to main menu Select 5");
            Console.WriteLine();
            Console.Write("Your Selection :  ");
            int selection = Convert.ToInt32(Console.ReadLine());
            switch (selection)
            {
                case 1:
                    CategoryShowData();
                    break;
                case 2:
                    CategoryInsertData();
                    break;
                case 3:
                    OperationUpdatingData();
                    break;
                case 4:
                    OperationDeleteData();
                    break;
                case 5:
                    SelectOption();
                    break;
                default:
                    break;
            }

            Console.WriteLine(new string('*', 20));
            Console.WriteLine();
        }
        public void SelectOption()
        {
            Console.WriteLine(new string('*', 20));

            Console.WriteLine("Welcome To FinanceManager :");
            Console.WriteLine(new string('*', 20));
            Console.WriteLine("For...");
            Console.WriteLine("Category Select 1");
            Console.WriteLine("Operation Select 2");
            Console.WriteLine("Transaction Select 3");
            Console.WriteLine("Exit Select 4");
            Console.WriteLine();
            Console.Write("Your Selection :  ");
            int selection = Convert.ToInt32(Console.ReadLine());
            switch (selection)
            {
                case 1:
                    CategorySelectOption();
                    break;
                case 2:
                    OperationSelectOption();
                    break;
                case 3:
                    TransactionSelectOption();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }

            Console.WriteLine(new string('*', 20));
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            p.SelectOption();


            Console.ReadLine();
        }
    }
}
