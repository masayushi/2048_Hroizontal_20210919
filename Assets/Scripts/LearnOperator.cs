using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �{�ѹB��l
// 1. ���w
// 2. �ƾ�
// 3. ���
// 4. �޿�
/// <summary>
/// �B��l���O
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

        #region ����B��l
        // �j��B�p��B�j�󵥩�B�p�󵥩�B����B������
        // >�B<�B>=�B<=�B==�B!=
        // �����ӭȡA�åB�o�쪺���G�����L��
        print("a > b" + (a > b));         // t
        print("a < b" + (a < b));         // f
        print("a >= b" + (a >= b));         // t
        print("a <= b" + (a <= b));         // f
        print("a == b" + (a == b));         // f
        print("a != b" + (a != b));         // t
        #endregion

        #region �޿�B��l
        // �åB�B�Ϊ̡B�A��
        // && || !
        // �åB�B�Ϊ�
        // �����ӥ��L�ȡA�åB�o�쪺���G�����L��

        // �åB�G�u�n���@�� f ���G�N�|�O f 
        print("t && t" + (true && true));    // t
        print("f && t" + (false && true));    // f
        print("t && f" + (true && false));    // f
        print("f && f" + (false && false));    // f

        // �Ϊ̡G�u�n���@�� t ���G�N�|�O t 
        print("t || t" + (true || true));    // t
        print("f || t" + (false || true));    // t
        print("t || f" + (true || false));    // t
        print("f || f" + (false || false));    // f
        // �ֳt����ֱ���GAlt + Shift + > 
        #endregion

        #region �A�˹B��l
        // �A�ˡG�u��[�b���L�ȫe��
        print(!true);                // f
        print(!(a > b));             // f
        print(!(true && true));      // f
        #endregion


    }

}
