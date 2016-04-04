// Program 1B
// CIS 200-75
// Fall 2014
// Due: 10/20/2014
// By: Javoni Faucette

// File: TestParcels.cs
// This is a simple, console application designed to exercise the Parcel hierarchy.
// It creates several different Parcels and prints them. This program also uses LINQ queries to sort through the data outputting sorted results.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prog1
{
    class TestParcels
    {
        // Precondition:  None
        // Postcondition: Parcels have been created and displayed
        static void Main(string[] args)
        {
            // Test Data - Magic Numbers OK
            Address a1 = new Address("John Smith", "123 Any St.", "Apt. 45",
                "Louisville", "KY", 40202); // Test Address 1
            Address a2 = new Address("Jane Doe", "987 Main St.",
                "Beverly Hills", "CA", 90210); // Test Address 2
            Address a3 = new Address("James Kirk", "654 Roddenberry Way",
                "El Paso", "TX", 79901); // Test Address 3
            Address a4 = new Address("John Crichton", "678 Pau Place", "Apt. 7",
                "Portland", "ME", 04101); // Test Address 4
            Address a5 = new Address("Travis Tingle", "5678 Lamplight Ln.", "APT. 1220",
                "Dallas", "Texas", 75056); // Test Address 5
            Address a6 = new Address("Javoni Faucette ", "1830 South 3rd Street", "APT. 18",
                "Austin", "Texas", 78660); // Test Address 6
            Address a7 = new Address("Sarah Drury", "5648 Sea Dr.", "APT. 90",
                "Los Angeles", "California", 90001); // Test Address 7
            Address a8 = new Address("Janelle Jenkins", "9878 Volleyball Ave.", "APT. 3",
                "Louisville", "Kentucky", 40208); // Test Address 8
            
            Letter letter1 = new Letter(a1, a2, 3.95M);                           // Letter test objects
            Letter letter2 = new Letter(a6, a5, 6.40M);
            GroundPackage gp1 = new GroundPackage(a3, a4, 14, 10, 5, 12.5);        // Ground test objects
            GroundPackage gp2 = new GroundPackage(a1, a2, 10, 9, 4, 6);
            NextDayAirPackage ndap1 = new NextDayAirPackage(a1, a3, 25, 15, 15,    // Next Day test objects
                85, 7.50M);
            NextDayAirPackage ndap2 = new NextDayAirPackage(a1, a3, 3, 6, 9, 10, 4.6m);
            TwoDayAirPackage tdap1 = new TwoDayAirPackage(a4, a1, 46.5, 39.5, 28.0, // Two Day test objects
                80.5, 'S');
            TwoDayAirPackage tdap2 = new TwoDayAirPackage(a1, a2, 6, 7, 8, 9, 'E');

            List<Parcel> parcels;      // List of test parcels

            parcels = new List<Parcel>();

            parcels.Add(letter1); // Populate list
            parcels.Add(letter2);
            parcels.Add(gp1);
            parcels.Add(gp2);
            parcels.Add(ndap1);
            parcels.Add(ndap2);
            parcels.Add(tdap1);
            parcels.Add(tdap2);

            Console.WriteLine("Original List:");
            Console.WriteLine("====================");
            foreach (Parcel p in parcels)
            {
                Console.WriteLine(p);
                Console.WriteLine("====================");
            }
            Pause(); // Pauses before the queries start. Must click Enter to proceed.

            // LINQ.

            // 1) Descending zipcodes from the destination address.
            //Precondition: None.
            //Postcondition: Runs a query through parcel in parcels and orders the destination address zip in descending order.
            var descZip =
                from parcel in parcels
                orderby parcel.DestinationAddress.Zip descending
                select parcel;

            //Precondition: None.
            //Postcondition: Display's each LINQ query in the console.
            Console.WriteLine("Descending Destination Zip Codes:");
            Console.WriteLine("******************");                //Just copied your symbol separators. It looked nicer.
            foreach (var parcel in descZip)                         // For each loop looping through the parcels that meet the query criteria.
            {
                Console.WriteLine(parcel);                          // Displays them in the console.
                Console.WriteLine("******************");
            }
            Pause(); // Pauses before next query. Must click Enter to proceed.

            // 2) Ascending order by cost
            //Precondition: None.
            //Postcondition: Runs a query through parcel in parcels and orders the parcel cost in ascending order.
            var ascOrderByCost =
                from parcel in parcels
                orderby parcel.CalcCost()
                select parcel;

            //Precondition: None.
            //Postcondition: Display's each LINQ query in the console.
            Console.WriteLine("Ascending Order By Cost:");
            Console.WriteLine("------------------");
            foreach (var parcel in ascOrderByCost)                  // For each loop looping through the parcels that meet the query criteria.
            {
                Console.WriteLine(parcel);                          // Displays them in the console.
                Console.WriteLine("------------------");
            }
            Pause(); // Pauses before next query. Must click Enter to proceed.

            // 3) Order by Parcel type then cost
            //Precondition: None.
            //Postcondition: Runs a query through parcel in parcels. It gets the type and then orders the cost in descending order.
            var orderByTypeCost =
                from parcel in parcels
                orderby parcel.GetType().ToString(), parcel.CalcCost() descending
                select parcel;

            //Precondition: None.
            //Postcondition: Display's each LINQ query in the console.
            Console.WriteLine("Order By Parcel Type Then Cost");
            Console.WriteLine("#################");
            foreach (var parcel in orderByTypeCost)                 // For each loop looping through the parcels that meet the query criteria.
            {
                Console.WriteLine(parcel);                          // Displays them in the console.
                Console.WriteLine("#################");
            }
            Pause(); // Pauses before next query. Must click Enter to proceed.

            // 4) All heavy Air Packages then orderby weight.
            //Precondition: None.
            //Postcondition: Runs a query through parcel in parcels where parcel comes from the Air Package class. Then is ordered by weight
                           // in descending order.
            var airPackagesWeight =
                from parcel in parcels
                where parcel is AirPackage
                let airP = (AirPackage)parcel                       // Definitely had the most trouble with figuring this out.
                where airP.IsHeavy()
                orderby airP.Weight descending
                select airP;

            //Precondition: None.
            //Postcondition: Display's each LINQ query in the console.
            Console.WriteLine("Heavy Air Packages Ordered By Weight");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~");
            foreach (var parcel in airPackagesWeight)               // For each loop looping through the parcels that meet the query criteria.
            {
                Console.WriteLine(parcel);                          // Displays them in the console.
                Console.WriteLine("~~~~~~~~~~~~~~~~~~");
            }
            Pause(); // Pauses before next query. Must click Enter to proceed.
        }

        // Precondition:  None
        // Postcondition: Pauses program execution until user presses Enter and
        //                then clears the screen
        public static void Pause()
        {
            Console.WriteLine("Press Enter to Continue...");
            Console.ReadLine();

            Console.Clear(); // Clear screen
        }
    }
}
