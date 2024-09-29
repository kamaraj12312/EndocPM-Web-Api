using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EndocPM.WebAPI
{
    public partial class Product
    {
        [Key]
        public int ID { get; set; }
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public int NoOfProvider { get; set; }
        public int NoOfUser { get; set; }
        public int NoOfMember { get; set; }
        public decimal Rate { get; set; }
        public decimal Discount { get; set; }
        public decimal DiscountRate { get; set; }
        public Nullable<int> PlanRoleSetupID { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
