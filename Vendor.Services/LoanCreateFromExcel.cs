using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic.FileIO;
using Vendor.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendor.Models.Loan;
using Vendor.Utilities.Calculate;
using Vendor.Utilities.ExcelCalculates;

namespace Vendor.Services
{
    public class LoanCreateFromExcel : ILoanCreateFromExcel
    {
        public async Task<List<LoanModel>> CreateLoan(IFormFile file)
        {
            var records = new List<string[]>();
            List<LoanModel> loanFinal = new List<LoanModel>();

            if (file != null && file.Length > 0)
            {
                using (var stream = file.OpenReadStream()) // Open the file stream
                using (var reader = new StreamReader(stream)) // Read the stream as text
                using (var parser = new TextFieldParser(reader))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(","); // Define la coma como separador
                    parser.HasFieldsEnclosedInQuotes = true; // Maneja valores entre comillas


                    string[] headers = parser.ReadFields();

                    // Dividir los encabezados y guardar sus posiciones
                    Dictionary<string, int> columnIndices = new Dictionary<string, int>();

                    for (int i = 0; i < headers.Length; i++)
                    {
                        columnIndices[headers[i]] = i;
                    }


                    // Leer el resto de las filas
                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields();
                        List<ConsumerModel> ConsumerList = new List<ConsumerModel>();


                        ConsumerList.Add(new ConsumerModel()
                        {
                            FirstName = fields[columnIndices["FirstName_1"]],
                            LastName = fields[columnIndices["LastName_1"]],
                            MiddleName = fields[columnIndices["MiddleName_1"]],
                            Ssn = fields[columnIndices["Ssn_1"]],
                            HomePhone = fields[columnIndices["HomePhone_1"]],
                            CellPhone = fields[columnIndices["CellPhone_1"]],
                            Email = fields[columnIndices["Email_1"]],
                            DateOfBirth = fields[columnIndices["DateofBirth_1"]],
                            DecisionCreditScore = fields[columnIndices["DecisionCreditScore_1"]],
                        });


                        ConsumerList.Add(new ConsumerModel()
                        {
                            FirstName = fields[columnIndices["FirstName_2"]],
                            LastName = fields[columnIndices["LastName_2"]],
                            MiddleName = fields[columnIndices["MiddleName_2"]],
                            Ssn = fields[columnIndices["Ssn_2"]],
                            CellPhone = fields[columnIndices["CellPhone_2"]],
                            Email = fields[columnIndices["Email_2"]],
                            DateOfBirth = fields[columnIndices["DateofBirth_2"]],
                        });

                        ConsumerList.Add(new ConsumerModel()
                        {
                            FirstName = fields[columnIndices["FirstName_3"]],
                            LastName = fields[columnIndices["LastName_3"]],
                            Ssn = fields[columnIndices["Ssn_3"]],
                            CellPhone = fields[columnIndices["CellPhone_3"]],
                            DateOfBirth = fields[columnIndices["DateofBirth_3"]],
                        });

                        ConsumerList.Add(new ConsumerModel()
                        {
                            FirstName = fields[columnIndices["FirstName_4"]],
                            LastName = fields[columnIndices["LastName_4"]],
                            Ssn = fields[columnIndices["Ssn_4"]],
                            DateOfBirth = fields[columnIndices["DateofBirth_4"]],
                        });


                        LoanModel loan = new LoanModel()
                        {
                            sLNm = fields[columnIndices["sLNm"]],
                            sTerm = fields[columnIndices["sTerm"]],
                            sNoteIR = fields[columnIndices["sNoteIR"]],
                            sSchedDueD1 = fields[columnIndices["sSchedDueD1"]],
                            sSchedDueD1Lckd = ValidateNullField.validateNullField(fields[columnIndices["sSchedDueD1"]].ToString()),
                            sAggregateAdjRsrvLckd = ValidateNullField.validateNullField(fields[columnIndices["sAggregateAdjRsrv"]].ToString()),
                            sAppSubmittedDLckd = ValidateNullField.validateNullField(fields[columnIndices["sAppSubmittedD"]].ToString()),
                            sFinMethT = ValidateFinMethTField.validateFinMethTField(fields[columnIndices["sFinMethT"]]),
                            sLT = ValidatesLTField.validatesLTField(fields[columnIndices["sLT"]]),
                            sGseRefPurposeT = ValidateGseRefPurposeT_Field.validateGseRefPurposeT_Field(fields[columnIndices["sGseRefPurposeT"]], fields[columnIndices["sLT"]]),

                            ConsumerList = ConsumerList

                        };

                        loanFinal.Add(loan);
                    };

                }
            }


            return  loanFinal;
        }
    }
    
}
