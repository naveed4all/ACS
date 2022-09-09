

using ACS.Models;
using ACS.Models.Common_Model;

namespace ACS.ViewModels
{
    public class TransactionView : CommonModel
    {
        public int TransactionID { get; set; }
        public int CategoryID { get; set; }

        public Category Category { get; set; }

        public int Amount { get; set; }
        public string? Note { get; set; }
        public DateTime Date { get; set; }
    }
}
