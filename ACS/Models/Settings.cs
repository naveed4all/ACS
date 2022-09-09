using System.ComponentModel.DataAnnotations;

namespace ACS.Models
{
    public class Settings
    {
        [Key]
        public int SettingID { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
