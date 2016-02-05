namespace Planbox.Net
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;

    public class PlanboxClient : HttpClient
    {
        public PlanboxClient(string accessToken, HttpMessageHandler handler) : base(handler)
        {
            if (string.IsNullOrEmpty(accessToken)) throw new Exception("Missing Planbox access token - please call Login first");

            this.BaseAddress = new Uri("https://work.planbox.com/");
            this.DefaultRequestHeaders.Authorization = this.AccessTokenAsAuthenticationHeader(accessToken);
            this.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public AuthenticationHeaderValue AccessTokenAsAuthenticationHeader(string accessToken)
        {
            var accessTokenString = Convert.ToBase64String(
                        Encoding.ASCII.GetBytes(string.Format("{0}:{1}", accessToken, accessToken)));
            return new AuthenticationHeaderValue("Basic", accessTokenString);
        }
    }
}
