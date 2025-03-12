using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendor.Models.Loan;

namespace Vendor.Services.Contracts
{
    public interface ILoanCreateFromExcel
    {
        Task<List<LoanModel>> CreateLoan(IFormFile file);

    }
}
