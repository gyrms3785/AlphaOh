using solution.src.model;

namespace solution.src.game
{
    public interface IDefenceLevelState
    {
        public Verdict GetResponse(Unit request);
    }
}