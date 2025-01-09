using AutoMapper;
using CityInfo.API.Models;
using CityInfo.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using CityInfo.API.Services;

namespace CityInfo.API.Controllers{

    [ApiController]
    [Route("api/[controller]")]

    public class ApplicantController : ControllerBase {

        private readonly IApplicantInfoRepository _applicantInfoRepository;
        private readonly IMapper _mapper;

        private readonly ApplicationService _applicationService;

        public ApplicantController(IApplicantInfoRepository applicantInfoRepository, IMapper mapper, ApplicationService applicationService){
            _applicantInfoRepository = applicantInfoRepository ?? throw new ArgumentNullException(nameof(ApplicantInfoRepository));
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
            _applicationService = applicationService;
        }


        [HttpPost]
        public async Task<IActionResult> SubmitApplicant([FromBody] ApplicantDto input){{
            if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            var result = await _applicationService.SubmitApplicationAsync(input);

            if (!result.Success){
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        
        }

    }
}