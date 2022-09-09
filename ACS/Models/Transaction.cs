using ACS.Models.Common_Model;
using System.ComponentModel.DataAnnotations;

namespace ACS.Models
{
    public class Transaction : CommonModel
    {
        [Key]
        public int TransactionID { get; set; }
        public int CategoryID { get; set; }

        public Category? Category { get; set; }

        public int Amount { get; set; }
        public string? Note { get; set; }
        public DateTime Date { get; set; }
    }
}
