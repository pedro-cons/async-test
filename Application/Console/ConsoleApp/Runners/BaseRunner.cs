using BenchmarkDotNet.Attributes;
using Domain.Constants;
using Domain.Interfaces;
using System;
using System.Threading.Tasks;

/// <summary>
/// Class responsible for executing the Console logic
/// </summary>
public class BaseRunner
{
    #region Properties

    private const int NumRequests = 5;

    #endregion

    #region Constructor

    /// <summary>
    /// Console Runner Constructor
    /// </summary>
    public BaseRunner()
    {
    }

    #endregion

    #region Methods

    /// <summary>
    /// Method responsible for starting the execution of the console
    /// </summary>
    /// <returns></returns>
    [Benchmark]
    public async Task RunAsync()
    {
        Console.WriteLine("Starting asynchronous execution...");

        var databaseTasks = new List<Task>();
        var serviceTasks = new List<Task>();

        for (int i = 0; i < NumRequests; i++)
        {
            databaseTasks.Add(SimulateDatabaseRequestAsync());
        }

        for (int i = 0; i < NumRequests; i++)
        {
            serviceTasks.Add(SimulateExternalServiceRequestAsync());
        }

        await Task.WhenAll(databaseTasks.Concat(serviceTasks));

        Console.WriteLine("Ending asynchronous execution.");
    }

    /// <summary>
    /// Method responsible for starting the execution of the console
    /// </summary>
    /// <returns></returns>
    [Benchmark]
    public void Run()
    {
        Console.WriteLine("Starting synchronous execution...");

        for (int i = 0; i < NumRequests; i++)
        {
            SimulateDatabaseRequest();
        }

        for (int i = 0; i < NumRequests; i++)
        {
            SimulateExternalServiceRequest();
        }

        Console.WriteLine("Ending synchronous execution.");
    }

    private async Task SimulateDatabaseRequestAsync()
    {
        Console.WriteLine("Starting database request...");
        await Task.Delay(1000);
        Console.WriteLine("Database request completed.");
    }

    private void SimulateDatabaseRequest()
    {
        Console.WriteLine("Starting database request...");
        Task.Delay(1000).Wait();
        Console.WriteLine("Database request completed.");
    }

    private void SimulateExternalServiceRequest()
    {
        Console.WriteLine("Starting external service request...");
        Task.Delay(1500).Wait();
        Console.WriteLine("External service request completed.");
    }

    private async Task SimulateExternalServiceRequestAsync()
    {
        Console.WriteLine("Starting external service request...");
        await Task.Delay(1500);
        Console.WriteLine("External service request completed.");
    }
    #endregion
}
