using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis_221_pa_5_hrenninger
{
    public class TrainerUtility
    {
        private Trainer[] trainers;

        public TrainerUtility(Trainer[] trainers){
            this.trainers = trainers;
        }

        public void GetAllTrainersFromFile(){
            //open
            StreamReader inFile = new StreamReader("trainers.txt");
            //process
            Trainer.SetCount(0);
            string line = inFile.ReadLine();
            while(line != null){
                string[] temp = line.Split('#');
                trainers[Trainer.GetCount()] = new Trainer(int.Parse(temp[0]), temp[1], temp[2], temp[3]);
                Trainer.IncCount();
                Trainer.IncMaxCount();
                line = inFile.ReadLine();
            }



            //close
            inFile.Close();
        }
        public void AddTrainer(){
            Trainer myTrainer = new Trainer();
            myTrainer.SetId(Trainer.GetMaxCount()+1);
            
            Console.WriteLine("Please enter trainer name (First, Last)");
            string name = Console.ReadLine();
            bool isValid = NewName(name);
            while(!isValid){
                Console.WriteLine($"Trainer {name} already exists");
                Console.WriteLine("Please enter new trainer name (First, Last)");
                name = Console.ReadLine();
                isValid = NewName(name);
            }
            myTrainer.SetName(name);
            
            Console.WriteLine("Please enter trainer mailing address");
            myTrainer.SetAddress(Console.ReadLine());
            
            Console.WriteLine("Please enter trainer email");
            myTrainer.SetEmail(Console.ReadLine());

            trainers[Trainer.GetCount()] = myTrainer;

            Trainer.IncCount();
            Trainer.IncMaxCount();
            Sort();
            Save();

        }
        private bool NewName(string name){
            for (int i = 0; i < Trainer.GetCount(); i++){
                if (name == trainers[i].GetName()){
                    return false;
                }
            }
            return true;
        }

        private void Save(){
            StreamWriter outFile = new StreamWriter("trainers.txt");
            for (int i = 0; i<Trainer.GetCount(); i++){
                outFile.WriteLine(trainers[i].ToFile());
            }
            outFile.Close();
        }

        public void UpdateTrainer(){
            Console.WriteLine("What is the ID of the trainer you would like to update");
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = Find(searchVal);

            if (foundIndex != -1){
                string title = "WHAT DO YOU WANT TO UPDATE?";
                string[] options = {"Trainer Name", "Trainer Address", "Trainer Email", "Exit"};
                ArrowKeyOptions update = new ArrowKeyOptions(title, options);
                int updateChoice = update.Run();
                while(updateChoice != 3){
                    if(updateChoice == 0){
                        Console.WriteLine("Please enter the name");
                        trainers[foundIndex].SetName(Console.ReadLine());
                    }
                    else if(updateChoice == 1){
                        Console.WriteLine("Please enter the address");
                        trainers[foundIndex].SetAddress(Console.ReadLine());
                    }
                    else if(updateChoice == 2){
                        Console.WriteLine("Please enter the email");
                        trainers[foundIndex].SetEmail(Console.ReadLine());
                    }
                    updateChoice = update.Run();
                } 
                Console.WriteLine("Trainer has been updated:");
                Console.WriteLine(trainers[foundIndex].ToString());
                Sort();
                Save(); 
            }
            else{
                Console.WriteLine("Trainer not found :(");
            }
        }
        private int Find(int searchVal){
            for(int i = 0; i<Trainer.GetCount();i++){  //
                if (trainers[i].GetId() == searchVal){
                    return i;
                }

            }
            return -1;
        }
        public void Sort(){
            for(int i = 0;i<Trainer.GetCount()-1; i++){
                int min = i;
                for(int j = i+1; j<Trainer.GetCount();j++){
                    if(trainers[j].GetId()< trainers[min].GetId()){
                        min = j;
                    }
                }
                if (min != i){
                    Swap(min, i);
                }
            }
            
        }
        private void Swap(int x, int y){
            Trainer temp = trainers[x];
            trainers[x] = trainers[y];
            trainers[y] = temp;
        }

        public void DeleteTrainer(){
            Console.WriteLine("What is the ID of the trainer you would like to delete");
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = Find(searchVal);
            Console.WriteLine($"foundIndex: {foundIndex}");
            if (foundIndex != -1){
                StreamWriter outFile = new StreamWriter("deleted.txt", true);//this is trashcan tehe
                outFile.WriteLine(trainers[foundIndex].ToFile());
                outFile.Close();
                for (int i = foundIndex; i< Trainer.GetCount();i++){
                    trainers[i] = trainers[i+1];
                }
                // Console.WriteLine("user count");
                // Console.WriteLine(Trainer.GetCount());
                Sort();
                SaveLess(); 
                Console.WriteLine("Trainer has been deleted. Press ENTER to continue...");
                Console.ReadKey();
            }
            else{
                Console.WriteLine("Trainer not found :(");
            }
        }
        private void SaveLess(){
            StreamWriter outFile = new StreamWriter("trainers.txt");
            for (int i = 0; i<Trainer.GetCount()-1; i++){
                outFile.WriteLine(trainers[i].ToFile());
            }
            outFile.Close();
        }
    }
}