using solution.src.game;

namespace solution.client
{
    public class GameAdapter : IGameUseCase
    {
        private Game _game = new ();

        public void NewGame(string mode, string diff)
        {
            var gameMode = GameTransfer.GameModeToEnum(mode);
            var difficulty = GameTransfer.DifficultyToEnum(diff);

            _game = new Game(gameMode, difficulty);
        }

        public string HandleComputerRequestTurn() //프로그램이 나에게 숫자 물어보기
        {
            var response = _game.ComputerRequest();
            return GameTransfer.UnitToString(response);
        }

        public void HandleComputerResponseTurn(string request) //내가 스볼 알려주면 프로그램에 저장
        {
            var verdict = GameTransfer.StringToVerdict(request);
            _game.ClientResponse(verdict);
        }

        public void HandleHumanRequestTurn(string request) //내가 숫자 물어보면 프로그램에 저장 후에
        {
            var unit = GameTransfer.StringToUnit(request);
            _game.ClientRequest(unit);
        }

        public string HandleHumanResponseTurn() //스볼 값 알려주기
        {
            var verdict = _game.ComputerResponse();
            return GameTransfer.VerdictToString(verdict);
        }
    }
}