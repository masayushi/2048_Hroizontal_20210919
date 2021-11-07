using UnityEngine;

public class LearnIf : MonoBehaviour
{
    public bool openDoor;

<<<<<<< Updated upstream
=======
<<<<<<< HEAD
    public int score = 99;

    // 開始事件
    private void Start()
    {
        // 判斷式 if
        // 語法
        // 如果 (布林值) { 當布林值 等於 true 會執行 一次 程式內容 }
        // 否則 { 當布林值 等於 false 會執行 程式內容 }
=======
>>>>>>> Stashed changes
    /// <summary>
    /// 判斷式 if
    /// </summary>
    private void Start()
    {
        // 判斷式 if else
        // 語法：
        // 如果 (布林值(只有true才讀的到)) { 當布林值 等於 true時 會執行 程式內容}
        // 否則 { 當布林值 等於 false 會執行 程式內容}
<<<<<<< Updated upstream
=======
>>>>>>> f425232ad980edd4d8ecf3f6b5b9f0f6a2b64500
>>>>>>> Stashed changes
        if (true)
        {
            print("布林值 true");
        }
<<<<<<< Updated upstream

=======
<<<<<<< HEAD
=======

>>>>>>> f425232ad980edd4d8ecf3f6b5b9f0f6a2b64500
>>>>>>> Stashed changes
        if (false)
        {
            print("布林值 false");
        }

<<<<<<< Updated upstream
        // openDoor == true 與 opendoor
=======
<<<<<<< HEAD
        // openDoor == true 與 openDoor
=======
        // openDoor == true 與 opendoor
>>>>>>> f425232ad980edd4d8ecf3f6b5b9f0f6a2b64500
>>>>>>> Stashed changes
        if (openDoor)
        {
            print("開門");
        }
        else
        {
            print("關門");
        }
    }

<<<<<<< Updated upstream
=======
<<<<<<< HEAD
    // 更新事件：一秒執行約六十次 60FPS
    private void Update()
    {
        // 如果分數 >= 60分 及格
        if (score >= 60)
        {
            print("及格");
        }

        // 如果分數 >= 40分 可補考
        // 語法：else if (布林值) { 布林值 為 true 時執行 }
        // else if 放在 if 下方 else 上方，可以無限個
        else if (score >= 40)
        {
            print("可補考");
        }
        
        // 如果分數 < 40分  死當
        else
        {
            print("死當");
        }
    }
=======
>>>>>>> f425232ad980edd4d8ecf3f6b5b9f0f6a2b64500
>>>>>>> Stashed changes
}
