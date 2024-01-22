using System.Text.Json.Serialization;

namespace SeleniumExample.DataModel;

[Serializable]
public class SeleniumOptions
{
    public string BaseUrl { get; set; } = string.Empty;
    public string[] DriverArguments { get; set; } = Array.Empty<string>();
}