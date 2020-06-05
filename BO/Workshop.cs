using System;

namespace BO
{
    #region Delegate
    /// <summary>
    /// Delegate.
    /// </summary>
    /// <param name="statement">communique</param>
    public delegate void Order(string statement);
    #endregion

    public class Workshop
    {

        /// <summary>
        /// Variables.
        /// <param name="availablePosition">amount of positions for cars in workshop</param>
        /// <param name="mechanicName">list of machanics working in workshop</param>
        /// </summary>
        static int availablePosition = 6;
        static string[] mechanicName = { "Pavlo Kochunski", "Gregorz Ranging", "Kuiba Tallawn" };

        /// <summary>
        /// Event.
        /// </summary>
        public event Order OrderSendEvent;

        #region CheckPosition
        /// <summary>
        /// Check available position for cars in workshop
        /// before "take" the car for repair.
        /// </summary>
        /// <returns>true, if there is position available.</returns>
        public static bool CheckAvaileblePosition()
        {
            if (Available == true) 
                return true;
            return false;
        }

        /// <summary>
        /// After adding car, position decreases.
        /// </summary>
        public static void MinusPosition()
        {
            AvailablePosition--;
        }
        #endregion

        #region return mechanics
        /// <summary>
        /// Get the mechanics' names and pass it to main program.
        /// </summary>
        /// <param name="m">array of mechanics' names</param>
        public static void Mechanic(ref string[] m)
        {
            m[0] = MechanicName[0];
            m[1] = MechanicName[1];
            m[2] = MechanicName[2];
        }
        #endregion

        /// <summary>
        /// After closing order change the state of car on 'ended'
        /// and insert a position.
        /// </summary>
        /// <param name="office">object of Office class which is changed</param>
        public static void EndRepair(Office office)
        {
            office.RepairState = "ended";
            availablePosition++;
        }

        /// <summary>
        /// Ordering the necessary car part in Warehouse.
        /// </summary>
        /// <param name="part">name's part entered by user</param>
        public void SendOrder(ref string part)
        {
            if (part != null)
                OnOrderSendEvent(part);
        }

        /// <summary>
        /// The method takes part in event.
        /// </summary>
        /// <param name="info">communique</param>
        public void OnOrderSendEvent(string info)
        {
            if (OrderSendEvent != null)
                OrderSendEvent(info);
        }

        #region Properties
        public static bool Available
        {
            get
            {
                if (availablePosition != 0)
                    return true;
                else
                    return false;
            }
        }
        public static int AvailablePosition
        {
            get { return availablePosition; }
            set { availablePosition = value; }
        }
        public static string[] MechanicName
        {
            get { return mechanicName; }
        }
        #endregion
    }
}

