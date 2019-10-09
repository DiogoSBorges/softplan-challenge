namespace Diogo.Softplan.Challenge.Api2.Api.DI.Provider
{
    public class Api1Provider
    {
        public string Url { get; private set; }

        public Api1Provider()
        {

        }

        public Api1Provider(string url)
        {
            Url = url;
        }
    }
}
