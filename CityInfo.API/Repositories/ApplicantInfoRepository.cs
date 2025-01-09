using CityInfo.API.Entities;
using CityInfo.API.DbContexts;
using SQLitePCL;

namespace CityInfo.API.Repositories{
    //where we provide persistence logic

    public class ApplicantInfoRepository: IApplicantInfoRepository{

        private readonly ApplicantInfoContext _context;

        public ApplicantInfoRepository(ApplicantInfoContext context){
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Applicant> AddApplicantAsync(Applicant applicant){
            _context.Applicants.Add(applicant);
            await _context.SaveChangesAsync();
            return applicant;
        }
    }

}