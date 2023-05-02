using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis_221_pa_5_hrenninger
{
    public class ArrowKeyMenu
    {
        private int index;
        private string[] options;
        private string title;
        private bool activeTrainer;
        private bool activeListing;
        private bool activeBooking;
        private bool activeFinancial;
        private bool activeTrainRepo;
        private bool activeReport;
        private bool activeCustomer;

        public ArrowKeyMenu(string title, string[] options){
            this.title = title;
            this.options = options;
            activeTrainer = false;
            activeListing = false;
            activeBooking = false;
            activeFinancial = false;
            activeTrainRepo = false;
            activeReport = false;
            activeCustomer = false;
            index = 0;
        }

        public void DisplayOptions(){
            Console.WriteLine(title);
            for(int i=0; i<options.Length; i++){
                string currentOption = options[i];
                string prefix = "X";
                string suffix = " ";
                bool isValid2 = char.IsLetter(currentOption[1]);
                if(currentOption[0] == '*'){
                    suffix = ">";
                    if(isValid2){
                        prefix = " ";
                        //currentOption = currentOption[1..];
                    }
                    else if(activeReport){
                        prefix = "    ";
                    }
                }
                else if(currentOption[0]=='^'&& currentOption[1]!='^'){
                    if(activeTrainer){
                        prefix = "    ";
                    }
                    else{
                        prefix = "X";
                    }
                }
                else if(currentOption[0]=='@'&& currentOption[1]!='@'){
                    if(activeListing){
                        prefix = "    ";
                        //currentOption = currentOption[1..];
                    }
                    else{
                        prefix = "X";
                    }
                }
                else if(currentOption[0]=='$'&& currentOption[1]!= '$'){
                    if(activeBooking){
                        prefix = "    ";
                        //currentOption = currentOption[1..];
                    }
                    else{
                        prefix = "X";
                    }
                }
                else if(activeReport){
                    
                    if(activeCustomer && currentOption[1] == '^'){
                        prefix = "    ";
                        prefix += "    ";
                        //currentOption = currentOption[2..];
                    }
                    if(activeFinancial && currentOption[1]=='@'){
                        prefix = "    ";
                        prefix += "    ";
                       // currentOption = currentOption[2..];
                    }
                    if(activeTrainRepo && currentOption[1]=='$'){
                        prefix = "    ";
                        prefix += "    ";
                        //currentOption = currentOption[2..];
                    }
                }
                
                bool isValid = char.IsLetter(currentOption.FirstOrDefault());
                if(isValid){
                    prefix = " ";
                    suffix = " ";
                }
                
                if(i==index){
                    prefix += "*";
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else{
                    prefix += " ";
                    ResetColor();
                }
                if(!isValid2){
                    currentOption = currentOption[2..];
                }
                else if(!isValid){
                    currentOption = currentOption[1..];
                }
                if(prefix[0] != 'X'){
                    Console.WriteLine($"{prefix} <> {currentOption} {suffix}");
                }
                
            }
            ResetColor();
        }
        public int Run(){
            ConsoleKey keyPressed;
            do{
                Console.Clear();
                DisplayOptions();
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;
                if(keyPressed == ConsoleKey.UpArrow){
                    index --;
                    if (!activeTrainer&&index==4){
                        index =0;
                    }
                    else if(!activeListing &&index ==9){
                        index = 5;
                    }
                    else if(!activeBooking&&index == 14){
                        index = 10;
                    }
                    else if (!activeReport&&index == 22){
                        index = 15;
                    }
                    else if(!activeTrainRepo&&index == 22){
                        index = 21;
                    }
                    else if(!activeFinancial && index == 20){
                        index = 19;
                    }
                    else if(!activeCustomer && index == 18){
                        index = 16;
                    }
                    if (index == -1){
                        index = options.Length -1;
                    }
                }
                else if(keyPressed == ConsoleKey.DownArrow){
                    index ++;
                    if(!activeTrainer&&index ==1){
                        index = 5;
                    }
                    else if(!activeListing&&index==6){
                        index =10;
                    }
                    else if(!activeBooking&&index==11){
                        index = 15;
                    }
                    else if(!activeReport&&index==16){
                        index = 23;
                    }
                    else if(!activeCustomer &&index ==17){
                        index=19;
                    }
                    else if(!activeFinancial && index == 20){
                        index = 21;
                    }
                    else if(!activeTrainRepo && index == 22){
                        index = 23;
                    }
                    if (index == options.Length){
                        index = 0;
                    }
                }
                // Console.WriteLine(index);
                // Console.ReadKey();
            }while (keyPressed != ConsoleKey.Enter);
            return index;
        }

        public void ToggleTrainerDropDown(){
            activeTrainer = !activeTrainer;
        }
        public void ToggleListingDropDown(){
            activeListing = !activeListing;
        }
        public void ToggleBookingDropDown(){
            activeBooking = !activeBooking;
        }
        public void ToggleReportDropDown(){
            activeReport = !activeReport;
        }
        public void ToggleReportCustDropDown(){
            activeCustomer = !activeCustomer;
        }
        public void ToggleFinancialReports(){
            activeFinancial = !activeFinancial;
        }
        public void ToggleTrainerReports(){
            activeTrainRepo = !activeTrainRepo;
        }

        private void ResetColor(){
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}