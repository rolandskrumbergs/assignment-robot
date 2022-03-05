using App;
using Domain;

var lines = new List<string>();

string? line;
var counter = -1;

while ((line = Console.ReadLine()) != null)
{
    lines.Add(line);
    
    if (counter.ToString() == lines[0])
    {
        break;
    }

    counter++;
}

var instructions = InstructionBuilder.BuildFromInput(lines);

var robot = new Robot(instructions);

var cleaningResult = robot.Clean();

Console.WriteLine($"=> Cleaned: {cleaningResult}");