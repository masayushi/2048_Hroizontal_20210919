using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �{�ѹB��l
// 1. ���w
// 2. �ƾ�
// 3. ���
// 4. �޿�
/// <summary>
/// 
/// </summary>
public class LearnOperator : MonoBehaviour
{
    public float a = 10;
    public float b = 3;
    public int c = 30;
    public int hp = 100;

    private void Start()
    {
        #region ���w�B��l
        // ���w = 
        // ��������w�B��l�k���~�|�A���楪��

        #endregion

        #region �ƾǹB��l
        // �[����l
        // + - * / %
        print("�[�k�G" + (a + b));         // ���G�G13
        print("��k�G" + (a - b));         // ���G�G7
        print("���k�G" + (a * b));         // ���G�G30
        print("���k�G" + (a / b));         // ���G�G3.333
        print("�l�G" + (a % b));          // ���G�G1

        c = c + 1;                        // ��l�g�k
        print("c ���G�G" + c);
        c++;                              // ���W ++ �A���� -- (�@���u�[1)
        print("c ���G�G" + c);

        hp = hp + 10;
        print("HP ���G�G" + hp);
        hp += 10;                         // �A�Ω�Ҧ��ƾǹB��l!! ex: += -= *= /= %=
        print("HP ���G�G" + hp);
        #endregion
    }

}
