using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    class Office
    {
        int repairNumber = 1;
        string typeOfRepair;
        public Car obiekt;

        public int RepairNumber
        {
            get { return repairNumber; }
            set { repairNumber = value; }
        }
        public string TypeOfRepair
        {
            get { return typeOfRepair; }
            set
            {
                while (value == null)
                {
                    typeOfRepair = Console.ReadLine();
                }
                typeOfRepair = value;
            }
        }
        //public Car Obiekt { get { return obiekt; } }
        public void Diagnosis()//create a new order - car's object
        {
            //Car one = new Car("Nissan", "juke", "John Daw", "+48 543 332 857",
            //    "OPO43123", "2019");
            //obiekt = one;
            //Car.wysw(obiekt);
            Console.WriteLine("Description of problem: ");
            TypeOfRepair = Console.ReadLine();
            RepairNumber++; 
        }
    }
}
