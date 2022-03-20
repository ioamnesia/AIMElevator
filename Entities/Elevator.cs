namespace AIMElevator;

public class Elevator
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public int Floor { get; set; } = 0;
    public Queue<int> FloorQueue { get; set; } = new Queue<int>();

}
