using System;

namespace BO
{
    public class WarehouseItem
    {
        /// <summary>
        /// Variables.
        /// <param name="name">the name of order's part</param>
        /// <param name="amount">amount of available part</param>
        /// <param name="ryply1">communique</param>
        /// <param name="reply2">communique</param>
        /// </summary>
        string name = "part";
        static int amount = 4;
        string reply1 = "The order is ready.",
            reply2 = "Out of warehouse.";

        /// <summary>
        /// Event.
        /// </summary>
        public event Order OrderReadyEvent;

        /// <summary>
        /// Reply on order from Workshop class.
        /// Check if the ordered part is on the stock
        /// and amount of part is available.
        /// </summary>
        /// <param name="part">name's part entered by user</param>
        public void ReplyToOrder(string part)
        {
            if (part == Name && Amount == true)
                OnOrderReady(reply1);
            else
                OnOrderReady(reply2);
        }
        /// <summary>
        /// The method takes part in event.
        /// </summary>
        /// <param name="info">communique</param>
        public void OnOrderReady(string info)
        {
            if (OrderReadyEvent != null)
                OrderReadyEvent(info);
        }

        /// <summary>
        /// Check amount of part.
        /// </summary>
        /// <returns>available number of part</returns>
        public static int CheckAmount()
        {
            return Amount_int;
        }

        #region Properties
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public bool Amount
        {
            get
            {
                if (amount != 0)
                {
                    amount--;
                    return true;
                }
                else
                    return false;
            }
        }
        public static int Amount_int
        {
            get { return amount; }
            set { amount = value; }
        }
        #endregion
    }
}
