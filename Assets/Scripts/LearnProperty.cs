using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearnProperty : MonoBehaviour
{
    // 欄位
    public int passwordField = 123456789;

    // 屬性 Property
    // 語法：
    // 修飾詞  資料類型  屬性名稱 { 存取子 }
    // 自動實作
    // get 取得
    // set 設定
    public int passwordProperty { get; set; }

    // 唯讀屬性：只能取得特定的單一資料
    // public int myPasswordProperty { get; } <- 這樣寫的話就被固定了
    // => 黏巴達 Lambda 於C# 6.0後才能使用(不過現在Unity只支援7.0後開始的C#)
    public int myPasswordProperty { get => 999; }

    // 唯讀完整寫法
    // get 需使用關鍵字 return 傳回

    public string nameCharacter
    {
        get
        {
            print("我在屬性 name Charater 裡!!");
            return "yushi";
        }
    }

    // 唯寫完整寫法 (遊戲製作上較少用唯寫)
    // Set 使用關鍵字 value 輸入值
    public float attack
    {
        set
        {
            print("攻擊力：" + value);
        }
    }


    void Start()
    {
        // 存放 Set 欄位資料
        // 語法：
        // 屬性名稱 指定 值：
        passwordProperty = 777;

        // 取得 Get 欄位資料 
        // 語法：
        // 屬性名稱
        print("屬性名稱：" + passwordProperty);

        // myPasswordProperty = 999; // 唯讀屬性不能被設定，所以這寫法是錯的
        print("我的屬性密碼：" + myPasswordProperty);

        print(nameCharacter);

        // print(attack);            // 唯寫屬性不能夠放在print內傳回，所以這是錯誤寫法  
        attack = 999.9f;
    }
}
