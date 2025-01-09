using AutoMapper;
//not sure whether this is needed

namespace CityInfo.API.Profiles{

    public class ApplicantProfile : Profile{

        public ApplicantProfile(){
            CreateMap<Entities.Applicant, Models.ApplicantDto>();
        }
    }
}