namespace AIMElevator.Entities
{

    public record Elevator
    {
        private int[] AvailableFloors {get;set;}   = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 14, 15, 16 };
        public Guid Id { get; set; } 
        public int Floor { get; set; }
        public Queue<int> FloorQueue { get; set; } 

        public Elevator(){
            this.Id = Guid.NewGuid();
            this.Floor =  AvailableFloors[Random.Shared.Next(AvailableFloors.Length)];
            this.FloorQueue = new Queue<int>(AvailableFloors.Where(floor => floor != this.Floor).OrderBy(x => Random.Shared.Next()).Take(Random.Shared.Next(5)));
        }
    }
}