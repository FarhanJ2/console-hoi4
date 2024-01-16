// IDEAS

// TO WIN A WAR OR TILE
// HAVE 5 BATTLES TAKE PLACE IN WHICH THERE WILL BE A LINE IN ThE MIDDLE
// WHOEVER PUSHES IT TO THE ENEMIES SIDE WILL WIN THAT BATTLE AND GET VICTORY POINTS

using System;

class Map
{
    static void Main()
    {
        // Define map size
        int width = 20;
        int height = 10;

        // Create a 2D array to represent the map
        char[,] map = new char[height, width];

        // Initialize the map
        InitializeMap(map);

        // Display the initial map
        DisplayMap(map);

        // Simulate battle progress
        SimulateBattle(map);

        // Display the final map after the battle
        DisplayMap(map);
    }

    // Function to initialize the map with default values
    static void InitializeMap(char[,] map)
    {
        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                // You can set different characters based on terrain or other features
                map[i, j] = '.';
            }
        }

        // Add a line in the middle of the map
        for (int i = 0; i < map.GetLength(0); i++)
        {
            map[i, map.GetLength(1) / 2] = '|';
        }
    }

    // Function to simulate battle progress
    static void SimulateBattle(char[,] map)
    {
        // Simulate side 1 moving to the left
        MoveSide(map, 1, -1);

        // Simulate side 2 moving to the right
        MoveSide(map, map.GetLength(1) - 2, 1);
    }

    // Function to move a side towards a direction
    static void MoveSide(char[,] map, int startingColumn, int direction)
    {
        for (int i = 0; i < map.GetLength(0); i++)
        {
            // Check if the next position is within the map boundaries
            int nextColumn = startingColumn + direction;
            if (nextColumn >= 0 && nextColumn < map.GetLength(1))
            {
                // Move to the next position
                map[i, startingColumn] = '.';
                map[i, nextColumn] = (char)(i % 2 == 0 ? '1' : '2'); // Alternate sides
                startingColumn = nextColumn;
            }
            else
            {
                // Side reached the edge of the map, consider it a victory
                Console.WriteLine($"Side {(startingColumn == 0 ? 1 : 2)} wins the battle!");
                break;
            }
        }
    }

    // Function to display the map in the console
    static void DisplayMap(char[,] map)
    {
        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                Console.Write(map[i, j] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}
