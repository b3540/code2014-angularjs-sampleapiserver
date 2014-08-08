using System.Data.Entity;

namespace SampleAPIServer.Models
{
    public class SampleAPIDBContext : DbContext
    {
        public DbSet<Bookmark> Bookmarks { get; set; }
    }
}