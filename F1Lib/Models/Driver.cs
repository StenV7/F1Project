using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace F1Lib.Models
{
    public class Driver
    {
        public int ID { get; set; }
        [StringLength(50, ErrorMessage = "Maximumlengte van {0} is {1} tekens")]
        public string Name { get; set; } = string.Empty;
        [DataType(DataType.Date)]
        [Display(Name ="Geboortedatum")]
        public DateTime? BirthDate { get; set; }
        [DataType(DataType.Url)]
        [Display(Name = "Wiki pagina")]
        [StringLength(250, ErrorMessage = "Maximumlengte van {0} is {1} tekens")]
        public string? Wiki { get; set; } = string.Empty;
        [RegularExpression("[MVO]{1}", ErrorMessage = "Alleen (M)an, (V)rouw of (O)nbekend")]
        [Column(TypeName = "char")]
        [Display(Name = "Geslacht")]
        [StringLength(1)]
        public string? Gender {get; set; }
        [DataType(DataType.Url)]
        [Display(Name ="Foto")]
        public string? ImageUrl { get; set; } = string.Empty;
        public Country? Country { get; set; }
        public IEnumerable<Result> Races { get; set; }
    }
}
