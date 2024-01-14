﻿using AsyncKeyedLock;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Jobs;
using Nito.AsyncEx;

namespace AsyncKeyedLockBenchmarks
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

        [Params(100, 10_000)] public int Contention { get; set; }

        [Params(0, 1, 5)] public int GuidReversals { get; set; }

        private void Operation()
        {
            for (int i = 0; i < GuidReversals; i++)
            {
                Guid guid = Guid.NewGuid();
                var guidString = guid.ToString();
                guidString = guidString.Reverse().ToString();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                if (guidString.Length != 53)
                {
                    throw new Exception($"Not 53 but {guidString?.Length}");
                }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            }
        }

        private async Task RunTests(ParallelQuery<Task> tasks)
        {
            await Task.WhenAll(tasks).ConfigureAwait(false);
        }

        #region AsyncNonKeyedLocker
        public AsyncNonKeyedLocker? AsyncNonKeyedLocker { get; set; }
        public ParallelQuery<Task>? AsyncNonKeyedLockerTasks { get; set; }

        [IterationSetup(Target = nameof(AsyncNonKeyedLock))]
        public void SetupAsyncNonKeyedLock()
        {
            AsyncNonKeyedLocker = new AsyncNonKeyedLocker();
            AsyncNonKeyedLockerTasks = Enumerable.Range(1, Contention)
                .Select(async i =>
                {
                    using (await AsyncNonKeyedLocker.LockAsync().ConfigureAwait(false))
                    {
                        Operation();
                    }

                    await Task.Yield();
                }).AsParallel();
        }

        [IterationCleanup(Target = nameof(AsyncNonKeyedLock))]
        public void CleanupAsyncKeyedLock()
        {
            AsyncNonKeyedLocker = null;
            AsyncNonKeyedLockerTasks = null;
        }

        [Benchmark(Baseline = true, Description = "AsyncNonKeyedLocker")]
        public async Task AsyncNonKeyedLock()
        {
#pragma warning disable CS8604 // Possible null reference argument.
            await RunTests(AsyncNonKeyedLockerTasks).ConfigureAwait(false);
#pragma warning restore CS8604 // Possible null reference argument.
        }
        #endregion AsyncKeyedLock

        #region AsyncEx
        public AsyncLock? AsyncExLocker { get; set; }
        public ParallelQuery<Task>? AsyncExLockerTasks { get; set; }

        [IterationSetup(Target = nameof(AsyncEx))]
        public void SetupAsyncEx()
        {
            AsyncExLocker = new AsyncLock();
            AsyncExLockerTasks = Enumerable.Range(1, Contention)
                .Select(async i =>
                {
                    using (await AsyncExLocker.LockAsync().ConfigureAwait(false))
                    {
                        Operation();
                    }

                    await Task.Yield();
                }).AsParallel();
        }

        [IterationCleanup(Target = nameof(AsyncEx))]
        public void CleanupAsyncEx()
        {
            AsyncExLocker = null;
            AsyncExLockerTasks = null;
        }

        [Benchmark(Baseline = true, Description = "Async.Ex.Coordination")]
        public async Task AsyncEx()
        {
#pragma warning disable CS8604 // Possible null reference argument.
            await RunTests(AsyncExLockerTasks).ConfigureAwait(false);
#pragma warning restore CS8604 // Possible null reference argument.
        }
        #endregion AsyncKeyedLock
    }
}
