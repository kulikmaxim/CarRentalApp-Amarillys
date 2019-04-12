using System;

namespace BLL.Models
{
    public class OrderInfo
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public DateTime RentalBeginDate { get; set; }
        public DateTime RentalEndDate { get; set; }

        public int UserId { get; set; }
        public UserInfo User { get; set; }

        public int CarId { get; set; }
        public CarInfo Car { get; set; }
    }
}
