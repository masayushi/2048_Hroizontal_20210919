using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 認識運算子
// 1. 指定
// 2. 數學
// 3. 比較
// 4. 邏輯
/// <summary>
/// 運算子筆記
/// </summary>
public class LearnOperator : MonoBehaviour
{
    public float a = 10;
    public float b = 3;
    public int c = 30;
    public int hp = 100;

    private void Start()
    {
        #region 指定運算子
        // 指定 = 
        // 先執行指定運算子右邊後才會再執行左邊

        #endregion

        #region 數學運算子
        // 加減乘除餘
        // + - * / %
        print("加法：" + (a + b));         // 結果：13
        print("減法：" + (a - b));         // 結果：7
        print("乘法：" + (a * b));         // 結果：30
        print("除法：" + (a / b));         // 結果：3.333
        print("餘：" + (a % b));          // 結果：1

        c = c + 1;                        // 原始寫法
        print("c 結果：" + c);
        c++;                              // 遞增 ++ ，遞減 -- (一次只加1)
        print("c 結果：" + c);

        hp = hp + 10;
        print("HP 結果：" + hp);
        hp += 10;                         // 適用於所有數學運算子!! ex: += -= *= /= %=
        print("HP 結果：" + hp);
        #endregion

        #region 比較運算子
        // 大於、小於、大於等於、小於等於、等於、不等於
        // >、<、>=、<=、==、!=
        // 比較兩個值，並且得到的結果為布林值
        print("a > b" + (a > b));         // t
        print("a < b" + (a < b));         // f
        print("a >= b" + (a >= b));         // t
        print("a <= b" + (a <= b));         // f
        print("a == b" + (a == b));         // f
        print("a != b" + (a != b));         // t
        #endregion

        #region 邏輯運算子
        // 並且、或者、顛倒
        // && || !
        // 並且、或者
        // 比較兩個布林值，並且得到的結果為布林值

        // 並且：只要有一個 f 結果就會是 f 
        print("t && t" + (true && true));    // t
        print("f && t" + (false && true));    // f
        print("t && f" + (true && false));    // f
        print("f && f" + (false && false));    // f

        // 或者：只要有一個 t 結果就會是 t 
        print("t || t" + (true || true));    // t
        print("f || t" + (false || true));    // t
        print("t || f" + (true || false));    // t
        print("f || f" + (false || false));    // f
        // 快速選取快捷鍵：Alt + Shift + > 
        #endregion

        #region 顛倒運算子
        // 顛倒：只能加在布林值前面
        print(!true);                // f
        print(!(a > b));             // f
        print(!(true && true));      // f
        #endregion


    }

}
