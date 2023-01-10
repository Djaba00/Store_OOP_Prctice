using System;

namespace OnlineStore
{
    /// <summary>
    /// Данные пользователей
    /// </summary>
    public static class UsersList
    {
        public static List<int> UserID = new List<int>() { 0, 1, 2, 3 };
        public static List<string> UserName = new List<string>() { "Tim", "Jhon", "Ann", "Jim" };
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
    public static class NewUser
    {
        public static void UserAdd()
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

    public static class UserInfo
    {
        public static void DisplayUserInfo(this int UserID)
        {
            if (UserID <= UsersList.UserID.Count - 1 && UserID >= 0)
            {
                Console.WriteLine($"Информация о ID#{UserID}: \nИмя: {UsersList.UserName[UserID]}\nТелефон: {UsersList.UserPhone[UserID]}" +
                    $"\nАдрес: {UsersList.UserAddress[UserID]}");
            }
            else
                Console.WriteLine("Пользователь не найден.");
        }
        
    }
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

    /// <summary>
    /// Доставка
    /// </summary>
    abstract class Delivery
    {
        public abstract void DeliveryRun(int OrderID, string Address, out string OrderDelivery);
    }

    /// <summary>
    /// Доставка на дом
    /// </summary>
    class HomeDelivery : Delivery
    {

        public override void DeliveryRun(int OrderID, string Address, out string OrderDelivery)
        {
            Console.WriteLine("Доступные ТК: DHL, CDEK, GDT");
            Console.Write("Укажите ТК: ");
            string DeliveryCompany = Console.ReadLine();
            switch (DeliveryCompany)
            {
                case "CDEK":
                    //отправить данные посылки и посылку в ближайший офис CDEK
                    Console.WriteLine($"Послылка #{OrderID} будет доставлена курьерской службой CDEK по адресу {Address}");
                    break;
                case "GDT":
                    //отправить данные посылки и посылку в ближайший офис GDT
                    Console.WriteLine($"Послылка #{OrderID} будет доставлена курьерской службой GDT по адресу {Address}");
                    break;
                default:
                    //отправить данные посылки и посылку в ближайший офис DHL
                    Console.WriteLine($"Послылка #{OrderID} будет доставлена курьерской службой DHL по адресу {Address}");
                    break;
            }

            OrderDelivery = DeliveryCompany;
        }
    }

    /// <summary>
    /// Доставка в пункт выдачи
    /// </summary>
    class PickPointDelivery : Delivery
    {
        public override void DeliveryRun(int OrderID, string Address, out string OrderDelivery)
        {
            Console.WriteLine($"Заказ #{OrderID} будет досатвен в ближайший к {Address} PickPoint");
            OrderDelivery = "PickPoint";
        }
    }

    /// <summary>
    /// Доставка в ближайший магазин
    /// </summary>
    class ShopDelivery : Delivery
    {
        public override void DeliveryRun(int OrderID, string Address, out string OrderDelivery)
        {
            Console.WriteLine($"Заказ #{OrderID} будет досатвен в ближайший к {Address} магазин");
            OrderDelivery = "ShopDelivery";
        }
    }

    /// <summary>
    /// Выбор способа доставки
    /// </summary>
    public static class DeliveryOptions
    {
        public static object Delivery()
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
                        switch(mesure)
                        {
                        
                            case "2":
                                newOrder.AddOrder<double>();
                                break;
                            default:
                                newOrder.AddOrder<int>();
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
                                newOrder1.AddOrder<double>();
                                break;
                            default:
                                newOrder1.AddOrder<int>();
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
                                newOrder2.AddOrder<double>();
                                break;
                            default:
                                newOrder2.AddOrder<int>();
                                break;
                        }
                        break;
                    default:
                        Console.WriteLine("Некоректный запрос. Укажите номер нужного варианта...");
                        break;
            }

            return option;
        }
    }

    /// <summary>
    /// Конструктор продукта
    /// </summary>
    /// <typeparam name="TCount"></typeparam>
    class Product<TCount>
    {
        public string name;
        public int price;
        public TCount count;
    }

    /// <summary>
    /// Оформление нового заказа
    /// </summary>
    /// <typeparam name="Tcount"></typeparam>
    /// <typeparam name="TDelivery"></typeparam>
    class NewOrder<TDelivery>
        where TDelivery : Delivery, new()
    {
        //public TDelivery delivery;

        public void AddOrder<TCount>()
        {
            TCount pCount = default(TCount);
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

            Console.WriteLine("Доставка\n");
            TDelivery delivery = new TDelivery();
            string OrderDelivery;
            delivery.DeliveryRun(Number, Address, out OrderDelivery);
            OrdersList.OrderDelivery.Add(OrderDelivery);
        }
    }

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