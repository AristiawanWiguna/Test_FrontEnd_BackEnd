using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace TestMcfAPI
{
    public class Users
    {
        [Key]
        public int user_id { get; set; }
        public string user_name { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public bool is_active { get; set; }
    }
}
