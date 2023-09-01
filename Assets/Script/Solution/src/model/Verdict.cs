using System.Linq;

namespace solution.src.model
{
    public class Verdict
    {
        public readonly int Strike;
        public readonly int Ball;
        
        public Verdict(int strike, int ball)
        {
            Strike = strike;
            Ball = ball;
        }

        public Verdict(Unit request, Unit target)
        {
            var match = request.Intersect(target).Count();
            var perfectMatch = request.Where((r, i) => r == target[i]).Count();

            Strike = perfectMatch;
            Ball = match - perfectMatch;
        }
        
        public static bool operator == (Verdict a, Verdict b)
        {
            return (a.Strike == b.Strike && a.Ball == b.Ball);
        }

        public static bool operator != (Verdict a, Verdict b)
        {
            return !(a.Strike == b.Strike && a.Ball == b.Ball);
        }
        
        public bool Equals(Verdict obj)
        {
            return (Strike == obj.Strike && Ball == obj.Ball);
        }
        
        public new int GetHashCode()
        {
            return (Strike * 4 + Ball).GetHashCode();
        }
    }

    public class VerdictWithCount
    {
        public Verdict Verdict;
        public int Count;

        public VerdictWithCount(Verdict Verdict, int Count)
        {
            this.Verdict = Verdict;
            this.Count = Count;
        }
    }

    //public record VerdictWithCount(Verdict Verdict, int Count);
}