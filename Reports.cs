using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis_221_pa_5_hrenninger
{
    public class Reports
    {
        Booking[] bookings;
        public Reports(Booking[] bookings){
            this.bookings = bookings;
        }
        public void SearchByEmail(){
            Console.WriteLine("Please enter customer email for list of bookings");
            string searchEmail = Console.ReadLine();
            string[] bookingsList = new String[Booking.GetCount()];
            int count = 0;
            for (int i = 0; i< Booking.GetCount(); i++){
                if (bookings[i].GetCustEmail() == searchEmail){
                    Console.WriteLine(bookings[i].ToString());
                    bookingsList[count] = bookings[i].ToString();
                    count++;
                }
                
            }
            SaveReport(bookingsList, count);
            Console.ReadKey();
        }
        public void SortByCustomer(){
            int count = 1;
            string[] customerList = new String[Booking.GetCount()*2];
            int stringCount = 0;
            for(int i = 0;i<Booking.GetCount()-1; i++){
                int min = i;
                for(int j = i+1; j<Booking.GetCount();j++){
                    if(bookings[j].GetCustName().CompareTo(bookings[min].GetCustName())<0){
                        min = j;
                    }
                    else if(bookings[j].GetCustName() == bookings[min].GetCustName() && bookings[j].GetDate() < bookings[min].GetDate()){
                        min = j;
                    }
                }
                if (min != i){
                    Swap(min, i);
                }
            }
            for(int i = 0; i< Booking.GetCount()-1; i++){
                Console.WriteLine(bookings[i].ToString());
                customerList[stringCount] = bookings[i].ToString();
                stringCount++;
                if (bookings[i].GetCustName() != bookings[i+1].GetCustName()){
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Customer {bookings[i].GetCustName()} has booked {count} sessions\n");
                    customerList[stringCount] = $"Customer {bookings[i].GetCustName()} has booked {count} sessions\n";
                    stringCount++;
                    Console.ForegroundColor = ConsoleColor.White;
                    count = 1;
                }
                else{
                    count ++;
                }
                // if(sameCust == false){
                //     
                // }
                
            }
            Console.WriteLine(bookings[Booking.GetCount()-1].ToString());
            customerList[stringCount] = bookings[Booking.GetCount()-1].ToString();
            stringCount++;
            Console.ForegroundColor = ConsoleColor.Green;
            
            string stringer = $"Customer {bookings[Booking.GetCount()-1].GetCustName()} has booked {count} sessions\n";
            Console.WriteLine(stringer);
            customerList[stringCount] = stringer;
            stringCount++;
            Console.ForegroundColor = ConsoleColor.White;
            //Console.ReadKey();
            SaveReport(customerList, stringCount);
        }
        public void SortByMonth(){
            for(int i = 0;i<Booking.GetCount()-1; i++){
                int min = i;
                for(int j = i+1; j<Booking.GetCount();j++){
                    if(bookings[j].GetDate()<bookings[min].GetDate()){
                        min = j;
                    }
                }
                if (min != i){
                    Swap(min, i);
                }
            }
            //Save();
        }
        //public int Month { get; }
        public void HistoricalRevReport(){
            SortByMonth();
            int sum = 0;
            //sum += bookings[0].GetCost();
            string[] revList = new String[13];
            int count = 0;
            int yearsum = 0;
            for(int i = 0; i < Booking.GetCount()-1; i++){
                int min = i;
                
                int j = i+1;
                int minMonth = bookings[min].GetDate().Month;
                int currentMonth = bookings[j].GetDate().Month;
                if(currentMonth == minMonth){
                    sum += bookings[j].GetCost();
                    yearsum+= bookings[j].GetCost();
                }
                else{
                    sum += bookings[min].GetCost();
                    yearsum+= bookings[min].GetCost();
                    string month = bookings[min].GetDate().ToString("MMMM");
                    Console.WriteLine($"Month: {month} -- Revenue: {sum}");
                    revList[count] = $"Month: {month} -- Revenue: {sum}";
                    count++;
                    sum = 0;
                }
                
            }
            sum += bookings[Booking.GetCount()-1].GetCost();
            yearsum+= bookings[Booking.GetCount()-1].GetCost();
            string lastMonth = bookings[Booking.GetCount()-1].GetDate().ToString("MMMM");
            Console.WriteLine($"Month: {lastMonth} -- Revenue: {sum}");
            Console.WriteLine($"Year: {bookings[0].GetDate().Year} -- Revenue: {yearsum}");
            revList[count] = $"Month: {lastMonth} -- Revenue: {sum}";
            count++;
            revList[count] = $"Year: {bookings[0].GetDate().Year} -- Revenue: {yearsum}";
            count++;
            for(int k = 0; k<count; k++){
                Console.WriteLine(revList[k]);
            }
            Console.ReadKey();
            SaveReport(revList, count);
            Sort();
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
        private void SaveReport(string[] report, int count){
            Console.WriteLine("Would you like to save this report to a file? (Y/N)");
            string userChoice = Console.ReadLine();
            while(userChoice != "Y" && userChoice != "N"){
                Console.WriteLine("Please enter a valid reponse, Y to save report, N to continue...");
                userChoice = Console.ReadLine();
            }
            if (userChoice=="Y"){
                ReportUtility utility = new ReportUtility(report, count);
                utility.RunReport();
            }
        }
        public void TopTrainers(){ //report the trainers and sessions theu have had boodled
            int count = 1;
            string[] trainerList = new String[Booking.GetCount()];
            int stringCount = 0;
            int[] maxCount = new int[Booking.GetCount()];
            for(int i = 0;i<Booking.GetCount()-1; i++){
                int min = i;
                for(int j = i+1; j<Booking.GetCount();j++){
                    if(bookings[j].GetTrainerId() < bookings[min].GetTrainerId()){
                        min = j;
                    }
                    else if(bookings[j].GetTrainerId() == bookings[min].GetTrainerId() && bookings[j].GetDate() < bookings[min].GetDate()){
                        min = j;
                    }
                }
                if (min != i){
                    Swap(min, i);
                }
            }
            for(int i = 0; i<Booking.GetCount()-1; i++){
    
                trainerList[stringCount] = bookings[i].ToString();
                stringCount++;
                if (bookings[i].GetTrainerName() != bookings[i+1].GetTrainerName()){
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Trainer {bookings[i].GetTrainerName()} has hosted {count} sessions\n");
                    trainerList[stringCount] = $"Trainer {bookings[i].GetTrainerName()} has hosted {count} sessions\n";
                    maxCount[stringCount] = count;
                    stringCount++;
                    Console.ForegroundColor = ConsoleColor.White;
                    count = 1;
                }
                else{
                    count ++;
                }
            }  
            trainerList[stringCount] = bookings[Booking.GetCount()-1].ToString();
            maxCount[stringCount] = count;
            stringCount++;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Trainer {bookings[Booking.GetCount()-1].GetTrainerName()} has hosted {count} session(s)\n");
            trainerList[stringCount] = $"Trainer {bookings[Booking.GetCount()-1].GetTrainerName()} has hosted {count} sessions\n";
            stringCount++;
            Console.ForegroundColor = ConsoleColor.White;
            SaveReport(trainerList, stringCount);
        }

    }
}