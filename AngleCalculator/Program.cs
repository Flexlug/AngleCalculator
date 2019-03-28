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

            Angle fstAngle, sndAngle, lastValue = new Angle(false, 0, 0);

            Console.WriteLine(new string('=', 40));
            Console.WriteLine("Инструкция");
            Console.WriteLine("Ввод должен состять из 5 значений");
            Console.WriteLine("[град° 1 угла] [мин' 1 угла] [операция] [град° 2 угла] [мин' 2 угла]");
            Console.WriteLine("К примеру чтобы сложить два угла (к примеру 26°45' и 15°56')");
            Console.WriteLine("Необходимо ввести следующее:");
            Console.WriteLine("26 45 + 15 56");
            Console.WriteLine("Доступные команды:");
            Console.WriteLine("Сложение : [°1] ['1] + [°2] ['2]");
            Console.WriteLine("Вычитание: [°1] ['1] - [°2] ['2]");
            Console.WriteLine("Умножение: [°1] ['1] * [°2] 0");
            Console.WriteLine("Деление  : [°1] ['1] / [°2] 0");
            Console.WriteLine("Также для каждой команды есть укороченная версия, которая применяется");
            Console.WriteLine("для последнего вычисленного значения");
            Console.WriteLine("Пример: \n+ [°2] ['2]");
            Console.WriteLine("Для очистки экрана можно ввести clear");
            Console.WriteLine("Для вычисления косинуса/синуса вводим cos или sin и значение угла");
            Console.WriteLine("Для выхода из программы пишем exit (или закрываем окно)");
            Console.WriteLine("Ссылка на GitHub: https://github.com/Flexlug/AngleCalculator");
            Console.WriteLine(new string('=', 40));
            Console.WriteLine();

            while (input != "exit")
            {
                Console.Write("-> ");
                input = Console.ReadLine();
                processingInput = input.Split(' ');

                if (processingInput[0].ToLower() == "clear")
                {
                    Console.Clear();
                    continue;
                }

                if (processingInput[0].ToLower() == "cos")
                {
                    try
                    {
                        fstAngle = new Angle(processingInput[1].Contains('-'),
                                             Convert.ToDouble(processingInput[1].Replace('.', ',')),
                                             Convert.ToDouble(processingInput[2].Replace('.', ',')));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Convertation error");
                        continue;
                    }

                    Console.WriteLine(Math.Cos(fstAngle.ToRadian()));
                    continue;
                }

                if (processingInput[0].ToLower() == "sin")
                {
                    try
                    {
                        fstAngle = new Angle(processingInput[1].Contains('-'),
                                             Convert.ToDouble(processingInput[1].Replace('.', ',')),
                                             Convert.ToDouble(processingInput[2].Replace('.', ',')));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Convertation error");
                        continue;
                    }

                    Console.WriteLine(Math.Sin(fstAngle.ToRadian()));
                    continue;
                }

                if (processingInput[0] == "-" ||
                    processingInput[0] == "+" ||
                    processingInput[0] == "/" ||
                    processingInput[0] == "*")
                {

                    try
                    {
                        fstAngle = new Angle(processingInput[1].Contains('-'),
                                             Convert.ToDouble(processingInput[1].Replace('.', ',')),
                                             Convert.ToDouble(processingInput[2].Replace('.', ',')));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Convertation error");
                        continue;
                    }

                    switch (processingInput[0])
                    {
                        case "+":
                            lastValue += fstAngle;
                            Console.WriteLine(lastValue);
                            Console.WriteLine(new string('-', 20));
                            continue;
                        case "-":
                            lastValue -= fstAngle;
                            Console.WriteLine(lastValue);
                            Console.WriteLine(new string('-', 20));
                            continue;
                        case "/":
                            lastValue /= fstAngle.Degrees;
                            Console.WriteLine(lastValue);
                            Console.WriteLine(new string('-', 20));
                            continue;
                        case "*":
                            lastValue *= fstAngle.Degrees;
                            Console.WriteLine(lastValue);
                            Console.WriteLine(new string('-', 20));
                            continue;
                        default:
                            Console.WriteLine("Incorrect opertaion");
                            Console.WriteLine(new string('-', 20));
                            continue;
                    }
                }

                if (processingInput.Length == 5)
                {
                    try
                    {
                        fstAngle = new Angle(processingInput[0].Contains('-'),
                                             Convert.ToDouble(processingInput[0].Replace('.', ',')), 
                                             Convert.ToDouble(processingInput[1].Replace('.', ',')));

                        sndAngle = new Angle(processingInput[3].Contains('-'), 
                                             Convert.ToDouble(processingInput[3].Replace('.', ',')), 
                                             Convert.ToDouble(processingInput[4].Replace('.', ',')));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Convertation error");
                        continue;
                    }

                    switch(processingInput[2])
                    {
                        case "+":
                            lastValue = fstAngle + sndAngle;
                            Console.WriteLine(lastValue);
                            Console.WriteLine(new string('-', 20));
                            break;
                        case "-":
                            lastValue = fstAngle - sndAngle;
                            Console.WriteLine(lastValue);
                            Console.WriteLine(new string('-', 20));
                            break;
                        case "/":
                            lastValue = fstAngle / sndAngle.Degrees;
                            Console.WriteLine(lastValue);
                            Console.WriteLine(new string('-', 20));
                            break;
                        case "*":
                            lastValue = fstAngle * sndAngle.Degrees;
                            Console.WriteLine(lastValue);
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
