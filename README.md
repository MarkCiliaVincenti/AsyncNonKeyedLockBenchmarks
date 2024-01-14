# Benchmarks for the AsyncKeyedLock library's AsyncNonKeyedLocker
This is a project to help benchmark the [AsyncKeyedLock](https://github.com/MarkCiliaVincenti/AsyncKeyedLock) library's AsyncNonKeyedLocker against other competing solutions. We are testing with 3 separate parameters:

1. Contention: 1,000,000
2. GUID reversals (to simulate some load): 0, 1 and 5

## Solutions tested
1. AsyncNonKeyedLocker (from [AsyncKeyedLock](https://github.com/MarkCiliaVincenti/AsyncKeyedLock))
2. AsyncLock (from [Nito.AsyncEx.Coordination](https://github.com/StephenCleary/AsyncEx) by Stephen Cleary)
3. AsyncLock (from [AsyncUtilities](https://github.com/i3arnon/AsyncUtilities) by Bar Arnon)

## Results
The [benchmark results](https://github.com/MarkCiliaVincenti/AsyncNonKeyedLockBenchmarks/actions/workflows/dotnet.yml) can be found in our actions as they run in Github Actions, in a fully transparent fashion.

There are also some [graphical comparisons over time](https://markciliavincenti.github.io/AsyncNonKeyedLockBenchmarks/dev/bench/).
