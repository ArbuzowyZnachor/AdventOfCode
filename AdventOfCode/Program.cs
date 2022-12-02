var input = await UsefulMethods.InputCreator.GetPuzzleInput(1);
var elfs = new List<int>();
int sum = 0;
foreach(var line in input.Split('\n', 10000).Where(line => line != null))
{
    if(line.Length > 0)
    {
        sum += Int32.Parse(line.Trim());
    }
    else
    {
        elfs.Add(sum);
        sum = 0;
    }
}

var sortedElfs = elfs.OrderByDescending(food => food);
Console.WriteLine("First answer: " + sortedElfs.First());
Console.WriteLine("Second anser: " + sortedElfs.Take(3).Sum());