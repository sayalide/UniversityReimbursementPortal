using Microsoft.EntityFrameworkCore;
using ReimbursementApp.Models;  

public class ApplicationDbContext : DbContext
{
    public DbSet<Receipt> Receipts { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        // Ensure Receipts is initialized
        Receipts = Set<Receipt>();
    }
}
