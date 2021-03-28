using System;
using System.Collections.Specialized;
using System.Web;

namespace TwitchClips.API.Helper
{
    public class TwitchUriBuilder
    {
        public string BaseUrl { get; }
        public UriBuilder UriBuilder;

        private readonly NameValueCollection _queryParameters;
        
        public TwitchUriBuilder(string baseUrl)
        {
            BaseUrl = baseUrl;
            UriBuilder = new UriBuilder(baseUrl) { Port = -1 };
            
            _queryParameters = HttpUtility.ParseQueryString(UriBuilder.Query);
        }

        public TwitchUriBuilder AppendQueryParameter(string name, string value)
        {
            _queryParameters[name] = value;

            return this;
        }
        
        public TwitchUriBuilder AppendQueryParameter(string name, object value)
        {
            _queryParameters[name] = value.ToString();

            return this;
        }

        public string Build()
        {
            UriBuilder.Query = _queryParameters.ToString() ?? throw new Exception();
            return UriBuilder.ToString();
        }

        public override string ToString()
        {
            return Build();
        }
    }
}