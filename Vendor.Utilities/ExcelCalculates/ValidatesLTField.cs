using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vendor.Utilities.Calculate
{
    public class ValidatesLTField
    {
       public static int validatesLTField(string ValueToValidate)
        {

            switch (ValueToValidate)
            {
                case "Conventional":
                    return 0;
                case "FHA":
                    return 1;
                case "VA":
                    return 2;
                case "USDA Rural Housing":
                    return 3;
                default:
                    return 4;
            }

            //if (ValueToValidate == "Conventional") { return 0; }
            //else if (ValueToValidate == "FHA") { return 1; }
            //else if (ValueToValidate == "VA") { return 2; }
            //else if (ValueToValidate == "Usda Rural Housing") { return 3; }
            //else { return 4; }

        }
    }
}
