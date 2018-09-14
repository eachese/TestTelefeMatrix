using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefeMatrix
{
    public class FindWord
    {
        List<char[]> crossWord;
        List<List<int>> Result;

        public FindWord(string[] secuencias)
        {
            crossWord = new List<char[]>();
            for (int i = 0; i < secuencias.Length; i++)
            {
                crossWord.Add(secuencias[i].ToCharArray());
            }

        }
        public List<List<int>> Find(string key)
        {
            Result = new List<List<int>>();
            char[] keyArray = key.ToCharArray();
            for (int i = 0; i < crossWord.Count; i++)
            {
                for (int j = 0; j < crossWord[i].Length; j++)
                {
                    int ret = CheckPositions(crossWord.ToArray(), key.ToCharArray(), i, j, -1, -1, 0);
                    if (ret == 1)
                    {
                        Result.Reverse();
                        return Result;
                    }
                }
            }
            return Result;
        }
        public int CheckPositions(char[][] array, char[] search, int x, int y, int prevX, int prevY, int pos)
        {
            
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    int newX = x + i;
                    int newY = y + j;

                    if (!(i == 0 && j == 0)
                        &&
                        (newX >= 0 && newY >= 0 && newX < array.Length && newY < array[newX].Length)
                        &&
                        !(newX == prevX && newY == prevY)
                       )
                    {
                        if (array[newX][newY] == search[pos])
                        {
                            if ((pos == search.Length - 1) || (CheckPositions(array, search, newX, newY, x, y, pos + 1) == 1))
                            {
                                Result.Add(new List<int> { (newX + 1), (newY + 1) });
                                return 1;
                            }
                        }
                    }
                }
            }


            return 0;
        }
    }
}
