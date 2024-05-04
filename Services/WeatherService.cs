using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using home_ui.Models.WeatherModel;

namespace home_ui.Services;

public interface IWeatherService
{

}

public class WeatherService : IWeatherService
{
    private const string WeatherApi = "https://api.openweathermap.org/data/3.0/onecall";

    public DateTime LastUpdated { get; set;} = DateTime.Now;
    public int DailyUpdates {get; set;} = 0;

    private readonly HttpClient _httpClient;
    private readonly IApiKeyService _apiKeys;
    private readonly ILocationService _locationService;

    public WeatherService(IApiKeyService apiKeys, ILocationService locationService,  HttpClient client)
    {
        _httpClient = client;
        _apiKeys = apiKeys;
        _locationService = locationService;
    }

    public async Task<WeatherReply> GetWeatherUpdate()
    {
        var location = await _locationService.GetCurrentLocation();
        var queryParameters = new Dictionary<string, string>
        {
            {"lat", location.Latitude },
            {"lon", location.Longitude},
            {"units", "imperial"},
            {"appid", _apiKeys.GetWeatherApiKey()}
        };

        var dictFormUrlEncoded = new FormUrlEncodedContent(queryParameters);
        var queryString = await dictFormUrlEncoded.ReadAsStringAsync();

        var request = new HttpRequestMessage(HttpMethod.Get, $"{WeatherApi}?{queryString}");

        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var reply = await response.Content.ReadFromJsonAsync<WeatherReply>();
        if (reply == null)
        {
            throw new Exception("Reply not received.");
        }

        return reply;
    }


}