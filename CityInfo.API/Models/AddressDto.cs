namespace CityInfo.API.Models{
    //get rid?

    public class AddressDto{
        //is this needed???? address hard coded

        public string line1 { get; set; } = string.Empty;

        public string? line2 { get; set; }

        public string city {get; set;} = string.Empty;

        public string postcode { get; set; } = string.Empty;

    }
}