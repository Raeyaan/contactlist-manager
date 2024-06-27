using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ContactList.Models
{
    public class Contact
    {
        // EF will instruct the database to automatically generate this value
        public int ContactId { get; set; }

        [Required(ErrorMessage = "Please enter a name.")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a name.")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a phone number.")]
        [RegularExpression(@"^\d{3}(-\d{3})+$", ErrorMessage = "Phone number must contain only numbers with a dash (-) after every three numbers.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please enter a valid email address.")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email address format.")]
        public string Email { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "CategoryId must be greater than zero.")]
        public int CategoryId { get; set; } 

        public DateTime Created { get; set; } = DateTime.Now;

        [ValidateNever]
        public Category Category  { get; set; } = null!;

        public string Slug =>
            $"{FirstName.Replace(' ', '-').ToLower()}-{LastName.Replace(' ', '-')}";
    }
}