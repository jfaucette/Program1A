using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog1A
{
    class TwoDayAirPackage : AirPackage
    {
        private char _deliveryType; // holds a character that signifies the delivery type, Saver or Early.

        private decimal COST_CONSTANT = 0.25m; // constants for calculating cost
        private decimal SAVER_CONSTANT = 0.10m;


        public TwoDayAirPackage(Address anOrigin, Address aDestination, double aLength, double aWidth, double aHeight, double aWeight, char aDeliveryType)
            : base(anOrigin, aDestination, aLength, aWidth, aHeight, aWeight) // PreCon: Two Addresses, four non negative doubles, and a character E or S. PostCon: creates a two day airpackage
        {
            DeliveryType = aDeliveryType;
        } // end Constructor

        public char DeliveryType
        {
            get { return _deliveryType; } // precon: none.  PostCon: returns a character, E or S.
            set // PreCon: must provide this set with the character E or S. PostCon: verifies and sets the character to _deliverytype
            {
                if (value == 'E' || value == 'S')
                    _deliveryType = value;
                else
                    throw new ArgumentOutOfRangeException("DeliveryType", value, "Delivery type must be 'E' or 'S'");
            }
        } // end property DeliveryType

        public override decimal CalcCost() // PreCon: None, twodayairpackage must exist.  PostCon: outputs a decimal with the package's cost, based on the delivery type.
        {
            decimal cost = COST_CONSTANT * ((decimal)Length + (decimal)Width + (decimal)Height) + COST_CONSTANT * (decimal)Weight;
            if (DeliveryType == 'E')
                return cost;
            else
                return cost * (1 - SAVER_CONSTANT);
        }

        public override string ToString() // PreCon: None PostCon: outputs a formatted string with information.
        {
            return string.Format("{2}{0}Delivery Type: {1}", Environment.NewLine, DeliveryType.ToString(), base.ToString());
        }

    }
}
