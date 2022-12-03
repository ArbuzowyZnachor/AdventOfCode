using System;
const int groupSize = 3;

var input = await UsefulMethods.InputCreator.GetPuzzleInput(3);
var sumOfDoubledItemsValues = 0;
var sumOfBagdeItemsValues = 0;
var rucksucks = UsefulMethods.InputCreator.GetLines(input);
foreach(var rucksuck in rucksucks)
{
    var firstCompartment = rucksuck.Take(rucksuck.Length / 2);
    var secondCompartment = rucksuck.Skip(firstCompartment.Count()).Take(rucksuck.Length / 2);
    var doubledItems = firstCompartment.Intersect(secondCompartment);
    foreach(var item in doubledItems)
    {
        sumOfDoubledItemsValues += ValueOfItem(item);
    }
}

Console.WriteLine("First answer: " + sumOfDoubledItemsValues);

var searchedRucksacks = 0;
var rucksucksToSearch = rucksucks.ToList();
while (rucksucksToSearch.Count > searchedRucksacks)
{
    var group = rucksucksToSearch.Skip(searchedRucksacks).Take(groupSize).ToList();
    var badge = group[0].Intersect(group[1].Intersect(group[2]));
    sumOfBagdeItemsValues += ValueOfItem(badge.FirstOrDefault());
    searchedRucksacks += groupSize;
}

Console.WriteLine("Second answer: " + sumOfBagdeItemsValues);

int ValueOfItem(char item)
{
    return Char.IsUpper(item) ? item - 38 : item - 96;
}