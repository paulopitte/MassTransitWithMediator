using MassTransit;
using MassTransit.Mediator;
using Microsoft.AspNetCore.Mvc;
using Sample.Twitch.Contract;

namespace Sample.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        readonly ILogger<OrderController> _logger;
        readonly IMediator _mediator;
        public OrderController(ILogger<OrderController> logger
            , IMediator mediator
            )
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }


        [HttpPost]
        public async Task<IActionResult> Post(string name)
        {
            var client = _mediator.CreateRequestClient<SubmitOrder>();
            var (accepted, rejected) = await client.GetResponse<SubmitOrderAccepted, SubmitOrderRejeted>(new
            {
                OrderId = NewId.NextGuid(),
                OrderDate = DateTime.UtcNow.AddHours(-3),
                CustomerName = name
            });

            if (accepted.IsCompletedSuccessfully)
            {
                Response<SubmitOrderAccepted>? resp = await accepted;
                return Ok(resp.Message);
            }
            
            var response = await rejected;
            return BadRequest(response.Message);


        }
    }
}
