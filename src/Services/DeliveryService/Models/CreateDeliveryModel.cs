using DeliveryService.Domain.Domain.Entities;
using DeliveryService.Domain.External.Entities;
using DeliveryService.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace DeliveryService.Models
{
    public class CreateDeliveryModel
    {
        public Guid Id { get; set; }
        public required Guid UserId { get; set; }
        public Guid OrderId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public DeliveryStatus DeliveryStatus { get; set; }
        public required int TotalQuantity { get; set; }
        public required decimal TotalPrice { get; set; }
        public PaymentType PaymentType { get; set; }        
        public required string ShippingAddress { get; set; }
        public Guid CourierId { get; set; }        
        public required DateTime EstimatedDeliveryTime { get; set; }
        public DateTime ActualDeliveryTime { get; set; }
    }
}
