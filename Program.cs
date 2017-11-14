using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace MakeCSVFile_moti_reut
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            //open txt file for names
            #region TextFileForName
            string pathNames = Path.Combine(Environment.CurrentDirectory, "bank_of_names.txt");
            FileStream file = new FileStream(pathNames, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(file);
            sr.ReadLine();
            int i = 0;
            var textLines = File.ReadAllLines("bank_of_names.txt");
            string[] dataNameArray = new string[70];
            foreach (var line in textLines)
            {
                i++;
                if (i < 70)
                {
                    dataNameArray[i] = line;
                    //Console.WriteLine(dataArray[i]);
                }
            }
            #endregion
            Random rnd = new Random();
            Console.WriteLine("Welcome! Are you ready? Y/N");
            if (Console.ReadLine().ToString().ToLower() == "y")
            {
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Please wait :)");
                StringBuilder csvcontent = new StringBuilder();
                csvcontent.AppendLine("Name,Sex,Height,Academic Level,Income,Self-Learning,experience,Age,Immigrant,Marital Status,Languages,Working status,volunteer,Motivation,Team Worker,");
                for (int jj = 0; jj < 10000; jj++)
                {
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    if (jj < 5000)
                        Console.Write(". ");
                    else
                        Console.Write("* ");
                    //generate random Name
                    string name = dataNameArray[rnd.Next(1, 70)];
                    csvcontent.Append(name + ",");
                    //generate random Sex
                    char[] sexStr = new char[2];
                    sexStr[0] = 'F';
                    sexStr[1] = 'M';
                    int sex = rnd.Next(0, 2);
                    csvcontent.Append(sexStr[sex] + ",");
                    //generate random height        
                    int height = rnd.Next(1, 3);
                    double height2;
                    if (height == 1)
                    {
                        height2 = 0.1;
                        while (height2 < 0.57)
                             height2 = rnd.NextDouble();
                    }
                    else
                    {
                        height2 = 0.6;
                        while (height2 > 0.05)
                             height2 = rnd.NextDouble();
                    }
                    height2 = (float)height + (float)height2;
                    float height3 = (float)Math.Truncate(height2 * 100) / 100;
                    csvcontent.Append(height3 + ",");
                    //generate random Academic Level
                    //0-12y, 1-BA, 2-MA, 3-Phd
                    int academic_level = rnd.Next(0, 4);
                    csvcontent.Append(academic_level + ",");
                    //generate random Income
                    int Income = rnd.Next(0, 2);
                    string Income_STR;
                    if (Income == 0)
                        Income_STR = ">30k$";
                    else
                        Income_STR = "<=30k$";
                    csvcontent.Append(Income_STR + ",");
                    //generate random Self-Learning
                    int selfLearning = rnd.Next(0, 2);
                    char[] yesNoStr = new char[2];
                    yesNoStr[0] = 'Y';
                    yesNoStr[1] = 'N';
                    csvcontent.Append(yesNoStr[selfLearning] + ",");           
                    //generate random experience
                    //0: no exp, 1: 1-2y, 2: 3-5y, 3: 6y and up
                    int experience = rnd.Next(0, 4);
                    csvcontent.Append(experience + ",");
                    //generate random Age
                    int Age = rnd.Next(28, 66);
                    csvcontent.Append(Age + ",");
                    //generate random Immigrant
                    int Immigrant = rnd.Next(0, 2);
                    csvcontent.Append(yesNoStr[Immigrant] + ",");
                    //generate random Marital Status
                    string[] MStatusStr = new string[5];
                    MStatusStr[0] = "Single";
                    MStatusStr[1] = "Married";
                    MStatusStr[2] = "Divorced";
                    MStatusStr[3] = "Widowed";
                    MStatusStr[4] = "other";
                    int status = rnd.Next(0, 5);
                    csvcontent.Append(MStatusStr[status] + ",");
                    //generate random Languages
                    string[] LanguagesStr = new string[4];
                    LanguagesStr[0] = "One";
                    LanguagesStr[1] = "Two";
                    LanguagesStr[2] = "Three";
                    LanguagesStr[3] = "Four";
                    int Languages = rnd.Next(0, 4);
                    csvcontent.Append(LanguagesStr[Languages] + ",");
                    //generate random Working status
                    int Working = rnd.Next(0, 2);
                    csvcontent.Append(yesNoStr[Working] + ",");
                    //generate random volunteer
                    int volunteer = rnd.Next(0, 2);
                    csvcontent.Append(yesNoStr[volunteer] + ",");
                    //generate random Motivation
                    //1=low, 5=high
                    int Motivation = rnd.Next(0, 6);
                    csvcontent.Append(Motivation + ",");
                    //generate random Team Worker
                    string[] TeamWorkerStr = new string[3];
                    TeamWorkerStr[0] = "No";
                    TeamWorkerStr[1] = "Middle";
                    TeamWorkerStr[2] = "Yes";
                    int TeamWorker = rnd.Next(0, 3);
                    csvcontent.AppendLine(TeamWorkerStr[TeamWorker] + ",");
                }

                //export the csv file
                string csvpath = "D:\\myDATA.csv";
                File.AppendAllText(csvpath, csvcontent.ToString());
                Console.WriteLine();
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("The file has been generated!");
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("~ ~ ~ ~ ~ ~ ~ ~ ~ M-o-t-i     S-h-a-u-l  . .&. .  R-e-u-t     B-i-b-a-s ~ ~ ~ ~ ~ ~ ~ ~ ~ ");
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("OK... -_-");
            }
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
        }
    }   
}
