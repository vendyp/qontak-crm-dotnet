using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using Moq;

namespace Qontak.Crm.Tests
{
    public static class MockCrmClient
    {
        public static IQontakCrmClient GetMockedObjectOfCrmClient<T>() where T : IQontakCrmEntity
        {
            var moq = new Mock<IQontakCrmClient>();

            moq.Setup(x => x.RequestAsync<T>(
                It.IsAny<HttpMethod>(),
                It.IsAny<string>(),
                It.IsAny<HttpContent>(),
                It.IsAny<CancellationToken>()))
                .ReturnsAsync(Activator.CreateInstance<T>());

            moq.Setup(x => x.RequestListAsync<T>(
                It.IsAny<HttpMethod>(),
                It.IsAny<string>(),
                It.IsAny<HttpContent>(),
                It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<T>());

            moq.Setup(x => x.RequestPaginationListAsync<T>(
                It.IsAny<HttpMethod>(),
                It.IsAny<string>(),
                It.IsAny<HttpContent>(),
                It.IsAny<CancellationToken>()))
                .ReturnsAsync(new PaginationResponse<T>());

            return moq.Object;
        }
    }
}
