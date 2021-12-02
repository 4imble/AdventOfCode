void Main()
{
	var input = GetInput();
	var inputLineList = input.Split(Environment.NewLine);
	var instructions = inputLineList.Select(line => InstructionFactory.Build(line)).ToList();

	var submarine = new Submarine();
	foreach (var instruction in instructions)
	{
		instruction.Invoke(submarine);
	}

	submarine.xPos.Dump("Forward");
	submarine.zPos.Dump("Depth");

	(submarine.xPos * submarine.zPos).Dump("Result");
}

public static class InstructionFactory
{
	public static Instruction Build(string line)
	{
		var lineSplit = line.Split(' ');
		var classString = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(lineSplit[0]);
		var value = Int32.Parse(lineSplit[1]);

		var instructionType = typeof(Instruction).Assembly.GetTypes().Single(t => t.Name.StartsWith(classString));
		var instruction = Activator.CreateInstance(instructionType, value) as Instruction;

		return instruction;
	}
}

public class Submarine
{
	public int xPos { get; set; } = 0;
	public int zPos { get; set; } = 0;

	public int aim { get; set; } = 0;
}

public class ForwardInstruction : Instruction
{
	public ForwardInstruction(int value) : base(value) { }

	public override void Invoke(Submarine sub)
	{
		sub.xPos += this.Value;
		sub.zPos += (sub.aim * this.Value);
	}
}

public class DownInstruction : Instruction
{
	public DownInstruction(int value) : base(value) { }

	public override void Invoke(Submarine sub)
	{
		sub.aim += this.Value;
	}
}

public class UpInstruction : Instruction
{
	public UpInstruction(int value) : base(value) { }

	public override void Invoke(Submarine sub)
	{
		sub.aim -= this.Value;
	}
}

public abstract class Instruction
{
	public Instruction(int value)
	{
		this.Value = value;
	}

	public int Value { get; set; }
	public abstract void Invoke(Submarine sub);
}

public string GetInput()
{
	return File.ReadAllText(@"C:\adventofcode\day2\input");
}
