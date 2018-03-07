using System;
using System.ComponentModel.DataAnnotations;
namespace Foro.Models
{
    public class Meeting
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Meeting Tittle is required")]
        public string MeetingTittle  { get; set; }
        [Required(ErrorMessage = "Date is required")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "User is required")]
        public int UserID { get; set; }
        public virtual User User { get; set; }
        [Required(ErrorMessage = "Its is required")]
        public Boolean Virtual { get; set; }
        [Required(ErrorMessage = "Client is required")]
        public int ClientID { get; set; }
        public virtual Client Client { get; set; }
    
    }
} 