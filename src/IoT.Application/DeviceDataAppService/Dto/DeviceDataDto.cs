using System;
using System.Collections.Generic;
using System.Text;
using Abp.AutoMapper;
using IoT.Core;

namespace IoT.Application
{
    [AutoMapFrom(typeof(DeviceData))]
    public class DeviceDataDto
    {
        public string DeviceId { get; set; }
        public string DeviceName { get; set; }
        public string DeviceType { get; set; }
        public string GatewayId { get; set; }
        public string MonitorId { get; set; }
        public string MonitorName { get; set; }
        public string MonitorType { get; set; }
        public decimal Value { get; set; }
        public string Unit { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
