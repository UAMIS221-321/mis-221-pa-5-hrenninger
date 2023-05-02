using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis_221_pa_5_hrenninger
{
    public class ReportUtility
    {
        private string[] report;
        private int count;

        public ReportUtility(){

        }
        public ReportUtility(string [] report, int count){
            this.report = report;
            this.count = count;
        }
        public void SetReport(string[] report){
            this.report = report;
        }
        public void SetCount(int count){
            this.count = count;
        }
        public string[] GetReport(){
            return report;
        }
        public int GetCount(){
            return count;
        }

        public void RunReport(){
            string fileName = GetOutputFile();
            CreateFile(fileName, report, count);
        }
        private string GetOutputFile(){
            Console.WriteLine("Please enter the name of the file that would like the text to be entered into:");
            Console.WriteLine("(ex: filename.txt)");
            string file = Console.ReadLine();
            return file;
        }
        private void CreateFile(string fileName, string[] report, int count){
            StreamWriter outputFile = new StreamWriter(fileName);
            string line = report[0];
            for(int i = 0; i<= count; i++){
                outputFile.WriteLine(line);
                line = report[i];
            }
            outputFile.Close();
        }
        public void ReadFile(string outputFile){
            StreamReader outFile = new StreamReader(outputFile);
            string line = outFile.ReadLine();
            while(line!=null){
                Console.WriteLine(line);
                line = outFile.ReadLine();
            }
            //Console.ReadKey();
            outFile.Close();
        }
        public void RestoreFile(string type){
            Console.WriteLine("Would you like to restore any of the records?(Y/N)");
            string userChoice = Console.ReadLine().ToUpper();
            while(userChoice!="Y" && userChoice!="N"){
                Console.WriteLine("Please enter valid input, Y to restore a record, N to exit");
                userChoice = Console.ReadLine();
            }
            if(userChoice == "Y"){
                if(type == "trainers"){
                    RestoreTrainer();
                }
                else if(type == "listings"){
                    RestoreListing();
                }
                else if(type == "bookings"){
                    RestoreBooking();
                }
            }
            else{
                return;
            }
        }
        private void RestoreTrainer(){
            int count = 0;
            Trainer[] trainers = new Trainer[100];
            ReadFile("deletedtrainers.txt",ref trainers);
            Console.WriteLine("What is the id of the trainer that you would like to restore?");
            int restoreId = int.Parse(Console.ReadLine());
            int foundIndex = Find(restoreId, trainers);
            Console.WriteLine(foundIndex);
            Console.ReadKey();
            EditFile("trainers.txt", trainers[foundIndex].ToFile());
        }
        private int Find(int searchVal, Trainer[] report){
            for(int i = 0; i<Trainer.GetCount();i++){  
                if (report[i].GetId() == searchVal){
                    return i;
                }
            }
            return -1;
        }
        private int Find(int searchVal, Listing[] report){
            for(int i = 0; i<Listing.GetCount();i++){  
                if (report[i].GetId() == searchVal){
                    return i;
                }
            }
            return -1;
        }
        private int Find(int searchVal, Booking[] report){
            for(int i = 0; i<Booking.GetCount();i++){  
                if (report[i].GetSessionId() == searchVal){
                    return i;
                }
            }
            return -1;
        }
        private void RestoreListing(){
            int count = 0;
            Listing[] listings = new Listing[100];
            ReadFile("deletedlistings.txt", ref listings);
            Console.WriteLine("What is the id of the listing that you would like to restore?");
            int restoreId = int.Parse(Console.ReadLine());
            int foundIndex = Find(restoreId, listings);
            if(foundIndex != -1){
                EditFile("listings.txt", listings[foundIndex].ToFile());
            }
        }
        private void RestoreBooking(){
            int count = 0;
            Booking[] bookings = new Booking[100];
            ReadFile("deletedlistings.txt", ref bookings);
            Console.WriteLine("What is the id of the booking that you would like to restore?");
            int restoreId = int.Parse(Console.ReadLine());
            int foundIndex = Find(restoreId, bookings);
            EditFile("bookings.txt", bookings[foundIndex].ToFile());
        }
        public void ReadFile(string outputFile, ref Trainer[] trainers){
            StreamReader inFile = new StreamReader(outputFile);
            Trainer.SetCount(0);
            string line = inFile.ReadLine();
            while(line != null){
                string[] temp = line.Split('#');
                trainers[Trainer.GetCount()] = new Trainer(int.Parse(temp[0]), temp[1], temp[2], temp[3]);
                Console.WriteLine(trainers[Trainer.GetCount()].ToString());
                Trainer.IncCount();
                Trainer.IncMaxCount();
                line = inFile.ReadLine();
            }
            inFile.Close();
        }
        public void ReadFile(string outputFile, ref Listing[] listings){
            StreamReader inFile = new StreamReader(outputFile);
            Listing.SetCount(0);
            Listing.SetMaxCount(0);
            string line = inFile.ReadLine();
            while(line != null){
                string[] temp = line.Split('#');
                listings[Listing.GetCount()] = new Listing(int.Parse(temp[0]), temp[1], int.Parse(temp[2]), DateOnly.Parse(temp[3]), TimeOnly.Parse(temp[4]), int.Parse(temp[5]), temp[6]);
                Console.WriteLine(listings[Listing.GetCount()].ToString());
                Listing.IncCount();
                Listing.IncMaxCount();
                line = inFile.ReadLine();
            }
            //close
            inFile.Close();
        }
        public void ReadFile(string outputFile, ref Booking[] bookings){
            StreamReader inFile = new StreamReader(outputFile);
            Booking.SetCount(0);
            string line = inFile.ReadLine();
            while(line != null){
                string[] temp = line.Split('#');
                bookings[Booking.GetCount()] = new Booking(int.Parse(temp[0]), temp[1], temp[2], DateOnly.Parse(temp[3]), int.Parse(temp[4]), temp[5], int.Parse(temp[6]), temp[7]);
                Console.WriteLine(bookings[Booking.GetCount()].ToString());
                Booking.IncCount();
                line = inFile.ReadLine();
            }
            //close
            inFile.Close();
        }
        private void EditFile(string fileName, string restore){
            StreamWriter outputFile = new StreamWriter(fileName,true);
            //string line = report[0].;
            outputFile.WriteLine(restore);
            
            outputFile.Close();
        }
    }
}