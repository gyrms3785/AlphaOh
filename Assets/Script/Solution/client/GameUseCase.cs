namespace solution.client;

public interface IGameUseCase
{
    void NewGame(string mode, string difficulty);

    string HandleComputerRequestTurn();

    void HandleComputerResponseTurn(string response);

    void HandleHumanRequestTurn(string request);

    string HandleHumanResponseTurn();
}