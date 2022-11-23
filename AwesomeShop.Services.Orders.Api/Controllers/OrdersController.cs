using AwesomeShop.Services.Orders.Application.Commands;
using AwesomeShop.Services.Orders.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AwesomeShop.Services.Orders.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(Guid Id)
        {
            var query = new GetOrderById(Id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddOrder command)
        {            
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { result}, command);
        }
    }
}
