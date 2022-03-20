using Microsoft.AspNetCore.Mvc;
using AIMElevator.Repositories;
using AIMElevator.Entities;
namespace AIMElevator.Controllers
{

    [ApiController]
    [Route("elevators")]
    public class ElevatorController : ControllerBase
    {
        private readonly IElevatorBank elevatorBank;

        public ElevatorController(ILogger<ElevatorController> logger, IElevatorBank elevators)
        {
            this.elevatorBank = elevators;
            _logger = logger;
        }

        [HttpGet(Name = "GetElevators")]
        public IEnumerable<Elevator> Get()
        {
            return elevatorBank.GetElevators();
        }

        [HttpGet("{id}", Name = "GetElevator")]
        public ActionResult<Elevator> GetElevator(Guid id)
        {
            var result = elevatorBank.GetElevator(id);

            if (result != null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost("call", Name = "CallElevator")]
        public ActionResult CallElevator(int floor)
        {
            if (elevatorBank.GetElevators().Where(e => e.Floor == floor).Count() > 0) { Conflict(); }
            var enroute = elevatorBank.GetElevators().Where(e => e.FloorQueue.Contains(floor));
            if (enroute.Count() > 0)
            {
                var closestEnroute = enroute.OrderBy(e => System.Math.Abs(e.Floor - floor)).First();
                return AcceptedAtRoute("GetElevator", new { id = closestEnroute.Id.ToString("d") }, closestEnroute);
            }
            Elevator closest = elevatorBank.GetElevators().OrderBy(e => System.Math.Abs(e.Floor - floor)).First();
            closest.FloorQueue.Enqueue(floor);
            return AcceptedAtRoute("GetElevator", new { id = closest.Id.ToString("d") }, closest);
        }

        [HttpPost("{id}/dispatch", Name="DispatchElevator")]
        public ActionResult EnqueueFloor(Guid id, int floor)
        {
            var elevator = elevatorBank.GetElevator(id);
            if (elevator == null) { return NotFound(); }
            if (elevator.FloorQueue.Contains(floor) == false) elevator.FloorQueue.Enqueue(floor);
            return AcceptedAtRoute("GetElevator", new { id = elevator.Id.ToString("d") }, elevator);
        }

        [HttpGet("{id}/stops", Name="GetStops")]
        public ActionResult<int[]> GetStops(Guid id){
            var elevator = elevatorBank.GetElevator(id);
            if (elevator == null) { return NotFound(); }
            return elevator.FloorQueue.ToArray();
        }

        [HttpGet("{id}/nextStop")]
        public ActionResult<int> GetNextStop(Guid id){
            var elevator = elevatorBank.GetElevator(id);
            if (elevator == null || elevator.FloorQueue.Count() == 0) { return NotFound(); }
            return elevator.FloorQueue.Peek();
        }


        private readonly ILogger<ElevatorController> _logger;

    }
}