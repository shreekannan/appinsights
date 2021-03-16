using AppInsights.Core.Entities;

namespace AppInsights.UnitTests
{
    // Learn more about test builders:
    // https://ardalis.com/improve-tests-with-the-builder-pattern-for-test-data
    public class ActivityLogBuilder
    {
        private ActivityLog _activityLog = new ActivityLog();

        public ActivityLogBuilder Id(int id)
        {
            _activityLog.Id = id;
            return this;
        }

        public ActivityLogBuilder ServerName(string serverName)
        {
            _activityLog.ServerName = serverName;
            return this;
        }

        public ActivityLogBuilder IsOnline(bool IsOnline)
        {
            _activityLog.IsOnline = IsOnline;
            return this;
        }

        public ActivityLogBuilder WithDefaultValues()
        {
            _activityLog = new ActivityLog() { Id = 1, ServerName = "PROD_APP01", ActivityDateTimeUTC = System.DateTime.UtcNow.ToString(), IsOnline=true, ClientID="XYZ-0001" };

            return this;
        }

        public ActivityLog Build() => _activityLog;
    }
}
