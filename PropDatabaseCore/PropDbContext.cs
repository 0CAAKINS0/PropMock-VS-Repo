using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PropMockModels;
using System.IO;


namespace PropDatabaseCore
{
    public class PropDbContext : DbContext
    {
        static IConfigurationRoot _configuration;

        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<LienSearch> LienSearches { get; set; }
        public DbSet<Estoppel> EstoppelSearches { get;set; }
        public DbSet<Tax> TaxSearches { get; set; }
        public DbSet<ReleaseTracking> RTSearches { get; set;}
        public DbSet<CurativeServices> CSSearches { get; set; }   
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        public PropDbContext() : base() { }

        public PropDbContext(DbContextOptions<PropDbContext> options)
        : base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json", optional: true,
                                reloadOnChange: true);
                _configuration = builder.Build();
                var cnstr = _configuration.GetConnectionString("PropMockDB");
                optionsBuilder.UseNpgsql(cnstr);
            }
        }
    }
}