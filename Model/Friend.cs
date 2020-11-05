using System;
using System.ComponentModel.DataAnnotations;

namespace net_core_web.Model
{
    public class Friend
    {
        public int Id { get; set; }

        [
            Required(ErrorMessage = "Name required!"),
            MaxLength(100, ErrorMessage = "No more than 100 characters")
        ]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email required!")]
        [Display(Name = "Email")]
        [
            RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-z0-9-]+\.[a-zA-Z0-9-.]+$",
            ErrorMessage = "Invalid Format!")
        ]
        public string Email { get; set; }

        [Required(ErrorMessage = "You must select a City!")]
        public Province? City { get; set; }

    }
}