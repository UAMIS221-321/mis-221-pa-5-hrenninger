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
            Sort();
            Console.Clear();
            for (int i = 0; i< Listing.GetCount(); i++){
                Console.WriteLine(listings[i].ToString());
            }
        }

        public void PrintAvailableListings(){ //print only the listings that are open
            for (int i = 0; i< Listing.GetCount(); i++){
                if (listings[i].GetStatus() == "Open"){
                    Console.WriteLine(listings[i].ToString());
                }
            }
            Console.ReadKey();
        }
         public void Sort(){
            for(int i = 0;i<Listing.GetCount()-1; i++){
                int min = i;
                for(int j = i+1; j<Listing.GetCount();j++){
                    if(listings[j].GetId()< listings[min].GetId()){
                        min = j;
                    }
                }
                if (min != i){
                    Swap(min, i);
                }
            }    
        }
        private void Swap(int x, int y){
            Listing temp = listings[x];
            listings[x] = listings[y];
            listings[y] = temp;
        }
    }
}