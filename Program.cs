using System;

namespace NombreMagique
{
    internal class Program
    {
        static int DemanderNombre(int min, int max)
        {

            int nombreUtilisateur = 0;

            while(nombreUtilisateur < min || nombreUtilisateur > max)
            {
                Console.Write("Veuillez entrer un nombre entre " + min + " et " + max + ": ");
                string reponse = Console.ReadLine();

                try
                {
                    nombreUtilisateur = int.Parse(reponse);
                    if(nombreUtilisateur < min || nombreUtilisateur > max)
                    {
                        Console.WriteLine("Le nombre doit être entre " + min + " et " + max );
                    }
                }
                catch
                {
                    Console.WriteLine("Veuillez entrer un nombre valide");
                }
            }

            return nombreUtilisateur;
        }
        static void Main(string[] args)
        {

            Console.WriteLine("Bienvenue sur NombreMagique !");
            Console.WriteLine("L'objectif du jeu est de deviner le nombre Magique.");

            Random rand = new Random();

            const int NOMBRE_MIN = 1;
            const int NOMBRE_MAX = 10;
            int NOMBRE_MAGIQUE = rand.Next(NOMBRE_MIN, NOMBRE_MAX + 1);

            int nbTentatives = 1;
            int nombre = NOMBRE_MAGIQUE + 1;

            for(int nbVies = 3; nbVies > 0; nbVies--)
            {
                Console.WriteLine();
                Console.WriteLine("Il vous reste: " + nbVies + " vies.");
                nombre = DemanderNombre(NOMBRE_MIN, NOMBRE_MAX);

                if (nombre > NOMBRE_MAGIQUE)
                {
                    Console.WriteLine("Le nombe magique est plus petit.");
                }
                else if (nombre < NOMBRE_MAGIQUE)
                {
                    Console.WriteLine("Le nombre magique est plus grand.");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Bravo, vous avez trouvé le nombre magique au bout de " + nbTentatives + " tentatives !");
                    Console.WriteLine();
                    break;
                }
                nbTentatives++;
            }

            if (nombre != NOMBRE_MAGIQUE)
            {
                Console.WriteLine();
                Console.WriteLine("Il ne vous reste plus de vies, vous avez perdu. Le nombre magique était: " + NOMBRE_MAGIQUE + ".");
                Console.WriteLine();
            }
        }
    }
}
