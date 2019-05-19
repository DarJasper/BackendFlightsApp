using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsReservationApp.API.DTO_s
{
    [NotMapped]
    public class User_DTO
    {
        [Required]
        [EmailAddress]
        [StringLength(256, ErrorMessage = "{0} character limit of {1} exceeded.")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
