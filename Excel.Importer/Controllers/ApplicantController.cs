//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System;
using System.Threading.Tasks;
using Excel.Importer.Models.Applicants;
using Excel.Importer.Services.Foundations.Applicants;
using Excel.Importer.Services.Orchestrations;
using Microsoft.AspNetCore.Mvc;

namespace Excel.Importer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicantController : Controller
    {
        private readonly IOrchestrationService orchestrationService;
        private readonly IApplicantService applicantService;

        string filePath = @"C:\Users\icom\Desktop\.net.xlsx";

        public ApplicantController(IOrchestrationService orchestrationService, IApplicantService applicantService)
        {
            this.orchestrationService = orchestrationService;
            this.applicantService = applicantService;
        }

        [HttpPost]
        public async Task<IActionResult> PostApplicant()
        {
            await this.orchestrationService.ProcessImportRequest(filePath);

            return Ok("Applicants successfully inserted");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteApplicantAsync(Guid guid)
        {
            await this.applicantService.RemoveApplicantAsync(guid);

            return Ok("Applicants successfully delted");
        }
    }
}
