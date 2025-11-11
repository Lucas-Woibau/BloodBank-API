using Newtonsoft.Json;

namespace BloodBank.Application.Models
{
    public class ZipCodeResult
    {
        [JsonProperty("cep")]
        public string Code { get; set; }

        [JsonProperty("logradouro")]
        public string PublicPlace { get; set; }

        [JsonProperty("localidade")]
        public string City { get; set; }

        [JsonProperty("uf")]
        public string State { get; set; }
    }

}
