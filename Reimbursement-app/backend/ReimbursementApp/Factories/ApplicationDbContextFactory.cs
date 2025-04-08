using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure; 
using ReimbursementApp.Models;  // Add this if it's missing

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseMySql(
            "server=localhost;database=reimbursement;user=root;password=yourpassword", 
            new MySqlServerVersion(new Version(8, 0, 23)) 
        );

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}
