using System.Net;

namespace ExampleStub.Tests;

public class HttpClientStubTests
{
    [Fact]
    public async Task Test_Stubbed_Http_Request()
    {
        var responseMessage = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent("{\"message\": \"Result from stub\"}")
        };

        var handlerStub = new HttpMessageHandlerStub(responseMessage);
        
        var httpClient = new HttpClient(handlerStub);

        var response = await httpClient.GetAsync("https://external/api");

        Assert.True(response.IsSuccessStatusCode);

        var content = await response.Content.ReadAsStringAsync();
        Assert.Equal("{\"message\": \"Result from stub\"}", content);
    }
}
