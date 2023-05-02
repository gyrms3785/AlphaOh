namespace solution.src.game;

using solution.src.model;


public class Player
{
    private readonly List<PlayLog> _playLogs = new();

    private CaseSet _caseSet = new ();

    public CaseSet GetCaseSet()
    {
        return _caseSet;
    }

    public void SetCaseSet(CaseSet caseSet)
    {
        _caseSet = caseSet;
    }

    public void InsertRequestLog(Unit request)
    {
        _playLogs.Add(new PlayLog().SetRequest(request));
    }

    public void InsertResponseLog(Verdict response)
    {
        _playLogs[^1].SetResponse(response);
    }

    public Unit GetLastInsertedAttack()
    {
        return _playLogs[^1].GetRequest();
    }
}