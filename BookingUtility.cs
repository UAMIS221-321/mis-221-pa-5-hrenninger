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
            //process
            Booking.SetCount(0);
            Booking.SetMaxCount(0);
            string line = inFile.ReadLine();
            while(line != null){
                string[] temp = line.Split('#');
                bookings[Booking.GetCount()] = new Booking(int.Parse(temp[0]), temp[1], temp[2], DateOnly.Parse(temp[3]), int.Parse(temp[4]), temp[5], int.Parse(temp[6]), temp[7]);
                Booking.IncCount();
                Booking.IncMaxCount();
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
        }
        public void BookListing(){  //book a listing only if valid listing

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
                    //Booking myBooking = 
                    Console.WriteLine("What is the patron name?");
                    string name = Console.ReadLine();
                    Console.WriteLine("What is the patron email address?");
                    string email = Console.ReadLine();
                    int id = Booking.GetMaxCount()+1;
                    Booking myBooking = new Booking(id, name, email, listings[foundIndex].GetDate(), listings[foundIndex].GetTrainerId(), listings[foundIndex].GetName(), listings[foundIndex].GetCost(), "Booked");
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
            Console.ReadKey();
        }
        private void UpdateListing(int foundIndex){//update the status in listings too
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
            //Sort();
            StreamWriter outFile = new StreamWriter("transactions.txt");
            for (int i = 0; i<Booking.GetCount(); i++){
                outFile.WriteLine(bookings[i].ToFile());
            }
            outFile.Close();
        }
        public void DeleteBooking(){
            Console.Write("What is the ID of the booking you would like to delete? ");
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = Find(searchVal);
            Console.WriteLine($"foundIndex: {foundIndex}");
            if (foundIndex != -1){
                StreamWriter outFile = new StreamWriter("deletedbookings.txt",true);
                outFile.WriteLine(listings[foundIndex].ToFile());
                outFile.Close();
                for (int i = foundIndex; i< Booking.GetCount();i++){
                    bookings[foundIndex] = bookings[foundIndex+1];
                }
                Booking.DecCount();
                SaveLess(); 
            }
            else{
                Console.WriteLine("Listing not found :(");
            }
        }
        private int Find(int searchVal){
            for(int i = 0; i<Booking.GetCount();i++){  //
                if (bookings[i].GetSessionId() == searchVal){
                    return i;
                }
            }
            return -1;
        }
        private void SaveLess(){
            //Sort();
            StreamWriter outFile = new StreamWriter("listings.txt");
            for (int i = 0; i<Booking.GetCount()-1; i++){
                outFile.WriteLine(bookings[i].ToFile());
            }
            outFile.Close();
        }
        public void UpdateBooking(){
            Console.WriteLine("What is the ID of the booking you would like to update");
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = Find(searchVal);
            if (foundIndex != -1){
                string title = "WHAT DO YOU WANT TO UPDATE?";
                string[] options = {"Status", "Customer Name", "Customer Email","Exit"};
                ArrowKeyOptions update = new ArrowKeyOptions(title, options);
                int updateChoice = update.Run();
                while(updateChoice != 3){
                    if(updateChoice == 0){
                        string newStatus = GetNewStatus();
                        bookings[foundIndex].SetStatus(newStatus);
                    }
                    else if(updateChoice == 1){
                        Console.WriteLine("What is the patron name?");
                        string name = Console.ReadLine();
                        bookings[foundIndex].SetCustName(name);
                    }
                    else if(updateChoice == 2){
                        Console.WriteLine("What is the patron email address?");
                        string email = Console.ReadLine();
                        bookings[foundIndex].SetCustEmail(email);
                    }
                    updateChoice = update.Run();
                }
                Save(); 
            } 
            else{
                Console.WriteLine("Booking not found :(");
            }   
               
        }
        private string GetNewStatus(){
            string updatetitle = "WHAT DO YOU WANT TO UPDATE?";
            string[] statusoptions = {"Completed", "Cancelled", "Booked","Exit"};
            ArrowKeyOptions updatestatus = new ArrowKeyOptions(updatetitle, statusoptions);
            int statusChoice = updatestatus.Run();
            return statusoptions[statusChoice];
        }
    }
}