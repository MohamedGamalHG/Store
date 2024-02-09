﻿using Microsoft.AspNetCore.Identity;

namespace Store.Models
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string Address {  get; set; }
        public string Phone {  get; set; }

    }
}
