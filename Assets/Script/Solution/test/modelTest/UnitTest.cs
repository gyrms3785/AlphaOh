using System.Diagnostics;
using solution.src.model;

namespace solution.test.modelTest;

public static class UnitTest
{
    public static void TestUnitValid()
    {
        var unit = new Unit("1234");
        Tester.Assert(4, unit.Count);
    }
}