namespace AwesomeCqrs.Samples.Controllers
{

    using Microsoft.AspNetCore.Mvc;
    using AwesomeCqrs;
    using System.Threading.Tasks;
    using AwesomeCqrs.Samples.Commands;

    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PeopleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddPerson command)
        {
            var result = await _mediator.Dispatch(command);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdatePerson command) {
            await _mediator.Dispatch(command);

            return Ok();
        }
    }
}