using System.Text.Json.Serialization;

namespace Store.Models
{
    public class SubCategory
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int CategoryId {  get; set; }
        [JsonIgnore]

        public Category Category { get; set; }
    }
}
