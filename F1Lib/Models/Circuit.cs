using System.ComponentModel.DataAnnotations;

namespace F1Project.Models
{
    public class Circuit
    {
        public int ID { get; set; }
        [StringLength(50, ErrorMessage = "Macimumlengte van {0} is {1} tekens")]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public double? Latitute { get; set; }
        public double? Longitute { get; set; }
        [DataType(DataType.Url)]
        [StringLength(250, ErrorMessage = "MaximumLengte van {0} is {1} tekens")]
        public string? Wiki { get; set; } = string.Empty;
        public Country? Country { get; set; }
        public IEnumerable<Result> Races { get; set; } = Enumerable.Empty<Result>();


    }
}
