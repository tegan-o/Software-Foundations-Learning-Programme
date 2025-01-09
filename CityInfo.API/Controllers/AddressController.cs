using Microsoft.AspNetCore.Mvc;
//get rid?

namespace CityInfo.API.Controllers{

    [ApiController]
    [Route("api/[controller]")]
    //same as [Route("api/address")]

    public class AddressController : ControllerBase {

        [HttpGet]
        public JsonResult GetAddress(){

            return new JsonResult(
                new List<object> {
                    new {propertyNo = 12, city = "Malmesbury", county = "Wiltshire", postcode = "SN16 9BB"}
                }
            );
        }

    }
}