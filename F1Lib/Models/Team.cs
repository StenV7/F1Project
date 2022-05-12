using System.ComponentModel.DataAnnotations;

namespace F1Lib.Models
{
    public class Team
    {
        public int ID { get; set; }
        [StringLength(50, ErrorMessage = "MaximumLengte van {0} is {1} tekens")]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        [DataType(DataType.Url)]
        [StringLength(250, ErrorMessage = "MaximumLengte van {0} is {1} Tekens")]
        [Display(Name ="wiki pagina")]
        public string? Wiki { get; set; } = string.Empty;
        public Country? Country { get; set; }
        public IEnumerable<Result> Races { get; set; }
    }
}
