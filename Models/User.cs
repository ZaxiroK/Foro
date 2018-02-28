using System;
using System.ComponentModel.DataAnnotations;
namespace Foro.Models
{
    public class User
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Account type is required")]
        public string Account { get; set; }
    }
}