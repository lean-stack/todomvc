using Newtonsoft.Json;

namespace TodoMVC.Backend.Models
{
    public class Todo
    {
        // Alternative: http://nyqui.st/json-net-newtonsoft-json-lowercase-keys

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "txt")]
        public string Txt { get; set; }
        [JsonProperty(PropertyName = "done")]
        public bool Done { get; set; }
    }
}