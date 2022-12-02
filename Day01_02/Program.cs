var inputCreator = new UsefulMethods.InputCreator();
var input = await inputCreator.GetPuzzleInput(2);
var elfs = new List<int>();
int sum = 0;

foreach (var line in input.Split('\n', 10000).Where(line => line != null))
{
    if (line.Length > 0)
    {
        sum += Int32.Parse(line.Trim());
    }
    else
    {
        elfs.Add(sum);
        sum = 0;
    }
}

elfs.Sort();
Console.WriteLine(elfs.Take(3).Sum());