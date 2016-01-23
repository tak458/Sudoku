using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Models
{
    public static class NumberGenerator
    {

        /// <summary>
        /// 数独ルールに基づいた9×9の数字配列を生成します。
        /// </summary>
        public static void Generate(ref NumberField field)
        {
            System.Diagnostics.Debug.WriteLine("数字配列の生成開始");
            field.Initialize();

            Random rand = new Random(Environment.TickCount);

            // チェックした数字をスタックする配列
            int[, ,] numField = new int[9, 9, 9];
            numField.Initialize();

            for (int row = 0; row < numField.GetLength(0); row++)
            {
                for (int col = 0; col < numField.GetLength(1); col++)
                {
                    // 配列の数字入ってない所を探索
                    int k = 0;
                    for (k = 0; k < numField.GetLength(2); k++)
                        if (numField[row, col, k] == 0) break;
                    
                    // 全て埋まってたら全部0埋めして前マスに戻る
                    if (k == numField.GetLength(2))
                    {
                        for (int idx = 0; idx < numField.GetLength(2); idx++)
                            numField[row, col, idx] = 0;
                        field[row, col].Value = 0;

                        // 前々マスに戻る(for文インクリメントを考慮)
                        BackCells(ref numField, ref row, ref col, 2);
                    }
                    else
                    {
                        // 重複しない数字を探索
                        bool check = true;
                        while (check)
                        {
                            check = false;
                            numField[row, col, k] = rand.Next(1, 10);
                            for (int i = 0; i < k; i++)
                                if (numField[row, col, i] == numField[row, col, k])
                                    check = true;
                        }

                        // 配置可能かチェック。OKなら配置。ダメなら再度数値取得。
                        if (field.CheckEnable(row, col, numField[row, col, k]))
                        {
                            field[row, col].Value = numField[row, col, k];
                        }
                        else
                        {
                            // 前マスに戻る(for文インクリメントを考慮)
                            BackCells(ref numField, ref row, ref col, 1);
                        }
                    }
                }
            }
            System.Diagnostics.Debug.WriteLine("数字配列の生成終了");
        }

        private static void BackCells(ref int[, ,] numField, ref int row, ref int col, int backCount)
        {
            int temp = row * numField.GetLength(0) + col - backCount;
            if (temp >= 0)
            {
                row = temp / numField.GetLength(0);
                col = temp % numField.GetLength(0);
            }
        }
    }
}
