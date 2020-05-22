using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    class Workshop: Office
    {
        public int availablePosition = 6;
        //bool available;
        string[] mechanicName = { "Pavlo Kochunski", "Gregorz Ranging", "Kuiba Tallawn" };

        public delegate void order_send(string name_tool);
        public event order_send order_send_event;
        public bool Available
        {
            get
            {
                if (availablePosition != 0)
                    return true;
                else
                    return false;
            }
        }
        
        public void RepairCar(ref Car car)
        {
            if(Available==true)
            {
                car.repairState = "during repair";
                availablePosition--;
            }
            //else
        }

        public void SendOrder()
        {
            string order_name_part = "";
            Console.Write("Enter part's name: ");
            order_name_part = Console.ReadLine();
            if (order_name_part != null)
                OnOrder_send_event(order_name_part);
        }

        protected void OnOrder_send_event(string info)
        {
            if (order_send_event != null)
                order_send_event(info);
        }

        public void Receive_events()
        {
            WarehouseItem order_back = new WarehouseItem();
            order_back.order_ready_event += new WarehouseItem.Order_ready(DisplayInformation);
            order_back.Reply_to_order();
        }

        void DisplayInformation(string info)
        {
            Console.WriteLine(info);
        }
    }
}
