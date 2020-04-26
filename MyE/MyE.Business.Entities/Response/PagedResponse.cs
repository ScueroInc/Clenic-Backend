using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MyE.Business.Entities.Response
{
    public class PagedResponse<T>
    {
        [Display(Name = "data")]
        [JsonProperty(PropertyName = "data")]
        public IEnumerable<T> Data { get; set; }

        [Display(Name = "links")]
        [JsonProperty(PropertyName = "links")]
        public PagedResponseLink[] Links { get; set; }

        [Display(Name = "current_page")]
        [JsonProperty(PropertyName = "current_page")]
        public int CurrentPage { get; set; }

        [Display(Name = "items_on_page")]
        [JsonProperty(PropertyName = "items_on_page")]
        public int ItemsOnPage { get; set; }

        [Display(Name = "total_items")]
        [JsonProperty(PropertyName = "total_items")]
        public int TotalItems { get; set; }

        [Display(Name = "total_pages")]
        [JsonProperty(PropertyName = "total_pages")]
        public int TotalPages { get; set; }

        [Display(Name = "has_more_items")]
        [JsonProperty(PropertyName = "has_more_items")]
        public bool HasMoreItems { get; set; }
    }

    public class PagedResponseLink
    {
        [Display(Name = "rel")]
        [JsonProperty(PropertyName = "rel")]
        public string Rel { get; set; }

        [Display(Name = "href")]
        [JsonProperty(PropertyName = "href")]
        public string Href { get; set; }
    }
}
