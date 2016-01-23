using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Livet;

namespace Sudoku.Models
{
    public class NumberField : NotificationObject
    {
        private NumberCell[,] field = new NumberCell[9, 9];	// 数独フィールド

        /// <summary>
        /// フィールドを初期化します。
        /// </summary>
        public NumberField()
        {
            this.Initialize();
        }

        public void Initialize()
        {
            for (int i = 0; i < field.GetLength(0); i++)
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (field[i, j] == null)
                        field[i, j] = new NumberCell();
                    else
                        field[i, j].Value = null;
                }
        }

        /// <summary>
        /// フィールド内の指定した場所の数字を設定または取得します。設定できない場合は例外を返します。
        /// </summary>
        /// <param name="row_index">行番号。0-8</param>
        /// <param name="col_index">列番号。0-8</param>
        /// <returns></returns>
        public NumberCell this[int row_index, int col_index]
        {
            get
            {
                if (row_index < 0 && row_index > 8) throw new ArgumentOutOfRangeException("row_index");
                if (col_index < 0 && col_index > 8) throw new ArgumentOutOfRangeException("col_index");

                return field[row_index, col_index];
            }
        }

        /// <summary>
        /// 値が指定した行に設定可能かをチェックします。
        /// </summary>
        /// <param name="row_index">設定先の行番号。</param>
        /// <param name="num">設定する数値。</param>
        /// <returns></returns>
        public bool CheckEnableInRow(int row_index, int num)
        {
            if (row_index < 0 && row_index > 8) throw new ArgumentOutOfRangeException("row_index");
            if (num < 1 && num > 9) throw new ArgumentOutOfRangeException("num");

            for (int i = 0; i < field.GetLength(1); i++)
            {
                if (field[row_index, i].Value == num)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 値が指定した列に設定可能かをチェックします。
        /// </summary>
        /// <param name="col_index">設定先の列番号。</param>
        /// <param name="num">設定する数値。</param>
        /// <returns></returns>
        public bool CheckEnableInColumn(int col_index, int num)
        {
            if (col_index < 0 && col_index > 8) throw new ArgumentOutOfRangeException("col_index");
            if (num < 1 && num > 9) throw new ArgumentOutOfRangeException("num");

            for (int i = 0; i < field.GetLength(0); i++)
            {
                if (field[i, col_index].Value == num)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 値が指定した場所を含むボックスに設定可能かをチェックします。
        /// </summary>
        /// <param name="row_index">設定先の行番号。</param>
        /// <param name="col_index">設定先の列番号。</param>
        /// <param name="num">設定する数値。</param>
        /// <returns></returns>
        public bool CheckEnableInBox(int row_index, int col_index, int num)
        {
            if (row_index < 0 && row_index > 8) throw new ArgumentOutOfRangeException("row_index");
            if (col_index < 0 && col_index > 8) throw new ArgumentOutOfRangeException("col_index");
            if (num < 1 && num > 9) throw new ArgumentOutOfRangeException("num");

            for (int i = (row_index / 3) * 3; i < (row_index / 3) * 3 + 3; i++)
            {
                for (int j = (col_index / 3) * 3; j < (col_index / 3) * 3 + 3; j++)
                {
                    if (field[i, j].Value == num)
                        return false;
                }
            }
            return true;
        }

        public bool CheckEnable(int row_index, int col_index, int num)
        {
            if (row_index < 0 && row_index > 8) throw new ArgumentOutOfRangeException("row_index");
            if (col_index < 0 && col_index > 8) throw new ArgumentOutOfRangeException("col_index");
            if (num < 1 && num > 9) throw new ArgumentOutOfRangeException("num");

            return this.CheckEnableInRow(row_index, num) 
                && this.CheckEnableInColumn(col_index, num) 
                && this.CheckEnableInBox(row_index, col_index, num);
        }
    }
}