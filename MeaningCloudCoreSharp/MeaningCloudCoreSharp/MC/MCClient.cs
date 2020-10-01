using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MeaningCloudCoreSharp.MC
{
    public class MCClient
    {
        #region Privte Members
        private MCParameters defaultParameters = null;
        private string defaultMCEndpointUrl;
        private string defaultMCRequestUri;
        #endregion

        #region Constructors
        public MCClient(MCParameters parameters, string mcEndpointUrl = "https://api.meaningcloud.com", string mcRequstUri = "/summarization-1.0")
        {
            if (parameters == null)
            {
                throw new InvalidOperationException("MCParameters cannot be null.");
            }

            if (string.IsNullOrWhiteSpace(mcEndpointUrl))
            {
                throw new InvalidOperationException("The MeaningCloud endpoint URL cannot be null or empty. Example: \"https://api.meaningcloud.com\"");
            }

            if (string.IsNullOrWhiteSpace(mcRequstUri))
            {
                throw new InvalidOperationException("The mcRequstUri cannot be null or empty. Example: \"/summarization-1.0\"");
            }

            if (string.IsNullOrWhiteSpace(parameters.Key))
            {
                throw new InvalidOperationException("The API Key cannot be null or empty.");
            }

            if (string.IsNullOrWhiteSpace(parameters.Sentences))
            {
                throw new InvalidOperationException("The number of sentences to return cannot be null or empty.");
            }

            if (!string.IsNullOrWhiteSpace(parameters.Url) && !string.IsNullOrWhiteSpace(parameters.Txt))
            {
                throw new InvalidOperationException("Either \"Url\" or \"Txt\" must be part of your request but not both.");
            }

            if (string.IsNullOrWhiteSpace(parameters.Url) && string.IsNullOrWhiteSpace(parameters.Txt))
            {
                throw new InvalidOperationException("Either \"Url\" or \"Txt\" must be part of your request.");
            }

            defaultParameters = parameters;
            defaultMCEndpointUrl = mcEndpointUrl;
            defaultMCRequestUri = mcRequstUri;
        }
        #endregion

        public MC Download()
        {
            string Json = GetJsonAsync(defaultParameters).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<MC>(Json);
        }

        #region Private Methods
        private async Task<string> GetJsonAsync(MCParameters mcParameters)
        {
            var Client = new HttpClient
            {
                BaseAddress = new Uri(defaultMCEndpointUrl)
            };
            
            var formContent = new FormUrlEncodedContent(mcParameters.ToList());

            using var responseMessage = await Client.PostAsync(defaultMCRequestUri, formContent);
            using var content = responseMessage.Content;
            return await content.ReadAsStringAsync();
        }
        #endregion
    }
}
