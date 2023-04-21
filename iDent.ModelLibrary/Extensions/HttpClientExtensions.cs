using System.Net.Http.Headers;
using System.Text.Json;

namespace iDent.ModelLibrary.Extensions
{
    public static class HttpClientExtensions
    {
        public static async Task<T> ReadContentAsAsync<T>(this HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
                throw new ApplicationException($"Something went wrong invoking the API: {response.ReasonPhrase}");

            var stringData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonSerializer.Deserialize<T>(stringData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }

        public static Task<HttpResponseMessage> PostAsJsonAsync<T>(this HttpClient httpClient, string url, T data)
        {
            var stringData = JsonSerializer.Serialize(data);
            var content = new StringContent(stringData);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return httpClient.PostAsync(url, content);
        }

        public static Task<HttpResponseMessage> PutAsJsonAsync<T>(this HttpClient httpClient, string url, T data)
        {
            var stringData = JsonSerializer.Serialize(data);
            var content = new StringContent(stringData);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return httpClient.PutAsync(url, content);
        }
    }
}