namespace YTArchiveCollector.Helpers
{
    internal static class RequestsManager
    {
        internal static string GetVideoHtmlDocument(string URL)
        {
            using (HttpClient Client = new HttpClient())
            {
                var response = Client.GetAsync(URL).Result;
                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsStringAsync().Result;
                else
                    throw new Exception($"Запрос не выполнен успешно, сервер вернул: {response.StatusCode}");
            }
        }
    }
}
