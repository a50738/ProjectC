using System;
using System.Threading;
using BR;
using BO;

namespace workLP2_a50718_a50738
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Variables
            string description; //for Office class
            char answer; //for order
            string part_name;//for order
            string[] mechanics = {"","","" };
            string chose_mechanic;
            string file_name = "The orders";
            #endregion


            Console.WriteLine("Loading the contents of the file 'The orders'\n" +
                "to the list<Office> orders.");
            bool load = Rules.LoadOrders(file_name);
            if (load == true)
            {
                Console.WriteLine("Succeed. Displaying...");
                Rules.Display();
            }
            else
                Console.WriteLine("Failed to load.");
            Console.ReadLine();
            Console.Clear();

            Car car = new Car("Nissan", "juke", "John Daw", "+48 543 332 857",
                  "OPO43123", "2019");
            Workshop order = new Workshop();
            WarehouseItem order_back = new WarehouseItem();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Order registration has started.\nUser needs to enter...\n" +
                "Description of the problem: ");
            description = Console.ReadLine();
            Thread.Sleep(1000);
            Console.ResetColor();
            Console.Clear();

            Office o = new Office(description, car);
            bool insert = Rules.InsertOrderII(o);
            if (insert == true)
                Console.WriteLine("The order is added to list. Displaing list...");
            else
                Console.WriteLine("The order wasn't added.");

            Rules.Display();
            Console.WriteLine("Enter key");
            Console.ReadKey();

            Console.ForegroundColor = ConsoleColor.Yellow;
            bool d = Rules.ChangeState();
            Rules.Display();

            Console.ResetColor();
            Console.WriteLine("Enter key");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Order (from Workshop class to WarehouseItem class.");
            Console.Write("Do you need to order the part? (y/n)");
            answer = Console.ReadKey().KeyChar;
            if(answer == 'y')
            {
                Console.Write("\nEnter the part's name: ");
                part_name = Console.ReadLine();
                Rules.Events(order, order_back, part_name);  
            }
            Console.WriteLine("Enter key");
            Console.ReadKey();
            Console.Clear();

            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Order completion.");
            Console.ResetColor();
            bool list = Rules.DisplayInfo();
            if (list == true)
            {
                Console.WriteLine("Please, enter the number of selected order: ");
                string n = Console.ReadLine();
                int number = int.Parse(n);
                bool c = Rules.Cheking(number);
                if (c == true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Here we need to enter the necessary info about payment.\n" +
                        "E.g. bill, more specific description, payment method.\n But we created that object (Payment object).");
                    //double bill, string description, string mechanic, string type)
                    Console.ResetColor();
                    Rules.MechanicName(ref mechanics);
                    Console.Write("Mechanic's list.\n Choose the mechanic's name.\n" +
                        "1- {0}\n2- {1}\n3- {2}\n\t Enter:", mechanics[0], mechanics[1], mechanics[2]);
                    char enter;
                    do
                    {
                        enter = Console.ReadKey().KeyChar;
                    } while (enter != '1' && enter != '2' && enter != '3');
                    if (enter == '1')
                        chose_mechanic = mechanics[0];
                    else if (enter == '2')
                        chose_mechanic = mechanics[1];
                    else
                        chose_mechanic = mechanics[2];
                    
                    Payment payment = new Payment(300.0, "specific", chose_mechanic, "by cash");

                    Rules.Get(ref o, payment);
                    Thread.Sleep(500);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\nThe summary of order.");
                    Rules.Display2(o);
                    Console.ResetColor();


                    
                    try { Rules.SaveOrders(file_name); }
                    catch { Console.WriteLine("erro"); }
                }
                else
                {
                    Console.WriteLine("Invalid order number.");
                }
            }
            

            Console.ReadLine();
        }
    }
}
