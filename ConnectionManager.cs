using System;

public class ConnectionManager
{
    private String connectionUrl = Const.BaseUrl + "api/";
    private HttpClient _client;
    public ConnectionManager()
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri(connectionUrl);

    }

    public async Task<DefaultResponsePagin<List<Item_OUT>>> SearchItems(SearchInput searchInput)
    {
        String query = "";
        if (searchInput != null)
        {
            query = "?";
            if (searchInput.PageNum >= 1)
            {
                query += "pagenum=" + searchInput.PageNum + "&";
            }
            if (!String.IsNullOrEmpty(searchInput.Text))
            {
                query += "text=" + Uri.EscapeDataString(searchInput.Text) + "&";
            }
        }
        if (query.EndsWith("&"))
        {
            query = query.Substring(0, query.Length - 1);
        }
        try
        {
            HttpResponseMessage response = await _client.GetAsync("items/search" + query);
            String text = await response.Content.ReadAsStringAsync();

            DefaultResponsePagin<List<Item_OUT>> result =
                JsonConvert.DeserializeObject<DefaultResponsePagin<List<Item_OUT>>>(text);

            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<DefaultResponse<Item_full_OUT>> GetItem(String slug)
    {

        try
        {
            HttpResponseMessage response = await _client.GetAsync("items/slug/" + slug);
            String text = await response.Content.ReadAsStringAsync();

            DefaultResponse<Item_full_OUT> result =
                JsonConvert.DeserializeObject<DefaultResponse<Item_full_OUT>>(text);

            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}

