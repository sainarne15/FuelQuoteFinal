using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FuelQuoteApp_p1.EntModels.Models
{
    public class Quote
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter the required quantity of fuel!")]
        public int GallonsRequested { get; set; }

        public string DeliveryAddress { get; set; }
        
        [Required(ErrorMessage = "Please enter the date!")]
        [StartDate(ErrorMessage = "Invalid date")]
        [DataType(DataType.Date)]
        public DateTime DateRequested { get; set; }
        public float PricePerGallon { get; set; }
        public float TotalAmount { get; set; }
        [ForeignKey("User")]
        public int User_Id { get; set; }
    }

    public class StartDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime _dateStart = Convert.ToDateTime(value);
            if (_dateStart >= DateTime.Now)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(ErrorMessage);
            }
        }
    }
}



