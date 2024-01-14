window.BENCHMARK_DATA = {
  "lastUpdate": 1705260362231,
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
      },
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
          "id": "73f221a4e0da9704945b351854f0ac5ecf0c2fb6",
          "message": "Add AsyncUtilities",
          "timestamp": "2024-01-14T20:14:15+01:00",
          "tree_id": "f4284f3f040c6868b142eb7eb3f87e6a5313a599",
          "url": "https://github.com/MarkCiliaVincenti/AsyncNonKeyedLockBenchmarks/commit/73f221a4e0da9704945b351854f0ac5ecf0c2fb6"
        },
        "date": 1705260361728,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "AsyncNonKeyedLockBenchmarks.Benchmarks.AsyncNonKeyedLock(Contention: 1000000, GuidReversals: 0)",
            "value": 424244923.26,
            "unit": "ns",
            "range": "± 34983268.81926684"
          },
          {
            "name": "AsyncNonKeyedLockBenchmarks.Benchmarks.AsyncEx(Contention: 1000000, GuidReversals: 0)",
            "value": 858918202.3571428,
            "unit": "ns",
            "range": "± 14394795.064737074"
          },
          {
            "name": "AsyncNonKeyedLockBenchmarks.Benchmarks.AsyncUtilities(Contention: 1000000, GuidReversals: 0)",
            "value": 380717291.83,
            "unit": "ns",
            "range": "± 30539220.46459677"
          },
          {
            "name": "AsyncNonKeyedLockBenchmarks.Benchmarks.AsyncNonKeyedLock(Contention: 1000000, GuidReversals: 1)",
            "value": 1715797403.0666666,
            "unit": "ns",
            "range": "± 16546907.532341028"
          },
          {
            "name": "AsyncNonKeyedLockBenchmarks.Benchmarks.AsyncEx(Contention: 1000000, GuidReversals: 1)",
            "value": 1960474535.6666667,
            "unit": "ns",
            "range": "± 8660379.967207357"
          },
          {
            "name": "AsyncNonKeyedLockBenchmarks.Benchmarks.AsyncUtilities(Contention: 1000000, GuidReversals: 1)",
            "value": 1713154209.857143,
            "unit": "ns",
            "range": "± 21901695.11221071"
          },
          {
            "name": "AsyncNonKeyedLockBenchmarks.Benchmarks.AsyncNonKeyedLock(Contention: 1000000, GuidReversals: 5)",
            "value": 5248915207.533334,
            "unit": "ns",
            "range": "± 76497422.94399488"
          },
          {
            "name": "AsyncNonKeyedLockBenchmarks.Benchmarks.AsyncEx(Contention: 1000000, GuidReversals: 5)",
            "value": 5414001121.933333,
            "unit": "ns",
            "range": "± 63298130.23641386"
          },
          {
            "name": "AsyncNonKeyedLockBenchmarks.Benchmarks.AsyncUtilities(Contention: 1000000, GuidReversals: 5)",
            "value": 5233571494.333333,
            "unit": "ns",
            "range": "± 78908261.23784927"
          }
        ]
      }
    ]
  }
}