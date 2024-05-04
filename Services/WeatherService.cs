using System;
using System.Net.Http;
using System.Threading.Tasks;
using home_ui.Models.WeatherModel;

namespace home_ui.Services;

public interface IWeatherService
{

}


public class WeatherService : IWeatherService
{

    public DateTime LastUpdated { get; set;} = DateTime.Now;
    public int DailyUpdates {get; set;} = 0;

    private readonly HttpClient _httpClient;
    private readonly IApiKeyService _apiKeys;

    public WeatherService(IApiKeyService apiKeys, HttpClient client)
    {
        _httpClient = client;
        _apiKeys = apiKeys;
    }

    public async Task<WeatherModel> GetWeatherUpdate()
    {
        throw new NotImplementedException();
    }


}