using UnityEngine;

public static class NumberToWordConverter
{
    private static readonly string[] Units = { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
    private static readonly string[] Teens = { "", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
    private static readonly string[] Tens = { "", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

    public static string ConvertToWord(int number)
    {
        if (number == 0)
        {
            return "zero";
        }

        return ConvertToWordHelper(number);
    }

    private static string ConvertToWordHelper(int number)
    {
        if (number < 0)
        {
            Debug.LogWarning("Can't convert number to word. Input must be a non-negative integer.");
            return null;
        }

        if (number < 10)
        {
            return Units[number];
        }
        else if (number < 20)
        {
            return Teens[number - 10];
        }
        else if (number < 100)
        {
            return Tens[number / 10] + (number % 10 != 0 ? " " + Units[number % 10] : "");
        }
        else if (number < 1000)
        {
            return Units[number / 100] + " hundred" + (number % 100 != 0 ? " and " + ConvertToWordHelper(number % 100) : "");
        }
        else
        {
            Debug.LogWarning("Can't convert number to word. Input is too large. This class only supports numbers up to 999.");
            return null;
        }
    }
}
