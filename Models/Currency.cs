namespace Avalonya_Praktika_Zadanue2.Models;

public class Currency
{
    public string Code { get; }
    public string Name { get; }
    public double Rate { get; }

    public Currency(string code, string name, double rate)
    {
        Code = code;
        Name = name;
        Rate = rate;
    }

    public override string ToString() => $"{Code} - {Name}";
}