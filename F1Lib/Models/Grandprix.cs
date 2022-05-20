using System.ComponentModel.DataAnnotations;

namespace F1Lib.Models
{
    public class Grandprix
    {
        public int ID { get; set; }
        [StringLength(50, ErrorMessage = "MaximumLengte van {0} is {1} tekens")]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        [DataType(DataType.Url)]
        [StringLength(250,ErrorMessage ="MaximumLengte van {0} is {1} Tekens")]
        public string? Wiki { get; set; } = string.Empty;
        public Country? Country { get; set; }

        public ICollection<Result> Races { get; set; }
    }
}
