//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using Excel.Importer.Brokers.DateTimes;
using Excel.Importer.Brokers.Loggings;
using Excel.Importer.Brokers.Storages;
using Excel.Importer.Models.Applicants;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Excel.Importer.Services.Foundations.Applicants
{
    public partial class ApplicantService : IApplicantService
    {
        private readonly IStorageBroker storageBroker;
        private readonly IDateTimeBroker dateTimeBroker;
        private readonly ILoggingBroker loggingBroker;

        public ApplicantService(
            IStorageBroker storageBroker,
            IDateTimeBroker dateTimeBroker,
            ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.dateTimeBroker = dateTimeBroker;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<Applicant> AddApplicantAsync(Applicant applicant) =>
        TryCatch(async () =>
        {
            ValidateApplicantOnAdd(applicant);

            return await this.storageBroker.InsertApplicantAsync(applicant);
        });

        public ValueTask<Applicant> RetrieveApplicantByIdAsync(Guid applicantid)
        {
            throw new NotImplementedException();
        }

        public IQueryable RetrieveAllApplicants()
        {
            throw new NotImplementedException();
        }

        public ValueTask<Applicant> ModifyApplicantAsync(Applicant applicant)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Applicant> DeleteApplicantAsync(Applicant applicant)
        {
            throw new NotImplementedException();
        }
    }
}
