using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AndroidApi.Domain.DTO_s
{
    public class LoginDTO
    {
        
        /// <example>
        /// "leerkracht"
        /// </example>
        [Required]
        public string UserName { get; set; }

        /// <example>
        /// "P@ssword1"
        /// </example>
        [Required]
        public string Password { get; set; }

    }
}
