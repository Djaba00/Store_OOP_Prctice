using System;

namespace OnlineStore
{
    /// <summary>
    /// Конструктор пользователя
    /// </summary>
    public class User
    {
        public int UserID { get; set; }

        private string name = "Unknown";
        public string Name
        {
            get { return name; }
            set
            {
                if (String.IsNullOrWhiteSpace(value) == false)
                    name = value;
            }
        }

        private string phone = "Unknown";
        public string Phone
        {
            get { return phone; }
            set
            {
                if (String.IsNullOrWhiteSpace(value) == false)
                    phone = value;
            }
        }

        private string address = "Unknown";
        public string Address
        {
            get { return address; }
            set
            {
                if (String.IsNullOrWhiteSpace(value) == false)
                    address = value;
            }
        }

        public static void AddUser(List<User> userList )
        {
            User user = new User();

            Console.WriteLine("Регистрация нового пользователя");
            user.UserID = userList.Count;

            Console.Write("Введите имя: ");
            user.Name = Console.ReadLine();
            

            Console.Write("Введите номер телефона: ");
            user.Phone = Console.ReadLine() ?? "Unknown";

            Console.Write("Введите адрес: ");
            user.Address = Console.ReadLine() ?? "Unknown";

            userList.Add(user);
        }

        
        // Вариант с перегрузкой
        //public User()
        //{
        //    Console.WriteLine("Регистрация нового пользователя");
        //    UsersList.UserID.Add(UsersList.UserID.Count);

        //    Console.Write("Введите имя: ");
        //    Name = Console.ReadLine() ?? "Unknown";

        //    Console.Write("Введите номер телефона: ");
        //    Phone = Console.ReadLine() ?? "Unknown";

        //    Console.Write("Введите адрес: ");
        //    Address = Console.ReadLine() ?? "Unknown";

        //    UsersList.UserName.Add(Name);
        //    UsersList.UserPhone.Add(Phone);
        //    UsersList.UserAddress.Add(Address);
        //}
        //public User(string n, string p, string a) { Name = n; Phone = p; Address = a; }
    }
}

