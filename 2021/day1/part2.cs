void Main()
{
	var puzzle1inputs = GetInput();
	var puzzleList = puzzle1inputs.Split(Environment.NewLine).Select(x => Int32.Parse(x)).ToList();

	var puzzleListTripletts = puzzleList.Select((item, index) => { 
		var triplet = puzzleList.Skip(index).Take(3); 
		if(triplet.Count() == 3)
			return triplet.Sum();
		return 0;
	}).ToList();

	var incrementCounts = 0;
	for (var index = 1; index < puzzleListTripletts.Count(); index++)
	{
		if (puzzleListTripletts[index - 1] < puzzleListTripletts[index])
			incrementCounts++;
	}
	incrementCounts.Dump();
}

public string GetInput()
{
	return File.ReadAllText(@"C:\adventofcode\day1\input");
}
