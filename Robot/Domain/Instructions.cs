namespace Domain;

public class Instructions
{
    public int AmountOfInstructions { get; set; }
    public IEnumerable<Tuple<string, int>> Steps { get; set; } = new List<Tuple<string, int>>();
    public Point StartingPoint { get; set; } = new Point(0, 0);
}