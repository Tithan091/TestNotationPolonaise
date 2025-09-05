using System;

namespace TestNotationPolonaise
{
    class Program
    {
        /// <summary>
        /// Calcul de formules en notation polonaise
        /// </summary>
        /// <param name="formule">formule à calculer</param>
        /// <returns>resultat de la formule</returns>
        static double Polonaise(String formule)
        {
            try
            {
                string[] nombres = formule.Split(' ');
                double val1;
                double val2;
                for (int i = nombres.Length - 1; i >= 0; i--)
                {
                    if (nombres[i] == "+" || nombres[i] == "-" || nombres[i] == "*" || nombres[i] == "/")
                    {
                        val1 = double.Parse(nombres[i + 1]);
                        val2 = double.Parse(nombres[i + 2]);
                        switch (nombres[i])
                        {
                            case "+":
                                nombres[i] = (val1 + val2).ToString();
                                break;
                            case "-":
                                nombres[i] = (val1 - val2).ToString();
                                break;
                            case "*":
                                nombres[i] = (val1 * val2).ToString();
                                break;
                            case "/":
                                if (val2 == 0)
                                {
                                    return double.NaN;
                                }
                                nombres[i] = (val1 / val2).ToString();
                                break;
                        }
                        for (int k = i + 1; k < nombres.Length - 2; k++)
                        {
                            nombres[k] = nombres[k + 2];
                        }
                        nombres[nombres.Length - 1] = " ";
                        nombres[nombres.Length - 2] = " ";
                    }
                    else
                    {
                        if (i == 0 && nombres.Length > 1)
                        {
                            return double.NaN;
                        }
                    }
                }
                return double.Parse(nombres[0]);
            }
            catch
            {
                return float.NaN;
            }
        }

        /// <summary>
        /// saisie d'une réponse d'un caractère parmi 2
        /// </summary>
        /// <param name="message">message à afficher</param>
        /// <param name="carac1">premier caractère possible</param>
        /// <param name="carac2">second caractère possible</param>
        /// <returns>caractère saisi</returns>
        static char saisie(string message, char carac1, char carac2)
        {
            char reponse;
            do
            {
                Console.WriteLine();
                Console.Write(message + " (" + carac1 + "/" + carac2 + ") ");
                reponse = Console.ReadKey().KeyChar;
            } while (reponse != carac1 && reponse != carac2);
            return reponse;
        }

        /// <summary>
        /// Saisie de formules en notation polonaise pour tester la fonction de calcul
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            char reponse;
            // boucle sur la saisie de formules
            do
            {
                Console.WriteLine();
                Console.WriteLine("entrez une formule polonaise en séparant chaque partie par un espace = ");
                string laFormule = Console.ReadLine();
                // affichage du résultat
                Console.WriteLine("Résultat =  " + Polonaise(laFormule));
                reponse = saisie("Voulez-vous continuer ?", 'O', 'N');
            } while (reponse == 'O');
        }
    }
}
