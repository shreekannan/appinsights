using System.Linq;
using System.Threading.Tasks;
using AppInsights.Core.Entities;
using AppInsights.SharedKernel.Interfaces;
using AppInsights.Web.ApiModels;
using Microsoft.AspNetCore.Mvc;
using AppInsights.Core.Interfaces;

namespace AppInsights.Web.Api
{
    public class AppInsightsController : BaseApiController
    {
       // private readonly IRepository _repository;

        private readonly IActivityLogSearchService _activityLogSearchService;

        public AppInsightsController(IActivityLogSearchService activityLogSearchService)
        {
            _activityLogSearchService = activityLogSearchService;
        }

        // GET: api/AppInsights
        [HttpGet]
        public async Task<IActionResult> List(string clientId)
        {
            var items = (await  _activityLogSearchService.ActivityLogSearchAync(clientId));
            var itemdto=  items.Value.Select(ActivityLogItemDTO.FromActivityLogItem);
            return Ok(itemdto);
        }


        // GET: api/AppInsights/ServerStatus
        [HttpGet("ServerStatus")]
        public async Task<IActionResult> ServerStatus(string clientId,string hostName)
        {
            var items = (await _activityLogSearchService.ActivityLogSearchAync(clientId,hostName));

            return Ok(items);
        }
        
        
    }
}
