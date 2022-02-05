using System;
using System.Threading;

namespace Textbased_Adventure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            introduction();
        }
        public static void introduction()
        {
            Console.WriteLine("Welcome to this Textbased Adventure Game");
            Console.WriteLine("Please press 'C' to continue, otherwise press 'Q' to quit");

            ConsoleKey choice;
            choice = Console.ReadKey(true).Key;
            Console.Clear();

            switch (choice)
            {
                case ConsoleKey.C:
                    firstRoom();
                    break;
                case ConsoleKey.Q:
                    Environment.Exit(0);
                    break;
            }
        }

        public static void firstRoom()
        {
            string story;
            string options;

            story = "You wake up in the middle of the night, due to a loud noise downstairs. \n" +
                "As you look outside the bedroom door, you see the shadows of intruders downstairs. \n" +
                "What do you do? \n";

            options = "1. Grap a bat and go downstairs quietly. \n" +
                "2. Call the police and hide in the closet. \n" +
                "3. Hide under the bed. \n";

            Console.WriteLine("{0} \n {1} \n", story, options);
           
            ConsoleKey choice;

            do
            {
                choice = Console.ReadKey(true).Key;
                switch (choice)
                {
                    case ConsoleKey.D1:
                        thirdRoom();
                        break;
                    case ConsoleKey.D2:
                        secondRoom();
                        break;
                    case ConsoleKey.D3:
                        Console.WriteLine("Hiding under the bed was a bad choice. \n " +
                            "Everyone has seen horror movies where people hid under the bed, and look how these turned out...");
                        Thread.Sleep(5000);
                        gameOver();
                        break;
                }
            } while (choice != ConsoleKey.D1 && choice != ConsoleKey.D2 && choice != ConsoleKey.D3);
        }

        public static void secondRoom()
        {
            string story;

            story = "The police is 15 minutes away. Can you stay in the closet for that long though? Y or N \n";

            ConsoleKey choice;

            Console.WriteLine(story);

            do
            {
                choice = Console.ReadKey(true).Key;
                switch (choice)
                {
                    case ConsoleKey.Y:
                        Console.WriteLine("One of the intruders go upstairs and looks into the closet... right at you. \n" +
                        "He grabs you and stabs you.");
                        Thread.Sleep(8000);
                        gameOver();
                        break;
                    case ConsoleKey.N:
                        fifthRoom();
                        break;
                    
                }
            } while (choice != ConsoleKey.Y && choice != ConsoleKey.N);           
        }

        public static void thirdRoom()
        {
            Random rand = new Random();
            string[] options = {"Downstairs you see one of the intruders. You make eyecontact. \n",
                "While going downstairs, you see the frontdoor that is wide open. \n",
                "Arriving downstairs, you quickly grap a kitchen knife. \n"};
            int randomNumber = rand.Next(0, 3);
            string selectedOption = options[randomNumber];

            Console.WriteLine(selectedOption);
            
            if (selectedOption.Contains(options[0]))
            {
                Console.WriteLine("The intruder yells to his comrades. \n" +
                    "They quickly surrounds you and stabs you to death.");
                gameOver();
            }

            if (selectedOption.Contains(options[1]))
            {
                Console.WriteLine("You run outside as fast as you can, but the intruders still notice you. \n" +
                    "Luckily, you find a place to hide until the cops arrive.");
                youWin();
            }

            if (selectedOption.Contains(options[2]))
            {
                Console.WriteLine("After grapping the knife, you manage to stab one of the intruders. \n" +
                    "The others run out of the door to escape the situation, but you are pumped with adrenaline and knocks one of the out. \n" +
                    "Now there is only one left, and he is standing right in front of you with a knife. \n" +
                    "What will you do next? \n");
                string choices = "1. Attack first \n" +
                    "2: Be passive";
                Console.WriteLine(choices);

                ConsoleKey choice;

                do
                {
                    choice = Console.ReadKey(true).Key;
                    switch (choice)
                    {
                        case ConsoleKey.D1:
                            fourthRoom();
                            break;
                        case ConsoleKey.D2:
                            Console.WriteLine("The intruder manages to wound you first. \n" +
                                "You slowly faint.");
                            Thread.Sleep(5000);
                            gameOver();
                            break;
                    }
                } while (choice != ConsoleKey.D1 && choice != ConsoleKey.D2);
            }
        }

        public static void fourthRoom()
        {
            Console.WriteLine("The intruder is much taller, wider and stronger than you. \n" +
                "You try to attack first, but he gets you first.");
            Thread.Sleep(5000);
            gameOver();
        }

        public static void fifthRoom()
        {
            Console.WriteLine("You go outside of the closet and quietly opens the window. \n" +
                "You go outside the window, try to close it, and walks out onto the roof. \n" +
                "You stay here until the police arrive");
            Thread.Sleep(8000);
            youWin();
        }

        public static void youWin()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Amazing play! You are a real winner!! :) \n" +
                "Try again? Press 'Y' \n");
            Console.ResetColor();

            ConsoleKey choice;
            do
            {
                choice = Console.ReadKey(true).Key;
                Console.Clear();
                if (choice == ConsoleKey.Y)
                {
                    firstRoom();
                }
                else
                {
                    Environment.Exit(0);
                }
            } while (choice != ConsoleKey.Y);
        }

        public static void gameOver()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You died by a stab wound. \n" +
                "Game Over! \n" +
                "Wanna try again? \n" +
                "Press 'Y' \n");
            Console.ResetColor();

            ConsoleKey choice;
            do
            {
                choice = Console.ReadKey(true).Key;
                Console.Clear();
                if (choice == ConsoleKey.Y)
                {
                    firstRoom();
                } else
                {
                    Environment.Exit(0);
                }
            } while (choice != ConsoleKey.Y);
        }
    }
}
