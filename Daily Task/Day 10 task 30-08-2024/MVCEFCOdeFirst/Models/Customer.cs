using System.ComponentModel.DataAnnotations;

namespace MVCEFCOdeFirst.Models
{
    public class Customer
    {
        [Key]
        public int custId {  get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }

        public List<Order>? orders { get; set; }
    }

}
