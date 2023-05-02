using solution.src.game;
using solution.src.model;

namespace solution.src.difficulty.attack;

public class HardState : IAttackLevelState
{
    private readonly CaseSet _caseSet;

    public HardState(CaseSet caseSet)
    {
        _caseSet = caseSet;
    }
    
    public Unit GetRequest()
    {
        return _caseSet.GetCases()
            .Select(cases => new UnitWithCount(cases, DefaultValue.VerdictCandidate
                .Select(verdictCandidate => new VerdictWithCount(verdictCandidate, _caseSet
                    .Filter((unit) => new Verdict(cases, unit) == verdictCandidate)
                    .Count()))
                .Aggregate((a, b) => a.Count > b.Count ? a : b).Count))
            .Aggregate((a, b) => a.Count < b.Count ? a : b).Unit;
    }

    public void HandleResponse(Unit request, Verdict response)
    {
        var newCases = _caseSet.Filter(unit => new Verdict(request, unit) == response);
        _caseSet.SetCases(newCases.GetCases());
    }
}