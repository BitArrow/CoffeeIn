using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using UWP.DTO;
using UWP.Extensions;
using UWP.Services.Interfaces;

namespace UWP.Services
{
    public class APIBaseService
    {
        private readonly HttpClient _httpClient;


        public APIBaseService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(App.WebApiEndpoint);
            if (!string.IsNullOrEmpty(App.AuthToken))
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(App.AuthToken);
        }

        public async Task<T> GetAsync<T>(string requestUri)
        {
            try
            {
                await ValidateToken();
                return await ReadContentAsync<T>(await _httpClient.GetAsync(requestUri));
            }
            catch (Exception ex)
            {
                Debug.Write("APIService: " + ex.ToString());
                throw new HttpRequestException(ex.ToString());
            }
        }

        public async Task<T> PostAsync<T>(string requestUri, object body)
        {
            try
            {
                await ValidateToken();
                return await ReadContentAsync<T>(await _httpClient.PostAsync(requestUri, body.UrlEncode()));
            }
            catch (Exception ex)
            {
                Debug.Write("APIService: " + ex.ToString());
                throw new HttpRequestException(ex.ToString());
            }
        }

        public async Task<T> PutAsync<T>(string requestUri, object body)
        {
            try
            {
                await ValidateToken();
                return await ReadContentAsync<T>(await _httpClient.PutAsync(requestUri, body.UrlEncode()));
            }
            catch (Exception ex)
            {
                Debug.Write("APIService: " + ex.ToString());
                throw new HttpRequestException(ex.ToString());
            }
        }

        private async Task<T> ReadContentAsync<T>(HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync();
            try
            {
                return JsonConvert.DeserializeObject<T>(content);
            }
            catch (Exception ex)
            {
                var error = JsonConvert.DeserializeObject<ErrorDto>(content);
                Debug.Write(error.ToString());
                return default(T);
            }
        }

        public async Task DeleteAsync(string requestUri)
        {
            try
            {
                await ValidateToken();
                await _httpClient.DeleteAsync(requestUri);
            }
            catch (Exception ex)
            {
                Debug.Write("APIService: " + ex.ToString());
                throw new HttpRequestException(ex.ToString());
            }
        }

        private async Task ValidateToken()
        {
            // TODO add validation
        }

        public async Task<T> GetAsync<T>(Uri requestUri)
        {
            return await GetAsync<T>(requestUri.ToString());
        }

        public async Task<T> PostAsync<T>(Uri requestUri, object body)
        {
            return await PostAsync<T>(requestUri.ToString(), body);
        }

        public async Task<T> PutAsync<T>(Uri requestUri, object body)
        {
            return await PutAsync<T>(requestUri.ToString(), body);
        }

        public async Task DeleteAsync(Uri requestUri)
        {
            await DeleteAsync(requestUri.ToString());
        }


    }
}
