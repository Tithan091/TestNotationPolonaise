using System;

namespace TestNotationPolonaise
{
    class Program
    {
        /// <summary>
        /// Calcul de formules en notation polonaise
        /// </summary>
        /// <param name="formule">formule en notation polonaise</param>
        /// <returns>résultat de la formule</returns>
        static double Polonaise(String formule)
        {
            try
            {
                // transformation de la formule en vecteur
                string[] nombres = formule.Split(' ');
                // déclaration
                double val1;
                double val2;
                double resultat = 0;
                // lecture et calcul de la formule
                for (int i = nombres.Length - 1; i >= 0; i--)
                {
                    // si la valeur correspond à un opérateur mathématique
                    if (nombres[i] == "+" || nombres[i] == "-" || nombres[i] == "*" || nombres[i] == "/")
                    {
                        // récupérer les deux nombres suivants dans le vecteur
                        val1 = double.Parse(nombres[i + 1]);
                        val2 = double.Parse(nombres[i + 2]);
                        // calcul des deux nombres
                        switch (nombres[i])
                        {
                            case "+":
                                resultat = val1 + val2;
                                break;
                            case "-":
                                resultat = val1 - val2;
                                break;
                            case "*":
                                resultat = val1 * val2;
                                break;
                            case "/":
                                // si division par 0
                                if (val2 == 0)
                                {
                                    return double.NaN;
                                }
                                resultat = val1 / val2;
                                break;
                        }
                        // assignation du résultat à la case du vecteur contenant l'opérateur
                        nombres[i] = resultat.ToString();
                        // décalage des cases suivantes
                        for (int k = i + 1; k < nombres.Length - 2; k++)
                        {
                            nombres[k] = nombres[k + 2];
                        }
                        // vider les deux dernières cases du vecteur (inutile après le premier calcul)
                        nombres[nombres.Length - 1] = " ";
                        nombres[nombres.Length - 2] = " ";
                    }
                    else
                    {
                        // si la première case du vecteur n'est pas un signe
                        if (i == 0 && nombres.Length > 1)
                        {
                            return double.NaN;
                        }
                    }
                }
                // retourner le résultat final qui est contenu dans la première case du vecteur
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
