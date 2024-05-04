using System.Threading.Tasks;

namespace home_ui.Services;

public interface ILocationService
{
    Task<(string Longitude, string Latitude)> GetCurrentLocation(); 
}

public class LocationService : ILocationService
{
    public Task<(string Longitude, string Latitude)> GetCurrentLocation()
    {
        var longitude = "-111.886797";
        var latitude = "40.7596198";

        return Task.FromResult((longitude, latitude));
    }
}