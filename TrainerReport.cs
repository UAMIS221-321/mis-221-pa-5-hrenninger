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
        public void PrintAllTrainers(){
            var lineCount = File.ReadLines("trainers.txt").Count();
            Sort();
            for (int i = 0; i< lineCount; i++){
                Console.WriteLine(trainers[i].ToString());
            }
            //Console.ReadKey();
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
        // public void PagesByGenre(){
        //     string curr = trainers[0].GetGenre();
        //     int count = trainers[0].GetPages();
        //     for (int i = 1; i < Trainer.GetCount(); i++){
        //         if (trainers[i].GetGenre() == curr){
        //             count += trainers[i].GetPages();

        //         }else {
        //             ProcessBreak(ref curr, ref count, trainers[i]);
        //         }
        //     }
        //     ProcessBreak(curr, count);
        // }

        // public void ProcessBreak(ref string curr, ref int count, Trainer newTrainer){
        //     Console.WriteLine($"{curr}\t{count}");
        //     curr = newTrainer.GetGenre();
        //     count = newTrainer.GetPages();
        // }
        // public void ProcessBreak(string curr, int count){
        //     Console.WriteLine($"{curr}\t{count}");
        // }
    }
}