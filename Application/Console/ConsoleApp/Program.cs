using BenchmarkDotNet.Running;
using Domain.Interfaces;
using Domain.Services;

var runner = new BaseRunner();

// Execute runner
await runner.RunAsync();
runner.Run();


var summary = BenchmarkRunner.Run<BaseRunner>();
