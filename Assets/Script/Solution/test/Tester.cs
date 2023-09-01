using System.Security.Cryptography;
using System;

using solution.test.modelTest;

namespace solution.test
{
    public static class Tester
    {
        public static void Test()
        {
            UnitTest.TestUnitValid();

            VerdictTest.TestVerdictValid();
            VerdictTest.TestVerdictByUnit();

            CaseSetTest.TestInit();
            CaseSetTest.TestFilter();
        }

        public static void Assert<T>(T expect, T result)
        {
            if (expect == null)
            {
                throw new NullReferenceException("");
            }

            if (result == null)
            {
                throw new NullReferenceException("");
            }

            if (!expect.Equals(result))
            {
                Console.WriteLine("expected: {0}, resulted: {1}", expect, result);
                throw new Exception("expected value and resulted value are different");
            }
        }
    }
}