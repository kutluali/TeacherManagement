namespace TeacherManagementUI.Helpers
{
    public static class HttpClientIstance
    {
        public static HttpClient CreateClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7139/api/");
            return client;
        }
    }
}
