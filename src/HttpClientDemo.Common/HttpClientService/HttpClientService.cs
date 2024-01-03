using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace HttpClientDemo.Common.HttpClientService;

public class HttpClientService(IHttpClientFactory clientFactory) : IHttpClientService
{
    public async Task<TRes?> GetRequestAsync<TRes>(string baseUrl, string url, string? token = null) where TRes : class
    {
        var client = CreateClient(baseUrl, token);
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        return await GetResponseResultAsync<TRes>(client, request);
    }

    public async Task<TRes?> PostRequestAsync<TReq, TRes>(string baseUrl, string url, TReq requestModel, string? token = null)
        where TRes : class
        where TReq : class
    {
        var client = CreateClient(baseUrl, token);
        var request = new HttpRequestMessage(HttpMethod.Post, url)
        {
            Content = new StringContent(JsonConvert.SerializeObject(requestModel), null, "application/json")
        };
        return await GetResponseResultAsync<TRes>(client, request);
    }

    public async Task<bool> PutRequestAsync<TReq>(string baseUrl, string requestUrl, TReq requestModel, string? token = null) where TReq : class
    {
        var client = CreateClient(baseUrl, token);
        var request = new HttpRequestMessage(HttpMethod.Put, requestUrl)
        {
            Content = new StringContent(JsonConvert.SerializeObject(requestModel), null, "application/json")
        };
        return await SendRequestAsync(client, request);
    }

    private async Task<bool> SendRequestAsync(HttpClient client, HttpRequestMessage request)
    {
        var response = await client.SendAsync(request);

        // Return true if the status code is 204 No Content, indicating success
        return response is { IsSuccessStatusCode: true, StatusCode: System.Net.HttpStatusCode.NoContent };
    }

    private async Task<TRes?> GetResponseResultAsync<TRes>(HttpClient client, HttpRequestMessage request) where TRes : class
    {
        var response = await client.SendAsync(request);
        var responseString = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<TRes>(responseString);
        return response.IsSuccessStatusCode ? result : throw new ArgumentException(response.ReasonPhrase);
    }

    private HttpClient CreateClient(string baseUrl, string? token)
    {
        var client = clientFactory.CreateClient();
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        client.BaseAddress = new Uri(baseUrl);
        if (!string.IsNullOrEmpty(token))
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
        return client;
    }
}