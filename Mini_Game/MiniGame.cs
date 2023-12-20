using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Mini_Game
{
    internal class MiniGame
    {
        private int originalWidth = Console.WindowWidth;
        private int originalHeight = Console.WindowHeight;
        private int[,] playerGrid = {
        { 1, 2, 3, 4, 5 },
        { 6, 7, 8, 9, 10 },
        { 11, 12, 13, 14, 15 },
        { 16, 17, 18, 19, 20 },
        { 21, 22, 23, 24, 25 }
        };
        private int previousLocationOfThePlayer;
        private int tempPreviousLocationOfThePlayer;
        private int currentLocationOfThePlayer;
        private int locationOfTheFood;
        private string[] playerStates = { /* Add player states */ };
        private string[] foodTypes = { /* Add food types */ };
        private string currentPlayerState;
        private string currentFoodState;

        private void GameTermination()
        {
            Console.WriteLine();
            InitialGameState();
            Console.WriteLine("Exiting The Game...");
        }

        private void CheckTerminalSize()
        {
            int currentWidth = Console.WindowWidth;
            int currentHeight = Console.WindowHeight;

            if (originalWidth != currentWidth || originalHeight != currentHeight)
            {
                Console.Clear();
                InitialGameState();
                Console.WriteLine("Console was resized. Program exiting");
                Environment.Exit(0);
            }
        }

        public void ControlPlayerMoments()
        {
            bool playerMoment = true;

            while (playerMoment)
            {
                CheckTerminalSize();

                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey().Key;

                    if (previousLocationOfThePlayer == 0)
                    {
                        previousLocationOfThePlayer = 1;
                    }

                    if (key == ConsoleKey.UpArrow || key == ConsoleKey.DownArrow || key == ConsoleKey.LeftArrow || key == ConsoleKey.RightArrow)
                    {
                        switch (key)
                        {
                            case ConsoleKey.UpArrow:
                                if (CanMove(previousLocationOfThePlayer, currentLocationOfThePlayer, changeValue: -5))
                                {
                                    currentLocationOfThePlayer = previousLocationOfThePlayer - 5;
                                    tempPreviousLocationOfThePlayer = previousLocationOfThePlayer;
                                    previousLocationOfThePlayer = currentLocationOfThePlayer;
                                    InitialGameState();
                                }
                                break;

                            case ConsoleKey.DownArrow:
                                if (CanMove(previousLocationOfThePlayer, currentLocationOfThePlayer, changeValue: +5))
                                {
                                    currentLocationOfThePlayer = previousLocationOfThePlayer + 5;
                                    tempPreviousLocationOfThePlayer = previousLocationOfThePlayer;
                                    previousLocationOfThePlayer = currentLocationOfThePlayer;
                                    InitialGameState();
                                }
                                break;

                            case ConsoleKey.LeftArrow:
                                if (CanMove(previousLocationOfThePlayer, currentLocationOfThePlayer, changeValue: -1))
                                {
                                    currentLocationOfThePlayer = previousLocationOfThePlayer - 1;
                                    tempPreviousLocationOfThePlayer = previousLocationOfThePlayer;
                                    previousLocationOfThePlayer = currentLocationOfThePlayer;
                                    InitialGameState();
                                }
                                break;
                            case ConsoleKey.RightArrow:
                                if (CanMove(previousLocationOfThePlayer, currentLocationOfThePlayer, changeValue: +1))
                                {
                                    currentLocationOfThePlayer = previousLocationOfThePlayer + 1;
                                    tempPreviousLocationOfThePlayer = previousLocationOfThePlayer;
                                    previousLocationOfThePlayer = currentLocationOfThePlayer;
                                    InitialGameState();
                                }
                                break;
                            default:
                                Console.WriteLine("Invalid Operation");
                                break;

                        }
                    }

                    else if (key == ConsoleKey.Escape)
                    {
                        Console.WriteLine("Are You Sure That You Want to Exit?(y/n)");
                        string userInput = Console.ReadLine().Trim().ToLower();

                        if (userInput == "y")
                        {
                            playerMoment = false;
                            GameTermination();
                        }
                        else if (userInput == "n")
                        {
                            continue;
                        }
                    }

                    else
                    {
                        playerMoment = false;
                        GameTermination();
                    }

                }
            }
        }

        private bool CanMove(int previousPlayerposition, int currentplayerPosition, int changeValue = 0)
        {
            int previousLocation = previousPlayerposition;
            int newLocation = currentplayerPosition + changeValue;

            return (newLocation >= 1 && newLocation <= 25);
        }

        public void SpawnFood()
        {
            // Implement food spawning logic
        }

        public string CurrentPlayerAppearance()
        {
            // Implement logic to get current player appearance
            return currentPlayerState;
        }

        public void ChangeThePlayerMoments()
        {
            // Implement logic to change player moments
        }

        public void InitialGameState()
        {
            // Implement logic for initializing the game state
            Console.WriteLine($"Player Previous Position: {tempPreviousLocationOfThePlayer}");
            Console.WriteLine($"Player Current Position: {currentLocationOfThePlayer}");

            Console.WriteLine($"Location Of The Food: {locationOfTheFood}\n");
        }
    }
}

}
