using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AngleCalculator;

namespace AngleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            string[] processingInput;

            Angle fstAngle, sndAngle;

            Console.WriteLine(new string('=', 20));
            Console.WriteLine("Инструкция");
            Console.WriteLine("Ввод должен состять из 5 значений");
            Console.WriteLine("[град° 1 угла] [мин' 1 угла] [операция] [град° 2 угла] [мин' 2 угла]");
            Console.WriteLine("К примеру чтобы сложить два угла (к примеру 26°45' и 15°56')");
            Console.WriteLine("Необходимо ввести следующее:");
            Console.WriteLine("26 45 + 15 56");
            Console.WriteLine();
            Console.WriteLine("Примеры правильно ввода:");
            Console.WriteLine("45 12 + 12 2");
            Console.WriteLine("10 5 - 80 10");
            Console.WriteLine("98 7 / 12 0");
            Console.WriteLine("120 1 * 2 0");
            Console.WriteLine(new string('=', 20));
            Console.WriteLine();

            while (input != "exit")
            {
                Console.Write("-> ");
                input = Console.ReadLine();
                processingInput = input.Split(' ');
                if (processingInput.Length == 5)
                {
                    try
                    {
                        fstAngle = new Angle(processingInput[0].Contains('-'), Convert.ToDouble(processingInput[0]), Convert.ToDouble(processingInput[1]));
                        sndAngle = new Angle(processingInput[3].Contains('-'), Convert.ToDouble(processingInput[3]), Convert.ToDouble(processingInput[4]));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Convertation error");
                        continue;
                    }

                    switch(processingInput[2])
                    {
                        case "+":
                            Console.WriteLine(fstAngle + sndAngle);
                            Console.WriteLine(new string('-', 20));
                            break;
                        case "-":
                            Console.WriteLine(fstAngle - sndAngle);
                            Console.WriteLine(new string('-', 20));
                            break;
                        case "/":
                            Console.WriteLine(fstAngle / sndAngle.Degrees);
                            Console.WriteLine(new string('-', 20));
                            break;
                        case "*":
                            Console.WriteLine(fstAngle * sndAngle.Degrees);
                            Console.WriteLine(new string('-', 20));
                            break;
                        default:
                            Console.WriteLine("Incorrect opertaion");
                            Console.WriteLine(new string('-', 20));
                            continue;
                    }
                }
                else
                    Console.WriteLine("Incorrect input");
            }
        }
    }
}
