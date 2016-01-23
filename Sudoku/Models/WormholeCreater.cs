using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Livet;

namespace Sudoku.Models
{
    public static class WormholeCreater
    {
        public static void Generate(ref NumberField field)
        {
            System.Diagnostics.Debug.WriteLine("虫食い穴の生成開始");

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (i - j == 0 || i + j == 8 ||
                        i - j == 2 || i + j == 6 ||
                        i - j == -2 || i + j == 10)
                    {
                        field[i, j].IsWormHole = false;
                    }
                    else
                    {
                        field[i, j].IsWormHole = true;
                    }
                }
            }

            System.Diagnostics.Debug.WriteLine("虫食い穴の生成完了");
        }
    }
}
