var input = await UsefulMethods.InputCreator.GetPuzzleInput(2);
var firsRound = 0;
var secondRound = 0;

var rockResponse = new Dictionary<char, (int, int)>();
rockResponse.Add('X', (4, 3)); // draw + 1 / lose + 3
rockResponse.Add('Y', (8, 4)); // win + 2 / draw + 1
rockResponse.Add('Z', (3, 8)); // lose + 3 / win + 2

var paperResponse = new Dictionary<char, (int, int)>();
paperResponse.Add('X', (1, 1)); // lose + 1 / lose + 1
paperResponse.Add('Y', (5, 5)); // draw + 2 / draw + 2
paperResponse.Add('Z', (9, 9)); // win + 3 / win  + 3

var scissorsResponse = new Dictionary<char, (int,int)>();
scissorsResponse.Add('X', (7, 2)); // win + 1 / lose + 2
scissorsResponse.Add('Y', (2, 6)); // lose + 2 / draw + 3
scissorsResponse.Add('Z', (6, 7)); // draw + 3 / win + 1

var strategyOutput = new Dictionary<char, Dictionary<char, (int, int)>>();
strategyOutput.Add('A', rockResponse);
strategyOutput.Add('B', paperResponse);
strategyOutput.Add('C', scissorsResponse);

(int, int) checkOutcome(char elf, char you)
{
    if(strategyOutput?.TryGetValue(elf, out var strategy) == true)
    {
        if(strategy?.TryGetValue(you, out var outcome) == true)
        {
            return outcome;
        }
    }
    throw new Exception("Your strategey is somehow wrong");
}

foreach (var game in UsefulMethods.InputCreator.GetLines(input))
{
    var outcome = checkOutcome(game[0], game[2]);
    firsRound += outcome.Item1;
    secondRound += outcome.Item2;
}

Console.WriteLine("First answer:" + firsRound);
Console.WriteLine("Second answer:" + secondRound);