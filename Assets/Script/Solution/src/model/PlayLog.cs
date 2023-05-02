namespace solution.src.model;

public struct PlayLog
{
    private Unit _request;
    private Verdict _response;

    public Unit GetRequest()
    {
        return _request;
    }

    public PlayLog SetRequest(Unit request)
    {
        _request = request;
        return this;
    }

    public Verdict GetResponse()
    {
        return _response;
    }

    public PlayLog SetResponse(Verdict response)
    {
        _response = response;
        return this;
    }
}