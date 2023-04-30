using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis_221_pa_5_hrenninger
{
    public class Booking
    {
        private int sessionId;
        private string custName;
        private string custEmail;
        private DateOnly date;
        private int trainerId;
        private string trainerName;
        private int cost;
        private string status;
        private static int count;
        private static int maxCount;

        public Booking(){

        }
        public Booking(int sessionId, string custName, string custEmail, DateOnly date, int trainerId, string trainerName, int cost, string status){
            this.sessionId = sessionId;
            this.custName = custName;
            this.custEmail = custEmail;
            this.date = date;
            this.trainerId = trainerId;
            this.trainerName = trainerName;
            this.cost = cost;
            this.status= status;
        }
        public void SetSessionId(int sessionId){
            this.sessionId = sessionId;
        }
        public void SetCustName(string custName){
            this.custName = custName;
        }
        public void SetCustEmail(string custEmail){
            this.custEmail = custEmail;
        }
        public void SetDate(DateOnly date){
            this.date = date;
        }
        public void SetTrainerId(int trainerId){
            this.trainerId = trainerId;
        }
        public void SetTrainerName(string trainerName){
            this.trainerName = trainerName;
        }
        public void SetStatus(string status){
            this.status = status;
        }
        public void SetCost(int cost){
            this.cost = cost;
        }

        public int GetSessionId(){
            return sessionId;
        }
        public string GetCustName(){
            return custName;
        }
        public string GetCustEmail(){
            return custEmail;
        }
        public DateOnly GetDate(){
            return date;
        }
        public int GetTrainerId(){
            return trainerId;
        }
        public string GetTrainerName(){
            return trainerName;
        }
        public string GetStatus(){
            return status;
        }
        public int GetCost(){
            return cost;
        }
        static public void SetCount(int count){
            Booking.count = count;
        }
        static public void IncCount(){
            count++;
        }

        static public int GetCount(){
            return count;
        }
        static public void SetMaxCount(int maxCount){
            Booking.maxCount = maxCount;
        }
        static public void IncMaxCount(){
            maxCount++;
        }

        static public int GetMaxCount(){
            return maxCount;
        }
         public override string ToString()
        {
            return $"{custName}'s session Id: {sessionId} with {trainerName} on {date}.\nFurther details will be relayed to {custEmail}\n";
            
        }
        public string ToFile()
        {
            return $"{sessionId}#{custName}#{custEmail}#{date}#{trainerId}#{trainerName}#{cost}#{status}";
            
        }
    }
}