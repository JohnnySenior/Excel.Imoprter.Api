//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System.Collections.Generic;
using Excel.Importer.Models.ExternalApplicants;

namespace Excel.Importer.Brokers.Spreadsheets
{
    public interface ISpreadsheetBroker
    {
        List<ExternalApplicant> ImportApplicants(string filePath);
    }
}
