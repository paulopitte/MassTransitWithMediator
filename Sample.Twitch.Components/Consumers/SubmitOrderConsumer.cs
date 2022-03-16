using MassTransit;
using Sample.Twitch.Contract;

namespace Sample.Twitch.Components.Consumers
{
    public class SubmitOrderConsumer :
        IConsumer<SubmitOrder>
    {
        public async Task Consume(ConsumeContext<SubmitOrder> context)
        {
            //REGRAS ETC..
            if (context.Message.CustomerName.Contains("erro"))
            {
                await context.RespondAsync<SubmitOrderRejeted>(new
                {
                    context.Message.OrderID,
                    context.Message.OrderDate,
                    context.Message.CustomerName,
                    Status = "REPROVED",
                    Reason = "CRÉDITO INSUFICIENTE."
                });
                return;
            }


            await context.RespondAsync<SubmitOrderAccepted>(new
            {
                context.Message.OrderID,
                context.Message.OrderDate,
                context.Message.CustomerName,
                Status = "Approved"
            });
        }
    }
}
