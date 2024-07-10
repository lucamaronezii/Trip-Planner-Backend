using Journey.Communication.Requests;
using Microsoft.AspNetCore.Mvc;
using Journey.Application.UseCases.Trips.Register;
using Journey.Exception.ExceptionsBase;
using Journey.Application.UseCases.Trips.GetAll;

namespace Journey.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private string error = "Unknown error.";

        [HttpPost]
        public IActionResult Register([FromBody] RequestRegisterTripJson request)
        {
            try
            {
                var useCase = new RegisterTripUseCase();

                var response = useCase.Execute(request);

                return Created(string.Empty, response);
            }
            catch (JourneyException ex)
            {
                return BadRequest(ex.Message);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, error);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var useCase = new GetAllTripsUseCase();
                var result = useCase.Execute();

                return Ok(result);
            } catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, error);
            }
        }
    }
}
