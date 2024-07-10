using Journey.Communication.Requests;

namespace Journey.Application.UseCases.Trips.Register
{
    public class RegisterTripUseCase
    {
        public void Execute(RequestRegisterTripJson request)
        {
            Validate(request);
        }

        private void Validate(RequestRegisterTripJson request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                throw new ArgumentException("Nome não pode ser vazio.");
            }

            if (request.StartDate.Date < DateTime.UtcNow.Date)
            {
                throw new ArgumentException("Data de início não pode ser antes do momento atual.");
            }

            if (request.EndDate.Date < request.StartDate.Date)
            {
                throw new ArgumentException("Data de fim deve ser durante ou após a data de início.");
            }
        }
    }
}
