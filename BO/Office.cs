using System;

namespace BO
{
    [Serializable]
    public class Office
    {
        /// <summary>
        /// Variables.
        /// <param name="payment">object of Payment class</param>
        /// <param name="auto">object of Car class</param>
        /// <param name="repairNumber">number of repair/order</param>
        /// <param name="typeOfRepair">initial description of the repair</param>
        /// <param name="repairState">current state of repairing car</param>
        /// <param name="date_admission">date of admission of order</param>
        /// </summary>
        Payment payment;
        Car auto;
        int repairNumber;
        string typeOfRepair;
        string repairState = "before repair";
        DateTime date_admission;
        

        #region Constructors
        public Office() { }

        public Office(string description, Car car)
        {
            Auto = car;
            TypeOfRepair = description;
            Date_admission = DateTime.Now;
        }
        #endregion

        /// <summary>
        /// Assigning payment value to payment attribute of this class
        /// </summary>
        /// <param name="pay">payment object created in main</param>
        public void GetPayment(Payment pay)
        {
            Payment = pay;
        }

        /// <summary>
        /// Displaying atrributes of Office object.
        /// </summary>
        /// <param name="office"></param>
        /// <returns>displaying</returns>
        #region Displaying
        public string ToString(Office office) => "Repair nr: "
            + office.RepairNumber + "\nData of admission: " + office.Date_admission +
            "\nDescription of the problem: " + office.TypeOfRepair + "\nCar details."
            + office.Auto.ToString(office.Auto) + "\n\nCurrent state of the car: "
            + office.repairState;
        #endregion

        #region Properties
        public Payment Payment
        {
            get { return payment; }
            set { payment = value; }
        }
        public Car Auto
        {
            get { return auto; }
            set { auto = value; }
        }
        public DateTime Date_admission
        {
            get { return date_admission; }
            set { date_admission = value; }
        }
        public int RepairNumber
        {
            get { return repairNumber; }
            set { repairNumber = value; }
        }
        public string RepairState
        {
            get { return repairState; }
            set { repairState = value; }
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
        #endregion
    }


}
