using CityInfo.API.Entities;
using CityInfo.API.Models;
using CityInfo.API.Repositories;
using CityInfo.API.Clients;

namespace CityInfo.API.Services{

    public class ApplicationService
    {
        private readonly IApplicantInfoRepository _repository;
        private readonly VRNAddressValidationClient _validationClient;

        public ApplicationService(IApplicantInfoRepository repository, VRNAddressValidationClient validationClient)
        {
            _repository = repository;
            _validationClient = validationClient;
        }

        public async Task<(bool Success, string Message, Applicant Data)> SubmitApplicationAsync(ApplicantDto input)
        {
            // Call external API to validate VRN and address
            bool isValid = await _validationClient.ValidateVRNAndAddressAsync(input.Vrn, input.Address);

            if (!isValid)
            {
                return (false, "Invalid VRN or address.", null);
            }

            // Save application details
            var application = new Applicant
            {
                Name = input.Name,
                Email = input.Email,
                Vrn = input.Vrn,
                Address = input.Address,
            };

            var savedApplication = await _repository.AddApplicantAsync(application);

            return (true, "Application submitted successfully.", savedApplication);
        }
    }
}

