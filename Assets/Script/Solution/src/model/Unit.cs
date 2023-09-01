using System.Collections.Generic;
using System.Collections;
using System;
using System.Linq;

namespace solution.src.model
{
    public class Unit : List<char>
    {
        public Unit(params char[] values) : base(values) {}
        
        public Unit(string str) : base(str.ToCharArray()) {}

        public Unit(Unit unit) : base(unit.ToArray()) {}
    }

    public class UnitWithCount
    {
        public Unit Unit;
        public int Count;

        public UnitWithCount(Unit Unit, int Count)
        {
            this.Unit = Unit;
            this.Count = Count;
        }
    }

    //public record UnitWithCount(Unit Unit, int Count);
}