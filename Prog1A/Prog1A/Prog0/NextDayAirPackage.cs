using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog1A
{
    class NextDayAirPackage : AirPackage
    {
        private const decimal PROP_CONST = 0.40m; // constants for cost calculation
        private const decimal WEIGHT_CONST = 0.30m;
        private const decimal OVERAGE_CONST = 0.25m;

        private decimal _expressFee; // contains the express fee

        public NextDayAirPackage(Address anOrigin, Address aDestination, double aLength, double aWidth, double aHeight, double aWeight, decimal anExpressFee)
            : base(anOrigin, aDestination, aLength, aWidth, aHeight, aWeight) // PreCon: Two Addresses, Four non negative doubles, one non negative decimal PostCon: creates a nextdayairpackage
        {
            if (anExpressFee >= 0)  // validation in constructor because no set in ExpressFee property
                _expressFee = anExpressFee;
            else
                throw new ArgumentOutOfRangeException("Express Fee", anExpressFee, "Express Fee must be non-negative");
        }

        public decimal ExpressFee
        {
            get { return _expressFee; } // PreCon: None PostCon: returns a decimal
        } // end property ExpressFee

        public override decimal CalcCost() // PreCon: None.  PostCon: returns the cost of the nextdayairpackage as a decimal
        {
            decimal cost = PROP_CONST * ((decimal)Length + (decimal)Width + (decimal)Height) + WEIGHT_CONST * (decimal)Weight + ExpressFee;
            
            if (IsHeavy())
                cost += OVERAGE_CONST * (decimal)Weight;

            if (IsLarge())
                cost += OVERAGE_CONST * ((decimal)Length + (decimal)Width + (decimal)Height);

            return cost;
        } // end method CalcCost

        public override string ToString() // PreCon: None.  PostCon: returns a formatted string with information.
        {
            return string.Format("{1}{0}Express Fee: {2:C}", Environment.NewLine, base.ToString(), ExpressFee);
        }
    }
}
