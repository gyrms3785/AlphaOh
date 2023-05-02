namespace solution.src.difficulty.defence;

using game;
using model;

public class EasyState : IDefenceLevelState
{
    private readonly CaseSet _caseSet;
    
    public EasyState(CaseSet caseSet)
    {
        _caseSet = caseSet;
    }

    public Verdict GetResponse(Unit request)
    {
        var idx = new Random().Next(0, _caseSet.Count());
        var target = _caseSet.GetCases()[idx];
        var response = new Verdict(request, target);

        var newCaseSet = _caseSet.Filter(unit => new Verdict(request, unit) == response);
        newCaseSet.SetCases(newCaseSet.GetCases());
        
        return response;
    }
}