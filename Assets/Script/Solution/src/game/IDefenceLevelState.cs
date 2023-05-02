namespace solution.src.game;

using model;


public interface IDefenceLevelState
{
    public Verdict GetResponse(Unit request);
}