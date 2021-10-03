using System;

namespace PZ1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(From_8_To_16_And_Back(200));
            Console.WriteLine(Plus_In_2(1010100, 10100));
        }

        static bool IsDouble(double number)
        {
            return number - (int)number > 0;
        }

        static string Int_From_10_To_2(double number)
        {
            string strbefore = "";
            string str = "";
            while (number >= 1)
            {
                if (number == 1)
                {
                    strbefore += 1;
                    break;
                }
                strbefore += (int)number % 2 == 0 ? 0 : 1;
                number /= 2;

            }
            for (int i = strbefore.Length - 1; i >= 0; i--)
            {
                str += strbefore[i];
            }
            return str;
        }

        static string From_2_To_10(double number, bool inWhich)
        {
            string str = "";
            int i = (number + "").Length - 1;
            str = number + "";
            int n = 0;
            int num = 0;
            while (i >= 0)
            {
                num += (Convert.ToInt32(Convert.ToString(str[n])) * (int)Math.Pow(2, i));
                i--;
                n++;
            }
            return num + "";
        }

        static string From_8_To_10(int number)
        {
            var i = (number + "").Length-1;
            var str = number + "";
            int num = 0;
            int n = 0;
            while (i >= 0)
            {
                num += (Convert.ToInt32(Convert.ToString(str[n])) * (int)Math.Pow(8, i));
                i--;
                n++;
            }
            return num+"";
        }

        static string From_16_To_10(string sxt)
        {
            var temp1 = "";
            var temp2 = "";
            foreach (var item in sxt)
            {
                int t = 0;
                if (int.TryParse(Convert.ToString(item), out t))
                    temp1 += item;
                else
                    temp2 += item;
            }
            var number = Convert.ToInt32(temp1);
            var i = sxt.Length - 1;
            var str = number + "";
            int num = 0;
            int i2 = 0;
            int n = 0;
            while (i >= 0)
            {
                if (n < str.Length)
                {
                    num += (Convert.ToInt32(Convert.ToString(str[n])) * (int)Math.Pow(16, i));
                    i--;
                    n++;
                }
                else
                {
                    if (temp2[i2] == 'F')
                    {
                        num += 15 * (int)Math.Pow(16, i);
                        i2--;
                        i--;
                    }
                    else if (temp2[i2] == 'E')
                    {
                        num += 14 * (int)Math.Pow(16, i);
                        i2--;
                        i--;
                    }

                    else if (temp2[i2] == 'D')
                    {
                        num += 13 * (int)Math.Pow(16, i);
                        i2--;
                        i--;
                    }
                    else if (temp2[i2] == 'C')
                    {
                        num += 12 * (int)Math.Pow(16, i);
                        i2--;
                        i--;
                    }
                    else if (temp2[i2] == 'B')
                    {
                        num += 11 * (int)Math.Pow(16, i);
                        i2--;
                        i--;
                    }
                    else
                    {
                        num += 10 * (int)Math.Pow(16, i);
                        i2--;
                        i--;
                    }
                }
            }
            return num + "";
        }

        static string From_10_To_16(int number)
        {
            string strbefore = "";
            string str = "";
            while (number >= 1)
            {
                if(number % 16 == 10)
                {
                    strbefore += "A";
                    number /= 16;
                }
                else if(number % 16 == 11)
                {
                    strbefore += "B";
                    number /= 16;
                }
                else if (number % 16 == 12)
                {
                    strbefore += "C";
                    number /= 16;
                }
                else if (number % 16 == 13)
                {
                    strbefore += "D";
                    number /= 16;
                }
                else if (number % 16 == 14)
                {
                    strbefore += "E";
                    number /= 16;
                }
                else if (number % 16 == 15)
                {
                    strbefore += "F";
                    number /= 16;
                }
                else
                {
                    strbefore += number % 16;
                    number /= 16;
                }
            }
            for (int i = strbefore.Length - 1; i >= 0; i--)
            {
                str += strbefore[i];
            }
            return str;
        }

        static string From_10_To_2_And_Back(double number, bool inWhich)
        {
            if (number < 2 && number >= 0)
                return "-1";
            string strbefore = "";
            string str = "";
            if (inWhich && !IsDouble(number))
            {
                return Int_From_10_To_2(number);
            }
            else if(inWhich && IsDouble(number))
            {
                str += Int_From_10_To_2((int)number) + ",";

                double dobl = number - (int)number;
                int i = 1;
                while (i<=4)
                {
                    str += (int)(dobl * 2);
                    dobl *= 2;
                    i++;
                    if (dobl >= 1)
                        dobl -= 1;
                }
                return str;
            }
            else if (!inWhich && !IsDouble(number))
            {
                return From_2_To_10(number, inWhich);
            }
            else
            {
                double numb = number - (int)number;
                str += numb + "";
                int n = 0;
                double num = 0; 
                while(n <= 4)
                {
                    double d;
                    if (Convert.ToInt32(Convert.ToString(str[n + 2])) == 0)
                        d = 0.0;
                    else
                        d = 1.0;
                    num += d * (1.0/((int)Math.Pow(2, n+1)));
                    n++;
                }
                num += Convert.ToInt32(From_2_To_10((int)number, inWhich));
                return Math.Round(num,4) + "";
            }
        }

        static string From_8_To_16_And_Back(int number)
        {
            string str = "";

            var res1 = From_8_To_10(number);
            return str += From_10_To_16(Convert.ToInt32(res1));
        }

        static string Plus_In_2(int i1, int i2)
        {
            string str1 = From_2_To_10(i1, true);
            string str2 = From_2_To_10(i2, true);
            int res = Convert.ToInt32(str1) + Convert.ToInt32(str2);
            return From_10_To_2_And_Back(res, true);
        }

    }
}
