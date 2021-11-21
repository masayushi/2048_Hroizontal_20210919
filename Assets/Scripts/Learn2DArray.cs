using UnityEngine;
using System.Linq;  // Lin"Q" => Query 查詢語言 - 資料查詢

/// <summary>
/// 認識二維陣列
/// </summary>
public class Learn2DArray : MonoBehaviour
{
    // 複習一維陣列
    public int[] numbers = { 1, 3, 7, 9, 10, 50 };

    // 學習二維陣列：二維陣列不會顯示在屬性面板(Inspector)上，須裝套件 Odin 自己寫 Editor( Odin須付費)
    public int[,] blocks = { { 2, 4 }, { 6, 8 } };

    public string[,] objects = new string[4, 6];

    public int[,] scores = { { 70, 90 }, { 77, 30 }, { 10, 20 } };

    private void Start()
    {
        #region 陣列的存取

        // 一維陣列的存取
        numbers[4] = 99;
        print("一維陣列第五筆資料：" + numbers[4]);

        // 二維陣列的存取
        print("二維陣列第二列第一欄 1, 0：" + blocks[1, 0]);
        blocks[1, 0] = 14;
        print("二維陣列第二列第一欄 1, 0：" + blocks[1, 0]);
        blocks[1, 1] = 200;
        print("二維陣列第二欄第二列 1, 1：" + blocks[1, 1]);

        print("分數二維陣列第一維度(y軸)長度：" + scores.GetLength(0));
        print("分數二維陣列第二維度(x軸)長度：" + scores.GetLength(1));

        // result(結果值) = ""(空值)
        string result = "";

        for (int i = 0; i < scores.GetLength(0); i++)       // 因為有兩個值，所以需要用兩個for迴圈
        {
            for (int j = 0; j < scores.GetLength(1); j++)   // 名稱不能跟第一個for迴圈相同!!
            {
                result += scores[i, j] + "|";
            }
            result += "\n";
        }
        print(result);
        #endregion

        #region 陣列的資料搜尋

        // 搜尋 numbers 一維陣列內大於等於 10 的資料
        // var 無類型資料型態
        // form 資料A in 陣列    - 從陣列搜尋資料並保存為 資料A
        // where 資料A 條件      - 判斷 資料A 是否符合條件(判斷式)
        // select 資料A;         - 選取 符合條件的 資料A
        var numberGratgerTen =
            from int n in numbers
            where n >= 10
            select n;

        print("符合 >= 10 的資料有幾筆：" + numberGratgerTen.Count());

        for (int i = 0; i < numberGratgerTen.Count(); i++)
        {
            print(">= 10 的資料為：" + numberGratgerTen.ToArray()[i]);
        }

        // scores 不及格的分數有哪些
        var nopass =
            from int no in scores
            where no < 60
            select no;

        for (int i = 0; i < nopass.Count(); i++)
        {
            print("不及格的分數為：" + nopass.ToArray()[i]);
        }
        #endregion


    }
}
