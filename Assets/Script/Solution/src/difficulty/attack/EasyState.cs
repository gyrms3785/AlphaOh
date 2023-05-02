namespace solution.src.difficulty.attack;


using game;
using model;


public class EasyState : IAttackLevelState
{
    private readonly CaseSet _caseSet;

    public EasyState(CaseSet caseSet)
    {
        _caseSet = caseSet;
    }
    
    public Unit GetRequest()
    {
        var rand = new Random();
        var idx = rand.Next(0, _caseSet.Count());
        var request = _caseSet.GetCases()[idx];
        return request;
    }

    public void HandleResponse(Unit request, Verdict response)
    {
        var newCases = _caseSet.Filter(unit => new Verdict(request, unit) == response);
        _caseSet.SetCases(newCases.GetCases());
    }
}