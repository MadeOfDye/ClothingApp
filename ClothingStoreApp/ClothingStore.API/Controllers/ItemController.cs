using ClothingStore.Application.Aggregates.Item.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClothingStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ItemController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllItems([FromQuery] GetAllItemsQuery query)
        {
            Console.WriteLine(query);
            return Ok(await _mediator.Send(query));
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetItemById([FromRoute] GetItemByIdQuery query)
        {
            var item = await _mediator.Send(query);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }
    }
}
