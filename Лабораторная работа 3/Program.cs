

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Timers;
using System.Xml.Linq;



class program
{
    static void Main()
    {
        Console.WriteLine("Введите строку: ");
        bool toExit = false;
        string pattern = RemoveSpaces(Console.ReadLine().ToLower());
        string pattern1 = new string(pattern);
        string pattern2 = new string(pattern);
        
        
        while (!toExit)
        {
            char ch;
            Console.WriteLine("Введите букву C - продолжить, X - выход");
            ch = Convert.ToChar(Console.ReadLine());

            


            


            switch (Char.ToLower(ch))
            {


                case 'c':
                    Console.WriteLine("Введите искомую подстроку:");
                    string substr = RemoveSpaces(Console.ReadLine().ToLower());
                    string substr1 = new string(substr);
                    string substr2 = new string(substr);

                    Vstr(pattern1, substr1);
                    Stopwatch timer = new();
                    timer.Start();
                    KMP(pattern2, substr2);
                    timer.Stop();
                    TimeSpan ts = timer.Elapsed;
                    string elapsedTime = String.Format("Поиск Кнута-Морриса-Пратта длился {0}", ts);
                    Console.WriteLine(elapsedTime);
                    break;

                case 'x':
                    Console.WriteLine("Закончить сессию");
                    Console.ReadLine();
                    toExit = true;
                    break;




            }

        }  


        static void Vstr(string pattern, string substr)
        {

            Stopwatch timer = new();
            timer.Start();
            if (pattern.Contains(substr) == false) Console.WriteLine("Не найдена");
            else
                timer.Stop();
            TimeSpan tm = timer.Elapsed;
            string elapsedTime = String.Format("Встроенный поиск длился {0}", tm);
            Console.WriteLine(elapsedTime);

        }

        static int[] GetPrefix(string pattern)
        {
            int[] result = new int[pattern.Length];
            result[0] = 0;

            for (int i = 1; i < pattern.Length; i++)
            {
                int j = result[i - 1];
                while (pattern[j] != pattern[i] && j > 0)
                {
                    j = result[j - 1];
                }
                if (pattern[j] == pattern [i])
                {
                    result[i] = j + 1;
                }
                else
                {
                    result[i] = 0;
                }
            }
            return result;
        }

        static int KMP(string pattern, string substr)
        {

            int[] pf = GetPrefix(pattern);
            int index = 0;

            for (int i = 0; i < substr.Length; i++)
            {
                while (index > 0 && pattern[index] != substr[i]) { index = pf[index - 1]; }
                if (pattern[index] == substr[i]) index++;
                if (index == pattern.Length)
                {
                    return i - index + 1;
                }
            }
            return -1;

        }
        static string RemoveSpaces(string str)
        {
            return str.Replace(" ", "");
        }

    }
}




