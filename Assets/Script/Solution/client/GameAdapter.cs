namespace solution.client;

using src.game;

public class GameAdapter : IGameUseCase
{
    private Game _game = new ();

    public void NewGame(string mode, string diff)
    {
        var gameMode = GameTransfer.GameModeToEnum(mode);
        var difficulty = GameTransfer.DifficultyToEnum(diff);

        _game = new Game(gameMode, difficulty);
    }

    public string HandleComputerRequestTurn()
    {
        var response = _game.ComputerRequest();
        return GameTransfer.UnitToString(response);
    }

    public void HandleComputerResponseTurn(string request)
    {
        var verdict = GameTransfer.StringToVerdict(request);
        _game.ClientResponse(verdict);
    }

    public void HandleHumanRequestTurn(string request)
    {
        var unit = GameTransfer.StringToUnit(request);
        _game.ClientRequest(unit);
    }

    public string HandleHumanResponseTurn()
    {
        var verdict = _game.ComputerResponse();
        return GameTransfer.VerdictToString(verdict);
    }
}