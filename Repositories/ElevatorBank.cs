using AIMElevator.Entities;

namespace AIMElevator.Repositories
{
    public class ElevatorBank : IElevatorBank
    {
        private readonly List<Elevator> elevators = Enumerable.Range(1, 5).Select(index => new Elevator()).ToList<Elevator>();

        public IEnumerable<Elevator> GetElevators()
        {
            return elevators;
        }

        public Elevator? GetElevator(Guid id)
        {
            return elevators.Where(e => e.Id == id).SingleOrDefault();
        }
    }
}
