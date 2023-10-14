//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using Excel.Importer.Models.ExternalApplicants;
using System.Collections.Generic;

namespace Excel.Importer.Services.Foundations.Spreadsheets
{
    public interface ISpreadsheetService
    {
        List<ExternalApplicant> GetExternalApplicants(string filepath);
    }
}
