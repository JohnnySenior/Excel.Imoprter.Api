//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using Excel.Importer.Brokers.Spreadsheets;
using Microsoft.AspNetCore.Mvc;

namespace Excel.Importer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpreadsheetController : Controller
    {
        private readonly ISpreadsheetBroker spreadsheetBroker;

        string filePath = @"C:\Users\Jamshidbek\Documents\import\applicants.xlsx";

        public SpreadsheetController(ISpreadsheetBroker spreadsheetBroker)
        {
            this.spreadsheetBroker = spreadsheetBroker;
        }

        [HttpGet("Importer")]
        public IActionResult Get()
        {
            var applicants = this.spreadsheetBroker.ImportApplicants(filePath);

            return Ok(applicants);
        }
    }
}
