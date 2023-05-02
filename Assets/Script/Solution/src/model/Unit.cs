namespace solution.src.model;

public class Unit : List<char>
{
    public Unit(params char[] values) : base(values) {}
    
    public Unit(string str) : base(str.ToCharArray()) {}

    public Unit(Unit unit) : base(unit.ToArray()) {}
}

public record UnitWithCount(Unit Unit, int Count);