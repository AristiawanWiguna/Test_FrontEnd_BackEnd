using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TestMcfMVC.Models
{
    public class LoginViewModel
    {
        public int user_id { get; set; }
        [Required,DisplayName("User Name")]
        public string user_name { get; set; } = string.Empty;
        [Required]
        public string password { get; set; } = string.Empty;
        [Required]
        public bool is_active { get; set; }
    }
}
