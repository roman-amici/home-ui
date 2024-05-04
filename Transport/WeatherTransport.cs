using System;
using System.Collections.Generic;

public class WeatherReply
{
    public DetailedWeather Current {get; set;} = null!;
    public List<DetailedWeather> Minutely {get; set;} = new List<DetailedWeather>();
    public List<DetailedWeather> Hourly {get; set;} = new List<DetailedWeather>();

    public List<WeatherAlert> Alerts{get; set;} = new List<WeatherAlert>();

}

public class WeatherAlert
{
    public string sender_name {get; set;} = default!;
    public string Event {get; set;} = default!;
    public DateTime Start {get; set;}
    public DateTime End {get; set;}

    public string Description {get; set;} = default!;
}

public class WeatherSummary
{
    public string Main {get; set;} = default!;
    public string Description {get; set;} = default!;
    public string Icon {get; set;} = default!;
}

public class DetailedWeather
{
    public DateTime Dt {get; set;}
    public DateTime Sunrise {get; set;}
    public DateTime Sunset {get; set;}
    public float FeelsLike {get; set;}
    public int Clouds {get; set;}

    public WeatherSummary Weather {get; set;} = null!;
}

public class DailyTemperature
{
    public float Day {get; set;}
    public float Min {get; set;}
    public float Max {get; set;}
    public float Night {get; set;}
    public float Eve {get; set;}
    public float Morn {get; set;}
}

public class DailyWeather
{
    public DateTime Dt {get; set;}
    public DateTime Sunrise {get; set;}
    public DateTime Sunset {get; set;}
    public DateTime Moonrise {get; set;}
    public DateTime Moonset {get; set;}

    public DailyTemperature Temp {get; set;} = null!;
    public DailyTemperature FeelsLike {get; set;} = null!;
    public WeatherSummary Weather {get; set;} = null!;


}