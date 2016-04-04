using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog1A
{
    abstract class AirPackage : Package
    {
        private const int WEIGHT_THRESHOLD = 75;
        private const int SIZE_THRESHOLD = 100;

        public AirPackage(Address anOrigin, Address aDestination, double aLength, double aWidth, double aHeight, double aWeight)
            : base(anOrigin, aDestination, aLength, aWidth, aHeight, aWeight)
        {
        } // end constructor

        public bool IsHeavy() // PreCon: None PostCon: outputs a true or false after checking if weight is past the threshold
        {
            if (Weight >= WEIGHT_THRESHOLD)
                return true;
            else
                return false;
        } // end method IsHeavy

        public bool IsLarge() // PreCon: None.  PostConL outputs a true or false after checking if dimensions are past the threshold
        {
            if (Length + Width + Height >= SIZE_THRESHOLD)
                return true;
            else
                return false;
        } // end method IsLarge


        public override string ToString() // PreCon: AirPackage must exist, abstract and will be implemented in child classes. PostCon: outputs a formatted string with information
        {
            return string.Format("{3}{0}Heavy: {1}{0}Large: {2}", Environment.NewLine, IsHeavy().ToString(), IsLarge().ToString(), base.ToString());
        } // end to string method
    }
}
