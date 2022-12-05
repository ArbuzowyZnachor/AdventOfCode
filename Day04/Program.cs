var input = await UsefulMethods.InputCreator.GetPuzzleInput(4);
var rangeFullyContained = 0;
var overlapedPairs = 0;

foreach(var line in UsefulMethods.InputCreator.GetLines(input))
{
    var elfsPairSection = line.Split(',').ToList();
    var elfs = elfsPairSection.ConvertAll(eps => eps.Split('-').ToList()).ToList();
    var firstElfSections = new List<int>();
    var secondElfSections = new List<int>();

    for(int i = int.Parse(elfs[0][0]); i <= int.Parse(elfs[0][1]); i++)
    {
        firstElfSections.Add(i);
    }

    for (int i = int.Parse(elfs[1][0]); i <= int.Parse(elfs[1][1]); i++)
    {
        secondElfSections.Add(i);
    }

    var overlap = firstElfSections.Intersect(secondElfSections);
    if (overlap.Any())
    {
        overlapedPairs++;
    }

    if (overlap.Count() >= Math.Min(firstElfSections.Count(), secondElfSections.Count()))
    {
        rangeFullyContained++;
    }
}

Console.WriteLine("First answer: "+ rangeFullyContained);
Console.WriteLine("Second answer: "+ overlapedPairs);