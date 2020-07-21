using System;

namespace DiceRolling
{
    class Program
    {
        static void Main(string[] args)
        {
            bool keepLooping = true;
            int rollNumber = 0;
            int dieSides = 1;

            Console.WriteLine("Welcome to the Grand Circus Casino!");

            while (dieSides < 2)//eliminates attempts of negative numbers, zero, or one
            {
                Console.Write("How many sides should each die have? ");
                dieSides = int.Parse(Console.ReadLine());

                if (dieSides == 1)
                {
                    Console.WriteLine("A one sided die is a ball. Why don't you choose something higher?");
                }
                else if (dieSides < 1)
                {
                    Console.WriteLine("You're going to have to choose a larger number...");
                }
            }

            while (keepLooping)
            {
                rollNumber = rollNumber + 1;

                int die1 = Roll(dieSides);
                int die2 = Roll(dieSides);
                Console.WriteLine();
                Console.WriteLine($"Roll {rollNumber}:");
                Console.WriteLine($"You rolled a {die1} and a {die2} ({die1 + die2} total).");
                if (dieSides == 6)
                {
                    RollResults(die1, die2);
                }
                Console.Write("Roll again? (y/n)?  ");
                string cont = Console.ReadLine();
                if (cont == "n" || cont == "N")
                {
                    keepLooping = false;
                }
                else if (cont != "y" && cont != "Y")
                {
                    Console.WriteLine("You have not selected Y or N, exiting");
                    break;
                }
            }
            Console.WriteLine("Thanks for playing!!");
        }

        static int Roll(int dieSides)
        {
            dieSides = dieSides + 1; //add one to die sizes to make all sides inclusive
            Random dieRoll = new Random(); //generate random integer
            int die = dieRoll.Next(1, dieSides); //output random integer to variable
            return die;
        }

        static void RollResults(int die1, int die2)
        {
            if ((die1 + die2 == 2))
            {
                Console.WriteLine("Snake Eyes!");
            }
            if ((die1 + die2 == 12))
            {
                Console.WriteLine("Box Cars!");
            }
            if ((die1 == 1 && die2 == 2) || (die1 == 2 && die2 == 1))
            {
                Console.WriteLine("Ace Deuce!");
            }
            if ((die1 + die2 == 7) || (die1 + die2 == 11))
            {
                Console.WriteLine("You win!");
                Console.WriteLine();
            }
            if ((die1 + die2 == 12) || (die1 + die2 == 3) || (die1 + die2 == 2))
            {
                Console.WriteLine("Craps!");
                Console.WriteLine();
            }
        }
    }
}
