using System.Diagnostics;
using solution.client;
using solution.src.model;

namespace solution.test.modelTest;

public static class VerdictTest
{

    public static void TestVerdictValid()
    {
        Verdict verdict = new(new Unit("1234"), new Unit("4321"));
    }
    
    public static void TestVerdictByUnit()
    {
        var testCases = 4;

        var input = new []
        {
            new Tuple<Unit, Unit>(new Unit("1234"), new Unit("1234")),
            new Tuple<Unit, Unit>(new Unit("1234"), new Unit("4321")),
            new Tuple<Unit, Unit>(new Unit("1234"), new Unit("1456")),
            new Tuple<Unit, Unit>(new Unit("1234"), new Unit("5678")),
        };

        var output = new[]
        {
            new Verdict(4, 0),
            new Verdict(0, 4),
            new Verdict(1, 1),
            new Verdict(0, 0),
        };
        
        for (var i = 0; i < testCases; i++)
        {
            var expect = output[i];
            var result = new Verdict(input[i].Item1, input[i].Item2);
            Tester.Assert(GameTransfer.VerdictToString(expect), GameTransfer.VerdictToString(result));
        }
    }
    
}