// IAR vie 06JUN2024

using MediatR;
using Microsoft.Extensions.DependencyInjection;
using projBaseDemo.Application.Interfaces;
using projBaseDemo.Domain.Common;
using projBaseDemo.Domain.Common.Interfaces;
using projBaseDemo.Infrastructure.Services;

namespace projBaseDemo.Infrastructure.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddInfrastructureLayer(this IServiceCollection services)
        {
            services.AddServices();
        }

        private static void AddServices(this IServiceCollection services)
        {
            services
                .AddTransient<IMediator, Mediator>()
                .AddTransient<IDomainEventDispatcher, DomainEventDispatcher>()
            .AddTransient<IDateTimeService, DateTimeService>()
                .AddTransient<IEmailService, EmailService>();
        }
    }
}
