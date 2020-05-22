using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    class Program
    {
        static void Main(string[] args)
        {

            Car one = new Car("Nissan", "juke", "John Daw", "+48 543 332 857",
                "OPO43123", "2019");
            Payment payment = new Payment(one);
            payment.car.wysw();


            Console.ReadKey();
        }
    }

    
}
