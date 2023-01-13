using System;


namespace OnlineStore
{
    public static class UserInfo
    {
        public static void DisplayUserInfo(this int UserID, List<User> usersList)
        {
            if (UserID <= usersList.Count - 1 && UserID >= 0)
            {
                Console.WriteLine($"Информация о ID#{UserID}: \nИмя: {usersList[UserID].Name}\nТелефон: {usersList[UserID].Phone}" +
                    $"\nАдрес: {usersList[UserID].Address}");
            }
            else
                Console.WriteLine("Пользователь не найден.");
        }
    }
}

