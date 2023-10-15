//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System;
using System.Linq;
using System.Threading.Tasks;
using Excel.Importer.Models.Applicants;
using Microsoft.EntityFrameworkCore;

namespace Excel.Importer.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Applicant> Applicants { get; set; }

        public async ValueTask<Applicant> InsertApplicantAsync(Applicant applicant) =>
            await InsertAsync(applicant);

        public IQueryable<Applicant> SelectAllApplicants() =>
            SelectAll<Applicant>().AsQueryable();

        public async ValueTask<Applicant> SelectApplicantByIdAsync(Guid applicantId) =>
            await SelectAsync<Applicant>(applicantId);

        public async ValueTask<Applicant> UpdateAppolicantAsync(Applicant applicant) =>
            await UpdateAsync(applicant);

        public async ValueTask<Applicant> DeleteApplicantAsync(Applicant applicant) =>
            await DeleteAsync(applicant);
    }
}

