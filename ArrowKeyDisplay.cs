using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis_221_pa_5_hrenninger
{
    public class ArrowKeyDisplay
    {
        private int[] index;
        private Trainer[] trainers;
        private string title;

        public ArrowKeyDisplay(string title, Trainer[] trainers, int[] index){
            this.title = title;
            this.trainers = trainers;
            this.index = index;
            // int[] index = new int[2];
            // index[0] =0;
            // index[1] = 0;
        }
        public void DisplayOptions(){
            Console.WriteLine(title);
            for(int i=0; i<Trainer.GetCount(); i++){
                int currentOption = trainers[i].GetId()-1;
                string text = "";
                for (int j = 0; j<4; j++){
                    if (i==index[1] && j == index[0]){
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    else{
                        ResetColor();
                    }
                    if(j == 0){
                        text = trainers[i].GetId().ToString();
                        Console.Write($"{text}");
                    }
                    else if(j==1){
                        text = trainers[i].GetName();
                        CenterText($"{text}");
                    }
                    else if(j==2){
                        text = trainers[i].GetAddress();
                        CenterText($"{text}");
                    }
                    else if(j==3){
                        text = trainers[i].GetEmail();
                        CenterText1($"{text}");
                    }
                }
                
                
            }
            ResetColor();
        }
        public int[] Run(){
            ConsoleKey keyPressed;
            do{
                Console.Clear();
                DisplayOptions();
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;
                if(keyPressed == ConsoleKey.UpArrow){
                    index[1] --;
                    if (index[1] == -1){
                        index[1] = Trainer.GetCount() -1;
                    }
                }
                else if(keyPressed == ConsoleKey.DownArrow){
                    index[1] ++;
                    if (index[1] == Trainer.GetCount()){
                        index[1] = 0;
                    }
                }
                else if(keyPressed == ConsoleKey.LeftArrow){
                    index[0] --;
                    if (index[0] == 0){
                        index[0] = 3;
                    }
                }
                else if(keyPressed == ConsoleKey.RightArrow){
                    index[0] ++;
                    if (index[0] == 4){
                        index[0] = 1;
                    }
                }

            }while (keyPressed != ConsoleKey.Enter);
            return index;
        }
        public void ResetColor(){
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }
        public static void CenterText(string text){
            Console.Write(String.Format("{0," + ((Console.WindowWidth/8)+3)+"}", text));
        }
        public static void CenterText1(string text){
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth/5)+1)+"}", text));
        }
        public static void CenterText2(string text){
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth/2)+(text.Length/8))+"}", text));
        }
        public static void CenterText3(string text){
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth/2)+(text.Length/8))+"}", text));
        }
    }
}