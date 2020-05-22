using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    class WarehouseItem
    {
        string name = "";
        int amount = 4;

        public delegate void Order_ready(string statement);
        public event Order_ready order_ready_event; 
        public void Receive_events()
        {
            Workshop order = new Workshop();
            order.order_send_event += new Workshop.order_send(DisplayInformation);
            order.SendOrder();
        }

        public string Name
        {
            set { name = value; }
        }
        public bool Amount
        {
            get
            {
                if (amount != 0)
                    return true;
                else 
                    return false;
            }
        }
        public int Amount_int
        {
            get { return amount; }
        }
        void DisplayInformation(string info)
        {
            Name = info;
            Console.WriteLine(info);
        }

        public void Reply_to_order()
        {
            if (Amount == true)
                OnOrder_ready("The order is ready.");
            else
                OnOrder_ready("Out of warehouse.");
        }
        protected void OnOrder_ready(string info)
        {
            if (order_ready_event != null)
                order_ready_event(info);
        }

        public void CheckAmount()
        {
            Console.WriteLine("Amount " + Amount_int);
        }
    }
}
