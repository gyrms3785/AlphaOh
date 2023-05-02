namespace solution.src.game;

using mode;
using model;
using difficulty;
using exception;



public class Game
{
    private IModeState _gameModeState;
    private Turn _turn;

    private IAttackLevelState _attackLevelState;
    private IDefenceLevelState _defenceLevelState;
    
    private readonly Player _computer = new ();
    private readonly Player _client = new ();
    
    public Game() {}
    
    public Game(GameMode gameMode, Difficulty difficulty)
    {
        InitializeGameMode(gameMode);
        InitializeDifficulty(difficulty);
    }
    
    private void InitializeDifficulty(Difficulty difficulty)
    {
        switch (difficulty)
        {
            case Difficulty.Easy:
                _attackLevelState = new difficulty.attack.EasyState(_client.GetCaseSet());
                _defenceLevelState = new difficulty.defence.EasyState(_computer.GetCaseSet());
                return;
            case Difficulty.Medium:
                throw new Exception("not yet");
            case Difficulty.Hard:
                _attackLevelState = new difficulty.attack.HardState(_client.GetCaseSet());
                _defenceLevelState = new difficulty.defence.HardState(_computer.GetCaseSet());
                return;
            default:
                throw new Exception("invalid difficulty");
        }
    }

    private void InitializeGameMode(GameMode gameMode)
    {
        switch (gameMode)
        {
            case GameMode.Battle:
                _gameModeState = new BattleMode(this);
                return;
            case GameMode.Challenge:
                _gameModeState = new ChallengeMode(this);
                return;
            default:
                throw new Exception("invalid game mode");
        }
    }

    public Turn GetTurn()
    {
        return _turn;
    }

    public void SetTurn(Turn turn)
    {
        _turn = turn;
    }

    public void ClientRequest(Unit request)
    {
        if (_turn != Turn.ClientRequest)
        {
            throw new TurnErrorException();
        }
        _computer.InsertRequestLog(request);
    }

    public void ClientResponse(Verdict response)
    {
        _client.InsertResponseLog(response);
        var request = _client.GetLastInsertedAttack();
        _attackLevelState.HandleResponse(request, response);
    }

    public Unit ComputerRequest()
    {
        var request = _attackLevelState.GetRequest();
        _client.InsertRequestLog(request);
        return request;
    }

    public Verdict ComputerResponse()
    {
        var request = _computer.GetLastInsertedAttack();
        var response = _defenceLevelState.GetResponse(request);
        _computer.InsertResponseLog(response);
        return response;
    }
}