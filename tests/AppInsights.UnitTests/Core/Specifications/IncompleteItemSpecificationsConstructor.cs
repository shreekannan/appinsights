using System.Collections.Generic;
using System.Linq;
using AppInsights.Core.Entities;
using AppInsights.Core.Specifications;
using Xunit;

namespace AppInsights.UnitTests.Core.Specifications
{
    public class IncompleteItemsSpecificationConstructor
    {
        [Fact]
        public void FilterCollectionToOnlyReturnItemsWithIsDoneFalse()
        {
           
            var item1 = new ActivityLog();
            var item2 = new ActivityLog();
            var item3 = new ActivityLog();
            
            
           var items = new List<ActivityLog>() { item1, item2, item3 };

           var spec = new ClientHostActivityLogSpecification("","");
           List<ActivityLog> filteredList = items
               .Where(spec.WhereExpressions.First().Compile())
               .ToList();
           

            Assert.Contains(item1, filteredList);
            Assert.Contains(item2, filteredList);
            Assert.DoesNotContain(item3, filteredList);
        }
    }
}
