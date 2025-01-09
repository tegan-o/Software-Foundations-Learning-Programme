//API client
//hanles external API calls.

using System.Net.Http;
using System.Threading.Tasks;

namespace CityInfo.API.Clients{

    public class VRNAddressValidationClient
    {
        private readonly HttpClient _httpClient;

        public VRNAddressValidationClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> ValidateVRNAndAddressAsync(string vrn, string address)
        {
            // Simulate API validation (assume always true)
            return await Task.FromResult(true);
        }
    }

}