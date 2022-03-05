namespace Domain;

public class Instructions
{
    public int AmountOfInstructions { get; set; }
    public List<Tuple<string, int>> Steps { get; set; } = new List<Tuple<string, int>>();
    public Point StartingPoint { get; set; }
}