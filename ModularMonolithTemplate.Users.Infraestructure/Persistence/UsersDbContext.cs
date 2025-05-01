using Microsoft.EntityFrameworkCore;
using ModularMonolithTemplate.Users.Domain.Entities;

namespace ModularMonolithTemplate.Users.Infraestructure.Persistence;

public class UsersDbContext(DbContextOptions<UsersDbContext> options) : DbContext(options)
{
    public DbSet<UserProfile> UserProfiles => Set<UserProfile>();
}
