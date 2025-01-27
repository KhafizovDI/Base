using System;
using System.Collections.Generic;

namespace PromoCodeFactory.WebHost.Models
{
    public class CreateEmployeeRequest
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string Role { get; set; }

        public int PromocodesCount { get; set; }

    }
}