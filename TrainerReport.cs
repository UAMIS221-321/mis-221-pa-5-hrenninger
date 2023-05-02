using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis_221_pa_5_hrenninger
{
    public class TrainerReport
    {
        Trainer[] trainers;
        public TrainerReport(Trainer[] trainers){
            this.trainers = trainers;
        }
        public void PrintAllTrainers(){  //print all trainers from Trainer[] trainers
            Console.Clear();
            var lineCount = File.ReadLines("trainers.txt").Count();
            Sort();
            for (int i = 0; i< lineCount; i++){
                Console.WriteLine(trainers[i].ToString());
            }
        }
        public void Sort(){  // sort the trainers before it is printed
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
    }
}