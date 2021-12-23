using BotTelegram.Model;
using Microsoft.EntityFrameworkCore;

namespace BotTelegram
{
    public class DataContex : DbContext
    {
        public DataContex(DbContextOptions<DataContex> options) : base(options)
        {

        }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Operation> Operations { get; set; }
    }
}