using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis_221_pa_5_hrenninger
{
    public class ReportUtility
    {
        private string[] report;
        private int count;

        public ReportUtility(){

        }
        public ReportUtility(string [] report, int count){
            this.report = report;
            this.count = count;
        }
        public void SetReport(string[] report){
            this.report = report;
        }
        public void SetCount(int count){
            this.count = count;
        }
        public string[] GetReport(){
            return report;
        }
        public int GetCount(){
            return count;
        }

        public void RunReport(){
            string fileName = GetOutputFile();
            CreateFile(fileName, report, count);
        }
        private string GetOutputFile(){
            Console.WriteLine("Please enter the name of the file that would like the text to be entered into:");
            Console.WriteLine("(ex: filename.txt)");
            string file = Console.ReadLine();
            return file;
        }
        private void CreateFile(string fileName, string[] report, int count){
            StreamWriter outputFile = new StreamWriter(fileName,true);
            string line = report[0];
            for(int i = 1; i<= count; i++){
                outputFile.WriteLine(line);
                line = report[1];
            }
            outputFile.Close();
        }
        public void ReadFile(string outputFile){
            StreamReader outFile = new StreamReader(outputFile);
            string line = outFile.ReadLine();
            while(line!=null){
                Console.WriteLine(line);
                line = outFile.ReadLine();
            }
            Console.ReadKey();
            outFile.Close();
        }
    }
}