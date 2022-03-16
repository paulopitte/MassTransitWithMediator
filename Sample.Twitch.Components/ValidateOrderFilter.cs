
using GreenPipes;
using MassTransit;
using Sample.Twitch.Contract;

namespace Sample.Twitch.Components
{
    public class ValidateOrderFilter<T> :
        IFilter<SendContext<T>>
        where T : class
    {
        public void Probe(ProbeContext context)
        {
         
        }

        /// <summary>
        /// Middleware
        /// O MassTransit Mediator é construído usando os mesmos componentes usados ​​para criar um barramento, 
        /// o que significa que todos os mesmos componentes de middleware podem ser configurados.Por exemplo, 
        /// para configurar o pipeline do Mediador, como adicionar um filtro com escopo, consulte o exemplo abaixo.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public Task Send(SendContext<T> context, IPipe<SendContext<T>> next)
        {
            if (context.Message is SubmitOrder getOrderStatus && getOrderStatus.Equals(Guid.Empty))
                throw new ArgumentException("The OrderId must not be empty");

            return next.Send(context);
        }
    }
}
