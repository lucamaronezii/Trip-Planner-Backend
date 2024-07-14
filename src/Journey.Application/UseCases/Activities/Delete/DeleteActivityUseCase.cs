using Journey.Infrastructure;
using Journey.Exception.ExceptionsBase;
using Journey.Exception;

namespace Journey.Application.UseCases.Activities.Delete
{
    public class DeleteActivityUseCase
    {
        public void Execute(Guid tripId, Guid activityId)
        {
            var dbContext = new JourneyDbContext();

            var activity = dbContext
                .Activities
                .FirstOrDefault(activity => activity.Id == activityId && activity.TripId == tripId)
                ?? throw new NotFoundException(ResourceErrorMessages.ID_NOT_FOUND);

            dbContext.Remove(activity);
            dbContext.SaveChanges();
        }
    }
}
