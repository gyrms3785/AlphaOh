using solution.src.model;

namespace solution.test.modelTest;

public static class CaseSetTest
{

    public static void TestInit()
    {
        CaseSet caseSet = new();
        
        Tester.Assert<int>(5040, caseSet.Count());
        caseSet.GetCases().ForEach(unit => Tester.Assert<int>(4, unit.Count));
    }

    public static void TestFilter()
    {
        CaseSet caseSet = new();

        var request = new Unit("1234");
        var response = new Verdict(1, 0);
        var filteredCaseSet = caseSet.Filter(unit => new Verdict(request, unit) == response);
        
        Tester.Assert(480, filteredCaseSet.Count());
    }
}