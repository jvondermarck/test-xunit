namespace MorpionApp;

public class Program
{
    static void Main(string[] args)
    {
        PlayGames();
    }

    static void PlayGames()
    {
        while (true)
        {
            Console.WriteLine("Jouer à quel jeu ? Taper [X] pour le morpion et [P] pour le puissance 4.");
            var key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.X:
                    PlayMorpion();
                    break;
                case ConsoleKey.P:
                    PlayPuissanceQuatre();
                    break;
                case ConsoleKey.Escape:
                    return;
                default:
                    Console.WriteLine("Choix invalide. Réessayez.");
                    break;
            }
        }
    }

    static void PlayMorpion()
    {
        Morpion morpion = new Morpion();
        morpion.BoucleJeu();
    }

    static void PlayPuissanceQuatre()
    {
        PuissanceQuatre puissanceQuatre = new PuissanceQuatre();
        puissanceQuatre.BoucleJeu();
    }
}