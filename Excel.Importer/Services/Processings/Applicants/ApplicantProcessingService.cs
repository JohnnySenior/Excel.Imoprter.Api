//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using Excel.Importer.Brokers.Loggings;
using Excel.Importer.Models.Applicants;
using Excel.Importer.Services.Foundations.Applicants;
using System.Threading.Tasks;

namespace Excel.Importer.Services.Processings.Applicants
{
    public partial class ApplicantProcessingService : IApplicantProcessingService
    {
        private readonly IApplicantService applicantService;
        private readonly ILoggingBroker loggingBroker;

        public ApplicantProcessingService(
            IApplicantService applicantService,
            ILoggingBroker loggingBroker)
        {
            this.applicantService = applicantService;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<Applicant> AddApplicantAsync(Applicant applicant) =>
        TryCatch(async () =>
        {
            return await applicantService.AddApplicantAsync(applicant);
        });
    }
}
