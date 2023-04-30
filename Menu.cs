using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis_221_pa_5_hrenninger
{
    public class Menu
    {
        private int userChoice;

        private int menuCount;

        public void SetCount(int menuCount){
            this.menuCount = menuCount;
        }
        public int GetCount(){
            return menuCount;
        }

        public int GetUserChoice(){
            Console.Clear();
            if (menuCount == 0){
                DisplayMainMenu();
            }
            else if (menuCount == 1){
                DisplayTrainerMenu();
            }
            else if(menuCount == 2){
                DisplaySessionsMenu();
            }
            string userChoice = Console.ReadLine();
            if (IsValidChoice(userChoice)) {
                return int.Parse(userChoice);
            }
            else return 0;
        }

        private void DisplayMainMenu(){
            // ConsoleKeyInfo key;
            // int option = 1;
            // bool isSelected = false;
            
            // while (!isSelected){
            //     key = Console.ReadKey(true);
            //     switch (key.Key);
            // }
            Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "TRAIN LIKE A CHAMPION"));
            Console.WriteLine("\n\t1 - Manage Trainers\n\t2 - Manage Listings\n\t3 - Book a Session\n\t4 - Reports\n\t5 - Exit");
            Console.Write("\nPlease enter an option # (1, 2, 3, 4, or 5): ");
        }
        private void DisplayTrainerMenu(){
            Console.WriteLine("1 - Add\n2 - Update\n3 - Delete\n4 - Exit");
        }
        private void DisplaySessionsMenu(){
            Console.WriteLine("1 - View Available Sessions\n2 - Book a Session\n3 - Exit");
        }

        private bool IsValidChoice(string userChoice) { //checks that userchoice is 1-4
            if (userChoice == "1" || userChoice == "2" || userChoice == "3" || userChoice == "4"||userChoice =="5") {
                return true;
            }
            return false;
        }
        
        
        

    }
}