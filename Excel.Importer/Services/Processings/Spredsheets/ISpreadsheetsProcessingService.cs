//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using Excel.Importer.Models.ExternalApplicants;
using System.Collections.Generic;

namespace Excel.Importer.Services.Processings.Spredsheets
{
    public interface ISpreadsheetsProcessingService
    {
        List<ExternalApplicant> ReadExternalApplicants(string filePath);
    }
}
