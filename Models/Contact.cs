using System;
using System.ComponentModel.DataAnnotations;

namespace Foro.Models
{
    public class Contact
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Client is required")]
        public int ClientID { get; set; }
        public virtual Client Client { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone is required")]
        public int Phone { get; set; }
        [Required(ErrorMessage = "Employment is required")]
        public string Employment { get; set; }
    }
} 