using System;

namespace OnlineStore
{
    /// <summary>
    /// Оформление нового заказа
    /// </summary>
    /// <typeparam name="Tcount"></typeparam>
    /// <typeparam name="TDelivery"></typeparam>
    class NewOrder<TDelivery>
        where TDelivery : Delivery, new()
    {
        public int number;
        private int user;

        private string productName;
        private int productPrice;
        private double productWeight;
        private int productCount;

        private string description;
        private string address;
        private string orderDelivery;

        private bool relID = false;

        public void AddOrder<TCount>(List<User> usersList)
        {
            Console.WriteLine("Новый заказ!\n");

            TCount pCount = default(TCount);
            OrdersList.OrderID.Add(OrdersList.OrderID.Count);
            number = OrdersList.OrderID[OrdersList.OrderID.Count - 1];

            while(relID == false)
            {
                Console.Write("ID пользователя: ");
                user = Int32.Parse(Console.ReadLine());
                if (user < 0 || user > usersList.Count - 1)
                    relID = false;
                else
                    relID = true;
            }

            OrdersList.OrderBuyer.Add(usersList[user].Name);

            Console.Write("Название товара: ");
            productName = Console.ReadLine();
            OrdersList.ProductName.Add(productName);

            Console.Write("Укажите цену товара: ");
            productPrice = Int32.Parse(Console.ReadLine());
            OrdersList.ProductPrice.Add(productPrice);

            if (pCount is double)
            {
                Console.Write("Укажите количество товара в килограммах: ");
                productWeight = Double.Parse(Console.ReadLine());
                OrdersList.ProductWeight.Add(productWeight);
                OrdersList.ProductCount.Add(0);
            }

            if (pCount is int)
            {
                Console.Write("Укажите количество товара в штуках: ");
                productCount = Int32.Parse(Console.ReadLine());
                OrdersList.ProductWeight.Add(0);
                OrdersList.ProductCount.Add(productCount);
            }

            Console.Write($"Комментарий к заказу #{number}: ");
            OrdersList.OrderDescription.Add(Console.ReadLine());
            description = OrdersList.OrderDescription[OrdersList.OrderDescription.Count - 1];

            address = usersList[user].Address;
            OrdersList.OrderAddress.Add(address);

            Console.WriteLine("Доставка\n");
            TDelivery delivery = new TDelivery();

            delivery.DeliveryRun(number, address, out orderDelivery);
            OrdersList.OrderDelivery.Add(orderDelivery);
        }
    }
}

