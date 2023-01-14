using System;

namespace OnlineStore
{
    /// <summary>
    /// Оформление нового заказа
    /// </summary>
    public class Order
    {
        public int OrderID;
        public int CustomerID;
        public string CustomerName;

        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public double ProductWeight { get; set; }
        public int ProductCount { get; set; }

        public string OrderDescription { get; set; }
        public string OrderAddress { get; set; }
        public string OrderDelivery;

        private bool relID = false;

        public void AddOrder<TCount, TDelivery>(List<User> usersList, List<Order> ordersList, Order order)
            where TDelivery : Delivery, new()
        {
            Console.WriteLine("Новый заказ!\n");

            TCount pCount = default(TCount);
            order.OrderID = ordersList.Count;

            while(relID == false)
            {
                Console.Write("ID пользователя: ");
                order.CustomerID = Int32.Parse(Console.ReadLine());
                if (order.CustomerID < 0 || order.CustomerID > usersList.Count - 1)
                    relID = false;
                else
                    relID = true;
            }

            order.CustomerName = usersList[order.CustomerID].Name;

            Console.Write("Название товара: ");
            order.ProductName = Console.ReadLine();

            Console.Write("Укажите цену товара: ");
            order.ProductPrice = Int32.Parse(Console.ReadLine());

            if (pCount is double)
            {
                Console.Write("Укажите количество товара в килограммах: ");
                order.ProductWeight = Double.Parse(Console.ReadLine());
            }

            if (pCount is int)
            {
                Console.Write("Укажите количество товара в штуках: ");
                order.ProductCount = Int32.Parse(Console.ReadLine());
            }

            Console.Write($"Комментарий к заказу #{order.OrderID}: ");
            order.OrderDescription = Console.ReadLine();

            order.OrderAddress = usersList[order.CustomerID].Address;

            Console.WriteLine("Доставка\n");
            TDelivery delivery = new TDelivery();

            delivery.DeliveryRun(order.OrderID, order.OrderAddress, out order.OrderDelivery);

            ordersList.Add(order);
        }
    }
}

