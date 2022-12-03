var input = await UsefulMethods.InputCreator.GetPuzzleInput(1);
var elfs = new List<int>();
int sum = 0;
foreach(var line in UsefulMethods.InputCreator.GetLines(input, false))
{
    if(line.Length > 0)
    {
        sum += int.Parse(line.Trim());
    }
    else
    {
        elfs.Add(sum);
        sum = 0;
    }
}

var sortedElfs = elfs.OrderByDescending(food => food);
Console.WriteLine("First answer: " + sortedElfs.FirstOrDefault());
Console.WriteLine("Second anser: " + sortedElfs.Take(3).Sum());