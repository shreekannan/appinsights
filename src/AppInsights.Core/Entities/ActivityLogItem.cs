using System;
using AppInsights.SharedKernel;
using AppInsights.SharedKernel.Interfaces;

namespace AppInsights.Core.Entities
{
    public class ActivityLog: BaseEntity, IAggregateRoot
    {

        public string ClientID { get; set; } = string.Empty;
        public string ServerName { get; set; } = string.Empty;
        public string ActivityDateTimeUTC { get; set; }
        public bool IsOnline { get;  set; }

        public override string ToString()
        {
            string status = IsOnline ? "Online!" : "Offline.";
            return $"{ServerName}: Status: {status} - {ActivityDateTimeUTC}";
        }
    }
}
