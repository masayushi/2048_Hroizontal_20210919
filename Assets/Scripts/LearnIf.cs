using UnityEngine;

public class LearnIf : MonoBehaviour
{
    public bool openDoor;

    public int score = 99;

    // �}�l�ƥ�
    private void Start()
    {
        // �P�_�� if
        // �y�k
        // �p�G (���L��) { ���L�� ���� true �|���� �@�� �{�����e }
        // �_�h { ���L�� ���� false �|���� �{�����e }
        if (true)
        {
            print("���L�� true");
        }
        if (false)
        {
            print("���L�� false");
        }

        if (openDoor)
        {
            print("�}��");
        }
        else
        {
            print("����");
        }
    }

    // ��s�ƥ�G�@���������Q�� 60FPS
    private void Update()
    {
        // �p�G���� >= 60�� �ή�
        if (score >= 60)
        {
            print("�ή�");
        }

        // �p�G���� >= 40�� �i�ɦ�
        // �y�k�Gelse if (���L��) { ���L�� �� true �ɰ��� }
        // else if ��b if �U�� else �W��A�i�H�L����
        else if (score >= 40)
        {
            print("�i�ɦ�");
        }
        
        // �p�G���� < 40��  ����
        else
        {
            print("����");
        }
    }
}
