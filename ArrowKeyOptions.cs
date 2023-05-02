using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis_221_pa_5_hrenninger
{
    public class ArrowKeyOptions
    {
        private int index;
        private string[] options;
        private string title;

        public ArrowKeyOptions(string title, string[] options){
            this.title = title;
            this.options = options;
            index = 0;
        }

        public void DisplayOptions(){
            Console.WriteLine(title);
            for(int i=0; i<options.Length; i++){
                string currentOption = options[i];
                string prefix;
                if(i==index){
                    prefix = "*";
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else{
                    prefix = " ";
                    ResetColor();
                }
                Console.WriteLine($"{prefix} >> {currentOption} <<");
                
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
                    if (index == -1){
                        index = options.Length -1;
                    }
                }
                else if(keyPressed == ConsoleKey.DownArrow){
                    index ++;
                    if (index == options.Length){
                        index = 0;
                    }
                }

            }while (keyPressed != ConsoleKey.Enter);
            return index;
        }
        private void ResetColor(){
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}