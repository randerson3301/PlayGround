// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace BenchmarkDotNetExample
{
    public class ForVsForeach
    {
       [Benchmark]
       public void ForLoop()
        {
            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }
        }

        [Benchmark]
        public void ForEachLoop()

        {
            int[] integers = new int[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};

            foreach(int i in integers)
            {
                Console.WriteLine(i);
            }
        }      
    }

    public class IntParseVsConvert {
        
        [Benchmark]
        public int ParseWithIntParse()
        {
            return int.Parse("1000");
        }

        [Benchmark]
        public int ParseWithConvert()
        {
            return Convert.ToInt32("1000");
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<IntParseVsConvert>();
        }
    }
}
