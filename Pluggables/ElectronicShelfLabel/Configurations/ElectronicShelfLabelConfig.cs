// Pluggable.Integration.ElectronicShelfLabel.Configurations.ElectronicShelfLabelConfig
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Pluggable.Integration.ElectronicShelfLabel.Interfaces;


namespace Pluggable.Integration.ElectronicShelfLabel.Configurations
{
    public class ElectronicShelfLabelConfig : IElectronicShelfLabelConfig
    {
        public static string Key => typeof(ElectronicShelfLabelConfig).FullName;

        public virtual TimeSpan CheckInterval { get; set; } = TimeSpan.FromMinutes(5.0);


        public virtual string DataManager { get; set; }

        public virtual string Communicator { get; set; }

        public virtual string Configuration { get; set; }

        public ElectronicShelfLabelConfig(ILogger<ElectronicShelfLabelConfig> logger, IConfiguration configuration) => configuration.Bind(Key, this);
    }
}

