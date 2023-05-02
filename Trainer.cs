using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis_221_pa_5_hrenninger
{
    public class Trainer
    {
        private int id;

        private string name;

        private string address;

        private string email;
        static private int count;
        static private int maxCount;
        
        public Trainer(){

        }

        public Trainer (int id, string name, string address, string email){
            this.id = id;
            this.name = name;
            this.address = address;
            this.email = email;
        }

        public void SetId(int id){
            this.id = id;
        }
        public void SetName(string name){
            this.name = name;
        }
        public void SetAddress(string address){
            this.address= address;
        }
        public void SetEmail(string email){
            this.email = email;
        }
        public int GetId(){
            return id;
        }
        public string GetName(){
            return name;
        }
        public string GetAddress(){
            return address;
        }
        public string GetEmail(){
            return email;
        }

        static public void SetCount(int count){
            Trainer.count = count;
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
            Trainer.maxCount = maxCount;
        }
        static public void IncMaxCount(){
            maxCount++;
        }

        static public int GetMaxCount(){
            return maxCount;
        }
        public override string ToString()
        {
            return $"Id: {id}\tName: {name}\tAddress: {address}\tEmail: {email}";
            
        }
        public string ToFile()
        {
            return $"{id}#{name}#{address}#{email}";
            
        }

    }
}