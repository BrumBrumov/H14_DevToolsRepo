using System;

class BitTowerOfDoom
{
    static void Main()
    {
        int[] field = new int [8];
        int knightsEntered = 0;
        int knightsLeft = 0;

        for (int i = 0; i < 8; i++)
        {
            field[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if ((field[i] & (1 << j)) != 0) knightsEntered++;
            }
        }

        int knightsJumped = 0;
        string input = string.Empty;

        while (input != "end")
        {

            input = Console.ReadLine();

            if (input == "select")
            {
                int posX = int.Parse(Console.ReadLine());
                int posY = 7 - int.Parse(Console.ReadLine());
                field[posX] &= ~(field[posX] & (1 << posY));
            }

            else if (input == "move")
            {
                int posX = int.Parse(Console.ReadLine());
                int posY = 7 - int.Parse(Console.ReadLine());
                if (posY > 7 || posY < 0)
                {
                    if (posX < 2) knightsJumped++;
                    continue;
                }
                else
                {
                    if ((field[posX] & (1 << posY)) == 0 && (field[posX] & (1 << posY - 1)) == 0 && (field[posX] & (1 << posY + 1)) == 0) field[posX] |= 1 << posY; 
                }
            }
            else if (input == "kill")
            {
                int posX = int.Parse(Console.ReadLine());
                int posY = 7 - int.Parse(Console.ReadLine());

                if (posY > 7 || posY < 0)
                {
                    if (posX < 2) knightsJumped++;
                    continue;
                }
                else
                {
                    if ((field[posX] & (1 << posY)) == 0 && (field[posX] & (1 << posY - 1)) != 0 && (field[posX] & (1 << posY + 1)) == 0) field[posX] &= ~(1 << posY - 1);
                    else if ((field[posX] & (1 << posY)) == 0 && (field[posX] & (1 << posY - 1)) == 0 && (field[posX] & (1 << posY + 1)) != 0) field[posX] &= ~(1 << posY + 1);
                    else if ((field[posX] & (1 << posY)) == 0 && (field[posX] & (1 << posY - 1)) == 0 && (field[posX] & (1 << posY + 1)) == 0) field[posX] |= 1 << posY; 
                }
            }
        }

        knightsLeft = knightsJumped;  
        int sum = 0;

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if ((field[i] & (1 << j)) != 0) knightsLeft++;
            }
            sum += field[i];
        }
        Console.WriteLine("{0}\n{1}\n{2}",knightsEntered, knightsLeft, sum);
        
    }
}

