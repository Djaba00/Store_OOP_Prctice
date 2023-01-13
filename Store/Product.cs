using System;
namespace Store
{
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
}

