using Ardalis.Specification;
using AppInsights.Core.Entities;

namespace AppInsights.Core.Specifications
{
    public class ClientActivityLogSpecification : Specification<ActivityLog>
    {
        public ClientActivityLogSpecification(string clientId)
        {
            Query.Where(item =>   item.ClientID.ToLower()  ==  clientId.ToLower());
        }
    }


    public class ClientHostActivityLogSpecification : Specification<ActivityLog>
    {
        public ClientHostActivityLogSpecification(string clientId, string hostName)
        {
            Query.Where(item => item.ClientID.ToLower() == clientId.ToLower() && item.ServerName.ToLower() == hostName.ToLower());
        }
    }
}
