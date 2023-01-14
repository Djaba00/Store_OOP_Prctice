using System;

namespace OnlineStore
{
    /// <summary>
    /// Запрос информации о конкретном заказе 
    /// </summary>
    public static class OrderInfo
    {
        public static int OrderReqest(List<Order> ordersList)
        {
            Console.WriteLine("Заказов в базе {0}.", ordersList.Count);
            Console.Write("Введите номер заказа: ");
            int orderNumber = Int32.Parse(Console.ReadLine());
            return orderNumber;
        }

        public static void DisplayOrderInfo(this int orderNumber, List<Order> ordersList)
        {
            if (orderNumber >= 0 && orderNumber <= ordersList.Count - 1)
            {
                Console.WriteLine("Данные о заказе {0}:", orderNumber);
                Console.WriteLine($"Получатель: {ordersList[orderNumber].CustomerName}\nАдрес доставки: {ordersList[orderNumber].OrderAddress}" +
                    $"\nТовар: {ordersList[orderNumber].ProductName} \tКоличество: " +
                    $"{Math.Max(ordersList[orderNumber].ProductCount, ordersList[orderNumber].ProductWeight)}" +
                    $"\nКомментарий к заказу: {ordersList[orderNumber].OrderDescription}");
            }
            else
                Console.WriteLine("Заказ не найден");
        }
    }
}

