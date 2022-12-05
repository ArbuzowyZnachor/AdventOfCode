var input = await UsefulMethods.InputCreator.GetPuzzleInput(5);

var crates = new Dictionary<int, List<char>>();
crates.Add(1, new List<char>() { 'J', 'H', 'P', 'M', 'S', 'F', 'N', 'V' });
crates.Add(2, new List<char>() { 'S', 'R', 'L', 'M', 'J', 'D', 'Q' });
crates.Add(3, new List<char>() { 'N', 'Q', 'D', 'H', 'C', 'S', 'W', 'B' });
crates.Add(4, new List<char>() { 'R', 'S', 'C', 'L' });
crates.Add(5, new List<char>() { 'M', 'V', 'T', 'P', 'F', 'B' });
crates.Add(6, new List<char>() { 'T', 'R', 'Q', 'N', 'C' });
crates.Add(7, new List<char>() { 'G', 'V', 'R' });
crates.Add(8, new List<char>() { 'C', 'Z', 'S', 'P', 'D', 'L', 'R' });
crates.Add(9, new List<char>() { 'D', 'S', 'J', 'V', 'G', 'P', 'B', 'F' });

Console.WriteLine($"First answer: {new string(SortCrates(crates, input, true))}");
Console.WriteLine($"Second answer: {new string(SortCrates(crates, input, false))}");

(int, int, int) ChangeLineIntoCommand(string line)
{
    line = line.Replace("move ", "").Replace(" from ", ",").Replace(" to ", ",");
    var parameters = line.Split(",").ToList().ConvertAll(param => int.Parse(param)); ;

    return (parameters[0], parameters[1], parameters[2]);
}

char[] SortCrates(Dictionary<int, List<char>> stacks, string input, bool reverseCratesWhileMoving)
{
    var crateStacks = stacks.ToDictionary(entry => entry.Key, entry => new List<char>(entry.Value));
    foreach (var line in UsefulMethods.InputCreator.GetLines(input).Where(line => line.StartsWith('m')))
    {
        var command = ChangeLineIntoCommand(line);
        var onCrene = crateStacks[command.Item2].TakeLast(command.Item1);
        var reversed = new List<char>(onCrene.ToList());
        if (reverseCratesWhileMoving)
        {
            reversed.Reverse();
        }

        crateStacks[command.Item3].AddRange(reversed);
        crateStacks[command.Item2].RemoveRange(crateStacks[command.Item2].Count - command.Item1, command.Item1);
    }

    return crateStacks.Select(heap => heap.Value.Last()).ToArray();
}