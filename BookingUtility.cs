using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis_221_pa_5_hrenninger
{
    public class BookingUtility
    {
        Booking[] bookings;
        Listing[] listings;
        public BookingUtility(Booking[] bookings, Listing[] listings){
            this.bookings = bookings;
            this.listings = listings;
        }
        public void GetAllListingsFromFile(){
            //open
            StreamReader inFile = new StreamReader("listings.txt");
            Listing[] listings = new Listing[100];
            //process
            Listing.SetCount(0);
            string line = inFile.ReadLine();
            while(line != null){
                string[] temp = line.Split('#');
                listings[Listing.GetCount()] = new Listing(int.Parse(temp[0]), temp[1], int.Parse(temp[2]), DateOnly.Parse(temp[3]), TimeOnly.Parse(temp[4]), int.Parse(temp[5]), temp[6]);
                Listing.IncCount();
                line = inFile.ReadLine();
            }
            //close
            inFile.Close();
        }
        public void GetAllBookingsFromFile(){
            //open
            StreamReader inFile = new StreamReader("transactions.txt");
            //Booking[] bookings = new Booking[100];
            //process
            Booking.SetCount(0);
            string line = inFile.ReadLine();
            while(line != null){
                string[] temp = line.Split('#');
                bookings[Booking.GetCount()] = new Booking(int.Parse(temp[0]), temp[1], temp[2], DateOnly.Parse(temp[3]), int.Parse(temp[4]), temp[5], int.Parse(temp[6]), temp[7]);
                Booking.IncCount();
                line = inFile.ReadLine();
            }
            //close
            inFile.Close();
        }
        private void Swap(int x, int y){
            Booking temp = bookings[x];
            bookings[x] = bookings[y];
            bookings[y] = temp;
        }
        public void Sort(){
            for(int i = 0;i<Booking.GetCount()-1; i++){
                int min = i;
                for(int j = i+1; j<Booking.GetCount();j++){
                    if(bookings[j].GetSessionId()< bookings[min].GetSessionId()){
                        min = j;
                    }
                }
                if (min != i){
                    Swap(min, i);
                }
            }
            Save();
            
        }
        public void BookListing(){

            Console.WriteLine("What is the ID of the listing that you would like to book?");
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = FindAvailable(searchVal);
            if (foundIndex == -2){
                Console.WriteLine("This listing is not available at the moment");
            }
            else if(foundIndex != -1){
                Console.WriteLine(listings[foundIndex]);
                Console.WriteLine("Is this the listing that you would like to sign up for? (Y/N)");
                string userChoice = Console.ReadLine();
                if (userChoice == "Y"){
                    Booking myBooking = new Booking();
                    Console.WriteLine("What is the patron name?");
                    string name = Console.ReadLine();
                    Console.WriteLine("What is the patron email address?");
                    string email = Console.ReadLine();
                    myBooking.SetSessionId(Booking.GetCount()+1);
                    myBooking.SetCustName(name);
                    myBooking.SetCustEmail(email);
                    myBooking.SetDate(listings[foundIndex].GetDate());
                    myBooking.SetTrainerName(listings[foundIndex].GetName());
                    myBooking.SetTrainerId(listings[foundIndex].GetTrainerId());
                    myBooking.SetStatus("Booked");
                    myBooking.SetCost(listings[foundIndex].GetCost());
                    bookings[Booking.GetCount()] = myBooking;
                    UpdateListing(foundIndex);
                    Booking.IncCount();
                    Booking.IncMaxCount();
                    Save();
                }
            }
            else{
                Console.WriteLine("Listing not found :(");
            }
            

        }
        private void UpdateListing(int foundIndex){
            listings[foundIndex].SetStatus("Booked");
            StreamWriter outFile = new StreamWriter("listings.txt");
            for (int i = 0; i<Listing.GetCount(); i++){
                outFile.WriteLine(listings[i].ToFile());
            }
            outFile.Close();
        }
        private int FindAvailable(int searchVal){
            for(int i = 0; i<Listing.GetCount();i++){  
                if (listings[i].GetId() == searchVal){
                    if (listings[i].GetStatus() == "Open"){
                        return i;
                    }
                    else return -2;
                    
                }

            }
            return -1;
        }
        private void Save(){
            StreamWriter outFile = new StreamWriter("transactions.txt");
            for (int i = 0; i<Booking.GetCount(); i++){
                outFile.WriteLine(bookings[i].ToFile());
            }
            outFile.Close();
        }
        
    }
}