using System;

namespace OOPLab2._3._2
{
    public class Program
    {
        static public int is_number(string input)
        {
            bool a = true;
            while (a)
            {
                int d = input.Length;
                foreach (char c in input)
                    if (char.IsNumber(c))
                    {
                        if ((input[0] == '0') && (d != 1))
                        {
                            Console.WriteLine("Ви ввели некоректне значення, спробуйте ще раз:\n");
                            input = Console.ReadLine();
                            a = true;
                            break;
                        }
                        a = false;
                    }
                    else if ((input[0] == '-') && (d != 1) && (input[1] != '-'))
                        continue;
                    else
                    {
                        Console.WriteLine("Ви ввели некоректне значення, спробуйте ще раз:");
                        input = Console.ReadLine();
                        a = true;
                        break;
                    }
            }

            return Convert.ToInt32(input);
        }

        static public int minimal(int[] h, int p)
        {
            bool a = true;
            int min = Math.Abs(h[0]);
            for (int i = 0; i < p; ++i)
                if (Math.Abs(min) > Math.Abs(h[i]))
                {
                    min = h[i];
                    if (h[i] < 0)
                        a = false;
                    else
                        a = true;
                }
            if (!a)
                min *= -1;
            return min;
        }

        static public string summa(int[] h, int p)
        {
            int n1 = -1;
            int n2 = -1;
            int s = 1;
            string s0;

            for (int i = 0; i < p; ++i)
                if (h[i] >= 0)
                {
                    n1 = i;
                    break;
                }

            for (int i = 0; i < p; ++i)
                if (h[i] >= 0)
                    n2 = i;

            if (n1 == n2)
            {
                if (n1 == -1)
                {
                    for (int i = 0; i < p; ++i)
                        s += h[i];
                    s0 = s.ToString();
                }
                else if (n1 == p - 1)
                    s0 = "-0-";
                else if (n1 == p - 2)
                    s0 = "-1-";
                else
                {
                    for (int i = n1 + 1; i < p; ++i)
                        s += h[i];
                    s0 = s.ToString();
                }
            }
            else if (n1 == n2 - 1)
                s0 = "-2-";
            else if (n1 == n2 - 2)
                s0 = "-3-";
            else
            {
                for (int i = n1 + 1; i < n2; ++i)
                    s += h[i];
                s0 = s.ToString();
            }
            return s0;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введiть кiлькiсть елементiв масиву:");
            string n = Console.ReadLine();
            int n0 = is_number(n);

            while (n0 < 1)
            {
                Console.WriteLine("Ви ввели некоректне значення, спробуйте ще раз:");
                n = Console.ReadLine();
                n0 = is_number(n);
            }

            int[] a = new int[n0];

            Console.WriteLine("\nЕлементи масиву:");

            int k = 0;
            Random rnd = new Random();
            for (int i = 0; i < n0; ++i)
            {
                a[i] = rnd.Next(-100, 100);
                Console.Write("a[{0}] = " + a[i] + "\n", i + 1);
                if (a[i] >= 0) ++k;
            }


            int min = minimal(a, n0);
            Console.WriteLine("\nМодуль мiнiмального елементу масиву: " + min);

            string s;
            int s0;
            if (k == 0)
            {
                s = summa(a, n0);
                s0 = Convert.ToInt32(s);
                Console.WriteLine("\nОскiльки серед елементiв масиву немає додатних, то була пiдрахована сума усiх елементiв масиву:\n" + (s0 - 1));
            }
            else if (k == 1)
            {
                s = summa(a, n0);
                if (s == "-0-")
                    Console.WriteLine("\nОскiльки додатний елемент масиву є останнiм, то сума елементiв пiсля даного дорiвнює нулю.");
                else if (s == "-1-")
                    Console.WriteLine("\nОскiльки додатний елемент масиву є передостаннiй, то сума елементiв пiсля даного дорiвнює нулю.");
                else
                {
                    s0 = Convert.ToInt32(s);
                    Console.WriteLine("\nОскiльки є лише один додатний елемент масиву, то була пiдрахована сума елементiв розташованих пiсля нього:\n" + (s0 - 1));
                }
            }
            else
            {
                s = summa(a, n0);
                if (s == "-2-")
                    Console.WriteLine("\nОскiльки перший i останнiй додатнi елементи масиву розташованi один пiсля одного, то сума елементiв мiж ними дорiвнює нулю.");
                else if (s == "-3-")
                    Console.WriteLine("\nОскiльки мiж першим i останнiм додатними елементами масиву розташований лише один елемент, то сума елементiв мiж ними дорiвнює нулю.");
                else
                {
                    s0 = Convert.ToInt32(s);
                    Console.WriteLine("\nСума елементiв масиву, розташованих мiж першим й останнiм додатними елементами:\n" + (s0 - 1));
                }

            }
        }
    }
}
