using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// summary 摘要
/// 資料說明，顯示在 VS 編譯器提示上
/// </summary>
public class LearnMethod : MonoBehaviour
{
    // 方法 Method、Function(也稱為函式)
    // 作用：執行較複雜的程式內容
    // 語法：
    // 修飾詞  傳回資料類型  方法名稱 (參數) { 程式內容(演算法) }
    // 無傳回void
    // 命名習慣：在 Unity 時，習慣方法以大寫開頭
    // 自訂方法：不會自動執行

    public void Test()
    {
        print("我是測試方法~");
    }

    private void Start()
    {
        // 呼叫方法
        // 方法名稱();
        Test();
        Test();
        Drive90();
        Drive150();

        // 呼叫方法：引數
        // 有預設值的參數可以不填寫，系統會自動套入預設值
        Drive(70, "咻咻咻");
        Drive(200, "轟轟轟");
        Drive(300);
        // 問題與範例：時速50的情況下，預設音效是?，特效要石頭
        // 指定預設值的參數語法： 參數名稱 冒號 值
        Drive(50, effect: "石頭");
        // 如果直接寫Drive(50, (音效系統會自己填入) "石頭") 的話，石頭會變成音效。原因是;

        int t = Ten();
        print("傳回方法值：" + t);
        print("不使用變數儲存傳回值：" + Ten());

        int damage = Damage(90, 30);
        print("90 攻擊力與 30防禦力時的傷害：" + damage);
    }

    // 企劃需求
    // 撥放音效
    // 汽車可以加速，時速為 90
    // 汽車可以加速，時速為 150
    public void Drive90()
    {
        print("開車，時速：" + 90);
        print("音效");
    }

    public void Drive150()
    {
        print("開車，時速：" + 150);
        print("音效");
    }

    // 定義方法
    // 參數：資料類型 參數名稱 指定 預設值(指定與預設值可填可不填，非必要 || 預設值必須寫在括弧的最右邊)
    // 參數可以無限制，ex：參數1，參數2，......，參數N
    public void Drive(int speed, string sound = "砰砰砰", string effect = "灰塵")
    {
        print("開車，時速：" + speed);
        print("音效" + sound);
        print("特效：" + effect);
    }

    // 有傳回類型的方法必須使用return傳回
    public int Ten()
    {
        return 10;
    }


    // summary 非必要但很重要 !!
    /// <summary>
    /// 計算傷害值：攻擊力 - 防禦力 = 傷害值
    /// </summary>
    /// <param name="attack">攻擊力</param>
    /// <param name="defence">防禦力</param>
    /// <returns>實際傷害值</returns>
    // 90 - 30 = 60
    public int Damage(int attack, int defence)
    {
        return attack - defence;
    }

}