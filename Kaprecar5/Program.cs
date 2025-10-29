using System;
using System.Linq;

namespace Kaprekar5
{
  class Program
  {
    static void Main()
    {
      Console.WriteLine("Nombre  | Constante | Étapes");
      Console.WriteLine("-----------------------------");

      for (int n = 12_345; n <= 98_765; n++)
      {
        // Vérifie que les 4 chiffres sont tous différents
        if (!AllDigitsUnique(n))
        {
          continue;
        }

        int constant = GetKaprekarConstant(n, out int steps);
        Console.WriteLine($"{n:D5}   | {constant}     | {steps}");
      }

      Console.WriteLine("\nTerminé. Appuyez sur une touche pour fermer la fenêtre.");
      Console.ReadKey();
    }

    /// <summary>
    /// Vérifie si les 4 chiffres d’un nombre sont tous différents.
    /// </summary>
    static bool AllDigitsUnique(int n)
    {
      string s = n.ToString("D5");
      return s.Distinct().Count() == 5;
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
    static int KaprekarStep(int n)
    {
      string digits = n.ToString("D5");
      int high = int.Parse(String.Concat(digits.OrderByDescending(c => c)));
      int low = int.Parse(String.Concat(digits.OrderBy(c => c)));
      return high - low;
    }
  }
}
