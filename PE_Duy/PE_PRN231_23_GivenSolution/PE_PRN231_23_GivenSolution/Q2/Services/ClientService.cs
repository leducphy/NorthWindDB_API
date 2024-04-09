using Microsoft.AspNetCore.Authentication;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Q2.Services
{
    public class ClientService
    {
        private readonly HttpClient _client;
        private readonly HttpContext _httpContext;

        public ClientService(HttpContext httpContext, HttpClient? client = null)
        {
            _httpContext = httpContext;
            _client = client ?? new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:5100");
            _client.DefaultRequestHeaders.Clear();
        }

        public async Task<T?> GetAll<T>(string relativeUrl)
        {
            try
            {
                var res = await _client.GetAsync(relativeUrl);
                var content = await res.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
                var options1 = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };
                return JsonSerializer.Deserialize<T>(content, options1);
            }
            catch
            {
                return default;
            }
        }

        public async Task<T?> GetDetail<T>(string relativeUrl, string? param)
        {
            try
            {
                var res = await _client.GetAsync(relativeUrl + param);
                if ((int)res.StatusCode == 401) await _httpContext.SignOutAsync("CookieAuthentication");
                var content = await res.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
                var options1 = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };
                return JsonSerializer.Deserialize<T>(content, options1);
            }
            catch
            {
                return default;
            }
        }

        public async Task<HttpResponseMessage> Post<T>(string relativeUrl, object? data)
        {
            try
            {
                var res = await _client.PostAsync(relativeUrl, GetBody(data));
                if ((int)res.StatusCode == 401) await _httpContext.SignOutAsync("CookieAuthentication");
                return res;
            }
            catch
            {
                return default;
            }
        }

        public async Task<T?> PostSearch<T>(string relativeUrl, object? data)
        {
            try
            {
                var res = await _client.PostAsync(relativeUrl, GetBody(data));
                if ((int)res.StatusCode == 401) await _httpContext.SignOutAsync("CookieAuthentication");
                var content = await res.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(content);
            }
            catch
            {
                return default;
            }
        }

        public async Task<T?> Patch<T>(string relativeUrl, object? data)
        {
            try
            {
                var res = await _client.PatchAsync(relativeUrl, GetBody(data));
                if ((int)res.StatusCode == 401) await _httpContext.SignOutAsync("CookieAuthentication");
                var content = await res.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(content);
            }
            catch
            {
                return default;
            }
        }

        /*public async Task<T?> Delete<T>(string relativeUrl, string? param)
        {
            try
            {
                var res = await _client.DeleteAsync(relativeUrl+param);
                if ((int)res.StatusCode == 401) await _httpContext.SignOutAsync("CookieAuthentication");
                var content = await res.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(content);
            }
            catch
            {
                return default;
            }
        }*/

        public async Task<string?> Get(string relativeUrl, string param)
        {
            try
            {
                var res = await _client.GetAsync(relativeUrl+param);
                if ((int)res.StatusCode == 401) await _httpContext.SignOutAsync("CookieAuthentication");
                return await res.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
            }
            catch
            {
                return default;
            }
        }

        public async Task<string?> PostAdd(string relativeUrl, object? data)
        {
            try
            {
                var res = await _client.PostAsync(relativeUrl, GetBody(data));
                if ((int)res.StatusCode == 401) await _httpContext.SignOutAsync("CookieAuthentication");
                return await res.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
            }
            catch
            {
                return default;
            }
        }

        public async Task<HttpResponseMessage> Export(string relativeUrl, object? data)
        {
            try
            {
                var res = await _client.PostAsync(relativeUrl, GetBody(data));
                if ((int)res.StatusCode == 401) await _httpContext.SignOutAsync("CookieAuthentication");
                return res;
            }
            catch
            {
                return default;
            }
        }

        public async Task<HttpResponseMessage> PostReturnResponse(string relativeUrl, object? data)
        {
            try
            {
                var res = await _client.PostAsync(relativeUrl, GetBody(data));
                return res;
            }
            catch
            {
                return default;
            }
        }

        public async Task<string?> Put(string relativeUrl, object? data)
        {
            try
            {
                var res = await _client.PutAsync(relativeUrl, GetBody(data));
                if ((int)res.StatusCode == 401) await _httpContext.SignOutAsync("CookieAuthentication");
                return await res.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
            }
            catch
            {
                return default;
            }
        }

        public async Task<string?> Delete(string relativeUrl, string? param)
        {
            try
            {
                var res = await _client.DeleteAsync(relativeUrl + param);
                if ((int)res.StatusCode == 401) await _httpContext.SignOutAsync("CookieAuthentication");
                return await res.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
            }
            catch
            {
                return default;
            }
        }

        private static StringContent? GetBody(object? data)
        {
            if (data == null) return null;
            var body = JsonSerializer.Serialize(data);
            return new StringContent(body, Encoding.UTF8, "application/json");
        }
    }
}