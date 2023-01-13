using System;

namespace OnlineStore
{
    /// <summary>
    /// Запрос информации о конкретном заказе 
    /// </summary>
    public static class OrderInfo
    {
        public static int OrderReqest()
        {
            Console.WriteLine("Заказов в базе {0}.", OrdersList.OrderID.Count);
            Console.Write("Введите номер заказа: ");
            int orderNumber = Int32.Parse(Console.ReadLine());
            return orderNumber;
        }

        public static void DisplayOrderInfo(this int orderNumber)
        {
            if (orderNumber >= 0 && orderNumber <= OrdersList.OrderID.Count - 1)
            {
                Console.WriteLine("Данные о заказе {0}:", orderNumber);
                Console.WriteLine($"Получатель: {OrdersList.OrderBuyer[orderNumber]}\nАдрес доставки: {OrdersList.OrderAddress[orderNumber]}" +
                    $"\nТовар: {OrdersList.ProductName[orderNumber]} \tКолиество: " +
                    $"{Math.Max(OrdersList.ProductCount[orderNumber], OrdersList.ProductWeight[orderNumber])}" +
                    $"\nКомментарий к заказу: {OrdersList.OrderDescription[orderNumber]}");
            }
            else
                Console.WriteLine("Заказ не найден");
        }
    }
}

