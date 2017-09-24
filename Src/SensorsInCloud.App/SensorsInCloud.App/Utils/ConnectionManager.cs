using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

public class ConnectionManager
{
    private String connectionUrl = "http://localhost:56666/api/";
    private HttpClient _client;
    public ConnectionManager()
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri(connectionUrl);

    }

    public async Task<List<SensorLine>> GetSensors()
    {
        
        try
        {
            HttpResponseMessage response = await _client.GetAsync("sensors" );
            String text = await response.Content.ReadAsStringAsync();

            List<SensorLine> result =
                JsonConvert.DeserializeObject<List<SensorLine>>(text);

            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

   
}

