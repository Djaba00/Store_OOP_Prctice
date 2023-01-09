using System;

namespace OnlineStore
{
    /// <summary>
    /// Данные пользователей
    /// </summary>
    public static class UsersList
    {
        public static List<int> UserID = new List<int>() { 0, 1, 2, 3 };
        public static List<string> UserName = new List<string>() { "Tim", "Jhon", "Ann", "Jim", "Bob" };
        public static List<string> UserPhone = new List<string>() { "+7121314", "+7121517", "+7910120", "+7834576" };
        public static List<string> UserAddress = new List<string>() { "Semenov St.", "5th Avenue", "7th Way", "7th Gaidara" };
    }

    /// <summary>
    /// Конструктор пользователя
    /// </summary>
    class User
    {
        public string name;
        public string phone;
        public string address;
        public User() { name = "Unknown"; phone = "Unknown"; address = "Unknown";  }
        public User(string n, string p, string a) { name = n; phone = p; address = a; }
    }

    /// <summary>
    /// Регистрация новго пользователя
    /// </summary>
    ///

    // Добавить класс User
    public class NewUser
    {

        public static void userAdd()
        {
            Console.WriteLine("Регистрация нового пользователя");
            UsersList.UserID.Add(UsersList.UserID.Count);

            Console.Write("Введите имя: ");
            string name = Console.ReadLine() ?? "Unknown";

            Console.Write("Введите номер телефона: ");
            string phone = Console.ReadLine() ?? "Unknown";

            Console.Write("Введите адрес: ");
            string address = Console.ReadLine() ?? "Unknown";

            User newUser = new User(name, phone, address);
            UsersList.UserName.Add(newUser.name);
            UsersList.UserPhone.Add(newUser.phone);
            UsersList.UserAddress.Add(newUser.address);
        }
    }

    /// <summary>
    /// Данные заказов
    /// </summary>
    public static class OrdersList
    {
        public static List<int> OrderID = new List<int>() { 0 };
        public static List<string> OrderDescription = new List<string>() { "Empty order" };
        public static List<string> OrderBuyer = new List<string>() { "Jhon Doe" };
        public static List<string> OrderAddress = new List<string>() { "Test delivery" };

        public static List<string> ProductName = new List<string>() { "Test product" };
        public static List<int> ProductPrice = new List<int>() { 0 };
        public static List<int> ProductCount = new List<int>() { 1 };
        public static List<double> ProductWeight = new List<double>() { 1 };

    }

    /// <summary>
    /// Доставка
    /// </summary>
    abstract class Delivery
    {
        public abstract void DeliveryRun(int OrderID);
    }

    class HomeDelivery : Delivery
    {

        public override void DeliveryRun(int OrderID)
        {
            Console.WriteLine("Доступные ТК: DHL, CDEK, GDT");
            Console.Write("Укажите ТК: ");
            string DeliveryCompany = Console.ReadLine();
            switch (DeliveryCompany)
            {
                case "CDEK":
                    //отправить данные посылки и посылку в ближайший офис CDEK
                    Console.WriteLine($"Послылка #{OrderID} будет доставлена курьерской службой CDEK по адресу {OrdersList.OrderAddress[OrderID]}");
                    break;
                case "GDT":
                    //отправить данные посылки и посылку в ближайший офис GDT
                    Console.WriteLine($"Послылка #{OrderID} будет доставлена курьерской службой GDT по адресу {OrdersList.OrderAddress[OrderID]}");
                    break;
                default:
                    //отправить данные посылки и посылку в ближайший офис DHL
                    Console.WriteLine($"Послылка #{OrderID} будет доставлена курьерской службой DHL по адресу {OrdersList.OrderAddress[OrderID]}");
                    break;
            }
        }
    }

    class PickPointDelivery : Delivery
    {
        public override void DeliveryRun(int OrderID)
        {
            
        }
    }

    class ShopDelivery : Delivery
    {
        public override void DeliveryRun(int OrderID)
        {

        }
    }

