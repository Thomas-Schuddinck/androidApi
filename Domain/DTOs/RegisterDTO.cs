using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AndroidApi.Domain.DTOs
{
    public class RegisterDTO
    {
        
        /// <example>
        /// "Thomas"
        /// </example>
        [Required]
        [StringLength(200)]
        public string FirstName { get; set; }

        /// <example>
        /// "Schuddinck"
        /// </example>
        [Required]
        [StringLength(250)]
        public string LastName { get; set; }

        /// <example>
        /// "thomas.schuddinck@mail.com"
        /// </example>
        [Required]
        [StringLength(200)]
        [EmailAddress]
        public string Email { get; set; }

        /// <example>
        /// "P@ssword1"
        /// </example>
        [Required]
        [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "Passwords must be at least 8 characters and contain at 3 of 4 of the following: upper case (A-Z), lower case (a-z), number (0-9) and special character (e.g. !@#$%^&*)")]
        public string Password { get; set; }

        /// <example>
        /// "P@ssword1"
        /// </example>
        [Required]
        [Compare("Password")]
        [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "Passwords must be at least 8 characters and contain at 3 of 4 of the following: upper case (A-Z), lower case (a-z), number (0-9) and special character (e.g. !@#$%^&*)")]
        public string PasswordConfirmation { get; set; }
    }
}
