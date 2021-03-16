using System.Linq;
using System.Threading.Tasks;
using Ardalis.Specification;
using AppInsights.Core.Entities;
using AppInsights.Core.Services;
using AppInsights.SharedKernel.Interfaces;
using Moq;
using Xunit;

namespace AppInsights.UnitTests.Core.Services
{
    public class ToDoItemSearchService_GetAllIncompleteItems
    {
        [Fact]
        public async Task ReturnsInvalidGivenNullSearchString()
        {
            var repo = new Mock<IRepository>();
            var service = new ActivityLogSearchService(repo.Object);

            var result = await service.ActivityLogSearchAync(null);

            Assert.Equal(Ardalis.Result.ResultStatus.Invalid, result.Status);
            Assert.Equal("searchString is required.", result.ValidationErrors.First().ErrorMessage);
        }

        [Fact]
        public async Task ReturnsErrorGivenDataAccessException()
        {
            string expectedErrorMessage = "Database not there.";
            var repo = new Mock<IRepository>();
            var service = new ActivityLogSearchService(repo.Object);
            repo.Setup(r => r.ListAsync(It.IsAny<ISpecification<ActivityLog>>()))
                .ThrowsAsync(new System.Exception(expectedErrorMessage));

            var result = await service.ActivityLogSearchAync("something","test");

            Assert.Equal(Ardalis.Result.ResultStatus.Error, result.Status);
            Assert.Equal(expectedErrorMessage, result.Errors.First());
        }

        [Fact]
        public async Task ReturnsListGivenSearchString()
        {
            var repo = new Mock<IRepository>();
            var service = new ActivityLogSearchService(repo.Object);

            var result = await service.ActivityLogSearchAync("xyz-0001");

            Assert.Equal(Ardalis.Result.ResultStatus.Ok, result.Status);
        }
    }
}
