namespace solution.src.model;

public class CaseSet
{
    private List<Unit> _cases = new ();

    public List<Unit> GetCases()
    {
        return _cases;
    }

    public void SetCases(List<Unit> cases)
    {
        _cases = cases;
    }

    public CaseSet()
    {
        InitializeUnit(0, DefaultValue.DefaultCharSize, new Unit());
    }

    private CaseSet(List<Unit> cases)
    {
        _cases = cases;
    }

    public CaseSet Filter(Func<Unit, bool> filter)
    {
        var filteredCases = _cases.Where(filter).ToList();
        return new CaseSet(filteredCases);
    }

    public int Count()
    {
        return _cases.Count;
    }

    private void InitializeUnit(int i, int n, Unit unit) {

        if (i == n) {
            _cases.Add(new Unit(unit));
            return;
        }
        
        var charList = DefaultValue.DefaultCharList.Where(c => !unit.Contains(c));
        foreach (var c in charList)
        {
            unit.Add(c);
            InitializeUnit(i + 1, n, unit);
            unit.RemoveAt(unit.Count - 1);
        }
    }
    
}