using ACS.Models.Common_Model;
using System.ComponentModel.DataAnnotations;

namespace ACS.Models
{
    public class Size : CommonModel
    {
        [Key]
        public int SizeID { get; set; }
        public string Name { get; set; }

        public ICollection<Inventory> Inventories { get; set; }

    }
}
