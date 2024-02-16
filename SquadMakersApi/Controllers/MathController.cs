using Application.Math.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SquadMakersApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MathController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MathController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("least-common-multiple")]
        public async Task<IActionResult> GetLeastCommonMultiple([FromQuery] List<int> numbers)
        {
            try
            {
                var joke = await _mediator.Send(new GetLCMQuery(numbers));
                return Ok(joke);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("plus-one")]
        public async Task<IActionResult> GetPlusNumber([FromQuery] int number)
        {
            try
            {
                var joke = await _mediator.Send(new GetPlusNumberQuery(number));
                return Ok(joke);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
