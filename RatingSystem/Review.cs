using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ReviewSystem
{
    public class Review
    {
        [JsonProperty(PropertyName = "Value")]
        public int Value { get; set; }

        [JsonProperty(PropertyName = "Room")]
        public int Room { get; set; }

        [JsonProperty(PropertyName = "Hotel")]
        public string HotelName { get; set; }

        [JsonProperty(PropertyName = "Title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "Content")]
        public string Label { get; set; }

        [JsonProperty(PropertyName = "Date")]
        public DateTime Date { get; set; }

        [JsonProperty(PropertyName = "Author")]
        public string Author { get; set; }
    }
}
