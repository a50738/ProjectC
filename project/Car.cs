using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    class Car
    {
        string brand, model, ownerName;
        string ownerPhoneNr;
        string registrationNr;
        string year;
        public string repairState = "before repair";

        public Car()
        { }

        public Car (string brand, string model, string ownerName, string ownerPhoneNr,
            string registrationNr, string year)
        {
            this.brand = brand; this.model = model; this.ownerName = ownerName;
            this.ownerPhoneNr = ownerPhoneNr; this.registrationNr = registrationNr;
            this.year = year;
        }
        public Car AddCar()
        {
            Console.Write("Brand: ");
            brand = Console.ReadLine();
            Console.Write("Model: ");
            model = Console.ReadLine();
            Console.Write("Owner's name: ");
            ownerName = Console.ReadLine();
            Console.Write("phone nr: ");
            ownerPhoneNr = Console.ReadLine();
            Console.Write("Car's registration nr: ");
            registrationNr = Console.ReadLine();
            Console.Write("Car's year (ex. 2010): ");
            year = Console.ReadLine();
            // correct = int.TryParse(Console.ReadLine(), out year); 
            return new Car(brand, model, ownerName, ownerPhoneNr,
                registrationNr, year);
        }
        public void EditCar(ref Car obiect)
        {
            char answer;
            string new_data;
            Console.Write("Which data do you want to modify?\n1- brand" +
                "\n2- model\n3- owner's name\n4- phone nr" +
                "\n5- car's registration nr\n6- year\nPlease, enter the number: ");
            answer = Console.ReadKey().KeyChar;
            Console.Write("Please, enter the correct data: ");
            new_data = Console.ReadLine();
            if (answer == '1')
                obiect.brand = new_data;
            else if (answer == '2')
                obiect.model = new_data;
            else if (answer == '3')
                obiect.ownerName = new_data;
            else if (answer == '4')
                obiect.ownerPhoneNr = new_data;
            else if (answer == '5')
                obiect.registrationNr = new_data;
            else if (answer == '6')
                obiect.year = new_data;
            
        }
        public void wysw()
        {
            Console.WriteLine(model);
            Console.WriteLine(brand);
            Console.WriteLine(ownerName);
            Console.WriteLine(ownerPhoneNr);
            Console.WriteLine(registrationNr);
            Console.WriteLine(year);

        }

    }
}
