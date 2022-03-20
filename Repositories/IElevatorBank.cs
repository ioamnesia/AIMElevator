using AIMElevator.Entities;

namespace AIMElevator.Repositories
{
    public interface IElevatorBank
    {
        Elevator? GetElevator(Guid id);
        IEnumerable<Elevator> GetElevators();
    }
}
