

// Pluggable.Integration.ElectronicShelfLabel.HostedServices.ElectronicShelfLabelHostedService
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Pluggable.Integration.ElectronicShelfLabel.Configurations;
using Pluggable.Integration.ElectronicShelfLabel.Enum;
using Pluggable.Integration.ElectronicShelfLabel.Interfaces;
using Pluggable.Integration.ElectronicShelfLabel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Pluggable.Integration.ElectronicShelfLabel.HostedServices
{
    public class ElectronicShelfLabelHostedService : IHostedService, IDisposable
    {
        private readonly ILogger<ElectronicShelfLabelHostedService> _logger;

        private readonly IConfiguration _configuration;

        private readonly CancellationTokenSource _stoppingCts = new CancellationTokenSource();

        private readonly IElectronicShelfLabelConfig _electronicShelfLabelConfig;

        private readonly IDataManager _dataManager;

        private readonly ICommunicator _communicator;

        private Task _executingTask;

        public ElectronicShelfLabelHostedService(ILogger<ElectronicShelfLabelHostedService> logger, IConfiguration configuration, IEnumerable<IElectronicShelfLabelConfig> electronicShelfLabelConfig = null, IEnumerable<IDataManager> dataManager = null, IEnumerable<ICommunicator> communicator = null)
        {
            _logger = logger;
            _configuration = configuration;
            _logger.LogInformation("ElectronicShelfLabelHostedService created. Use configuration from section " + ElectronicShelfLabelConfig.Key + ".");
            _electronicShelfLabelConfig = electronicShelfLabelConfig.Where((IElectronicShelfLabelConfig c) => c.GetType().FullName == ElectronicShelfLabelConfig.Key).FirstOrDefault();
            if (_electronicShelfLabelConfig == null)
            {
                throw new Exception("ElectronicShelfLabelHostedService creation failed because the configuration is not valid.");
            }
            if (_electronicShelfLabelConfig.GetType().FullName != _electronicShelfLabelConfig.Configuration)
            {
                _logger.LogInformation("ElectronicShelfLabelHostedService replace base configuration with " + _electronicShelfLabelConfig.Configuration);
                _electronicShelfLabelConfig = electronicShelfLabelConfig.Where((IElectronicShelfLabelConfig c) => c.GetType().FullName == _electronicShelfLabelConfig.Configuration).FirstOrDefault();
            }
            _dataManager = dataManager.Where((IDataManager c) => c.GetType().FullName == _electronicShelfLabelConfig.DataManager).FirstOrDefault();
            _logger.LogInformation("ElectronicShelfLabelHostedService data manager is " + _electronicShelfLabelConfig.DataManager);
            _communicator = communicator.Where((ICommunicator c) => c.GetType().FullName == _electronicShelfLabelConfig.Communicator).FirstOrDefault();
            _logger.LogInformation("ElectronicShelfLabelHostedService communicator is " + _electronicShelfLabelConfig.Communicator);
        }

        protected virtual async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            string funcName = "ExecuteAsync";
            _logger?.LogInformation("ElectronicShelfLabelHostedService is starting (" + funcName + ").");
            stoppingToken.Register(delegate
            {
                _logger.LogDebug("ElectronicShelfLabelHostedService background task is stopping.");
            });
            List<Task> tasks;
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    _logger?.LogDebug("ElectronicShelfLabelHostedService task doing background work.");
                    await Task.Delay(_electronicShelfLabelConfig.CheckInterval, stoppingToken);
                    if (await _dataManager.HasPendingPackages())
                    {
                        _logger?.LogDebug("ElectronicShelfLabelHostedService has pending packages");
                        List<List<ElectronicShelfLabelData>> pendingPackages = new List<List<ElectronicShelfLabelData>>();
                        await foreach (List<ElectronicShelfLabelData> package2 in _dataManager.NextPendingPackage())
                        {
                            pendingPackages.Add(package2);
                            _logger?.LogDebug($"ElectronicShelfLabelHostedService package {pendingPackages.Count()} contains {package2.Count} records");
                        }
                        tasks = new List<Task>();
                        Parallel.ForEach((IEnumerable<List<ElectronicShelfLabelData>>)pendingPackages, (Action<List<ElectronicShelfLabelData>>)delegate (List<ElectronicShelfLabelData> package)
                        {
                            Task task = new Task(delegate
                            {
                                _logger?.LogDebug($"ElectronicShelfLabelHostedService task started has loaded {package.Count} records");
                                DataState result = _communicator.Send(package).Result;
                                _logger?.LogDebug($"ElectronicShelfLabelHostedService communication with the ESL system returns {result}");
                                bool result2 = _dataManager.SetPackage(package, result).Result;
                                _logger?.LogDebug(string.Format("ElectronicShelfLabelHostedService package has {0}been set to {1}", result2 ? "" : "not ", result));
                            });
                            tasks.Add(task);
                            _logger?.LogDebug($"ElectronicShelfLabelHostedService task {task.Id} created to handle {package.Count} records");
                        });
                        _logger?.LogDebug($"ElectronicShelfLabelHostedService starting {tasks.Count} tasks in order to process pending packages");
                        tasks.ForEach(delegate (Task _)
                        {
                            _.Start();
                        });
                        while (tasks.Any())
                        {
                            Task completed = await Task.WhenAny(tasks);
                            _logger?.LogDebug($"ElectronicShelfLabelHostedService task {completed.Id} has been completed ({completed.Status})");
                            tasks.Remove(completed);
                        }
                        _logger?.LogDebug("ElectronicShelfLabelHostedService elaboration completed");
                    }
                    else
                    {
                        _logger?.LogDebug("ElectronicShelfLabelHostedService has no pending packages");
                    }
                }
                catch (Exception ex)
                {
                    _logger?.LogError(ex, "ElectronicShelfLabelHostedService exception occurs.");
                }
            }
            _logger?.LogInformation("ElectronicShelfLabelHostedService background task is stopping.");
        }

        public virtual Task StartAsync(CancellationToken cancellationToken)
        {
            _executingTask = ExecuteAsync(_stoppingCts.Token);
            if (_executingTask.IsCompleted)
            {
                return _executingTask;
            }
            return Task.CompletedTask;
        }

        public virtual async Task StopAsync(CancellationToken cancellationToken)
        {
            if (_executingTask != null)
            {
                try
                {
                    _stoppingCts.Cancel();
                }
                finally
                {
                    await Task.WhenAny(new Task[2]
                    {
                    _executingTask,
                    Task.Delay(-1, cancellationToken)
                    });
                }
            }
        }

        public virtual void Dispose()
        {
            _stoppingCts.Cancel();
        }
    }
}