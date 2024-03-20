using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSCS.FinancingStatements.Core.Models.BusinessObjects.HeartbeatModel
{
    public class HeartbeatModel
    {
        public HeartbeatModel()
        {
            Heartbeat = "OK";
        }

        [JsonProperty(propertyName: "heartbeat")]
        public string Heartbeat { get; private set; }
    }
}
