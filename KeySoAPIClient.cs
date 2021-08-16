namespace ClassLibrary
{
    public class KeySoAPIClient
    {
        private readonly SimpleReports client;

        public KeySoAPIClient(string token)
        {
            this.client = new SimpleReports(token);
        }
    }
}
