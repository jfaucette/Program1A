using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog1A
{
    class GroundPackage : Package
    {
        // Constants
        private const decimal PROPORTION_CONSTANT = 0.2m; // constants for zone distance calculation
        private const decimal DISTANCE_CONSTANT = 0.5m;

        // Constructor
        public GroundPackage(Address anOrigin, Address aDestination, double aLength, double aWidth, double aHeight, double aWeight)
            : base(anOrigin, aDestination, aLength, aWidth, aHeight, aWeight)  // PreCon: must have 2 Addresses, and four non negative doubles.  PostCon: Creates a GroundPackage
        {
        }// end constructor

        //Methods
        public int ZoneDistance() // Calculate the Zonedistance in between the two zipcodes of the addresses.  PreCon: GroundPackage must be instantiated.  PostCon: Outputs a postive integer
        {
            int OriginFirstDigit = Convert.ToInt32(OriginAddress.Zip.ToString("D5")[0]);
            int DestinationFirstDigit = Convert.ToInt32(DestinationAddress.Zip.ToString("D5")[0]);

            return Math.Abs(OriginFirstDigit - DestinationFirstDigit);
        } // end method ZoneDistance()
        public override decimal CalcCost() // returns the decimal cost.  PreCon: GroundPackage must be instantiated.  PostCon: Outputs the cost as a decimal
        {
            return PROPORTION_CONSTANT*((decimal)Length+(decimal)Width+(decimal)Height) + DISTANCE_CONSTANT*(ZoneDistance()+1)*((decimal)Weight);
        }// End method CalcCost

        public override string ToString()  //   PreCon: GroundPackage must be instantiated. PostCon: outputs a formatted string with information.
        {
            return string.Format("{0}{2}Zone Distance: {1}", base.ToString(), ZoneDistance().ToString(), Environment.NewLine);
        } // end method ToString
    } // end class GroundPackage
}
