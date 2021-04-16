using System;
using System.ComponentModel.DataAnnotations;

namespace PetCare.Domain.Communication
{
    public class AuthenticateRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
