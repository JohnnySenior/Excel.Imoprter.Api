//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System.Threading.Tasks;
using Excel.Importer.Services.Orchestrations;
using Microsoft.AspNetCore.Mvc;

namespace Excel.Importer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicantController : Controller
    {
        private readonly IOrchestrationService orchestrationService;

        string filePath = @"C:\Users\Jamshidbek\Documents\import\applicants.xlsx";

        public ApplicantController(IOrchestrationService orchestrationService)
        {
            this.orchestrationService = orchestrationService;
        }

        [HttpPost]
        public async Task<IActionResult> PostApplicant()
        {
            await this.orchestrationService.ProcessImportRequest(filePath);

            return Ok("Applicants successfully inserted");
        }
    }
}
