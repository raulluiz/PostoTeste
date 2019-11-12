using System.ComponentModel.DataAnnotations;

namespace Posto.ApplicationCore.ViewModels
{
    public class ComboSelect2VM
    {
        [Key]
        public string id { get; set; }

        public string text { get; set; }
        public bool disabled { get; set; } = false;
        public bool selected { get; set; } = false;
    }
}