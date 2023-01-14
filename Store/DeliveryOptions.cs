using System;

namespace OnlineStore
{
    /// <summary>
    /// Выбор способа доставки
    /// </summary>
    public static class DeliveryOptions
    {
        public static void Delivery(List<User> usersList, List<Order> ordersList, Order order)
        {
            Console.WriteLine("Способы доставки:\n1 - HomeDelivery\n2 - PickPointDelivery\n3 - ShopDelivery");
            Console.Write("Выберите способ доставки(1 - 3): ");

            object option = null;
            string mesure;
            string number = Console.ReadLine();

            switch (number)
            {
                case "1":
                    Console.Write("Количество товара в ...\n1 - штуках\n2 - килограммах\nОтвет (1 - 2): ");
                    mesure = Console.ReadLine();
                    switch (mesure)
                    {
                        case "2":
                            order.AddOrder<double, HomeDelivery>(usersList, ordersList, order);
                            break;
                        default:
                            order.AddOrder<int, HomeDelivery>(usersList, ordersList, order);
                            break;
                    }
                    break;
                case "2":
                    Console.Write("Количество товара в ...\n1 - штуках\n2 - килограммах\nОтвет (1 - 2): ");
                    mesure = Console.ReadLine();
                    switch (mesure)
                    {
                        case "2":
                            order.AddOrder<double, PickPointDelivery>(usersList, ordersList, order);
                            break;
                        default:
                            order.AddOrder<int, PickPointDelivery>(usersList, ordersList, order);
                            break;
                    }
                    break;
                case "3":
                    Console.Write("Количество товара в ...\n1 - штуках\n2 - килограммах\nОтвет (1 - 2): ");
                    mesure = Console.ReadLine();
                    switch (mesure)
                    {
                        case "2":
                            order.AddOrder<double, ShopDelivery>(usersList, ordersList, order);
                            break;
                        default:
                            order.AddOrder<int, ShopDelivery>(usersList, ordersList, order);
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

