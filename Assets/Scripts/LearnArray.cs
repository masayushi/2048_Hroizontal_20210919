using UnityEngine;


/// <summary>
/// 認識陣列
/// </summary>
public class LearnArray : MonoBehaviour
{
    // 5 個學生的分數
    public int score1 = 100;
    public int score2 = 10;
    public int score3 = 70;
    public int score4 = 80;
    public int score5 = 65;

    // 資料類型[] - 陣列資料類型
    // 陣列：儲存相同資料類型
    public int[] scores;

    private void Start()
    {
        score3 = 60;
    }
}
