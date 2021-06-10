using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Qontak.Crm.Tests.Integrations
{
    public class DealServiceIntegrationTests
    {
        public DealServiceIntegrationTests()
        {
            QontakCrmClient = new QontakCrmClient(GetCrmOptions());

            DealService = new DealService(QontakCrmClient);
        }

        public QontakCrmOptions GetCrmOptions()
        {
            return new QontakCrmOptions
            {
                CrmUsername = "****",
                CrmPassword = "****",
                DealPipelineName = "Sales Pipeline"
            };
        }

        public QontakCrmClient QontakCrmClient { get; }
        public DealService DealService { get; }

        //[Fact(Skip = "For integration test only")]
        public async Task DealService_Integration_GetInfoAsync()
        {
            List<Info> results = await DealService.GetInfosAsync();

            Assert.NotNull(results);
            Assert.True(results.Count > 0, userMessage: "Results info not empty");
        }
    }
}
