using BenchmarkDotNet.Attributes;
using SNF.MonoGame.Features;

namespace SNF.Benchmark
{
    public class Benchmarks
    {
        [Benchmark(Baseline = true)]
        public void Scenario1()
        {
            for (int i = 0; i < 10; i++)
            {
                var node = Context.CreateNode();
                Context.CreateFeature<Transform>();
                Context.CreateFeature<Counter>();
            }
        }

        [Benchmark]
        public void Scenario2()
        {
            for (int i = 0; i < 100; i++)
            {
                var node = Context.CreateNode();
                Context.CreateFeature<Transform>();
                Context.CreateFeature<Counter>();
            }
        }

        [Benchmark]
        public void Scenario3()
        {
            for (int i = 0; i < 1_000; i++)
            {
                var node = Context.CreateNode();
                Context.CreateFeature<Transform>();
                Context.CreateFeature<Counter>();
            }
        }
    }
}
