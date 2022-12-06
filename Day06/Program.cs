var input = await UsefulMethods.InputCreator.GetPuzzleInput(6);
var firstMarkerDistinctionLen = 4;
var secondMarkerDistinctionLen = 14;

returnSearchMarkerPosition(input, firstMarkerDistinctionLen);
returnSearchMarkerPosition(input, secondMarkerDistinctionLen);

void returnSearchMarkerPosition(string input, int markerDistinctionLen)
{
    var skip = 0;
    while (skip + markerDistinctionLen < input.Length)
    {
        var signals = new string(input.Skip(skip).Take(markerDistinctionLen).ToArray());
        if (isStringDistinct(signals))
        {
            var answer = markerDistinctionLen + skip;
            Console.WriteLine("Answer: " + answer);
            break;
        }

        skip++;
    }
}

bool isStringDistinct(string signal)
{
    if(signal == null)
    {
        return false;
    }
    var searchedForRepetitionSignal = signal.Distinct().ToList() ?? default;
    return (signal.Length == searchedForRepetitionSignal?.Count);
}