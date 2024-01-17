using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestMcfMVC.Models
{
    public class LocationModel
    {
        [Key]
        public string location_id { get; set; } = string.Empty;
        public string location_name { get; set; } = string.Empty;
        [NotMapped]
        public List<SelectListItem> location_name_list { get; set; } = new List<SelectListItem>();
    }
}
