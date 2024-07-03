// IAR lun 01JUL2024

using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.ChangeTracking;
using projBaseDemo.Domain.Common;
using projBaseDemo.Domain.Common.Interfaces;
using projBaseDemo.Domain.Entities;
using System.Reflection;

namespace projBaseDemo.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IDomainEventDispatcher _dispatcher;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
          IDomainEventDispatcher dispatcher)
            : base(options)
        {
            _dispatcher = dispatcher;
        }

        public DbSet<Articulo> Clubs => Set<Articulo>();
        //public DbSet<Club> Clubs => Set<Club>();
        //public DbSet<Player> Players => Set<Player>();
        //public DbSet<Stadium> Stadiums => Set<Stadium>();
        //public DbSet<Country> Countries => Set<Country>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            // ignore events if no dispatcher provided
            if (_dispatcher == null) return result;

            // dispatch events only if save was successful
            var entitiesWithEvents = ChangeTracker.Entries<BaseEntity>()
                .Select(e => e.Entity)
                .Where(e => e.DomainEvents.Any())
                .ToArray();

            await _dispatcher.DispatchAndClearEvents(entitiesWithEvents);

            return result;
        }

        public override int SaveChanges()
        {
            return SaveChangesAsync().GetAwaiter().GetResult();
        }
    }
}
