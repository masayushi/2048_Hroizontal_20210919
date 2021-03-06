using UnityEngine;

public class LearnLoop : MonoBehaviour
{
    private void Start()
    {
        // 輸出數字 1 ~ 6
        print("數字：" + 1);
        print("數字：" + 2);
        print("數字：" + 3);
        print("數字：" + 4);
        print("數字：" + 5);

        // 迴圈：重複執行
        // while 迴圈語法：
        // while (布林值) { 當布林值 等於 true 會重複執行 程式內容 直到false為止}

        int number = 1;

        // 當 數字 小於 6時 會執行...
        while (number < 6)
        {
            print("while 迴圈數字：" + number);
            number++;
        }

        // for ( 初始值;布林值;迴圈結束執行程式敘述)
        for (int n = 1; n < 6; n++)
        {
            print("for 迴圈數字：" + n);
        }
    }
}
