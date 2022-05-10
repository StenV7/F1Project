using System.ComponentModel.DataAnnotations;

namespace F1Project.Models
{
    public class Circuit
    {
        public int ID { get; set; }
        [StringLength(50,ErrorMessage ="Macimumlengte van {0} is {1} tekens")]
        public string Name { get; set; } = String.Empty;
        public string? Description { get; set; } = String.Empty;
        public double? Latitute { get; set; } 
        public double? Longitute { get; set; }
        [DataType(DataType.Url)]
        [StringLength(250, ErrorMessage = "MaximumLengte van {0} is {1} tekens")]
        public string? wiki { get; set; } = String.Empty;
        public Country? country { get; set; }
        public IEnumerable<Result> Races { get; set; } = Enumerable.Empty<Result>();


    }
}
