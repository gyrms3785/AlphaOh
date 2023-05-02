namespace solution.client;

public class GameDummy : IGameUseCase
{
    public void NewGame(string mode, string difficulty)
    {
    }

    public string HandleComputerRequestTurn()
    {
        return "1234";
    }

    public void HandleComputerResponseTurn(string response)
    {
    }

    public void HandleHumanRequestTurn(string request)
    {
    }

    public string HandleHumanResponseTurn()
    {
        return "1S1B";
    }
}