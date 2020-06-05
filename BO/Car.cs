using System;

namespace BO
{
    [Serializable]
    public class Car
    {
        /// <summary>
        /// Variables.
        /// <param name="brand">brand name of car</param>
        /// <param name="model">model of car</param>
        /// <param name="ownerName">car owner name</param>
        /// <param name="ownerPhoneNr">owner's phone number</param>
        /// <param name="registrationNr">registration number of car</param>
        /// <param name="year">car production year</param>
        /// </summary>
        string brand, model, ownerName;
        string ownerPhoneNr;
        string registrationNr;
        string year;

        #region Consructors
        public Car() { }

        public Car(string brand, string model, string ownerName, string ownerPhoneNr,
            string registrationNr, string year)
        {
            this.brand = brand; this.model = model; this.ownerName = ownerName;
            this.ownerPhoneNr = ownerPhoneNr; this.registrationNr = registrationNr;
            this.year = year;
        }
        #endregion

        /// <summary>
        /// Displaying atrributes of Car object.
        /// </summary>
        /// <param name="car"></param>
        /// <returns>displaying</returns>
        public string ToString(Car car)
        {
            return "\nBrand: " + car.Brand + "\nModel: " + car.Model +
                "\nOwner: " + car.OwnerName +
                "\nOwner's phone nr: " + car.OwnerPhoneNr + "\nCar's registration nr: "
                + car.RegistrationNr + "\nYear of car production: " + car.Year;
        }

        #region Properties
        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public string OwnerName
        {
            get { return ownerName; }
            set { ownerName = value; }
        }
        public string OwnerPhoneNr
        {
            get { return ownerPhoneNr; }
            set { ownerPhoneNr = value; }
        }
        public string RegistrationNr
        {
            get { return registrationNr; }
            set { registrationNr = value; }
        }
        public string Year
        {
            get { return year; }
            set { year = value; }
        }
        #endregion


        #region could be
        //public Car AddCar()
        //{
        //    Console.Write("Brand: ");
        //    brand = Console.ReadLine();
        //    Console.Write("Model: ");
        //    model = Console.ReadLine();
        //    Console.Write("Owner's name: ");
        //    ownerName = Console.ReadLine();
        //    Console.Write("phone nr: ");
        //    ownerPhoneNr = Console.ReadLine();
        //    Console.Write("Car's registration nr: ");
        //    registrationNr = Console.ReadLine();
        //    Console.Write("Car's year (ex. 2010): ");
        //    year = Console.ReadLine();
        //    // correct = int.TryParse(Console.ReadLine(), out year); 
        //    return new Car(brand, model, ownerName, ownerPhoneNr,
        //        registrationNr, year);
        //}

        //public void EditCar(ref Car obiect)
        //{
        //    char answer;
        //    string new_data;
        //    Console.Write("Which data do you want to modify?\n1- brand" +
        //        "\n2- model\n3- owner's name\n4- phone nr" +
        //        "\n5- car's registration nr\n6- year\nPlease, enter the number: ");
        //    answer = Console.ReadKey().KeyChar;
        //    Console.Write("Please, enter the correct data: ");
        //    new_data = Console.ReadLine();
        //    if (answer == '1')
        //        obiect.brand = new_data;
        //    else if (answer == '2')
        //        obiect.model = new_data;
        //    else if (answer == '3')
        //        obiect.ownerName = new_data;
        //    else if (answer == '4')
        //        obiect.ownerPhoneNr = new_data;
        //    else if (answer == '5')
        //        obiect.registrationNr = new_data;
        //    else if (answer == '6')
        //        obiect.year = new_data;

        //}
        #endregion
    }
}
