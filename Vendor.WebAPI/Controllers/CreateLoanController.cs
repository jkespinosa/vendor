using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;
using System;
using System.IO;
using Vendor.Models.Loan;
using Vendor.Models;
using Vendor.Utilities;
using Vendor.Utilities.Calculate;
using Vendor.Services.Contracts;
using static System.Net.Mime.MediaTypeNames;
using System.Text.Json;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Newtonsoft.Json.Linq;

namespace Vendor.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CreateLoanController : Controller
    {
        private readonly ILoanCreateFromExcel _LoanCreateFromExcel;

        public CreateLoanController(ILoanCreateFromExcel LoanCreateFromExcel)
        {
            _LoanCreateFromExcel = LoanCreateFromExcel;
        }

        [HttpPost]
        public async Task<List<LoanModel>> createLoan(IFormFile file)
        {
            var Loan = await _LoanCreateFromExcel.CreateLoan(file);

            string jsonString = JsonSerializer.Serialize(Loan);


            Console.WriteLine($"Respuesta de la API: {jsonString}");

            return Loan;

        }
    }
}
