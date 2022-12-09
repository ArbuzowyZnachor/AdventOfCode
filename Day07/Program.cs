var input = await UsefulMethods.InputCreator.GetPuzzleInput(7);
var folderWeight = 0;
var folderName = string.Empty;
var foldersStack = new Stack<Folder>();
var system = new List<Folder>();

foreach (var line in UsefulMethods.InputCreator.GetLines(input))
{
    if (line.StartsWith("$ ls") || line.StartsWith("dir "))
    {
        continue;
    }
    else if (line.StartsWith("$ cd .."))
    {
        system.Add(foldersStack.Pop());
    }
    else if (line.StartsWith("$ cd "))
    {
        folderWeight = default;
        folderName = new string(line.Skip(5).ToArray());
        foldersStack.Push(new Folder(folderName, folderWeight, foldersStack?.Any() == true ?
            foldersStack.Peek() : default));
    }
    else{
        if (int.TryParse(line.Split(" ").First(), out var weight))
        {
            if(foldersStack?.Count > 0)
            {
                foldersStack.Peek().Weight += weight;
            }
        }
    }
}

system.AddRange(foldersStack.ToList());

void GetLowerFoldersWeight(Folder start)
{
    var list = system?.Where(folder => folder.UpperFolder == start);
    if (list?.Any() == true)
    {
        foreach(var folder in list)
        {
            GetLowerFoldersWeight(folder);
            start.Weight += folder.Weight;
        }
    }
}

GetLowerFoldersWeight(system.Last());

const int maxSize = 100000;
const int totalDiscSpace = 70000000;
const int minimalDiscSpace = 30000000;
int leftSpace = totalDiscSpace - system.Max(folder => folder.Weight);

Console.WriteLine("First answer: " + system.Where(folder => folder.Weight <= maxSize).Sum(folder => folder.Weight));
Console.WriteLine("Second answer: " + system.Where( folder => leftSpace + folder.Weight >= minimalDiscSpace)
    .Min(folder => folder.Weight) ?? default);

class Folder
{
    public string Name { get; set; }
    public int Weight { get; set; }
    public Folder UpperFolder { get; set; }

    public Folder(string name, int weight, Folder upperFolder)
    {
        Name = name;
        Weight = weight;
        UpperFolder = upperFolder;
    }
};