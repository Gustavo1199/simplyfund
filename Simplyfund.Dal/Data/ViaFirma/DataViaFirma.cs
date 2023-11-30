using Microsoft.Extensions.Configuration;
using Simplyfund.Dal.DataInterface.ViaFirma;
using SimplyFund.Domain.Dto.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Simplyfund.Dal.Data.ViaFirma
{
    public class DataViaFirma : IDataViafirma
    {
        public readonly IHttpClientFactory _httpClientFactory;
        public HttpClient httpClient;
        public readonly IConfiguration _config;

        public string? user = "";
        public string? pass = "";
        public string? BaseUrl = "";

        public DataViaFirma(IHttpClientFactory httpClientFactory, IConfiguration config)
        {
            _config = config;
            _httpClientFactory = httpClientFactory;
            httpClient = _httpClientFactory.CreateClient();

            user = _config.GetSection("ViaFirmaSetting:Usuario").Value; 
            pass = _config.GetSection("ViaFirmaSetting:Password").Value; 
            BaseUrl = _config.GetSection("ViaFirmaSetting:BaseUrl").Value;

            httpClient.BaseAddress = new Uri(BaseUrl);

            string? authenticationString = $"{user}:{pass}";
            string base64EncodedAuthenticationString = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(authenticationString));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", base64EncodedAuthenticationString);


        }

        public async Task<string> httpPostRequest(string content, string enpoint)
        {
            try
            {
                var contents = new StringContent(content, Encoding.UTF8, Application.Json);

                var request = httpClient.PostAsync(enpoint, contents).Result;

                if (request.IsSuccessStatusCode)
                {

                    var responses = await request.Content.ReadAsStringAsync();

                    return responses;
                }
                else
                {
                    throw new Exception("Error: " + request);
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
