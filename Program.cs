using projetFinalTest.GameLogic;

namespace projetFinalTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Instanciez et démarrez le jeu
            Game game = new Game();
            game.Start();

            // Attendez une action de l'utilisateur avant de fermer
            Console.WriteLine("Appuyez sur une touche pour quitter...");
            Console.ReadKey();
        }
    }
}
