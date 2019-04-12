using System;
using System.Collections.Generic;

namespace BLL.Models
{
    public class UserInfo
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string DrivingLicenseNumber { get; set; }
    }
}
