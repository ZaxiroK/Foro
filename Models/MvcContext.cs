using Microsoft.EntityFrameworkCore;
using Foro.Models;

namespace Foro.Models
{
    public class MvcContext : DbContext
    {
        public MvcContext (DbContextOptions<MvcContext> options)
            : base(options)
        {
        }

        public DbSet<Foro.Models.User> User { get; set; }
        public DbSet<Foro.Models.Client> Client { get; set; }
        public DbSet<Foro.Models.Contact> Contact { get; set; }
        public DbSet<Foro.Models.Meeting> Meeting { get; set; }
        public DbSet<Foro.Models.SupportTicket> SupportTicket { get; set; }
        
        

    }
}