using System;
namespace Utility
{
    public class SD
    {
        public const string AdminRole = "Admin";
        public const string CustomerRole = "Customer";
        public const string PaymentStatusPending = "Payment Pending";
        public const string PaymentStatusApproved = "Payment Approved";
        public const string StatusApproved = "Approved";
        public const string StatusInProcess = "Processing";
        public const string StatusShipped = "Shipped";
        public const string StatusCancelled = "Cancelled";
        public const string StatusRefunded = "Refunded";

        public const int FashionId = 1;
        public const int ElectronicsId = 2;
        public const int FurnitureId = 3;
        public const int SportsId = 4;
        public const int HealthId = 5;
        public const int MiscId = 6;
        public static readonly List<string> PageList = new List<string> { "Fashion", "Electronics", "Furniture","Sports", "Health", "Miscellaneous"};
    }
}

