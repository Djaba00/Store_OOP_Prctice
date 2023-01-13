using System;

namespace OnlineStore
{
    /// <summary>
    /// Доставка
    /// </summary>
    abstract class Delivery
    {
        public abstract void DeliveryRun(int orderID, string address, out string OrderDelivery);
    }

    /// <summary>
    /// Доставка на дом
    /// </summary>
    class HomeDelivery : Delivery
    {
        public override void DeliveryRun(int orderID, string address, out string orderDelivery)
        {
            Console.WriteLine("Доступные ТК: DHL, CDEK, GDT");
            Console.Write("Укажите ТК: ");
            string deliveryCompany = Console.ReadLine();
            switch (deliveryCompany)
            {
                case "CDEK":
                    //отправить данные посылки и посылку в ближайший офис CDEK
                    Console.WriteLine($"Послылка #{orderID} будет доставлена курьерской службой CDEK по адресу {address}");
                    break;
                case "GDT":
                    //отправить данные посылки и посылку в ближайший офис GDT
                    Console.WriteLine($"Послылка #{orderID} будет доставлена курьерской службой GDT по адресу {address}");
                    break;
                default:
                    //отправить данные посылки и посылку в ближайший офис DHL
                    Console.WriteLine($"Послылка #{orderID} будет доставлена курьерской службой DHL по адресу {address}");
                    break;
            }
            orderDelivery = deliveryCompany;
        }
    }

    /// <summary>
    /// Доставка в пункт выдачи
    /// </summary>
    class PickPointDelivery : Delivery
    {
        public override void DeliveryRun(int orderID, string address, out string orderDelivery)
        {
            Console.WriteLine($"Заказ #{orderID} будет досатвен в ближайший к {address} PickPoint");
            orderDelivery = "PickPoint";
        }
    }

    /// <summary>
    /// Доставка в ближайший магазин
    /// </summary>
    class ShopDelivery : Delivery
    {
        public override void DeliveryRun(int orderID, string address, out string orderDelivery)
        {
            Console.WriteLine($"Заказ #{orderID} будет досатвен в ближайший к {address} магазин");
            orderDelivery = "ShopDelivery";
        }
    }
}

