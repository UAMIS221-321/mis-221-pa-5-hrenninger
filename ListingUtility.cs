using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis_221_pa_5_hrenninger
{
    public class ListingUtility
    {
        private Listing[] listings;
        private Trainer[] trainers;
        public ListingUtility(Listing[] listings){
            this.listings = listings;
        }

        public void GetAllListingsFromFile(){
            //open
            StreamReader inFile = new StreamReader("listings.txt");
            //process
            Listing.SetCount(0);
            bool first = false;
            if(Listing.GetMaxCount()==0){
                first = true;
            }
            string line = inFile.ReadLine();
            while(line != null){
                string[] temp = line.Split('#');
                listings[Listing.GetCount()] = new Listing(int.Parse(temp[0]), temp[1], int.Parse(temp[2]), DateOnly.Parse(temp[3]), TimeOnly.Parse(temp[4]), int.Parse(temp[5]), temp[6]);
                Listing.IncCount();
                if(first){
                    Listing.IncMaxCount();
                }
                line = inFile.ReadLine();
            }
            //close
            inFile.Close();
        }
        public void AddListing(){
            Listing myListing = new Listing();
            myListing.SetId(Listing.GetMaxCount()+1);
            
            Console.WriteLine("Please choose trainer name");
            string userTrainerChoice = ChooseTrainer(); //call arrow key options for listings
            myListing.SetName(userTrainerChoice);
            int userTrainerIdChoice = ChooseTrainerId(userTrainerChoice);
            myListing.SetTrainerId(userTrainerIdChoice);
            
            Console.WriteLine("Please choose listing date");//call arrow key options for listings
            myListing.SetDate(ChooseDate());
            
            Console.WriteLine("Please choose listing time");//call arrow key options for listings
            myListing.SetTime(ChooseTime());

            Console.WriteLine("Please enter listing cost");//call arrow key options for listings
            myListing.SetCost(ChooseCost());

            myListing.SetStatus("Open");

            listings[Listing.GetCount()] = myListing;

            Listing.IncCount();
            Listing.IncMaxCount();
            Save();
        }
        private DateOnly ChooseDate(){
            Console.Clear();
            string title = "CHOOSE A MONTH";
            string[] months = {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"};
            ArrowKeyOptions monthOptions = new ArrowKeyOptions(title, months);
            int monthChoice = monthOptions.Run();
            int month = monthChoice+1;
            int monthBound = Bounds(monthChoice);
            Console.WriteLine("Enter day");
            int day = int.Parse(Console.ReadLine());
            while(day > monthBound || day<1){
                Console.WriteLine("Invalid day input");
                Console.WriteLine($"Please enter a day between 1-{monthBound}:");
                day = int.Parse(Console.ReadLine());
            }
            var dateOnly = new DateOnly(2023, month, day);
            return dateOnly;

        }
        private int Bounds(int monthChoice){
            if (monthChoice == 0 || monthChoice == 2 || monthChoice == 4 || monthChoice == 6 || monthChoice == 7|| monthChoice ==9 || monthChoice == 11){
                return 31;
            }
            else if (monthChoice == 3 || monthChoice == 5 || monthChoice == 8 || monthChoice == 10){
                return 30;
            }
            else if(monthChoice == 1){
                var datetime = DateTime.Now;
                var year = datetime.Year;
                if(year%4==0){
                    return 29;
                }
                else{
                    return 28;
                }
            }
            else {
                return -1;
            }
        }
        private TimeOnly ChooseTime(){
            TimeOnly[] timeOptions = new TimeOnly[24];
            for(int i = 0; i <24; i++){
                if (i < 18){
                    timeOptions[i] = new TimeOnly(i+6,0);
                }
                else {
                    timeOptions[i] = new TimeOnly(i-18,0);
                }
            }
            Console.Clear();
            int time = Times();
            TimeOnly var = timeOptions[time];
            return var;
        }
        private int Times(){
            StreamReader times = new StreamReader("times.txt");
            string line = times.ReadLine();
            var lineCount = File.ReadLines("times.txt").Count();
            string[] timeOptions = new String[lineCount];
            int count = 0;
            while(line != null){
                timeOptions[count] = line;
                count++;
                line = times.ReadLine();
            }
            times.Close();
            string title = "CHOOSE A TIME SLOT";
            ArrowKeyOptions options = new ArrowKeyOptions(title, timeOptions );
            return options.Run();
        }

        private string ChooseTrainer(){
            StreamReader inFile = new StreamReader("trainers.txt");
            Trainer[] trainers = new Trainer[100];
            int count = 0;
            Trainer.SetCount(0);
            string line = inFile.ReadLine();
            while(line != null){
                string[] temp = line.Split('#');
                trainers[count] = new Trainer(int.Parse(temp[0]), temp[1], temp[2], temp[3]);
                count++;
                Trainer.IncCount();
                line = inFile.ReadLine();
            }
            //close
            inFile.Close();

            string[] trainerNames = new string[Trainer.GetCount()];
            for (int i = 0; i < Trainer.GetCount(); i ++){
                trainerNames[i] = trainers[i].GetName();
            }
            string title = "Please choose a trainer\n";
            ArrowKeyOptions trainerOptions = new ArrowKeyOptions(title, trainerNames);
            int userTrainerChoice = trainerOptions.Run();
            return trainerNames[userTrainerChoice];
            
        }
        private int ChooseTrainerId(string userTrainerChoice){  //consider combining this with trainer name
            StreamReader inFile = new StreamReader("trainers.txt");
            Trainer[] trainers = new Trainer[100];
            int count = 0;
            Trainer.SetCount(0);
            string line = inFile.ReadLine();
            while(line != null){
                string[] temp = line.Split('#');
                trainers[count] = new Trainer(int.Parse(temp[0]), temp[1], temp[2], temp[3]);
                count++;
                Trainer.IncCount();
                line = inFile.ReadLine();
            }
            //close
            inFile.Close();
            string[] trainerNames = new string[Trainer.GetCount()];
            for (int i = 0; i < Trainer.GetCount(); i ++){
                trainerNames[i] = trainers[i].GetName();
            }
            int userTrainerIdChoice = -1;
            for (int i = 0; i < Trainer.GetCount(); i ++){
                if (trainerNames[i] == userTrainerChoice){
                    userTrainerIdChoice = i;
                }
            }
            return trainers[userTrainerIdChoice].GetId();  
        }
        private int ChooseCost(){
            int cost;
            bool betterVal = int.TryParse(Console.ReadLine(), out cost);
            while(betterVal==false || cost<50){
                Console.WriteLine("Invalid input. Please enter cost (50 or above)");
                betterVal = int.TryParse(Console.ReadLine(), out cost);
            }
            return cost;
        }
        private void Save(){
            //Sort();
            StreamWriter outFile = new StreamWriter("listings.txt");
            for (int i = 0; i<Listing.GetCount(); i++){
                outFile.WriteLine(listings[i].ToFile());
            }
            outFile.Close();
        }

        public void UpdateListing(){  //update a listing
            Console.WriteLine("What is the ID of the listing you would like to update");
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = Find(searchVal);
            if (foundIndex != -1){
                string title = "WHAT DO YOU WANT TO UPDATE?";
                string[] options = {"Trainer", "Date", "Time", "Cost", "Exit"};
                ArrowKeyOptions update = new ArrowKeyOptions(title, options);
                int updateChoice = update.Run();
                while(updateChoice != 4){
                    if(updateChoice == 0){
                        Console.WriteLine("Please choose a trainer");
                        listings[foundIndex].SetName(ChooseTrainer());
                    }
                    else if(updateChoice == 1){
                        Console.WriteLine("Please choose the date");
                        listings[foundIndex].SetDate(ChooseDate());
                    }
                    else if(updateChoice==2){
                        Console.WriteLine("Please choose the time");
                        listings[foundIndex].SetTime(ChooseTime());
                    }
                    else if(updateChoice ==3){
                        Console.WriteLine("Please enter the cost");
                        listings[foundIndex].SetCost(ChooseCost());
                    }
                    updateChoice = update.Run();
                }
                Console.WriteLine("Listing has been updated:");
                Console.WriteLine(listings[foundIndex].ToString());
                Console.WriteLine("Press ENTER to continue...");
                Console.ReadKey();
                Save(); 
            }
            else{
                Console.WriteLine("Listing not found :(");
            }
        }
        private int Find(int searchVal){
            for(int i = 0; i<Listing.GetCount();i++){  //
                if (listings[i].GetId() == searchVal){
                    return i;
                }
            }
            return -1;
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
        public void DeleteListing(){  //delete a listing
            Console.Write("What is the ID of the listing you would like to delete? ");
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = Find(searchVal);
            Console.WriteLine($"foundIndex: {foundIndex}");
            if (foundIndex != -1){
                StreamWriter outFile = new StreamWriter("deletedlistings.txt",true);
                outFile.WriteLine(listings[foundIndex].ToFile());
                outFile.Close();
                for (int i = foundIndex; i< Listing.GetCount();i++){
                    listings[foundIndex] = listings[foundIndex+1];
                }
                Listing.DecCount();
                SaveLess(); 
            }
            else{
                Console.WriteLine("Listing not found :(");
            }
        }
        private void SaveLess(){
            //Sort();
            StreamWriter outFile = new StreamWriter("listings.txt");
            for (int i = 0; i<Listing.GetCount()-1; i++){
                outFile.WriteLine(listings[i].ToFile());
            }
            outFile.Close();
        }
        
    }
}
