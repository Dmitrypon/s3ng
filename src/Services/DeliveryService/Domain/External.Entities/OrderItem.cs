﻿using DeliveryService.Domain.Domain.Entities;

namespace DeliveryService.Domain.External.Entities
{
    public class OrderItem : IEntity<Guid>
    {       
        public Guid Id { get; set; }
        public Guid ProductGuid { get; }
        public Decimal PricePerUnit { get; private set; }
        public int Count { get; }

        public Order Order { get; set; }
        public Decimal TotalPrice { get; }

        //public OrderItem(
        //    //Order order,
        //    Guid orderGuid,
        //    Guid productGuid,
        //    decimal pricePerUnit,
        //    int count) : base()
        //{
        //    //OrderGuid = order.Guid;
        //    OrderGuid = orderGuid;
        //    ProductGuid = productGuid;

        //    PricePerUnit = pricePerUnit;
        //    Count = count;
        //    TotalPrice = pricePerUnit * count;
        //}

        public bool IsPricePerUnitActual()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Актуализировать стоимость единицы товара.
        /// Актуальная стоимость берётся из ProductService.
        /// </summary>
        public bool ActualizePricePerUnit()
        {
            throw new NotImplementedException();
        }
    }
}