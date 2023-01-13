namespace OnlineStore
{
    class Program
    {
        public static void Main()
        {
            List<User> usersList = new List<User>() { new User() { UserID = 0, Name = "Timofey", Phone = "+79055856556", Address = "Semenov St."} };

            Program.ConsoleProgram(usersList);
            Console.ReadKey();
        }

        public static void ConsoleProgram(List<User> usersList)
        {
            string command = "";

            while(command != "exit")
            {
                Console.Write("Для вызова списка команд введите <help>\nВведите команду: ");
                command = Console.ReadLine();

                string help = "Доступные команды:\n<user> - вход в блок управления данными пользователей\nuser<user add, user info, back>\n" +
                            "<order> - вход в блок управления заказами\n<order add, order info, back>";

                switch (command)
                {
                    case "help":
                        Console.WriteLine(help);
                        break;
                    case "user":
                        while(command != "back" && command != "exit")
                        {
                            UserBlock(usersList,out command);
                        }
                        break;
                    case "order":
                        while(command != "back" && command != "exit")
                        {
                            OrderBlock(usersList, out command);
                        }
                        break;
                    case "exit":
                        command = "exit";
                        break;
                    default:
                        Console.WriteLine($"Неизвестная команда! {help}");
                        break;
                }
            }
            Console.WriteLine("Программа завершена");
            Console.ReadLine();
        }
        
        public static void UserBlock(List<User> usersList, out string command)
        {
            Console.WriteLine("Вы находитесь в блоке user");
            string usercommand = "";
            string question = "";

            while (usercommand != "back" && usercommand != "exit")
            {
                Console.Write("<user>Введите команду: ");
                usercommand = Console.ReadLine();
                switch (usercommand)
                {
                    case "user add":
                        
                        while (question != "N")
                        {
                            User.AddUser(usersList);

                            Console.Write("Добавить еще пользователя?(Y/N): ");
                            question = Console.ReadLine();
                        }
                        question = "Y";
                        break;
                    case "user info":
                        while (question != "N")
                        {
                            Console.Write($"Пользователей в базе {usersList.Count}\nВведите ID пользоватея: ");
                            int UserID = Int32.Parse(Console.ReadLine());
                            UserID.DisplayUserInfo(usersList);
                            Console.Write("Продолжить работу с базой пользователей?(Y/N): ");
                            question = Console.ReadLine();
                        }
                        question = "Y";
                        break;
                    case "exit":
                        usercommand = "exit";
                        break;
                    case "back":
                        usercommand = "back";
                        break;
                    default:
                        Console.WriteLine("Неизвестная команда! Доступные команды: <user add, user info, back>");
                        break;
                }
            }
            command = usercommand;
        }

        public static void OrderBlock(List<User> usersList, out string command)
        {
            Console.WriteLine("Вы находитесь в блоке oder");
            string ordercommand = "";
            //Question question = new Question();
            string question = "";
            while (ordercommand != "back" && ordercommand != "exit")
            {
                Console.Write("<order>Введите команду: ");
                ordercommand = Console.ReadLine();
                switch (ordercommand)
                {
                    case "order add":
                        while (question != "N")
                        {
                            Console.WriteLine("Новый заказ!");
                            DeliveryOptions.Delivery(usersList);
                            Console.Write("Добавить еще один заказ?(Y/N): ");
                            question = Console.ReadLine();
                        }
                        question = "Y";
                        break;
                    case "order info":
                        while (question != "N")
                        {
                            Console.Write($"Заказов в базе {OrdersList.OrderID.Count}\nВведите номер заказа: ");
                            int OrderID = Int32.Parse(Console.ReadLine());
                            OrderID.DisplayOrderInfo();
                            Console.Write("Продолжить работу с базой заказов?(Y/N): ");
                            question = Console.ReadLine();
                        }
                        question = "Y";
                        break;
                    case "exit":
                        ordercommand = "exit";
                        break;
                    case "back":
                        ordercommand = "back";
                        break;
                    default:
                        Console.WriteLine("Неизвестная команда! Доступные команды: <user add, user info, back>");
                        break;
                }
            }
            command = ordercommand;
        }
    }
}