using System.Collections.Generic;

namespace TestNinja.Fundamentals
{
    public class Math
    {
        public int Add(int a, int b)
        { 
            return a + b; //only a single path
        }
        
        public int Max(int a, int b)
        {
            return (a > b) ? a : b; //two execution paths
        }

        public IEnumerable<int> GetOddNumbers(int limit)
        {
            for (var i = 0; i <= limit; i++)
                if (i % 2 != 0)
                    yield return i; 
        }
    }
}