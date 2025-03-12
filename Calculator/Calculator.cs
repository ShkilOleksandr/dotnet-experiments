using System;

namespace Calculator;



public static class Calculator
{

    public static int Calculate(object value)
    {
        if (value is string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return 0;
            }

            string[] delims;
            if (str.StartsWith("//["))
            {
                delims = [str[(str.IndexOf('[') + 1)..str.IndexOf(']')], ",", "\n"];
            }
            else if (str.StartsWith("//"))
            {
                delims = [str[2].ToString(), ",", "\n"];
            }
            else
            {
                delims = [",", "\n"];
            }
            string[] values = str.Split(delims, StringSplitOptions.None);
            int sum = 0;
            for (int i = (str.StartsWith("//") ? 1 : 0); i < values.Length; i++)
            {
                string v;
                if (str.StartsWith("//[") && i == 1)
                {
                    v = values[i][1..values[i].Length];
                }
                else
                {
                    v = values[i];
                }
                int t = int.Parse(v);
                if (t < 0)
                    throw new ArgumentException();
                if (t > 1000)
                    continue;
                sum += t;
            }
            return sum;
        }
        return Convert.ToInt32(value);
    }


}