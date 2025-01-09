namespace CityInfo.API.Models{

    public class ApplicantDto{
        public string Name { get; set;} = string.Empty;

        public string Email {get; set;} = string.Empty;
        public string Vrn {get; set;}

        public string Address {get; set;} = string.Empty;
    }
}