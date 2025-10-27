using System;
using System.Linq;

namespace KaprekarConstant
{
  class Program
  {
    static void Main()
    {
      Console.WriteLine("Nombre  | Constante | Étapes");
      Console.WriteLine("-----------------------------");

      for (int n = 1000; n <= 9999; n++)
      {
        // Vérifie que les 4 chiffres sont tous différents
        if (!AllDigitsUnique(n))
          continue;

        int steps;
        int constant = GetKaprekarConstant(n, out steps);
        Console.WriteLine($"{n:D4}   | {constant}     | {steps}");
      }

      Console.WriteLine("\nTerminé. Appuyez sur une touche pour fermer la fenêtre.");
      Console.ReadKey();
    }

    /// <summary>
    /// Vérifie si les 4 chiffres d’un nombre sont tous différents.
    /// </summary>
    static bool AllDigitsUnique(int n)
    {
      string s = n.ToString("D4");
      return s.Distinct().Count() == 4;
    }

    /// <summary>
    /// Calcule la constante de Kaprekar et le nombre d’itérations nécessaires.
    /// </summary>
    static int GetKaprekarConstant(int n, out int steps)
    {
      steps = 0;
      int previous = -1;

      while (n != previous)
      {
        previous = n;
        n = KaprekarStep(n);
        steps++;

        // Si le résultat reste identique (la constante est atteinte)
        if (n == previous)
        {
          break;
        }
      }

      return n;
    }

    /// <summary>
    /// Réalise une étape du processus de Kaprekar :
    /// trie les chiffres en ordre décroissant et croissant, puis soustrait.
    /// </summary>
    static int KaprekarStep(int n)
    {
      string digits = n.ToString("D4");
      int high = int.Parse(String.Concat(digits.OrderByDescending(c => c)));
      int low = int.Parse(String.Concat(digits.OrderBy(c => c)));
      return high - low;
    }
  }
}
