//using System;
//namespace Store
//{
//	public class UsersData
//	{
//		public List<int> UserID = new List<int>() { 0, 1, 2, 3 };
//		public List<string> UserName = new List<string>() { "Tim", "Jhon", "Ann", "Jim", "Bob" };
//    }

//	public class Request
//	{
//        public void User(int ID)
//        {
//            UsersData User = new UsersData();

//            string name = User.UserName[ID];
//        }
//    }
//}



//class Order<TDelivery> where TDelivery : Delivery
//{
//    public TDelivery Delivery;
//public void NewOrder(List<int> UserID, List<int> OrderID, List<string> OrderDescription)
//{

//    OrderID.Add(OrderID.Count);
//    int Number = OrderID[OrderID.Count - 1];

//    Console.Write($"Order #{Number} description: ");
//    OrderDescription.Add(Console.ReadLine());
//    string Description = OrderDescription[OrderDescription.Count - 1];
//}


//    public void DisplayAddress()
//    {
//        Console.WriteLine();
//    }
//    // ... Другие поля
//}


//public class NewOrder : OrderList
//{
//    public void AddOrder()
//    {
//        OrderID.Add(OrderID.Count);
//        int Number = OrderID[OrderID.Count - 1];

//        Console.Write("ID пользователя: ");
//        int User = UserID[Int32.Parse(Console.ReadLine())];

//        Console.Write($"Order #{Number} description: ");
//        OrderDescription.Add(Console.ReadLine());
//        string Description = OrderDescription[OrderDescription.Count - 1];

//        string Address = UserAddress[User];
//        OrderAddress.Add(Address);

//        DisplayAddress(Address);
//    }

//    public void DisplayAddress(string Address)
//    {
//        Console.WriteLine($"Адрес доставки: {Address}");
//    }
//}

using OnlineStore;

namespace NewHuew
{
    abstract class Delivery
    {
        public string Address;
    }

    class HomeDelivery : Delivery
    {
        /* ... */
    }

    class PickPointDelivery : Delivery
    {
        /* ... */
    }

    class ShopDelivery : Delivery
    {
        /* ... */
    }

    class Order<TDelivery,
    TStruct> where TDelivery : Delivery
    {
        public TDelivery Delivery;

        public int Number;

        public string Description;

        public void DisplayAddress()
        {
            Console.WriteLine(Delivery.Address);
        }

        // ... Другие поля
    }

    public void CountSwitch()
    {
        switch (countOption)
        {
            case "1":
                Product<int> productCount = new Product<int>();

                Console.Write("Укажите количество: ");
                int count = Int32.Parse(Console.ReadLine());
                OrdersList.ProductCount.Add(count);
                OrdersList.ProductWeight.Add(0);
                break;
            case "2":
                Product<double> productWeight = new Product<double>();

                Console.Write("Укажите количество: ");
                double weight = Double.Parse(Console.ReadLine());
                OrdersList.ProductWeight.Add(weight);
                OrdersList.ProductCount.Add(0);
                break;
        }
    }

    Console.WriteLine("Количество товара в ...\n1 - штуках\n2 - килограммах");
            Console.Write("Ответ (1 - 2): ");
}


