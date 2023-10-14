//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using Excel.Importer.Models.Applicants;
using System.Threading.Tasks;

namespace Excel.Importer.Services.Processings.Applicants
{
    public interface IApplicantProcessingService
    {
        ValueTask<Applicant> AddApplicantAsync(Applicant applicant);
    }
}
