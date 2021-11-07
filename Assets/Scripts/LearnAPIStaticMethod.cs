using UnityEngine;

public class LearnAPIStaticMethod : MonoBehaviour
{
    private void Start()
    {
        // 靜態方法
        // 呼叫靜態方法語法：
        // 呼叫靜態方法名稱(對應的引數);
        float f = Random.Range(3.5f, 7.5f);
        print("隨機範圍3.5f ~ 7.5f" + f);
        // 有多個 Declaration 代表此方法有多載方法：多種呼叫方式
        int rInt = Random.Range(1, 3); // 1、2
        print("隨機整數 1 ~ 2 " + rInt);
    }

    private void Update()
    {
        bool space = Input.GetKeyDown(KeyCode.Space);
        print("玩家是否按空白建：" + space);
    }
}
