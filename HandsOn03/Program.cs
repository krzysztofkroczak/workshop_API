using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Workshop.DPtoCT.HandsOn03
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Assignment:
             * Add Last classes so that the commented-out code compiles.
             * Uncomment the Last-based result block, comment out the
             * First-based result block, and run the program.
             * 
             * The output should be:
             * 
             * Last<Int32>(1337)
             * 
             * */

            var resultFirst = First.Accumulate(new[] {
                new First<int>(),
                new First<int>(42),
                new First<int>(),
                new First<int>(1337),
                new First<int>() });

            var resultLast = Last.Accumulate(new[] {
                new Last<int>(),
                new Last<int>(42),
                new Last<int>(),
                new Last<int>(1337),
                new Last<int>() });

            Console.WriteLine(resultFirst);
            Console.WriteLine(resultLast);
            Console.ReadKey();
        }
    }
}
