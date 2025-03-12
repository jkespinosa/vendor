using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vendor.Utilities.Calculate
{
    public class ValidateFinMethTField
    {
     public   static int validateFinMethTField(string ValueToValidate)
        {
            if ((ValueToValidate == "Fixed") || (ValueToValidate == "HELOC")) { return 0; }
            else if ((ValueToValidate == "Adjustable Rate") || (ValueToValidate == "Step")) { return 1; }
            else { return 2; }
        }
    }
}
