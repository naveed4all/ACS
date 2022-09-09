using ACS.Models.User_Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACS.Models.Common_Model
{
    public class CommonModel
    {
        [ForeignKey("CreatedByUser")]
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow.AddHours(5);
        [ForeignKey("UpdatedByUser")]
        public int? UpdatedByUserID { get; set; }
        public DateTime? UpdatedDateTime { get; set; } = DateTime.UtcNow.AddHours(5);

        public User CreatedByUser { get; set; }
        public User? UpdatedByUser { get; set; }
        public bool IsActive { get; set; }

    }
}
