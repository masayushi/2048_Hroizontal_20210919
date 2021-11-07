using UnityEngine;

public class LearnAPIPropertyStatic : MonoBehaviour
{
    private void Start()
    {
        // 靜態屬性 Static Property
        // 取得靜態屬性
        // 語法：類別名稱.靜態屬性名稱
        print("隨機值：" + Random.value);
        print(Camera.allCamerasCount);

        // 設定靜態屬性
        // 語法：類別名稱.靜態屬性名稱 指定 值;
        Cursor.visible = false;
        // Mathf.PI = 9.99999;            // 只要有 Read Only 的值都不能夠設定 為 唯讀屬性
    }

}
