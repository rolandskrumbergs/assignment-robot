using Domain;

namespace App;

public static class InstructionBuilder
{
    public static Instructions BuildFromInput(List<string> input)
    {
        var startingPoints = input[1].Split(' ');
        return new Instructions
        {
            AmountOfInstructions = int.Parse(input[0]),
            StartingPoint = new Point(int.Parse(startingPoints[0]), int.Parse(startingPoints[1])),
            Steps = input
                .TakeLast(input.Count - 2)
                .Select(x => new Tuple<string, int>(x.Split(' ')[0], int.Parse(x.Split(' ')[1])))
        };
    }
}