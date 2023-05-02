namespace solution.src.mode;

using game;

public class ChallengeMode : IModeState
{
    private Game _game;

    public ChallengeMode(Game game)
    {
        _game = game;
        _game.SetTurn(Turn.ClientRequest);
    }

    public void Next()
    {
        switch (_game.GetTurn())
        {
            case (Turn.ClientRequest):
                _game.SetTurn(Turn.ComputerResponse);
                return;
            case (Turn.ComputerResponse):
                _game.SetTurn(Turn.ClientRequest);
                return;
            default:
                throw new Exception("invalid turn");
        }
    }
}