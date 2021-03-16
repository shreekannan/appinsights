using System.ComponentModel.DataAnnotations;
using AppInsights.Core.Entities;
using System;

namespace AppInsights.Web.ApiModels
{

    public class ActivityLogItemDTO
    {
        public string ServerName { get; set; }
        public string ActivityDateTimeUTC { get; set; }
        public bool IsOnline { get; private set; }

        public static ActivityLogItemDTO FromActivityLogItem(ActivityLog item)
        {
            return new ActivityLogItemDTO()
            {
                ServerName = item.ServerName,
                ActivityDateTimeUTC = item.ActivityDateTimeUTC,
                IsOnline = item.IsOnline
            };
        }
    }
}
