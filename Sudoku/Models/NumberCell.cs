using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Livet;

namespace Sudoku.Models
{
    public class NumberCell : NotificationObject
    {
        /*
         * NotificationObjectはプロパティ変更通知の仕組みを実装したオブジェクトです。
         */
        
        #region Number変更通知プロパティ
        private int _Value = 0;

        public int? Value
        {
            get
            { return (_Value == 0) ? null : (int?)_Value; }
            set
            { 
                if (_Value == value)
                    return;                
                else if (value == 0 || value == null)
                    _Value = 0;
                else if (value > 0 && value <= 9)
                    _Value = (int)value;
                else
                    throw new InvalidOperationException("設定された数値が正しくありません。");

                RaisePropertyChanged(() => Value);
            }
        }
        #endregion

        #region Visible変更通知プロパティ
        private bool _Visible = true;

        public bool Visible
        {
            get
            { return _Visible; }
            set
            { 
                if (_Visible == value)
                    return;
                _Visible = value;
                RaisePropertyChanged(() => Visible);
            }
        }
        #endregion
    }
}
