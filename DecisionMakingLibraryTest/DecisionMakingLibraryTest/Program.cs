using DecisionMakingLibrary;
using Range = DecisionMakingLibrary.Range;

Notion notion1 = new Notion("notion1");
Range range = new ContinuousRange("Range", notion1, -10, 10);
List<string> list = new List<string> { "Hi", "Hello", "By" };
Set<string> testSet = new Set<string>(notion1, list);
FunctionalRange<string, int, string> funcRange = new FunctionalRange<string, int, string>(range, testSet, function);
string function(int input)
{
    return (input * input).ToString() + "!@#";
}
Console.WriteLine(funcRange.GetFunctionResult(3));  