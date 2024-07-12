using FluentValidation;
using Journey.Communication.Requests;
using Journey.Exception;

namespace Journey.Application.UseCases.Trips.Register
{
    public class RegisterTripValidator : AbstractValidator<RequestRegisterTripJson>
    {
        public RegisterTripValidator()
        {
            RuleFor(request => request.Name).NotEmpty().WithMessage(ResourceErrorMessages.NAME_EMPTY);
            RuleFor(request => request.StartDate.Date).GreaterThanOrEqualTo(DateTime.UtcNow.Date).WithMessage(ResourceErrorMessages.STARTDATE_MUST_BE_LATER_THAN_TODAY);
            RuleFor(request => request.EndDate.Date).LessThan(request => request.StartDate.Date).WithMessage(ResourceErrorMessages.ENDDATE_MUST_BE_LATER_THAN_STARTDATE);
        }
    }
}
