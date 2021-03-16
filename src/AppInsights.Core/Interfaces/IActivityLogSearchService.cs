using System.Collections.Generic;
using System.Threading.Tasks;
using Ardalis.Result;
using AppInsights.Core.Entities;

namespace AppInsights.Core.Interfaces
{
    public interface IActivityLogSearchService : IAppServiceBae
    {
        Task<Result<List<ActivityLog>>> ActivityLogSearchAync(string clientId);
        Task<Result<ActivityLog>> ActivityLogSearchAync(string clientId,  string hostName);
    }

    public interface IAppServiceBae
    {

    }
}
