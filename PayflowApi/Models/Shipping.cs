using PayFlowApi.Enum;

namespace PayFlowApi.Models
{
    public class Shipping
    {
        public ShippingType Type { get; set; } = ShippingType.PICKUP_IN_STORE;
        public int DeliveryTime { get; set; }
        public decimal Freight { get; set; }
    }
}
