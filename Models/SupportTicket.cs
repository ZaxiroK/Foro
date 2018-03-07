using System;
using System.ComponentModel.DataAnnotations;
namespace Foro.Models
{
    public class SupportTicket
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Problem Tittle is required")]
        public string ProblemTittle  { get; set; }
        [Required(ErrorMessage = "Problem Detail is required")]
        public string ProblemDetail { get; set; }
        [Required(ErrorMessage = "User is required")]
        public int UserID { get; set; }
        public virtual User User { get; set; }
        [Required(ErrorMessage = "Client is required")]
        public int ClientID { get; set; }
        public virtual Client Client { get; set; }
        [Required(ErrorMessage = "Status is required")]
        public string Status { get; set; }
    
    }
}