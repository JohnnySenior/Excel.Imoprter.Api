//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System.Threading.Tasks;

namespace Excel.Importer.Services.Orchestrations
{
    public interface IOrchestrationService
    {
        Task ProcessImportRequest(string filePath);
    }
}
