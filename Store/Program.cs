namespace OnlineStore
{
    class Program
    {
        public static void Main()
        {

            //user.userAdd();
            //newOrder.AddOrder();
            Console.WriteLine("Количество товара:\n1 - штуки\n2 - килограммы");
            Console.Write("Ответ (1 - 2): ");
            string countMesure = "0";
            
            while(countMesure != "1" || countMesure != "2")
            {
                countMesure = Console.ReadLine();
                if (countMesure == "1")
                {
                    Order<int>.DisplayOrderInf(Order<int>.OrderReqest());
                    continue;
                }
                if(countMesure == "2")
                {
                    Order<double>.DisplayOrderInf(Order<double>.OrderReqest());
                    continue;
                }
                else
                {
                    Console.WriteLine("Некорректный запрос! Попробуйте еще раз.");
                }
            }
            

            Console.ReadKey();
        }
    }
}