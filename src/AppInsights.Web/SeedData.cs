using System;
using System.Linq;
using AppInsights.Core.Entities;
using AppInsights.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AppInsights.Web
{
    public static class SeedData
    {
        public static readonly ActivityLog item1 = new ActivityLog
        {
            ClientID = "XYZ-0001",
            ServerName = "SP_DEV01",
            ActivityDateTimeUTC = DateTime.UtcNow.ToString(),
            IsOnline = true
        };
        public static readonly ActivityLog item2 = new ActivityLog
        {
            ClientID = "XYZ-0001",
            ServerName = "SP_DEV02",
            ActivityDateTimeUTC = DateTime.UtcNow.AddMinutes(-1).ToString() ,
            IsOnline = false
        };
        public static readonly ActivityLog item3 = new ActivityLog
        {
            ClientID = "ABC-0002",
            ServerName = "SP_DEV02",
            ActivityDateTimeUTC = DateTime.UtcNow.AddMinutes(-2).ToString(),
            IsOnline = false
        };

        public static void Initialize(IServiceProvider serviceProvider)
        {
       
            using (var dbContext = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>(), null))
            {

              
                //dbContext.Database.Migrate();

                // Look for any TODO items.
                if (dbContext.ActivityLogs.Any())
                {
                    return;   // DB has been seeded
                }

                PopulateTestData(dbContext);



            }
        }
        public static void PopulateTestData(AppDbContext dbContext)
        {
  
            foreach (var item in dbContext.ActivityLogs)
            {
                dbContext.Remove(item);
            }
            dbContext.SaveChanges();
            dbContext.ActivityLogs.Add(new ActivityLog
            {
                ClientID = "XYZ-0001",
                ServerName = "PROD_WFE01",
                ActivityDateTimeUTC = DateTime.UtcNow.ToString(),
                IsOnline = true
            });

            dbContext.ActivityLogs.Add(new ActivityLog
            {
                ClientID = "XYZ-0001",
                ServerName = "PROD_WFE02",
                ActivityDateTimeUTC = DateTime.UtcNow.AddMinutes(-1).ToString(),
                IsOnline = false
            });
            dbContext.SaveChanges();
            dbContext.ActivityLogs.Add( new ActivityLog
            {
                ClientID = "XYZ-0001",
                ServerName = "PROD_APP01",
                ActivityDateTimeUTC = DateTime.UtcNow.AddMinutes(-1).ToString(),
                IsOnline = true
            });
            dbContext.SaveChanges();
            dbContext.ActivityLogs.Add(new ActivityLog
            {
                ClientID = "ABC-0002",
                ServerName = "WFE01",
                ActivityDateTimeUTC = DateTime.UtcNow.AddMinutes(-1).ToString(),
                IsOnline = true
            });

            dbContext.ActivityLogs.Add(new ActivityLog
            {
                ClientID = "ABC-0002",
                ServerName = "APP01",
                ActivityDateTimeUTC = DateTime.UtcNow.AddMinutes(-3).ToString(),
                IsOnline = false
            });

            dbContext.SaveChanges();

        }
    }
}
