namespace Domain;

public class Robot
{
    private Instructions _instructions;

    private List<Point> _cleanedPoints;

    public Robot(Instructions instructions)
    {
        _instructions = instructions;
        _cleanedPoints = new List<Point>
        {
            _instructions.StartingPoint
        };
    }

    public int Clean()
    {
        var position = _instructions.StartingPoint;

        for (int i = 0; i < _instructions.AmountOfInstructions; i++)
        {
            var pointsToMove = GetNextPoints(position, _instructions.Steps[i]);

            position = pointsToMove.Last();

            var newlyCleanedPoints = pointsToMove.Where(p => !_cleanedPoints.Contains(p));

            _cleanedPoints.AddRange(newlyCleanedPoints);
        }

        return _cleanedPoints.Count;
    }

    private List<Point> GetNextPoints(Point initialPosition, Tuple<string, int> step)
    {
        var result = new List<Point>();

        for (int i = 1; i <= step.Item2; i++)
        {
            result.Add(GetNextPoint(initialPosition, step.Item1, i));
        }

        return result;
    }

    private Point GetNextPoint(Point initialPosition, string direction, int steps)
    {
        switch (direction)
        {
            case "E":
                return new Point(initialPosition.X + steps, initialPosition.Y);
            case "W":
                return new Point(initialPosition.X - steps, initialPosition.Y);
            case "N":
                return new Point(initialPosition.X, initialPosition.Y + steps);
            case "S":
                return new Point(initialPosition.X, initialPosition.Y - steps);
            default:
                break;
        }

        return initialPosition;
    }
}