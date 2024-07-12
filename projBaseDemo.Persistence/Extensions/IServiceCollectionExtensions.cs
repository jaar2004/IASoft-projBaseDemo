// IAR lun 01JUL2024

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using projBaseDemo.Application.Interfaces.Repositories;
using projBaseDemo.Persistence.Context;
using projBaseDemo.Persistence.

namespace projBaseDemo.Persistence.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddMappings();
            services.AddDbContext(configuration);
            services.AddRepositories();
        }

        //private static void AddMappings(this IServiceCollection services)
        //{
        //    services.AddAutoMapper(Assembly.GetExecutingAssembly());
        //}

        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(connectionString,
                   builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services
                .AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork))
                .AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>))
                .AddTransient<IArticuloRepository, ArticuloRepository>();
                //.AddTransient<IPlayerRepository, PlayerRepository>()
                //.AddTransient<IClubRepository, ClubRepository>()
                //.AddTransient<IStadiumRepository, StadiumRepository>()
                //.AddTransient<ICountryRepository, CountryRepository>();
        }
    }
}
