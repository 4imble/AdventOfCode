void Main()
{
	var input = GetInput();

	var lines = input.Split(Environment.NewLine).ToList();
	var mdArray = lines.Select(line => line.ToCharArray()).ToList();

	var oxygenBinary = GetFilteredItems(mdArray, Rating.Oxygen);
	var c02Binary = GetFilteredItems(mdArray, Rating.C02);

	var oxygen = Convert.ToInt32(oxygenBinary, 2);
	var c02 = Convert.ToInt32(c02Binary, 2);

	(oxygen*c02).Dump();
}

public string GetFilteredItems(List<char[]> mdArray, Rating rating)
{
	var temp = mdArray;
	for (var x = 0; x < 12; x++)
	{
		var bits = temp.Select(a => a[x]);
		var zeroCount = bits.Count(a => a == '0');
		var oneCount = bits.Count(a => a == '1');
		var magorityBit = (oneCount >= zeroCount ? '1' : '0');
		var minorityBit = (zeroCount <= oneCount ? '0' : '1');
		var filterBy = rating == Rating.Oxygen ? magorityBit : minorityBit;

		temp = temp.Where(a => a[x] == filterBy).ToList();

		if (temp.Count() == 1)
		{
			return new string(temp.Single());
		}
	}

	throw new Exception("ERROR");
}

public enum Rating
{
	Oxygen,
	C02
}

public string GetInput()
{
	return File.ReadAllText(@"C:\adventofcode\day3\input");
}
