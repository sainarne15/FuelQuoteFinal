﻿using System.ComponentModel.DataAnnotations;

namespace FuelQuoteApp_p1.Models.Account
{
    public class Login
    {
        [Required(ErrorMessage = "Email is required!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
