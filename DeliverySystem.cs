using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceSystem
{
    internal class DeliverySystem
    {
        public string DeliveryID { get; set; }
        public string OrderID { get; set; }
        public string DeliveryAddress { get; set; }
        public string DeliveryStatus { get; set; }
        public DateTime EstimatedDeliveryDate { get; set; }
        public DateTime ActualDeliveryDate { get; set; }
        public string TrackingNumber { get; set; }
        public string Deliverymethod { get; set; }
        public decimal DeliveryCost { get; set; }

        // metoder
        public void UpdateStatus(string newStatus)
        {
            DeliveryStatus = newStatus;
            Console.WriteLine($"Delivery {DeliveryID} status updated to {DeliveryStatus}");
        }

        public void TrackDelivery()
        {
            Console.WriteLine($"Tracking Number: {TrackingNumber}");
            Console.WriteLine($"Current Status: {DeliveryStatus}");
            Console.WriteLine($"Estimated Delivery: {EstimatedDeliveryDate:yyyy-MM-dd}");
        }

        public void ScheduleDelivery(DateTime deliveryDate)
        {
            EstimatedDeliveryDate = deliveryDate;
            Console.WriteLine($"Delivery scheduled for {EstimatedDeliveryDate:yyyy-MM-dd}");
        }

        private string GenerateTrackingNumber()
        {
            return "TRK" + Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
        }



        // Konstruktor
        public DeliverySystem()
        {
            DeliveryID = Guid.NewGuid().ToString();
            DeliveryStatus = "Pending";
            TrackingNumber = "TRK" + Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
        }

    }
}
