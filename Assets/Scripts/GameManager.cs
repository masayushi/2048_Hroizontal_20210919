using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �C���޲z��
/// �C�������e������
/// �����e�����D��s
/// </summary>
public class GameManager : MonoBehaviour
{
    [Header("�e������")]
    public GameObject goFinalCanvas;

    [Header("�������D")]
    public Text textFinalTitle;

    public void ShowFinalCanvas(bool win)
    {
        goFinalCanvas.SetActive(true);

        // �T���B��l
        // ���L�� ? ���L�Ȭ� true : ���L�Ȭ� false
        string title = win ? "Win" : "Lose";

        // �P�_�� if
        /*
         if (win) title = "win";
        alse title = "Lose";
         */

        textFinalTitle.text = title;
    }
}
