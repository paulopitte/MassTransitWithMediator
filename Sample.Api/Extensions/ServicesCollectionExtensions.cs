using MassTransit;
using Sample.Twitch.Components.Consumers;
using Sample.Twitch.Contract;

namespace Sample.Api.Extensions
{
    public static class ServicesCollectionExtensions
    {
        public static IServiceCollection AddBus(this IServiceCollection services)
        {
            services.AddMediator(m =>
            {
                m.AddConsumer<SubmitOrderConsumer>();
                m.AddRequestClient<SubmitOrder>();
            });

            return services;
        }
    }
}
