using RestSharp;
using RestSharp.Authenticators;
using SnakeOnlineClient.Models;
using System.Threading.Tasks;
using System.Windows;
using DataFormat = RestSharp.DataFormat;

namespace SnakeOnlineClient.ViewModels
{
    public sealed class Client
    {
        private readonly RestClient _httpClient;
        public Client (string uri)
        {
            _httpClient = new RestClient(uri);
        }

        public async Task<string> GetNameAsync(string token)
        {
            var request = new RestRequest($"api/Player/name", Method.GET);
            request.AddQueryParameter("token", token);
            var response = await _httpClient.ExecuteGetTaskAsync<NameResponse>(request);
            return response.Data.Name;
        }

        public async Task<GameBoardResponse> GetGameBoardAsync()
        {
            var request = new RestRequest($"api/Player/gameboard", Method.GET);
            var response = await _httpClient.ExecuteGetTaskAsync<GameBoardResponse>(request);
            return response.Data;
        }

        public void PostSnakeDirection(string _token, string _direction)
        {
            var request = new RestRequest($"api/Player/direction", Method.POST);
            request.AddHeader("Accept", "application/json");
            request.Parameters.Clear();
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new { token = _token, direction = _direction });
            var response = _httpClient.Execute(request);
        }
    }
}
