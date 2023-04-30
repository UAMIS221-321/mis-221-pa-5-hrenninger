using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis_221_pa_5_hrenninger
{
    public class BookingReport
    {
        Booking[] bookings;
        public BookingReport(Booking[] bookings){
            this.bookings = bookings;
        }
        public void PrintAllBookings(){
           // var lineCount = File.ReadLines("transactions.txt").Count();
            //Sort();
            //Console.WriteLine(bookings[0].ToString());
            for (int i = 0; i< Booking.GetCount(); i++){
                Console.WriteLine(bookings[i].ToString());
            }
            Console.ReadKey();
        }
        public void Sort(){
            for(int i = 0;i<Booking.GetCount()-1; i++){
                int min = 1;
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
        private void Swap(int x, int y){
            Booking temp = bookings[x];
            bookings[x] = bookings[y];
            bookings[y] = temp;
        }

        public void SearchByEmail(){
            Console.WriteLine("Please enter customer email for list of bookings");
            string searchEmail = Console.ReadLine();
            for (int i = 0; i< Booking.GetCount(); i++){
                if (bookings[i].GetCustEmail() == searchEmail){
                    Console.WriteLine(bookings[i].ToString());
                }
            }
            Console.ReadKey();
        }
        
    }   
}