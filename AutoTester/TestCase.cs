namespace AutoTester;

public class TestCase
{
    public bool Use { get; set; }
    public bool IsNegative { get; set; }
    public string ArgumentLine { get; set; }
    public int TestNumber { get; set; }
    public bool IsPassed { get; set; }
    public string? Result { get; set; }
    public string? Expected { get; set;}
    public string? Diff { get; set; } = null;
    public string Eps { get; set; }
    public string TestHeader { get { return $"TEST {TestNumber} {(IsNegative ? "N" : "P")}\n{ArgumentLine}\n{Eps}\n{Expected}"; } }
    public override string ToString()
    {
        string isNeg = IsNegative ? "N" : "P";
        string isPas = IsPassed ? "PASSED" : "NOT PASSED";
        return $"TEST {TestNumber} {isNeg}\n{ArgumentLine}\n{Eps}\n{Expected}\n{Result}{(Diff is null ? "\n" : $"\n{Diff}\n")}{isPas}\n\n";
    }
}
