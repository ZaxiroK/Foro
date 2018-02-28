using System;
using System.ComponentModel.DataAnnotations;


namespace Foro.Models
{
    public class Client
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Identity Card is required")]
        public string IdentityCard { get; set; }
        [Required(ErrorMessage = "Web Page is required")]
        public string WebPage { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Phone is required")]
        public int Phone { get; set; }
        [Required(ErrorMessage = "Sector is required")]
        public string Sector { get; set; }
    }
}