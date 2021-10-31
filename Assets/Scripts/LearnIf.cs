using UnityEngine;

public class LearnIf : MonoBehaviour
{
    public bool openDoor;

    /// <summary>
    /// 判斷式 if
    /// </summary>
    private void Start()
    {
        // 判斷式 if else
        // 語法：
        // 如果 (布林值(只有true才讀的到)) { 當布林值 等於 true時 會執行 程式內容}
        // 否則 { 當布林值 等於 false 會執行 程式內容}
        if (true)
        {
            print("布林值 true");
        }

        if (false)
        {
            print("布林值 false");
        }

        // openDoor == true 與 opendoor
        if (openDoor)
        {
            print("開門");
        }
        else
        {
            print("關門");
        }
    }

}
