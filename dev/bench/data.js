window.BENCHMARK_DATA = {
  "lastUpdate": 1705259529574,
  "repoUrl": "https://github.com/MarkCiliaVincenti/AsyncNonKeyedLockBenchmarks",
  "entries": {
    "Benchmark.Net Benchmark": [
      {
        "commit": {
          "author": {
            "email": "markciliavincenti@gmail.com",
            "name": "Mark Cilia Vincenti",
            "username": "MarkCiliaVincenti"
          },
          "committer": {
            "email": "markciliavincenti@gmail.com",
            "name": "Mark Cilia Vincenti",
            "username": "MarkCiliaVincenti"
          },
          "distinct": true,
          "id": "725c2deacb0bf09110a99cc9248da000ad03612e",
          "message": "Fix",
          "timestamp": "2024-01-14T20:11:27+01:00",
          "tree_id": "847e663c2c2c3fec70d75004c3beb03eb8edacb7",
          "url": "https://github.com/MarkCiliaVincenti/AsyncNonKeyedLockBenchmarks/commit/725c2deacb0bf09110a99cc9248da000ad03612e"
        },
        "date": 1705259528642,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "AsyncNonKeyedLockBenchmarks.Benchmarks.AsyncNonKeyedLock(Contention: 1000, GuidReversals: 0)",
            "value": 863177.0104166666,
            "unit": "ns",
            "range": "± 78129.25700812723"
          },
          {
            "name": "AsyncNonKeyedLockBenchmarks.Benchmarks.AsyncEx(Contention: 1000, GuidReversals: 0)",
            "value": 1043390.3076923077,
            "unit": "ns",
            "range": "± 12635.320483896292"
          },
          {
            "name": "AsyncNonKeyedLockBenchmarks.Benchmarks.AsyncNonKeyedLock(Contention: 1000, GuidReversals: 1)",
            "value": 2258227,
            "unit": "ns",
            "range": "± 13121.481817116657"
          },
          {
            "name": "AsyncNonKeyedLockBenchmarks.Benchmarks.AsyncEx(Contention: 1000, GuidReversals: 1)",
            "value": 2314850.2421052633,
            "unit": "ns",
            "range": "± 174999.58629888584"
          },
          {
            "name": "AsyncNonKeyedLockBenchmarks.Benchmarks.AsyncNonKeyedLock(Contention: 1000, GuidReversals: 5)",
            "value": 6431445.083333333,
            "unit": "ns",
            "range": "± 13811.91416171582"
          },
          {
            "name": "AsyncNonKeyedLockBenchmarks.Benchmarks.AsyncEx(Contention: 1000, GuidReversals: 5)",
            "value": 6365941.5360824745,
            "unit": "ns",
            "range": "± 438983.036168257"
          }
        ]
      }
    ]
  }
}