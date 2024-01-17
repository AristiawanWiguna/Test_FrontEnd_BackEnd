using System.ComponentModel.DataAnnotations;

namespace TestMcfAPI
{
    public class BPKB
    {
        [Key]
        public int ID { get; set; }
        public string agreement_number { get; set; } = string.Empty;
        public string bpkb_no { get; set; } = string.Empty;
        public string branch_id { get; set; } = string.Empty;
        public DateTime bpkb_date { get; set; }
        public string faktur_no { get; set; } = string.Empty;
        public DateTime faktur_date { get; set; }
        public string location_id { get; set; } = string.Empty;
        public string police_no { get; set; } = string.Empty;
        public DateTime bpkb_date_in { get; set; }
        public string created_by { get; set; } = string.Empty;
        public DateTime created_on { get; set; }
        public string last_updated_by { get; set; } = string.Empty;
        public DateTime last_updated_on { get; set; }
    }
}
