using CityInfo.API.Entities;

namespace CityInfo.API.Repositories{

    public interface IApplicantInfoRepository{
        //this is the contract

        Task<Applicant> AddApplicantAsync(Applicant applicant);
        
    }
}