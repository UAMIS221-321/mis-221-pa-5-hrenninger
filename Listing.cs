using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis_221_pa_5_hrenninger
{
    public class Listing
    {
        private int id;
        private string name;
        private int trainerId;
        private DateOnly date;
        private TimeOnly time;
        private int cost;
        private string status;
        static private int count;
        static private int maxCount;
        public Listing(){

        }
        public Listing(int id, string name, int trainerId, DateOnly date, TimeOnly time, int cost, string status){
            this.id = id;
            this.name = name;
            this.trainerId = trainerId;
            this.date = date;
            this.time = time;
            this.cost= cost;
            this.status = status;
        }
        public Listing (int id, DateOnly date, string status){
            this.id = id;
            this.date = date;
            this.status = status;
        }
        public void SetId(int id){
            this.id = id;
        }
        public void SetName(string name){
            this.name = name;
        }
        public void SetTrainerId(int trainerId){
            this.trainerId = trainerId;
        }
        public void SetDate(DateOnly date){
            this.date = date;
        }
        public void SetTime(TimeOnly time){
            this.time = time;
        }
        public void SetCost(int cost){
            this.cost = cost;
        }
        public void SetStatus(string status){
            this.status = status;
        }
        public int GetId(){
            return id;
        }
        public string GetName(){
            return name;
        }
        public int GetTrainerId(){
            return trainerId;
        }
        public DateOnly GetDate(){
            return date;
        }
        public TimeOnly GetTime(){
            return time;
        }
        public int GetCost(){
            return cost;
        }
        public string GetStatus(){
            return status;
        }
        static public void SetCount(int count){
            Listing.count = count;
        }
        static public void IncCount(){
            count++;
        }
        static public void DecCount(){
            count--;
        }

        static public int GetCount(){
            return count;
        }
        static public void SetMaxCount(int maxCount){
            Listing.maxCount = maxCount;
        }
        static public void IncMaxCount(){
            maxCount++;
        }

        static public int GetMaxCount(){
            return maxCount;
        }
        public override string ToString()
        {
            return $"Id: {id}\tName: {name}\tDate: {date}\tTime: {time}\tCost: {cost}\tStatus: {status}";
            
        }
        public string ToFile()
        {
            return $"{id}#{name}#{trainerId}#{date}#{time}#{cost}#{status}";
            
        }
    }
}