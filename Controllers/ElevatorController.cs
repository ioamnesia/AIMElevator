using Microsoft.AspNetCore.Mvc;

namespace AIMElevator.Controllers;

[ApiController]
[Route("elevators")]
public class ElevatorController : ControllerBase
{
    public static readonly int[] Floors = new[]
    {
        1,2,3,4,5,6,7,8,9,10,11,12,14,15,16
    };

    List<Elevator> Elevators = Enumerable.Range(1, 5).Select(index => new Elevator
    {
        Floor = Floors[Random.Shared.Next(Floors.Length)],
        FloorQueue = new Queue<int>(Floors.OrderBy(x => Random.Shared.Next()).Take(Random.Shared.Next(5)))
    }).ToList<Elevator>();
    
    [HttpGet(Name = "GetElevators")]
    public IEnumerable<Elevator> Get()
    {
        return Elevators.ToArray();
    }

    private readonly ILogger<ElevatorController> _logger;

    public ElevatorController(ILogger<ElevatorController> logger)
    {
        _logger = logger;
    }

    
}
