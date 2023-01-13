using System;

namespace OnlineStore
{
    /// <summary>
    /// Выбор способа доставки
    /// </summary>
    public static class DeliveryOptions
    {
        public static void Delivery(List<User> usersList)
        {
            Console.WriteLine("Способы доставки:\n1 - HomeDelivery\n2 - PickPointDelivery\n3 - ShopDelivery");
            Console.Write("Выберите способ доставки(1 - 3): ");

            object option = null;
            string mesure;
            string number = Console.ReadLine();

            switch (number)
            {
                case "1":
                    NewOrder<HomeDelivery> newOrder = new NewOrder<HomeDelivery>();
                    Console.Write("Количество товара в ...\n1 - штуках\n2 - килограммах\nОтвет (1 - 2): ");
                    mesure = Console.ReadLine();
                    switch (mesure)
                    {
                        case "2":
                            newOrder.AddOrder<double>(usersList);
                            break;
                        default:
                            newOrder.AddOrder<int>(usersList);
                            break;
                    }
                    break;
                case "2":
                    NewOrder<PickPointDelivery> newOrder1 = new NewOrder<PickPointDelivery>();
                    Console.Write("Количество товара в ...\n1 - штуках\n2 - килограммах\nОтвет (1 - 2): ");
                    mesure = Console.ReadLine();
                    switch (mesure)
                    {
                        case "2":
                            newOrder1.AddOrder<double>(usersList);
                            break;
                        default:
                            newOrder1.AddOrder<int>(usersList);
                            break;
                    }
                    break;
                case "3":
                    NewOrder<ShopDelivery> newOrder2 = new NewOrder<ShopDelivery>();
                    Console.Write("Количество товара в ...\n1 - штуках\n2 - килограммах\nОтвет (1 - 2): ");
                    mesure = Console.ReadLine();
                    switch (mesure)
                    {
                        case "2":
                            newOrder2.AddOrder<double>(usersList);
                            break;
                        default:
                            newOrder2.AddOrder<int>(usersList);
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("Некоректный запрос. Укажите номер нужного варианта...");
                    break;
            }
        }
    }
}

