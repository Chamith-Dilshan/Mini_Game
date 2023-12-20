namespace Mini_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please Enter 'Escape' key to exit the Game.");
            Console.WriteLine("You can change the player position using Arrow Keys");
            Console.WriteLine("Good Luck!\n");

            MiniGame miniGame = new MiniGame();

            miniGame.InitialGameState();
            miniGame.ControlPlayerMoments();
        }
    }
}