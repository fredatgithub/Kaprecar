using System;

namespace Kaprecar
{
  internal class Program
  {
    static void Main()
    {
      /*
       * Write a console application for all 4 digit numbers
          Write the number highest possible with these 4 digits
          Substract with the lowest number with these 4 digits
          And do that until the result keeps the same 
          This is what we call la constant de Kaprekar
          List all four digit number with their constant 
       * */
      Action<string> Display = Console.WriteLine;
      Display("Kaprekar Constant for all 4 digit numbers:");
      for (int i = 1234; i <= 9999; i++)
      {

        int result = Kaprekar(i);
        Console.WriteLine($"{i} -> {result}");
      }

      Display("Press any key to exit...");
      Console.ReadKey();
    }

    private static int Kaprekar(int i)
    {
      // Convert number to string and pad with leading zeros if necessary
      string numStr = i.ToString("D4");
      // Create highest and lowest numbers from the digits
      char[] digits = numStr.ToCharArray();
      Array.Sort(digits);
      string lowStr = new string(digits);
      Array.Reverse(digits);
      string highStr = new string(digits);
      // Convert back to integers
      int low = int.Parse(lowStr);
      int high = int.Parse(highStr);
      // Calculate the difference
      return high - low;
    }
  }
}
