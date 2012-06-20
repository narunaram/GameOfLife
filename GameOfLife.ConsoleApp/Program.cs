using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GOILib;
using GOILib.Contracts;

namespace GameOfLife.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Cell[] cells = null;
            // Ask the user for initial state
            Console.WriteLine("\t\tWelcome to the game of life.\n");
            PrintWelcomeAndInstructions();
            
            // Get proper initial state from the user
            string userinput = GetValidUserInput(ref cells);
            if (!string.IsNullOrWhiteSpace(userinput))
            {
                // Create a Grid
                Grid grid = new Grid(4, 4);

                SetInitialGridState(cells, grid);

                IGameOfLife gameoflife = GetGameOfLifeController(grid);

                // Print the current state
                PrintCellState(grid);

                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("Press to evolve to next generation.\n");
                    Console.ReadLine();

                    gameoflife.Evolve();
                    PrintCellState(grid);
                }

                Console.WriteLine("Game over. Press enter to exit.");
                Console.ReadLine();
            }
        }

        private static void SetInitialGridState(Cell[] cells, Grid grid)
        {
            // Initialize with certain seed values got from the user (validation of the user input can be done while initializing as well)
            foreach (Cell cell in cells)
            {
                grid[cell.RowNumber, cell.ColumnNumber].IsAlive = true;
            }
        }

        private static string GetValidUserInput(ref Cell[] cells)
        {
            string userinput = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(userinput))
            {
                return string.Empty;
            }
            while (true)
            {
                try
                {
                    cells = AcceptAndValidateUserInput(userinput);
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\n\n\n\n\nInvalid input! Please read the instructions below and try again.\n\n");
                    PrintWelcomeAndInstructions();
                    userinput = Console.ReadLine();
                }
            }
            return userinput;
        }

        private static IGameOfLife GetGameOfLifeController(Grid grid)
        {
            // Create the neighbourhood rule
            INeighbourRuleFactory neighbourrulefactory = new NeighbourRuleFactory();

            // Create the evolution rule
            IEvolutionRuleFactory evolutionruefactory = new EvolutionRuleFactory();

            IGameOfLife gameoflife = new BasicGameOfLife(grid, evolutionruefactory, neighbourrulefactory);
            return gameoflife;
        }

        private static void PrintCellState(Grid grid)
        {
            int rowno = 0;
            foreach (Cell cell in grid)
            {
                if (rowno != cell.RowNumber)
                {
                    rowno++;
                    Console.WriteLine();
                }
                Console.Write("{0}\t", cell.IsAlive ? "Live" : "Dead");
            }
            Console.WriteLine();
        }

        private static Cell[] AcceptAndValidateUserInput(string userInput)
        {
            List<Cell> cells = new List<Cell>();
            string[] cellsinstringformat = userInput.Split('|');

            if (string.IsNullOrWhiteSpace(userInput))
            {
                return cells.ToArray();
            }

            if (cellsinstringformat.Length == 0)
            {
                throw new Exception("Invalid user input.");
            }

            for (int i = 0; i < cellsinstringformat.Length; i++)
            {
                string[] coordinstring = cellsinstringformat[i].Split(',');
                if (coordinstring.Length != 2)
                {
                    throw new Exception("Invalid user input.");
                }
                int rownum;
                int colnum;
                if (!Int32.TryParse(coordinstring[0], out rownum))
                {
                    throw new Exception("Invalid user input.");
                }
                if (!Int32.TryParse(coordinstring[1], out colnum))
                {
                    throw new Exception("Invalid user input.");
                }
                cells.Add(new Cell(rownum, colnum, true));
            }
            return cells.ToArray();
        }

        private static void PrintWelcomeAndInstructions()
        {
            Console.WriteLine("Please enter the initial values for a 4 by 4 Grid of Cells.\n");
            Console.WriteLine("You need to only specify the cells that are originally alive.\n");
            Console.WriteLine("Specify the live cells in the following format.");
            Console.WriteLine("<rownum>,<colnum> | <rownum>,<columnnum>\n");
            Console.WriteLine("Example - 0,0| 2,2 - Means that the cells in the specific rownumber and the column number are alive.\n");
            Console.WriteLine("This example evolves the cells 10 times.");
            Console.WriteLine("Press ENTER after entering the values. Waiting...");
            Console.WriteLine("Press ENTER without anything else to exit.");
        }
    }
}
