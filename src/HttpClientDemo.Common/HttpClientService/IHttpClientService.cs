namespace HttpClientDemo.Common.HttpClientService;

public interface IHttpClientService
{
    Task<TRes?> PostRequestAsync<TReq, TRes>(string baseUrl, string requestUrl, TReq requestModel, string? token = null)
      where TRes : class
      where TReq : class;

    Task<bool> PutRequestAsync<TReq>(string baseUrl, string requestUrl, TReq requestModel, string? token = null)
        where TReq : class;

    Task<TRes?> GetRequestAsync<TRes>(string baseUrl, string requestUrl, string? token = null)
      where TRes : class;
}