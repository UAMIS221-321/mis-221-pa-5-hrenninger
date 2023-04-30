using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis_221_pa_5_hrenninger
{
    public class ListingReport
    {
        Listing[] listings;
        public ListingReport(Listing[] listings){
            this.listings = listings;
        }
        public void PrintAllListings(){
            for (int i = 0; i< Listing.GetCount(); i++){
                Console.WriteLine(listings[i].ToString());
            }
            Console.ReadKey();
        }

        public void PrintAvailableListings(){
            for (int i = 0; i< Listing.GetCount(); i++){
                if (listings[i].GetStatus() == "Open"){
                    Console.WriteLine(listings[i].ToString());
                }
            }
            Console.ReadKey();
        }
    }
}