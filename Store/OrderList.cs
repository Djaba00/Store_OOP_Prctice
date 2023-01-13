using System;

namespace OnlineStore
{
    /// <summary>
    /// Данные заказов
    /// </summary>
    public static class OrdersList
    {
        public static List<int> OrderID = new List<int>() { 0 };
        public static List<string> OrderBuyer = new List<string>() { "Jhon Doe" };
        public static List<string> OrderDescription = new List<string>() { "Empty field" };
        public static List<string> OrderAddress = new List<string>() { "5th Avenue" };
        public static List<string> OrderDelivery = new List<string>() { "HomeDelivery" };

        public static List<string> ProductName = new List<string>() { "MacBook" };
        public static List<int> ProductPrice = new List<int>() { 1999 };
        public static List<int> ProductCount = new List<int>() { 1 };
        public static List<double> ProductWeight = new List<double>() { 0 };
    }
}

