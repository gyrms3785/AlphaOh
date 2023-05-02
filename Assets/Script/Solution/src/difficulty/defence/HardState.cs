namespace solution.src.difficulty.defence;

using game;
using model;

public class HardState : IDefenceLevelState
{
    private readonly CaseSet _caseSet;
    
    public HardState(CaseSet caseSet)
    {
        _caseSet = caseSet;
    }

    public Verdict GetResponse(Unit request)
    {
        var response = DefaultValue.VerdictCandidate
            .Select(verdictCandidate => new VerdictWithCount(verdictCandidate, _caseSet
                .Filter((unit) => new Verdict(request, unit) == verdictCandidate)
                .Count()))
            .Aggregate((a, b) => a.Count > b.Count ? a : b).Verdict;

        var newCaseSet = _caseSet.Filter(unit => new Verdict(request, unit) == response);
        _caseSet.SetCases(newCaseSet.GetCases());

        return response;
    }
}