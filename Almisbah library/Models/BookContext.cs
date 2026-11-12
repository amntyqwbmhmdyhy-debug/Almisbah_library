using Almisbah_library.Models;
using System.Data.Entity;
public class BookContext : DbContext
{
    public BookContext() : base("AlMisbahDB") { }
    public DbSet<Book> Books { get; set; }
    public DbSet<Category> Categories { get; set; }
}
