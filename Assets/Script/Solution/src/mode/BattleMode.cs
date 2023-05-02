using solution.src.game;

namespace solution.src.mode;

public class BattleMode : IModeState
{
    private Game _game;

    public BattleMode(Game game)
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
                _game.SetTurn(Turn.ComputerRequest);
                return;
            case (Turn.ComputerRequest):
                _game.SetTurn(Turn.ClientResponse);
                return;
            case (Turn.ClientResponse):
                _game.SetTurn(Turn.ClientRequest);
                return;
            default:
                throw new Exception("invalid turn");
        }
    }
}