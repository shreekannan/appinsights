using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.Result;
using AppInsights.Core.Entities;
using AppInsights.Core.Interfaces;
using AppInsights.Core.Specifications;
using AppInsights.SharedKernel.Interfaces;


namespace AppInsights.Core.Services
{
    public class ActivityLogSearchService : IActivityLogSearchService
    {
        private readonly IRepository _repository;
       

  
        public ActivityLogSearchService(IRepository repository)
        {
            _repository = repository;

        }

        public async Task<Result<List<ActivityLog>>> ActivityLogSearchAync(string clientId)
        {
            if(string.IsNullOrEmpty(clientId))
            {
                var errors = new List<ValidationError>();
                errors.Add(new ValidationError()
                {
                    Identifier = nameof(clientId),
                    ErrorMessage = $"{nameof(clientId)} is required."
                });
                return Result<List<ActivityLog>>.Invalid(errors);
            }

            var clientFilter = new ClientActivityLogSpecification(clientId);

            try
            {
               

                var items = await _repository.ListAsync (clientFilter);

        
                return new Result<List<ActivityLog>>(items);
            }
            catch (Exception ex)
            {
                return Result<List<ActivityLog>>.Error(new[] { ex.Message });
            }
        }


        public async Task<Result<ActivityLog>> ActivityLogSearchAync(string clientId,string hostName)
        {
            var errors = new List<ValidationError>();
            if (string.IsNullOrEmpty(clientId))
            {

                errors.Add(new ValidationError()
                {
                    Identifier = nameof(clientId),
                    ErrorMessage = $"{nameof(clientId)} is required."
                });
            }

            if (string.IsNullOrEmpty(hostName))
            {
                errors.Add(new ValidationError()
                {
                    Identifier = nameof(hostName),
                    ErrorMessage = $"{nameof(hostName)} is required."
                });

            }
            //Any validation error return result dto with errors
            if (errors.Any())
            {
                return Result<ActivityLog>.Invalid(errors);
            }

            var clientFilter = new ClientHostActivityLogSpecification(clientId, hostName);

            try
            {
                var items = await _repository.ListAsync(clientFilter);

                return new Result<ActivityLog>(items.FirstOrDefault());
            }
            catch (Exception ex)
            {
                return Result<ActivityLog>.Error(new[] { ex.Message });
            }
        }

    }
}
