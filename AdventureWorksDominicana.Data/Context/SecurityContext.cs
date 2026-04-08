using AdventureWorksDominicana.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksDominicana.Data.Context;


public class SecurityContext : IdentityDbContext<AspNetUser>
{
    public SecurityContext(DbContextOptions<SecurityContext> options)
        : base(options)
    {
    }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		if (!optionsBuilder.IsConfigured)
		{
			
			optionsBuilder.UseSqlServer("workstation id=AdventureWorksDomDb.mssql.somee.com;packet size=4096;user id=Apl1ProyFin_SQLLogin_1;pwd=puxthi9hug;data source=AdventureWorksDomDb.mssql.somee.com;persist security info=False;initial catalog=AdventureWorksDomDb;TrustServerCertificate=True");
		}
	}

	protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

    }
}