using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vendor.Utilities.ExcelCalculates
{
    public class ValidateGseRefPurposeT_Field
    {
        public static int validateGseRefPurposeT_Field(string sGseRefPurposeT, string sLT)
        {

            if (sGseRefPurposeT == "Yes" && sLT == "FHA")
            {
                return 5;
            }
            else if (sGseRefPurposeT == "Yes" && !sLT.Contains("FHA", StringComparison.OrdinalIgnoreCase))
            { return 8; }
            else { return 0; }

            //if (ValueToValidate == "Conventional") { return 0; }
            //else if (ValueToValidate == "FHA") { return 1; }
            //else if (ValueToValidate == "VA") { return 2; }
            //else if (ValueToValidate == "Usda Rural Housing") { return 3; }
            //else { return 4; }

        }
    }

}

