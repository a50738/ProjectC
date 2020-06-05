using System;

namespace BO
{
    [Serializable]
    public class Payment 
    {
        /// <summary>
        /// Variables.
        /// <param name="bill">price of the repair</param>
        /// <param name="description">description of the service performed</param>
        /// <param name="type">by cash, by card</param>
        /// <param name="mechanic">chosen mechanic from mechanic's list</param>
        /// <param name="end_repair">date of ending order</param>
        /// </summary>
        double bill = 0.00;
        string description = ""; 
        string type; 
        string mechanic;
        DateTime end_repair;

        #region Constructors
        /// <summary>
        /// Constuctors.
        /// </summary>
        public Payment() { }
        public Payment(double bill, string description, string mechanic, string type)
        {
            Bill = bill;
            Description = description;
            Mechanic = mechanic;
            Type = type;
            End_repair = DateTime.Now;
        }
        #endregion

        /// <summary>
        /// Displaying atrributes of Payment object.
        /// </summary>
        /// <param name="payment"></param>
        /// <returns>displaying</returns>
        public string ToString(Payment payment)
        {
            return "\n Price of the repair: " + payment.Bill +
                "\nDescription of the service performed: " + payment.Description +
                "\nMechanic's name: " + payment.Mechanic + "\nPayment type: " + payment.Type
                + "\nOrder end date: " + payment.End_repair +"\n-------------------------" +
                "--------------------\n";
        }

        #region Properties
        
        public double Bill
        {
            get { return bill; }
            set { bill = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public string Mechanic
        {
            get { return mechanic; }
            set { mechanic = value; }
        }
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public DateTime End_repair
        {
            get { return end_repair; }
            set { end_repair = value; }
        }

        #endregion
    }
}
    
