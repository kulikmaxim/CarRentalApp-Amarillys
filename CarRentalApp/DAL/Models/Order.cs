using System;

namespace DAL.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public DateTime RentalBeginDate { get; set; }
        public DateTime RentalEndDate { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}
