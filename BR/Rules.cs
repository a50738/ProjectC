using System;
using BO;
using OList;

namespace BR
{

    public class Rules
    {
        /// <summary>
        /// Insert new order.
        /// </summary>
        /// <param name="o">object of Office class</param>
        /// <returns></returns>
        public static bool InsertOrderII(Office o)
        {
            return OfficeList.AddOrderII(o);
        }

        /// <summary>
        /// Displaying the whole content of list<Office>.
        /// </summary>
        /// <returns>true, if the list is not empty</returns>
        public static bool Display()
        {
            if (OfficeList.Orders.Count != 0)
            {
                Console.WriteLine("OfficeList class, displaying 'List<Office> orders'.");
                OfficeList.Display();
                return true;
            }
            else
            {
                Console.WriteLine("The 'List<Office> orders' is empty.");
                return false;
            }
        }

        /// <summary>
        /// Displaying chosen object of Office class.
        /// </summary>
        /// <param name="o">object for displaying</param>
        public static void Display2(Office o)
        {
            OfficeList.Display2(o);
        }

        /// <summary>
        /// Change of state. If the position is available we 
        /// change state on 'during repair' and substract one position.
        /// </summary>
        /// <returns>true, if the process of 'taking' car to workshop succeed</returns>
        public static bool ChangeState()
        {
            bool ap = Workshop.CheckAvaileblePosition();
            if(ap==true)
            {
                bool c = OfficeList.Finding();
                if (c == true)
                {
                    Workshop.MinusPosition();
                    return true;
                }
                else
                {
                    Console.WriteLine("There isn't the order with RepairState 'before repair'.");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("There isn't availble position.");
                return false;
            }
        }

        /// <summary>
        /// After entering payment data we change the 
        /// order state from 'during repair' to 'ended' 
        /// </summary>
        /// <param name="o">Office object</param>
        /// <param name="pay">Payment object</param>
        public static void Get(ref Office o, Payment pay)
        {
            o.GetPayment(pay);
            Workshop.EndRepair(o);
        }

        /// <summary>
        /// Checking the selected order nr entered by the user
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool Cheking(int number)
        {
            return OfficeList.CheckNumber(number);
        }

        #region Events
        /// <summary>
        /// Operating events. Displaing current amount of car part from WarehouseItem.
        /// </summary>
        /// <param name="workshop">Workshop object</param>
        /// <param name="stock">WarehouseItem object</param>
        /// <param name="part">the necessary part that name is entered by user</param>
        public static void Events(Workshop workshop, WarehouseItem stock, string part)
        {
            int amount;

            Console.Write("Warehouse has the notification: ");
            workshop.OrderSendEvent += new Order(DisplayInformation);
            workshop.SendOrder(ref part);

            Console.Write("Warehouse sends reply: ");
            stock.OrderReadyEvent += new Order(DisplayInformation);
            stock.ReplyToOrder(part);
            amount = WarehouseItem.CheckAmount();
            Console.WriteLine("Current number of parts in stock: " + amount);
        }

        /// <summary>
        /// Displaying statement(method for delegate).
        /// </summary>
        /// <param name="info">notification from class</param>
        public static void DisplayInformation(string info)
        {
            Console.WriteLine(info);
        }
        #endregion

        /// <summary>
        /// Getting mechanics' name from the Workshop mechanicName array.
        /// </summary>
        /// <param name="m">stores the mechanics' name</param>
        public static void MechanicName(ref string[] m)
        {
            Workshop.Mechanic(ref m);
        }

        /// <summary>
        /// Displaying.
        /// </summary>
        /// <returns></returns>
        public static bool DisplayInfo()
        {
            return OfficeList.DisplayInfo();
        }

        /// <summary>
        /// Preserve all data.
        /// </summary>
        /// <param name="fileName">file name from main</param>
        /// <returns></returns>
        public static bool SaveOrders(string fileName)
        {
            return OfficeList.SaveAll(fileName);
        }

        /// <summary>
        /// Get all preserved data.
        /// </summary>
        /// <param name="fileName">file name from main</param>
        /// <returns></returns>
        public static bool LoadOrders(string fileName)
        {
            return OfficeList.LoadAll(fileName);
        }




        #region could be
        //public static bool InsertOrder(string description, Car car)
        //{
        //    return OfficeList.AddOrder(description, car);
        //}
        #endregion
    }
}
