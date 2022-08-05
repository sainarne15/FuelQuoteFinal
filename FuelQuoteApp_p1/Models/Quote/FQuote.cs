using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FuelQuoteApp_p1.Models.Quote
{
    public class FQuote
    {

        [Required(ErrorMessage = "Please enter the required quantity of fuel!")]
        public int GallonsRequested { get; set; }

        [ReadOnly(true)]
        public string DeliveryAddress { get; set; }

        [Required(ErrorMessage = "Please enter the date!")]
        [StartDate(ErrorMessage = "Invalid date")]
        [DataType(DataType.Date)]
        public DateTime DateRequested { get; set; }

        [ReadOnly(true)]
        public float PricePerGallon { get; set; }

        [ReadOnly(true)]
        public float TotalAmount { get; set; }
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
