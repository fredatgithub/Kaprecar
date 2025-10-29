using System;
using System.Linq;

namespace Kaprecar51
{
  internal class Program
  {
    static void Main()
    {
      int number = 12_345;
      Console.WriteLine($"Nombre de départ : {number:D5}");
      int constant = GetKaprekarConstant(number, out int steps);
      Console.WriteLine($"{number:D5}   | {constant}     | {steps}");

      Console.WriteLine("\nAppuyez sur une touche pour fermer la fenêtre.");
      Console.ReadKey();
    }

    /// <summary>
    /// Calcule la constante de Kaprekar et le nombre d’itérations nécessaires.
    /// </summary>
    static int GetKaprekarConstant(int number, out int steps)
    {
      steps = 0;
      int previous = -1;

      while (number != previous)
      {
        previous = number;
        number = KaprekarStep(number);
        steps++;
        Console.WriteLine($"previous : {previous} - steps : {steps} - number : {number:D5}");
        // Si le résultat reste identique (la constante est atteinte)
        if (number == previous)
        {
          break;
        }
      }

      return number;
    }

    /// <summary>
    /// Réalise une étape du processus de Kaprekar :
    /// trie les chiffres en ordre décroissant et croissant, puis soustrait.
    /// </summary>
    static int KaprekarStep(int number)
    {
      string digits = number.ToString("D5");
      int high = int.Parse(String.Concat(digits.OrderByDescending(c => c)));
      int low = int.Parse(String.Concat(digits.OrderBy(c => c)));
      return high - low;
    }
  }
}
