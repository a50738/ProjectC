using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using BO;

namespace OList
{
    [Serializable]
    public class OfficeList
    {
        /// <summary>
        /// Variables.
        /// <param name="orders">list<T> that stores office objects</param>
        /// <param name="nrOrders">number of order</param>
        /// <param name="repairstatetoFind">used for comperison</param>
        /// </summary>
        static List<Office> orders;
        static int nrOrders;
        public static string repairstatetoFind = "before repair";

        #region Construktors
        static OfficeList()
        {
            Orders = new List<Office>();
        }
        #endregion

        #region Add order
        /// <summary>
        /// Add the order to the list<Office>.
        /// Increments the order number.
        /// </summary>
        /// <param name="office">object of Office class</param>
        /// <returns></returns>
        public static bool AddOrderII(Office office)
        {
            if (orders.Contains(office))        //avoid to have repeated elements
            {
                return false;
            }
            NrOrders++;
            office.RepairNumber = NrOrders;
            Orders.Add(office);
            return true;
        }
        #endregion

        #region FindMethod
        /// <summary>
        /// Find the order number by its RepairState
        /// office object o nr ... change state -> aval pos--
        /// </summary>
        /// <returns>true, if the order with state 'during repair'
        /// exists on the list</returns>
        public static bool Finding()
        {
            Office result = Orders.Find(
                delegate (Office of)
            { return of.RepairState == OfficeList.repairstatetoFind; });

            if(result !=null)
            { 
                result.RepairState = "during repair";
                return true;
            }
            return false;

        }
        #endregion

        #region CheckChoseNr
        /// <summary>
        /// The order nr selected by user does really exist.
        /// </summary>
        /// <param name="number">number entered by user</param>
        /// <returns>true, if the order exists</returns>
        public static bool CheckNumber(int number)
        {
            foreach (Office o in orders)
            {
                if (o.RepairNumber == number && o.RepairState == "during repair")
                    return true;
            }
            return false;
        }
        #endregion

        #region File
        /// <summary>
        /// Preserve all data.
        /// </summary>
        /// <param name="fileName">file name from main</param>
        /// <returns></returns>
        public static bool SaveAll(string fileName)
        {
            try
            {
                Stream stream = File.Open(fileName, FileMode.OpenOrCreate);
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(stream, Orders);
                stream.Close();
                return true;
            }
            catch (IOException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Get all preserved data.
        /// </summary>
        /// <param name="fileName">file name from main</param>
        /// <returns></returns>
        public static bool LoadAll(string fileName)
        {
            if (File.Exists(fileName) && (new FileInfo(fileName).Length > 0))
            {
                try
                {
                    Stream stream = File.Open(fileName, FileMode.Open);
                    BinaryFormatter bin = new BinaryFormatter();
                    Orders = (List<Office>)bin.Deserialize(stream);
                    NrOrders = Orders.Count;
                    stream.Close();
                    return true;
                }
                catch (IOException e)
                {
                    throw e;
                }
            }
            return false;
        }
        #endregion

        #region DisplayMethods
        /// <summary>
        /// Displaying the order with state 'during repair'.
        /// </summary>
        /// <returns>true, if the orders exist</returns>
        public static bool DisplayInfo()
        {
            string repairstate = "during repair";
            int i = 0;//counts how many will be displayed
            foreach (Office o in Orders)
            {
                if (o.RepairState == repairstate)
                {
                    Console.WriteLine(o.ToString(o));
                    i++;
                }
            }
            if (i != 0)
                return true;
            return false;
        }

        /// <summary>
        /// Displaying the whole list.
        /// </summary>
        public static void Display()
        {
            foreach (Office o in Orders)
            {
                Console.WriteLine(o.ToString(o));
                if (o.Payment != null)
                    Console.WriteLine(o.Payment.ToString(o.Payment));
            }
        }

        /// <summary>
        /// Displaying the concrete object.
        /// </summary>
        /// <param name="o">selected object of Office class</param>
        public static void Display2(Office o)
        {
            Console.WriteLine(o.ToString(o));
            Console.WriteLine(o.Payment.ToString(o.Payment));
        }

        #endregion

        #region Properties
        public static List<Office> Orders
        {
            get { return orders; }
            set { orders = value; }
        }
        public static int NrOrders
        {
            get { return nrOrders; }
            set { nrOrders = value; }
        }
        #endregion






        #region could be
        //public static bool AddOrder(string description, Car car)
        //{

        //    Office office = new Office(description, car);

        //    //office.Diagnosis(description, car, order_nr);

        //    if (Orders.Contains(office))        //avoid to have repeated elements
        //    {
        //        return false;
        //    }
        //    NrOrders++;
        //    office.RepairNumber = NrOrders;
        //    Orders.Add(office);
        //    return true;
        //}

        //public static bool ChoosingOrder2(int number)
        //{
        //    string repairstate = "during repair";
        //    Office find = Orders.Find(delegate (Office of)
        //    { return ((of.RepairState == repairstate) && (of.RepairNumber = number)); });
        //    return true;
        //}

        //public static bool ChoosingOrder(int number, ref Office find)
        //{
        //    find = Orders.Find(delegate (Office of)
        //    { return of.RepairNumber == number; });
        //    if (find != null)
        //        return true;
        //    return false;//return Office
        //}

        
        #endregion
    }
}
