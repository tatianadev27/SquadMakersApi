using Application.Commands.Create;
using Application.Commands.Update;
using Application.Jokes.Commands.Delete;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SquadMakersApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JokesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public JokesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetJoke([FromQuery] string type)
        {
            try
            {
                var joke = await _mediator.Send(new GetRandomJokeQuery(type));
                return Ok(joke);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateJoke([FromBody] CreateJokeCommand command)
        {
            try
            {
                await _mediator.Send(command); 
                return Created();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateJoke([FromBody] UpdateJokeCommand command)
        {
            try
            {
                var joke = await _mediator.Send(command);
                return Ok(joke);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }



        [HttpDelete]
        public async Task<IActionResult> DeleteJoke([FromBody] DeleteJokeCommand command)
        {
            try
            {
                var joke = await _mediator.Send(command);
                return Ok(joke);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
