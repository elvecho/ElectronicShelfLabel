// Pluggable.Integration.ElectronicShelfLabel.Controllers.ElectronicShelfLabelController
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pluggable.Integration.ElectronicShelfLabel.Enum;
using Pluggable.Integration.ElectronicShelfLabel.Interfaces;
using Pluggable.Integration.ElectronicShelfLabel.Models;

namespace Pluggable.Integration.ElectronicShelfLabel.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ElectronicShelfLabelController : ControllerBase
    {
        private readonly ILogger<ElectronicShelfLabelController> _logger;

        private readonly IDataManager _dataManager;

        private readonly ICommunicator _communicator;

        public ElectronicShelfLabelController(ILogger<ElectronicShelfLabelController> logger, IDataManager dataManager, ICommunicator communicator = null)
        {
            _logger = logger;
            _dataManager = dataManager;
            _communicator = communicator;
        }

        [HttpGet("{action}")]
        public virtual async Task<bool> HasPendingPackages()
        {
            string funcName = "HasPendingPackages";
            bool rc = false;
            try
            {
                _logger?.LogDebug(funcName + " called");
                rc = await _dataManager.HasPendingPackages();
            }
            catch (Exception ex2)
            {
                Exception ex = ex2;
                _logger?.LogError(funcName + ": " + ex.Message);
                throw ex;
            }
            finally
            {
                _logger?.LogDebug($"{funcName} returns {rc}");
            }
            return rc;
        }

        [HttpGet("{action}")]
        public virtual async Task<List<ElectronicShelfLabelData>> NextPendingPackage()
        {
            string funcName = "NextPendingPackage";
            List<ElectronicShelfLabelData> rc = new List<ElectronicShelfLabelData>();
            try
            {
                _logger?.LogDebug(funcName + " called");
                await foreach (List<ElectronicShelfLabelData> item in _dataManager.NextPendingPackage())
                {
                    rc.AddRange(item);
                }
            }
            catch (Exception ex2)
            {
                Exception ex = ex2;
                _logger?.LogError(funcName + ": " + ex.Message);
                throw ex;
            }
            finally
            {
                _logger?.LogDebug($"{funcName} returns {rc.Count}");
            }
            return rc;
        }

        [HttpGet("{action}")]
        public virtual async Task<List<ElectronicShelfLabelData>> AllPackages()
        {
            string funcName = "AllPackages";
            List<ElectronicShelfLabelData> rc = new List<ElectronicShelfLabelData>();
            try
            {
                _logger?.LogDebug(funcName + " called");
                rc = await _dataManager.AllPackages();
            }
            catch (Exception ex2)
            {
                Exception ex = ex2;
                _logger?.LogError(funcName + ": " + ex.Message);
                throw ex;
            }
            finally
            {
                _logger?.LogDebug($"{funcName} returns {rc.Count}");
            }
            return rc;
        }

        [HttpPost("{action}/{state}")]
        public virtual async Task<bool> SetPackage([FromBody] List<ElectronicShelfLabelData> data, int state)
        {
            string funcName = "SetPackage";
            bool rc = false;
            try
            {
                _logger?.LogDebug(funcName + " called");
                rc = await _dataManager.SetPackage(data, (DataState)state);
            }
            catch (Exception ex2)
            {
                Exception ex = ex2;
                _logger?.LogError(funcName + ": " + ex.Message);
                throw ex;
            }
            finally
            {
                _logger?.LogDebug($"{funcName} returns {rc}");
            }
            return rc;
        }

        [HttpGet]
        public virtual async Task<List<string>> Get()
        {
            string funcName = "Load";
            List<string> rc = new List<string>();
            try
            {
                _logger?.LogDebug(funcName + " called");
                await Task.Run(delegate
                {
                    rc.Add("IDataManager = " + (_dataManager == null ? "null" : _dataManager.GetType().FullName));
                    rc.Add("ICommunicator = " + (_communicator == null ? "null" : _communicator.GetType().FullName));
                });
            }
            catch (Exception ex2)
            {
                Exception ex = ex2;
                _logger?.LogError(funcName + ": " + ex.Message);
                throw ex;
            }
            finally
            {
                _logger?.LogDebug($"{funcName} returns {rc}");
            }
            return rc;
        }
    }
}