    /// <summary>
    /// Выбор способа доставки
    /// </summary>
    static class DeliveryOptions
    {
        public static void Delivery()
        {
            Console.WriteLine("Способы доставки:\n1 - HomeDelivery\n2 - PickPointDelivery\n3 - ShopDelivery");
            Console.Write("Выберите способ доставки(1 - 3): ");
            
            object option = null;
            while (option is null)
            {
                string number = Console.ReadLine();
                switch (number)
                {
                    case "1":
                        HomeDelivery homeDelivery = new HomeDelivery();
                        option = homeDelivery;
                        break;
                    case "2":
                        PickPointDelivery pickPointDelivery = new PickPointDelivery();
                        option = pickPointDelivery;
                        break;
                    case "3":
                        ShopDelivery shopDelivery = new ShopDelivery();
                        option = shopDelivery;
                        break;
                    default:
                        Console.WriteLine("Некоректный запрос. Укажите номер нужного варианта...");
                        break;

                }
            }
        }
    }

    /// <summary>
    /// Конструктор продукта
    /// </summary>
    class Product<TCount>
    {
        public string name;
        public int price;
        public TCount count;
    }

    /// <summary>
    /// Оформление нового заказа
    /// </summary>
    class NewOrder<Tcount> : Product<Tcount>
    {
        string countOption = Console.ReadLine();
        
        public Tcount pCount;

        public void AddOrder()
        {
            OrdersList.OrderID.Add(OrdersList.OrderID.Count);
            int Number = OrdersList.OrderID[OrdersList.OrderID.Count - 1];

            Console.Write("ID пользователя: ");
            int User = UsersList.UserID[Int32.Parse(Console.ReadLine())];
            OrdersList.OrderBuyer.Add(UsersList.UserName[User]);

            Console.Write("Название товара: ");
            string productName = Console.ReadLine();
            OrdersList.ProductName.Add(productName);

            Console.Write("Укажите цену товара: ");
            int productPrice = Int32.Parse(Console.ReadLine());
            OrdersList.ProductPrice.Add(productPrice);

            if (pCount is double)
            {
                Console.Write("Укажите количество товара в килограммах: ");
                double productWeight = Double.Parse(Console.ReadLine());
                OrdersList.ProductWeight.Add(productWeight);
                OrdersList.ProductCount.Add(0);
            }
            if (pCount is int)
            {
                Console.Write("Укажите количество товара в штуках: ");
                int productCount = Int32.Parse(Console.ReadLine());
                OrdersList.ProductWeight.Add(0);
                OrdersList.ProductCount.Add(productCount);
            }

            Console.Write($"Комментарий к заказу #{Number}: ");
            OrdersList.OrderDescription.Add(Console.ReadLine());
            string Description = OrdersList.OrderDescription[OrdersList.OrderDescription.Count - 1];

            string Address = UsersList.UserAddress[User];
            OrdersList.OrderAddress.Add(Address);
        }
    }

    class Order<TOrderID>
    {
        public TOrderID OrderId;

        public static int OrderReqest()
        {
            Console.WriteLine("Заказов в базе {0}.", OrdersList.OrderID.Count);
            Console.Write("Введите номер заказа: ");
            int orderNumber = Int32.Parse(Console.ReadLine());
            return orderNumber;
        }

        public static void DisplayOrderInf(int orderNumber)
        {
            Console.WriteLine("Данные о заказе {0}:", orderNumber);
            
            Console.WriteLine($"Получатель: {OrdersList.OrderBuyer[orderNumber]}\nАдрес доставки: {OrdersList.OrderAddress[orderNumber]}" +
                $"\nТовар: {OrdersList.ProductName[orderNumber]} \tКолиество: " +
                $"{Math.Max(OrdersList.ProductCount[orderNumber], OrdersList.ProductWeight[orderNumber])}" +
                $"\nКомментарий к заказу: {OrdersList.OrderDescription[orderNumber]}");
        }
    }
}