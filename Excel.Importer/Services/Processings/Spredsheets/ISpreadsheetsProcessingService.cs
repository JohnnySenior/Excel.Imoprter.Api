//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System.Collections.Generic;
using Excel.Importer.Models.ExternalApplicants;

namespace Excel.Importer.Services.Processings.Spredsheets
{
    public interface ISpreadsheetsProcessingService
    {
        List<ExternalApplicant> ReadExternalApplicants(string filePath);
    }
}
