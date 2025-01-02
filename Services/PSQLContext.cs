using Microsoft.EntityFrameworkCore;
using MVC.Models.Entities;

namespace MVC.Services;

public class PSQLContext : DbContext
{
    public DbSet<User> Users { get; private set; }

    public PSQLContext(DbContextOptions<PSQLContext> options) 
        : base(options)
    {
    }
}
