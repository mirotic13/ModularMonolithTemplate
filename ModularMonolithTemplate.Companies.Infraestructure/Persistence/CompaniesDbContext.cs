using Microsoft.EntityFrameworkCore;
using ModularMonolithTemplate.Companies.Domain.Entities;

namespace ModularMonolithTemplate.Companies.Infraestructure.Persistence;

public class CompaniesDbContext(DbContextOptions<CompaniesDbContext> options) : DbContext(options)
{
    public DbSet<Company> Companies => Set<Company>();
}
