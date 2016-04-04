using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog1A
{
    abstract class Package : Parcel
    {
        private double _length; // stores length as double.  Inches
        private double _width; // stores width as double. Inches
        private double _height; // stores height as double. Inches
        private double _weight; // stores weight as double. Pounds

        private const string lengthPropName = "Length";  // strings used for ExecuteValidationAndSet Method
        private const string widthPropName = "Width";
        private const string heightPropName = "Height";
        private const string weightPropName = "Weight";

        //Constructor
        public Package(Address anOrigin, Address aDestination, double aLength, double aWidth, double aHeight, double aWeight)
            : base(anOrigin, aDestination)  // PreCon: Two Addreses, Four Doubles >= 0.  PostCon: Creates a Package (abstract, constructor will be used in child classes)
        {
            Length = aLength;
            Width = aWidth;
            Height = aHeight;
            Weight = aWeight;
        } // end constructor

        //Properties
        public double Length
        {
            get { return _length; } // end get PreCon: None. PostCon: returns a double
            set // PreCon: value must be a double greater than or equal to zero to pass validation PostCon: _length is set to value
            {
                if (value >= 0)
                {
                    _length = value;
                } // end if statement

                else
                {
                    throw new ArgumentOutOfRangeException("Length", value, string.Format("Length cannot be negative"));
                } // end else statement
            }// End set
        } // end property Length

        public double Width
        {
            get { return _width; } // end get PreCon: None. PostCon: returns a double
            set //  PreCon: value must be a double greater than or equal to zero to pass validation PostCon: _width is set to value
            {
                if (value >= 0)
                {
                    _width = value;
                } // end if statement

                else
                {
                    throw new ArgumentOutOfRangeException("width", value, string.Format("Width cannot be negative"));
                } // end else statement
            }// End set
        } // end property Width

        public double Height
        {
            get { return _height; } // end get PreCon: None. PostCon: returns a double
            set //  PreCon: value must be a double greater than or equal to zero to pass validation PostCon: _height is set to value
            {
                if (value >= 0)
                {
                    _height = value;
                } // end if statement

                else
                {
                    throw new ArgumentOutOfRangeException("Height", value, string.Format("Height cannot be negative"));
                } // end else statement
            }// End set
        } // end property height

        public double Weight
        {
            get { return _weight; } // end get PreCon: None. PostCon: returns a double
            set //  PreCon: value must be a double greater than or equal to zero to pass validation PostCon: _weight is set to value
            {
                if (value >= 0)
                {
                    _weight = value;
                } // end if statement

                else
                {
                    throw new ArgumentOutOfRangeException("Weight", value, string.Format("Weight cannot be negative"));
                } // end else statement
            }// End set
        } // end property Weight

        //Methods
        public override string ToString() // PreCon: None. PostCon: Outputs a formatted string with information
        {
            return string.Format("{6}{4}Length: {0}{4}Width: {1}{4}Height: {2}{4}Weight: {3}{4}Cost: {5:C}", Length, Width, Height, Weight, Environment.NewLine, CalcCost(), base.ToString());
        } // end method ToString

    } // end class Package
}
