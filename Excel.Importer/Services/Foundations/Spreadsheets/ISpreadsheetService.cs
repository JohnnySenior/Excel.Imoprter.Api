//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System.Collections.Generic;
using Excel.Importer.Models.ExternalApplicants;

namespace Excel.Importer.Services.Foundations.Spreadsheets
{
    public interface ISpreadsheetService
    {
        List<ExternalApplicant> GetExternalApplicants(string filepath);
    }
}
