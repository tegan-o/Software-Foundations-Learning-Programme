using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
//get rid?

namespace CityInfo.API.Controllers{

    [ApiController]
    [Route("api/[controller]")]

    public class VrnController : ControllerBase {

        [HttpGet]
        public JsonResult GetVrn(){
            //needs to take 1 input parameter and always return true

            var temp = new JsonResult(new {valid = 1});
            temp.StatusCode = 200;
            return temp;
        }

    }
}