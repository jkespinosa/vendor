using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vendor.Utilities.Calculate
{
    public class ValidateNullField
    {
        public static bool validateNullField(string ValueToValidate)
        {
            if (!string.IsNullOrWhiteSpace(ValueToValidate) )
            { return true; }
            else { return false; }
        }

    }
}
