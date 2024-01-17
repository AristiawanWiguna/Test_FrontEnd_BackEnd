using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace TestMcfAPI
{
    public class Location
    {
        [Key]
        public string location_id { get; set; } = string.Empty;
        public string location_name { get; set; } = string.Empty;
    }
}
