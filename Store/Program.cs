namespace OnlineStore
{
    class Program
    {
        public static void Main()
        {

            //user.userAdd();
            //newOrder.AddOrder();
            object deliveryOption = DeliveryOptions.Delivery();
            Order<>.DisplayOrderInf(Order<>.OrderReqest());

            Console.ReadKey();
        }
    }
}