using solution.src.model;

namespace solution.src.game;

public interface IAttackLevelState
{
    public Unit GetRequest();
    public void HandleResponse(Unit request, Verdict response);
}