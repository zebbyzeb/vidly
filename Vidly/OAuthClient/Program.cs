using System;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;

namespace OAuthClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var response = GetClientToken().GetAwaiter().GetResult();
            CallApi(response);
        }

        static async Task<TokenResponse> GetClientToken()
        {
            var _client = new HttpClient();

            var tokenRequest = new ClientCredentialsTokenRequest();
            tokenRequest.Address = "http://localhost:5000/connect/token";
            tokenRequest.ClientId = "silicon";
            tokenRequest.ClientSecret = "F621F470-9731-4A25-80EF-67A6F7C5F4B8";
            tokenRequest.Scope = "api1";

            var response = await _client.RequestClientCredentialsTokenAsync(tokenRequest);

            //var client = new TokenClient(
            //    "http://localhost:5000/connect/token",
            //    "silicon",
            //    "F621F470-9731-4A25-80EF-67A6F7C5F4B8");

            //var res = await client.RequestClientCredentialsAsync("api1");
            //return res;

            return response;
        }

        static void CallApi(TokenResponse response)
        {
            var client = new HttpClient();
            client.SetBearerToken(response.AccessToken);

            Console.WriteLine(client.GetStringAsync("http://localhost:7001/api/customers").Result);
        }
    }
}
