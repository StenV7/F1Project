using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace F1Project.Models
{
    public class Country
    {
        [RegularExpression("[A-Z]{2}",ErrorMessage ="Landcode moet bestaan uit 2 hoofdletters")]
        [Column(TypeName = "char")]
        [Key]
        [Display(Name ="Landcode")]
        [StringLength(2)]
        public string CountryCode { get; set; } = string.Empty;
        [Required]
        [Display(Name = "land")]
        [StringLength(100,ErrorMessage ="Maximum voor {0{} is {1} tekens")]
        public string CountryName { get; set; } = string.Empty; 
        [RegularExpression("[A-Z]{3}", ErrorMessage = "Code moet bestaan uit 3 hoofdletters")]
        [Column(TypeName = "char")]
        [Display(Name = "Landcode3")]
        [StringLength(3)]

        public string? Code3 { get; set; } = string.Empty;  
        [StringLength(5,ErrorMessage = "Maximum voor {0{} is {1} tekens")]
        public string? CountryNumber { get; set; } = string.Empty;
        [StringLength(250, ErrorMessage = "Maximum voor {0{} is {1} tekens")]
        [Display(Name ="Vlag")]
        public string? FlagUrl { get; set; } = string.Empty;
        public IEnumerable<Driver> Drivers { get; set; } = Enumerable.Empty<Driver>();
        public IEnumerable<Team> Teams { get; set; } = Enumerable.Empty<Team>();
        public IEnumerable<Circuit> Circuits { get; set; } = Enumerable.Empty<Circuit>();
    }
}
