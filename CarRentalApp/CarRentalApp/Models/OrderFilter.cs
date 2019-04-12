using System;

namespace CarRentalApp.Models
{
    public class OrderFilter
    {
        public DateTime? RentalBeginDate { get; set; }
        public DateTime? RentalEndDate { get; set; }
        public string UserName { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
    }
}
