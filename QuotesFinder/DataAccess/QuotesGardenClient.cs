using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using QuotesFinder.DataAccess.Models;

namespace QuotesFinder.DataAccess;

public class QuotesGardenClient(Func<HttpClient> httpClientFactory) : IQuotesGardenClient
{
    public async Task<QuotesResponse> GetQuotesAsync(QuotesParams quoteParams)
    {
        var endpointUrlBuilder = new StringBuilder();
        // TODO: usar Attributes
        endpointUrlBuilder.Append("https://quote-garden.onrender.com/api/v3/quotes?");
        if (quoteParams.Author is not null)
            endpointUrlBuilder.Append($"author={quoteParams.Author}&");
        if (quoteParams.Limit is not null)
            endpointUrlBuilder.Append($"limit={quoteParams.Limit}&");
        if (quoteParams.Genre is not null)
            endpointUrlBuilder.Append($"genre={quoteParams.Genre}&");
        if (quoteParams.Page is not null)
            endpointUrlBuilder.Append($"page={quoteParams.Page}&");
        if (quoteParams.Query is not null)
            endpointUrlBuilder.Append($"query={quoteParams.Query}");
        using HttpClient httpClient = httpClientFactory(); 
        var httpRespMsg = await httpClient.GetAsync(endpointUrlBuilder.ToString());
        httpRespMsg.EnsureSuccessStatusCode();
        var jsonStream = await httpRespMsg.Content.ReadAsStreamAsync();
        var response = await JsonSerializer.DeserializeAsync<QuotesResponse>(jsonStream);
        return response!;
    }
}