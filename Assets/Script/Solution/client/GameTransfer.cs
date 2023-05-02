using System.Text.RegularExpressions;

using solution.src.difficulty;
using solution.src.model;
using solution.src.mode;


namespace solution.client;



internal static class GameTransfer
{
    internal static string UnitToString(Unit unit)
    {
        return unit.Aggregate("", (current, ch) => current + ch);
    }

    internal static string VerdictToString(Verdict verdict)
    {
        return $"{verdict.Strike}S{verdict.Ball}B";
    }

    internal static Unit StringToUnit(string str)
    {
        if (!Regex.IsMatch(str, "^[0-9]{4}$"))
        {
            throw new Exception("invalid unit format");
        }
        return new Unit(str.ToCharArray());
    }

    internal static Verdict StringToVerdict(string str)
    {
        if (!Regex.IsMatch(str, "^0S[0-4]B$|^1S[0-3]B$|^2S[0-2]B$|^3S0B$^4S0B$"))
        {
            throw new Exception("invalid input");
        }

        var strike = str[0] - '0';
        var ball = str[0] - '0';

        return new Verdict(strike, ball);
    }
    
    internal static Difficulty DifficultyToEnum(string difficulty)
    {
        return difficulty switch
        {
            "EASY"   => Difficulty.Easy,
            "MEDIUM" => Difficulty.Medium,
            "HARD"   => Difficulty.Hard,
            _ => throw new Exception("invalid difficulty")
        };
    }
    
    internal static GameMode GameModeToEnum(string gameMode)
    {
        return gameMode switch
        {
            "BATTLE"    => GameMode.Battle,
            "CHALLENGE" => GameMode.Challenge,
            _ => throw new Exception("invalid GameMode")
        };
    }
}