using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    class Payment
    {
        double bill = 0.00; //price of the repair
        string description = ""; //description of the service performed
        string type; //by cash, by card
        public Car car;

        public Payment(Car car)
        {
            this.car = car;
        }
        //public Payment(int repair_nr, )
        //wszystkie dane spisujemy do pliku
        public double Bill
        {
            get { return bill; }
            set
            {
                bill = value;
            }
        }
        public void PayRepair()
        {
            Console.Write("Please, enter the price for repair: ");
            while (Bill == 0.00)
            {
                Bill = Convert.ToDouble(Console.ReadLine());
            }
        }
        

    }
}
