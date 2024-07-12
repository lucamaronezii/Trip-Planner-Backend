using Journey.Communication.Requests;
using Microsoft.AspNetCore.Mvc;
using Journey.Application.UseCases.Trips.Register;
using Journey.Exception.ExceptionsBase;
using Journey.Application.UseCases.Trips.GetAll;
using Journey.Exception;
using Journey.Application.UseCases.Trips.GetById;
using Journey.Communication.Responses;
using Journey.Application.UseCases.Trips.Delete;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Journey.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(typeof(ResponseShortTripJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public class TripsController : ControllerBase
    {
        [HttpPost]
        public IActionResult Register([FromBody] RequestRegisterTripJson request)
        {
            var useCase = new RegisterTripUseCase();
            var response = useCase.Execute(request);
            return Created(string.Empty, response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseTripsJson), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {

            var useCase = new GetAllTripsUseCase();
            var response = useCase.Execute();
            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResponseTripJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var useCase = new GetTripByIdUseCase();
            var response = useCase.Execute(id);
            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var useCase = new DeleteTripUseCase();

            useCase.Execute(id);

            return Ok($"Removed trip: {id}");
        }
    }
}
