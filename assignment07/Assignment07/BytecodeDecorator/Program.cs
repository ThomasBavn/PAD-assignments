public static class Program
{
    private static readonly IReadOnlyDictionary<int, string> _lookupTable = new Dictionary<int, string>()
    {
        { 0, "CSTI" },
        { 1, "ADD" },
        { 2, "SUB" },
        { 3, "MUL" },
        { 4, "DIV" },
        { 5, "MOD" },
        { 6, "EQ" },
        { 7, "LT" },
        { 8, "NOT" },
        { 9, "DUP" },
        { 10, "SWAP" },
        { 11, "LDI" },
        { 12, "STI" },
        { 13, "GETBP" },
        { 14, "GETSP" },
        { 15, "INCSP" },
        { 16, "GOTO" },
        { 17, "IFZERO" },
        { 18, "IFNZRO" },
        { 19, "CALL" },
        { 20, "TCALL" },
        { 21, "RET" },
        { 22, "PRINTI" },
        { 23, "PRINTC" },
        { 24, "LDARGS" },
        { 25, "STOP" }
    };

    public static void Main(string[] args)
    {
        //var fileName = args[0];
        var fileName = "ex13.out";
        var line = File.ReadAllText(fileName);
        var numbers = line.Split(' ').Select(int.Parse).ToList();
        var enumerator = numbers.GetEnumerator();
        var output = DecodeInstruction(enumerator, new List<string>(),0);
        File.WriteAllText(Path.GetFileNameWithoutExtension(fileName) + ".decoded", output);
    }

    private static string DecodeInstruction(IEnumerator<int> numbers, List<string> instructions,int instructionIndex)
    {
        if (!numbers.MoveNext())
        {
            return string.Join(Environment.NewLine, instructions);
        }

        var instruction = ($"[{instructionIndex}] "+numbers.Current + ": ").PadLeft(4);

        instruction += numbers.Current switch
        {
            0 => "CSTI",
            1 => "ADD",
            2 => "SUB",
            3 => "MUL",
            4 => "DIV",
            5 => "MOD",
            6 => "EQ",
            7 => "LT",
            8 => "NOT",
            9 => "DUP",
            10 => "SWAP",
            11 => "LDI",
            12 => "STI",
            13 => "GETBP",
            14 => "GETSP",
            15 => "INCSP",
            16 => "GOTO",
            17 => "IFZERO",
            18 => "IFNZRO",
            19 => "CALL",
            20 => "TCALL",
            21 => "RET",
            22 => "PRINTI",
            23 => "PRINTC",
            24 => "LDARGS",
            25 => "STOP"
        };

        switch (numbers.Current)
        {
            case 0:
            case 15:
            case 16:
            case 17:
            case 18:
            case 21:
                numbers.MoveNext();
                instruction += $" {numbers.Current}";
                instructionIndex++;

                break;
            case 19:
                numbers.MoveNext();
                instruction += $" {numbers.Current}";
                numbers.MoveNext();
                instruction += $" {numbers.Current}";
                instructionIndex += 2;

                break;
            case 20:
                numbers.MoveNext();
                instruction += $" {numbers.Current}";
                numbers.MoveNext();
                instruction += $" {numbers.Current}";
                numbers.MoveNext();
                instruction += $" {numbers.Current}";
                
                instructionIndex += 3;

                break;
        }

        instructions.Add(instruction);

        return DecodeInstruction(numbers, instructions,instructionIndex+1);
    }
}
