using Journey.Exception;
using Journey.Exception.ExceptionsBase;
using Journey.Infrastructure;

namespace Journey.Application.UseCases.Trips.Delete
{
    public class DeleteTripUseCase
    {
        public Guid Execute(Guid id)
        {
            var dbContext = new JourneyDbContext();

            var trip = dbContext
                .Trips
                .FirstOrDefault(trip => trip.Id == id);

            if (trip == null)
            {
                throw new NotFoundException(ResourceErrorMessages.ID_NOT_FOUND);
            }

            dbContext.Trips.Remove(trip);

            dbContext.SaveChanges();

            return id;
        }
    }
}
