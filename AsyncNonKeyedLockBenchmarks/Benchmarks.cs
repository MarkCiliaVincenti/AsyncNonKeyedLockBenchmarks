using AsyncKeyedLock;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Jobs;
using Proto.Promises;
using Proto.Utilities.Benchmark;

namespace AsyncNonKeyedLockBenchmarks
{
    //[Config(typeof(Config))]
    [Config(typeof(MemoryConfig))]
    [MemoryDiagnoser]
    [JsonExporterAttribute.Full]
    [JsonExporterAttribute.FullCompressed]
    public class Benchmarks
    {
        private class MemoryConfig : ManualConfig
        {
            public MemoryConfig()
            {
                AddDiagnoser(MemoryDiagnoser.Default);
            }
        }

        //private class Config : ManualConfig
        //{
        //    public Config()
        //    {
        //        var baseJob = Job.Default;

        //        AddJob(baseJob.WithNuGet("AsyncKeyedLock", "6.2.5").WithBaseline(true));
        //        AddJob(baseJob.WithNuGet("AsyncKeyedLock", "6.2.6-alpha"));
        //    }
        //}

        [Params(1_000)] public int Contention { get; set; }

        [Params(0, 1, 5)] public int GuidReversals { get; set; }

        private AsyncBenchmarkThreadHelper? _threadHelper;

        private void Operation()
        {
            for (int i = 0; i < GuidReversals; i++)
            {
                Guid guid = Guid.NewGuid();
                string guidString = guid.ToString();
                guidString = guidString.Reverse().ToString()!;
                if (guidString.Length != 53)
                {
                    throw new Exception($"Not 53 but {guidString.Length}");
                }
            }
        }

        [GlobalCleanup]
        public void Cleanup()
        {
            _threadHelper!.Dispose();
            _threadHelper = null;
        }

        #region AsyncNonKeyedLocker

        [GlobalSetup(Target = nameof(AsyncNonKeyedLock))]
        public void SetupAsyncNonKeyedLock()
        {
            var locker = new AsyncNonKeyedLocker();
            _threadHelper = new(Contention);
            for (int i = 0; i < Contention; ++i)
            {
                _threadHelper.Add(() => Core());
            }

            // Using `async Promise` instead of `async (Value)Task` to avoid allocations of the async method that we aren't interested in measuring.
            async Promise Core()
            {
                using (await locker.LockAsync().ConfigureAwait(false))
                {
                    Operation();
                }
            }
        }

        [Benchmark(Baseline = true, Description = "AsyncNonKeyedLocker")]
        public ValueTask AsyncNonKeyedLock()
            => _threadHelper!.ExecuteAndWaitAsync();
        #endregion AsyncKeyedLock

        #region AsyncEx

        [GlobalSetup(Target = nameof(AsyncEx))]
        public void SetupAsyncEx()
        {
            var locker = new Nito.AsyncEx.AsyncLock();
            _threadHelper = new(Contention);
            for (int i = 0; i < Contention; ++i)
            {
                _threadHelper.Add(() => Core());
            }

            // Using `async Promise` instead of `async (Value)Task` to avoid allocations of the async method that we aren't interested in measuring.
            async Promise Core()
            {
                using (await locker.LockAsync().ConfigureAwait(false))
                {
                    Operation();
                }
            }
        }

        [Benchmark(Description = "Async.Ex.Coordination")]
        public ValueTask AsyncEx()
            => _threadHelper!.ExecuteAndWaitAsync();
        #endregion AsyncEx

        #region AsyncUtilities

        [GlobalSetup(Target = nameof(AsyncUtilities))]
        public void SetupAsyncUtilities()
        {
            var locker = new AsyncUtilities.AsyncLock();
            _threadHelper = new(Contention);
            for (int i = 0; i < Contention; ++i)
            {
                _threadHelper.Add(() => Core());
            }

            // Using `async Promise` instead of `async (Value)Task` to avoid allocations of the async method that we aren't interested in measuring.
            async Promise Core()
            {
                using (await locker.LockAsync().ConfigureAwait(false))
                {
                    Operation();
                }
            }
        }

        [Benchmark(Description = "AsyncUtilities")]
        public ValueTask AsyncUtilities()
            => _threadHelper!.ExecuteAndWaitAsync();
        #endregion AsyncUtilities

        #region NeoSmart

        [GlobalSetup(Target = nameof(NeoSmart))]
        public void SetupNeoSmart()
        {
            var locker = new NeoSmart.AsyncLock.AsyncLock();
            _threadHelper = new(Contention);
            for (int i = 0; i < Contention; ++i)
            {
                _threadHelper.Add(() => Core());
            }

            // Using `async Promise` instead of `async (Value)Task` to avoid allocations of the async method that we aren't interested in measuring.
            async Promise Core()
            {
                using (await locker.LockAsync().ConfigureAwait(false))
                {
                    Operation();
                }
            }
        }

        [Benchmark(Description = "NeoSmart.AsyncLock")]
        public ValueTask NeoSmart()
            => _threadHelper!.ExecuteAndWaitAsync();
        #endregion NeoSmart

        #region ProtoPromise

        [GlobalSetup(Target = nameof(ProtoPromise))]
        public void SetupProtoPromise()
        {
            var locker = new Proto.Promises.Threading.AsyncLock();
            _threadHelper = new(Contention);
            for (int i = 0; i < Contention; ++i)
            {
                _threadHelper.Add(() => Core());
            }

            // Using `async Promise` instead of `async (Value)Task` to avoid allocations of the async method that we aren't interested in measuring.
            async Promise Core()
            {
                using (await locker.LockAsync())
                {
                    Operation();
                }
            }
        }

        [Benchmark(Description = "ProtoPromise.AsyncLock")]
        public ValueTask ProtoPromise()
            => _threadHelper!.ExecuteAndWaitAsync();
        #endregion ProtoPromise
    }
}