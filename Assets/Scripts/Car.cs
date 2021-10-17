// 引用Unity API
using UnityEngine;

// class - 類別 (藍圖)  /  Car - 檔名，名稱需要相同且大小寫也須一致
public class Car : MonoBehaviour
{
    #region 欄位語法與四大基本類型
    // 認識欄位 Field - 作用是儲存資料
    // 語法格式：
    // 修飾詞 資料類型 欄位名稱 指定(=) 預設值 結束符號(;)
    // 常用四大資料類型
    // 1. 整數 沒有小數點的正負整數 int     預設值 0
    // 2. 浮點數 有小數點的正負整數 float   預設值 0
    // 3. 字串 文字資訊  string    預設值 空值
    // 4. 布林值 是與否 true、false  bool  預設值 false
    // 修飾詞
    // 私人 僅限此類別存取 Unity 不會公開顯示 private (預設)
    // 公開 所有類別皆可存取 Unity 會公開顯示 public

    // 欄位屬性 Attritube
    // 語法格式：
    // [屬性名稱(值)] - 必須放在欄位前面或者是上一行
    // 1. 標題 Header (字串)
    // 2. 提示 Tooltip (字串)

    [Header("汽車的CC數"), Range(1000, 5000)]
    public int cc = 2000;
    [Tooltip("這是汽車的重量，範圍是 3 ~ 15"), Range(3, 15)]
    public float weight = 3.5f;
    public string brand = "BMW";
    public bool hasSkyWindow = true;
    #endregion

    #region 遊戲常用的資料類型
    // 顏色 Color
    public Color color1;
    public Color colorRed = Color.red;
    public Color colorCustom = new Color(0, 0, 1);
    public Color colorCustomAlpga = new Color(0, 1, 0, 0.3f);
    // 座標 Vector
    // Vector 有 2 - 4 維
    public Vector2 v2;
    public Vector2 v2One = Vector2.one;
    public Vector2 v2Custom = new Vector2(7, 9);
    public Vector3 v3Custom = new Vector3(1, 2, 3);
    public Vector4 v4Custom = new Vector4(1, 2, 3, 4);
    // 案件 KeyCode
    public KeyCode kc;
    public KeyCode kcW = KeyCode.W;
    public KeyCode kcML = KeyCode.Mouse0;

    // 遊戲物件 GameObject 不須指定預設值
    public GameObject carBox;
    public GameObject caroil;
    // 元件 Component 不須指定預設值
    public Transform traBox;
    public SpriteRenderer sprBox;
    public Camera cam;
    #endregion
}
