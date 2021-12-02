void Main()
{
	var puzzle1inputs = GetInput();
	var puzzleList = puzzle1inputs.Split(Environment.NewLine).Select(x => Int32.Parse(x)).ToList();

	var incrementCounts = 0;
	for (var index = 1; index < puzzleList.Count(); index++)
	{
		if (puzzleList[index - 1] < puzzleList[index])
			incrementCounts++;
	}
	incrementCounts.Dump();
}

public string GetInput()
{
	return File.ReadAllText(@"C:\adventofcode\day1\input");
}
