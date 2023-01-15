using System;

namespace OnlineStore
{
    /// <summary>
    /// Выбор способа доставки
    /// </summary>
    public static class OrderOptions
    {
        public static void ChoosingOptions(List<User> usersList, List<Order> ordersList, Order order)
        {
            Console.WriteLine("Способы доставки:\n1 - HomeDelivery\n2 - PickPointDelivery\n3 - ShopDelivery");
            Console.Write("Выберите способ доставки(1 - 3): ");

            object option = null;
            string mesure = "";
            string number = Console.ReadLine();

            switch (number)
            {
                case "1":
                    ChoosingMesure<HomeDelivery>(mesure, usersList, ordersList, order);
                    break;
                case "2":
                    ChoosingMesure<PickPointDelivery>(mesure, usersList, ordersList, order);
                    break;
                case "3":
                    ChoosingMesure<ShopDelivery>(mesure, usersList, ordersList, order);
                    break;
                default:
                    Console.WriteLine("Некоректный запрос. Укажите номер нужного варианта...");
                    break;
            }
        }

        public static void ChoosingMesure<TDelivery>(string mesure, List<User> usersList, List<Order> ordersList, Order order)
            where TDelivery : Delivery, new()
        {
            Console.Write("Количество товара в ...\n1 - штуках\n2 - килограммах\nОтвет (1 - 2): ");
            switch (mesure = Console.ReadLine())
            {
                case "2":
                    order.AddOrder<double, TDelivery>(usersList, ordersList, order);
                    break;
                default:
                    order.AddOrder<int, TDelivery>(usersList, ordersList, order);
                    break;
            }
        }
    }
}

