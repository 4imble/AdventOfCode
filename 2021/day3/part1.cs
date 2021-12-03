void Main()
{
	var input = GetInput();

	var lines = input.Split(Environment.NewLine).ToList();
	var mdArray = lines.Select(line => line.ToCharArray()).ToList();

	var binaryResult = "";
	for (var x = 0; x < 12; x++)
	{
		var bits = mdArray.Select(a => a[x]);
		var zeroCount = bits.Count(a => a == '0');
		var oneCount = bits.Count(a => a == '1');
		binaryResult+= zeroCount > oneCount ? '0':'1';
	}
	var gamma = Convert.ToInt32(binaryResult, 2);
	var epilon = 4095 - gamma; // 4095 == 111111111111

	var result = gamma * epilon;
	result.Dump();
}

public string GetInput()
{
	return File.ReadAllText(@"C:\adventofcode\day3\input");
}
