using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CityInfo.API.Entities{
    public class Applicant{


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set;} = string.Empty;

        public string Email {get; set;} = string.Empty;

        public string Vrn { get; set;} = string.Empty;

        [Required]
        public string Address {get; set; } = string.Empty;

    }
}